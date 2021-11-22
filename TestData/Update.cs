using Octokit;
using System.Threading.Tasks;

namespace TestData
{
    class Update
    {
        public static bool NewerVersion { get; private set; }
        public static string Message { get; private set; }
        public static string LatesUrl { get; private set; }
 

        public static async Task<bool> UpdateCheck()
        {
            //https://github.com/octokit/octokit.net/blob/main/docs/getting-started.md

            bool result = false;

            var tokenAuth = new Credentials("hanslon", "ghp_token");
            var client = new GitHubClient(new ProductHeaderValue("hanslon"));
            client.Credentials = tokenAuth;
            var latesRelease = await client.Repository.Release.GetLatest("hanslon", "TestDataWPF");
            LatesUrl = latesRelease.HtmlUrl;


            if (latesRelease.TagName.ToString() != MainWindow.Version)
            {
                result = true;
                Message = $"New version available at {LatesUrl}\n Go to download page?";
            }

            NewerVersion = result;

            return result;

            
        }

    }
}
