using Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SubRedditLogic
{
    public class SubRedditLogic : ISubRedditLogic
    {
        private Reddit.RedditClient reddit;
        private List<Reddit.Controllers.Subreddit> subreddits;
        private List<Reddit.Controllers.Post> toppostsofalltime;
        private string AccessToken, AppID;
        private Result result = null;

        public SubRedditLogic()
        {

            result = new Result();
          

            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            AppID = configuration["MyAppSettings:AppID"] ?? String.Empty;
            AccessToken = configuration["MyAppSettings:AccessToken"] ?? String.Empty;

        }
        public Result Setup()
        {
            try
            {
                
                 reddit = new RedditClient(AppID, null, null, AccessToken, null);


                subreddits = reddit.Account.MySubscribedSubreddits();
                toppostsofalltime = subreddits[0].Posts.GetTop("all");
                result.ErrorMessage = "Success";
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                return result;
            }
        }


        public Result Process()
        {
            try
            {
 
                result.SubRedditName = subreddits[0].Name;
                result.TopPosts = toppostsofalltime.First().UpVotes.ToString();
                result.TopPoster = subreddits[0].Posts.GetTop("all").First().Author;
                return result;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                return result;
            }
        }
    }
}
