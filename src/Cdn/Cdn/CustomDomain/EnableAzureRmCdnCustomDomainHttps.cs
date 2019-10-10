// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Cdn.CustomDomain
{
    [Cmdlet("Enable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "CdnCustomDomainHttps", DefaultParameterSetName = FieldsParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class EnableAzureRmCdnCustomDomainHttps : AzureCdnCmdletBase
    {
        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "The resource group of the Azure CDN profile")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "The resource group of the Azure CDN profile")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN profile name.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "Azure CDN profile name.")]
        [ResourceNameCompleter("Microsoft.Cdn/profiles", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN endpoint name.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "Azure CDN endpoint name.")]
        [ResourceNameCompleter("Microsoft.Cdn/profiles/endpoints", nameof(ResourceGroupName), nameof(ProfileName))]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsParameterSet, HelpMessage = "Azure CDN custom domain display name.")]
        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "Azure CDN custom domain display name.")]
        [ResourceNameCompleter("Microsoft.Cdn/profiles/endpoints/customdomains", nameof(ResourceGroupName), nameof(ProfileName), nameof(EndpointName))]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The custom domain object.", ParameterSetName = ObjectParameterSet)]
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The custom domain object.", ParameterSetName = ObjectUserManagedParameterSet)]
        [ValidateNotNull]
        public PSCustomDomain InputObject { get; set; }

        [Parameter(ParameterSetName = ResourceIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the Custom Domain")]
        [Parameter(ParameterSetName = ResourceIdUserManagedParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "ResourceId of the Custom Domain")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "The ResourceId of the KeyVault where the user-managed certificate is stored.")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectUserManagedParameterSet, HelpMessage = "The ResourceId of the KeyVault where the user-managed certificate is stored.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdUserManagedParameterSet, HelpMessage = "The ResourceId of the KeyVault where the user-managed certificate is stored.")]
        [Alias("VaultResourceId")]
        [ValidateNotNullOrEmpty]
        public string UserManagedCertKeyVaultResourceId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsUserManagedParameterSet, HelpMessage = "The SecretId of the user-managed certificate secret in key-vault. If not provided, a CDN managed certificate will be used.")]
        [Parameter(Mandatory = true, ParameterSetName = ObjectUserManagedParameterSet, HelpMessage = "The SecretId of the user-managed certificate secret in key-vault. If not provided, a CDN managed certificate will be used.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdUserManagedParameterSet, HelpMessage = "The SecretId of the user-managed certificate secret in key-vault. If not provided, a CDN managed certificate will be used.")]
        [Alias("CertSecretId")]
        [ValidateNotNullOrEmpty]
        public string UserManagedCertSecretId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return object if specified.")]
        public SwitchParameter PassThru { get; set; }

        private const string VaultResourceType = "Microsoft.KeyVault/vaults";

        public override void ExecuteCmdlet()
        {
            if (ParameterSetName.Equals(ObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                EndpointName = InputObject.EndpointName;
                ProfileName = InputObject.ProfileName;
                ResourceGroupName = InputObject.ResourceGroupName;
                CustomDomainName = InputObject.Name;
            }

            if (ParameterSetName.Equals(ResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                ProfileName = parsedResourceId.GetProfileName();
                EndpointName = parsedResourceId.GetEndpointName();
                CustomDomainName = parsedResourceId.ResourceName;
            }

            var existingCustomDomain = CdnManagementClient.CustomDomains
                .ListByEndpoint(ResourceGroupName, ProfileName, EndpointName)
                .FirstOrDefault(cd => cd.Name.ToLower() == CustomDomainName.ToLower());

            if (existingCustomDomain == null)
            {
                throw new PSArgumentException(string.Format(Resources.Error_NonExistingCustomDomain,
                    CustomDomainName,
                    EndpointName,
                    ProfileName,
                    ResourceGroupName));
            }

            // Setup certificate parameters.
            Management.Cdn.Models.CustomDomainHttpsParameters parameters = null;
            if (string.IsNullOrEmpty(UserManagedCertSecretId))
            {
                // No custom certificate was specified - use a CDN managed certificate.
                parameters = new Management.Cdn.Models.CdnManagedHttpsParameters
                {
                    ProtocolType = Management.Cdn.Models.ProtocolType.IPBased,
                    CertificateSourceParameters = new Management.Cdn.Models.CdnCertificateSourceParameters { CertificateType = "Shared" }
                };
            }
            else
            {
                // We're using a user-managed certificate, so KeyVault resource ID is required.
                if (string.IsNullOrEmpty(UserManagedCertKeyVaultResourceId))
                {
                    throw new PSArgumentException(string.Format(Resources.Error_UserManagedCertificateSubscriptionIdNotSpecified));
                }

                // Parse and verify the KeyVault resource ID.
                var vaultResourceId = new ResourceIdentifier(UserManagedCertKeyVaultResourceId);
                if (vaultResourceId.ResourceType != VaultResourceType)
                {
                    throw new PSArgumentException(string.Format(Resources.Error_InvalidKeyVaultResourceId, UserManagedCertKeyVaultResourceId));
                }

                // Parse and verify the secret ID.
                KeyVault.SecretIdentifier secretId;
                try
                {
                    secretId = new KeyVault.SecretIdentifier(UserManagedCertSecretId);
                }
                catch
                {
                    throw new PSArgumentException(Resources.Error_InvalidCertSecretId);
                }

                parameters = new Management.Cdn.Models.UserManagedHttpsParameters
                {
                    // ProtocolType value is ignored and set by the server for user managed certificates, but it cannot be empty or request will fail validation.
                    ProtocolType = Management.Cdn.Models.ProtocolType.IPBased,
                    CertificateSourceParameters = new Management.Cdn.Models.KeyVaultCertificateSourceParameters
                    {
                        SubscriptionId = vaultResourceId.Subscription,
                        ResourceGroupName = vaultResourceId.ResourceGroupName,
                        VaultName = vaultResourceId.ResourceName,
                        SecretName = secretId.Name,
                        SecretVersion = secretId.Version,
                    },
                };
            }
           

            ConfirmAction(MyInvocation.InvocationName,
                String.Format("{0} ({1})", existingCustomDomain.Name, existingCustomDomain.HostName),
                () => CdnManagementClient.CustomDomains.EnableCustomHttps(
                    ResourceGroupName,
                    ProfileName,
                    EndpointName,
                    CustomDomainName,
                    parameters
                    ));

            if (PassThru)
            {
                WriteObject(true);
            }
        }
    }
}