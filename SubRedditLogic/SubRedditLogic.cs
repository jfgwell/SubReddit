namespace SubRedditLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Reddit;

    /// <summary>
    /// SubredditLogic class - calls the Reddit Client api.
    /// </summary>
    public class SubRedditLogic : ISubRedditLogic
    {
        private Reddit.RedditClient reddit;
        private List<Reddit.Controllers.Subreddit> subreddits;
        private List<Reddit.Controllers.Post> toppostsofalltime;
        private readonly string accessToken;
        private readonly string appID;
        private readonly Result? result = null;
        private int choice = 0;

        public SubRedditLogic()
        {
            this.result = new Result();

            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            this.appID = configuration["MyAppSettings:AppID"] ?? string.Empty;
            this.accessToken = configuration["MyAppSettings:AccessToken"] ?? string.Empty;
        }

        /// <summary>
        /// Initializes RedditClient object and gets a lits of subreddits the user can choose from their acccount
        /// </summary>
        /// <returns></returns>
        public Result PreSetup()
        {
            this.reddit = new RedditClient(this.appID, null, null, this.accessToken, null);

            this.subreddits = this.reddit.Account.MySubscribedSubreddits();

            result.Subreddits = this.subreddits;

            return result;
        }

        /// <summary>
        /// Initializes the subreddit class.
        /// </summary>
        /// <returns>Result object.</returns>
        public Result Setup(int choice)
        {
            try
            {
                 this.toppostsofalltime = this.subreddits[choice].Posts.GetTop("all");
                 this.result.ErrorMessage = "Success";
                 this.choice = choice;
                 return this.result;
            }
            catch (Exception ex)
            {
                this.result.ErrorMessage = ex.Message;
                return this.result;
            }
        }

        /// <summary>
        /// Processes the necessary information from the subreddit.
        /// </summary>
        /// <returns>Result object.</returns>
        public Result Process()
        {
            try
            {
                this.result.SubRedditName = this.subreddits[this.choice].Name;
                this.result.TopPosts = this.toppostsofalltime.First().UpVotes.ToString();
                this.result.TopPoster = this.toppostsofalltime.First().Author;
                return this.result;
            }
            catch (Exception ex)
            {
                this.result.ErrorMessage = ex.Message;
                return this.result;
            }
        }
    }
}
