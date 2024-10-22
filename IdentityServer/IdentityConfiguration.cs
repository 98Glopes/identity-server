using System.Diagnostics;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class IdentityConfiguration
 {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                     SubjectId = "1144",
                     Username = "macoratti",
                     Password = "numsey",
                     Claims =
                     {
                        new Claim(JwtClaimTypes.Name, "Macoratti Net"),
                        new Claim(JwtClaimTypes.GivenName, "Macoratti"),
                        new Claim(JwtClaimTypes.FamilyName, "Net"),
                        new Claim(JwtClaimTypes.WebSite, "http://macoratti.net"),
                     }
              }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
                new ApiScope("LeiteApi.read"),
                new ApiScope("LeiteApi.write"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
               new ApiResource("myApi")
               {
                   Scopes = new List<string>{ "myApi.read","myApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }
               },

               new ApiResource("LeiteApi")
               {
                   Scopes = new List<string>{ "LeiteApi.read","LeiteApi.write" },
                   ApiSecrets = new List<Secret>{ new Secret("supersecret".Sha256()) }   
               }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "cwm.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.read"}
                },

                                new Client
                {
                    ClientId = "leiteClient",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "LeiteApi.read"}
                }
            };

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
