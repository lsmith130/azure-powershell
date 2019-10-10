﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Cdn.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Azure.Commands.Cdn.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to permanently remove custom domain &apos;{0}&apos; from endpoint &apos;{1}&apos; in profile &apos;{2}&apos;, resource group &apos;{3}&apos;?.
        /// </summary>
        internal static string Confirm_RemoveCustomDomain {
            get {
                return ResourceManager.GetString("Confirm_RemoveCustomDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to permanently remove endpoint &apos;{0}&apos; from profile &apos;{1}&apos; in resource group &apos;{2}&apos;?.
        /// </summary>
        internal static string Confirm_RemoveEndpoint {
            get {
                return ResourceManager.GetString("Confirm_RemoveEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Profile {0} currently contains endpoints.  Are you sure you want to permanently remove profile &apos;{0}&apos;?.
        /// </summary>
        internal static string Confirm_RemoveProfile {
            get {
                return ResourceManager.GetString("Confirm_RemoveProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to stop endpoint &apos;{0}&apos; from profile &apos;{1}&apos; in resource group &apos;{2}&apos;?.
        /// </summary>
        internal static string Confirm_StopEndpoint {
            get {
                return ResourceManager.GetString("Confirm_StopEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm.
        /// </summary>
        internal static string Confirm_Title {
            get {
                return ResourceManager.GetString("Confirm_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is already an existing custom domain with name &apos;{0}&apos; in the endpoint &apos;{1}&apos;, profile &apos;{2}&apos;, resource group &apos;{3}&apos;.
        /// </summary>
        internal static string Error_CreateExistingCustomDomain {
            get {
                return ResourceManager.GetString("Error_CreateExistingCustomDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is already an existing endpoint with name &apos;{0}&apos;..
        /// </summary>
        internal static string Error_CreateExistingEndpoint {
            get {
                return ResourceManager.GetString("Error_CreateExistingEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is already an existing profile with name &apos;{0}&apos; in the resource group &apos;{1}&apos;..
        /// </summary>
        internal static string Error_CreateExistingProfile {
            get {
                return ResourceManager.GetString("Error_CreateExistingProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Endpoint with name &apos;{0}&apos; in the profile &apos;{1}&apos; and resource group &apos;{2}&apos; does not exist..
        /// </summary>
        internal static string Error_DeleteNonExistingEndpoint {
            get {
                return ResourceManager.GetString("Error_DeleteNonExistingEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Origin with name &apos;{0}&apos; on endpoint &apos;{1}&apos; could not be found..
        /// </summary>
        internal static string Error_DeleteNonExistingOrigin {
            get {
                return ResourceManager.GetString("Error_DeleteNonExistingOrigin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Profile with name &apos;{0}&apos; in the resource group &apos;{1}&apos; does not exist..
        /// </summary>
        internal static string Error_DeleteNonExistingProfile {
            get {
                return ResourceManager.GetString("Error_DeleteNonExistingProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UserManagedCertSecretId is invalid..
        /// </summary>
        internal static string Error_InvalidCertSecretId {
            get {
                return ResourceManager.GetString("Error_InvalidCertSecretId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to KeyVaultResourceId &apos;{0}&apos; is invalid..
        /// </summary>
        internal static string Error_InvalidKeyVaultResourceId {
            get {
                return ResourceManager.GetString("Error_InvalidKeyVaultResourceId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Custom domain with name &apos;{0}&apos; in the endpoint &apos;{1}&apos;,profile &apos;{2}&apos;, resource group &apos;{3}&apos; does not exist..
        /// </summary>
        internal static string Error_NonExistingCustomDomain {
            get {
                return ResourceManager.GetString("Error_NonExistingCustomDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Profile with name &apos;{0}&apos; in the resource group &apos;{1}&apos; does not exist..
        /// </summary>
        internal static string Error_ProfileNotFound {
            get {
                return ResourceManager.GetString("Error_ProfileNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The resource group name is not specified. Specify the resource group or do not specify profile name..
        /// </summary>
        internal static string Error_ResourceGroupNotSpecified {
            get {
                return ResourceManager.GetString("Error_ResourceGroupNotSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UserManagedCertificateSubscriptionId was not specified..
        /// </summary>
        internal static string Error_UserManagedCertificateSubscriptionIdNotSpecified {
            get {
                return ResourceManager.GetString("Error_UserManagedCertificateSubscriptionIdNotSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing custom domain ....
        /// </summary>
        internal static string Progress_RemovingCustomDomain {
            get {
                return ResourceManager.GetString("Progress_RemovingCustomDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing endpoint ....
        /// </summary>
        internal static string Progress_RemovingEndpoint {
            get {
                return ResourceManager.GetString("Progress_RemovingEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing origin....
        /// </summary>
        internal static string Progress_RemovingOrigin {
            get {
                return ResourceManager.GetString("Progress_RemovingOrigin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing profile ....
        /// </summary>
        internal static string Progress_RemovingProfile {
            get {
                return ResourceManager.GetString("Progress_RemovingProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Success!.
        /// </summary>
        internal static string Success {
            get {
                return ResourceManager.GetString("Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove-AzCdnCustomDomain on {0}..
        /// </summary>
        internal static string Success_RemoveCustomDomain {
            get {
                return ResourceManager.GetString("Success_RemoveCustomDomain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove-AzCdnEndpoint on {0}..
        /// </summary>
        internal static string Success_RemoveEndpoint {
            get {
                return ResourceManager.GetString("Success_RemoveEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove-AzCdnProfile on {0}..
        /// </summary>
        internal static string Success_RemoveProfile {
            get {
                return ResourceManager.GetString("Success_RemoveProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Endpoint with name &apos;{0}&apos; in the profile &apos;{1}&apos; and resource group &apos;{2}&apos; has been started..
        /// </summary>
        internal static string Success_StartEndpoint {
            get {
                return ResourceManager.GetString("Success_StartEndpoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Stop-AzCdnEndpoint on {0}..
        /// </summary>
        internal static string Success_StopEndpoint {
            get {
                return ResourceManager.GetString("Success_StopEndpoint", resourceCulture);
            }
        }
    }
}
