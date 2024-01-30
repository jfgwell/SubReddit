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
        /// Initializes the subreddit class.
        /// </summary>
        /// <returns>Result object.</returns>
        public Result Setup()
        {
            try
            {
                 this.reddit = new RedditClient(this.appID, null, null, this.accessToken, null);

                 this.subreddits = this.reddit.Account.MySubscribedSubreddits();
                 this.toppostsofalltime = this.subreddits[0].Posts.GetTop("all");
                 this.result.ErrorMessage = "Success";
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
                this.result.SubRedditName = this.subreddits[0].Name;
                this.result.TopPosts = this.toppostsofalltime.First().UpVotes.ToString();
                this.result.TopPoster = this.subreddits[0].Posts.GetTop("all").First().Author;
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
