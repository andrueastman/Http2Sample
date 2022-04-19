using Azure.Identity;
using Microsoft.Graph;

namespace GraphV4Sample
{
    class Program
    {
        public static async Task Main(string[] _)
        {
            string[] scopes = new[] { "User.Read", "User.ReadWrite" };
            InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions()
            {
                ClientId = "CLIENT_ID"
            };
            var interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

            var authProvider = new TokenCredentialAuthProvider(interactiveBrowserCredential,scopes);

            var graphClient = new GraphServiceClient("https://microsoftgraphvalidation.ags.msidentity.com/v1.0", authProvider);

            var me = await graphClient.Me.Request().GetAsync();
        }
    }
}