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

namespace Microsoft.Azure.Commands.Cdn.Models.CustomDomain
{
    public enum PSCertificateProtocolType
    {
        /// <summary>
        /// Unset.
        /// </summary>
        None,

        /// <summary>
        /// The substate is unknown.
        /// This is a generic substate that can be used for cases where certificate provisioning workflow fails unexpectedly.
        /// This should never happen unless there is an unhandled failure case.
        /// </summary>
        Unknown,

        /// <summary>
        /// The certificate is is an SNI certificate.
        /// </summary>
        ServerNameIndication,

        /// <summary>
        /// The certificate is an IP based certificate.
        /// </summary>
        IPBased
    }
}
