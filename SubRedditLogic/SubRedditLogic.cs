using Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SubRedditLogic
{
    public class SubRedditLogic : ISubRedditLogic
    {
        private Reddit.RedditClient reddit;
        private List<Reddit.Controllers.Subreddit> subreddits;
        private List<Reddit.Controllers.Post> toppostsofalltime;
        private readonly ILogger<SubRedditLogic> logger;

        public SubRedditLogic(ILogger<SubRedditLogic> _logger)
        {



            //this.logger = _logger;

            var loggerFactory = LoggerFactory.Create(
           builder => builder
                       // add console as logging target
                       .AddConsole()
                       // add debug output as logging target
                       .AddDebug()
                       // set minimum level to log
                       .SetMinimumLevel(LogLevel.Debug)
       );

            // create a logger
            var logger = loggerFactory.CreateLogger<SubRedditLogic>();
        }
        public void Setup()
        {
            try
            {
                //reddit = new RedditClient("_gPgpfkDiWqwtvBnVoUUEA", null, null, "eyJhbGciOiJSUzI1NiIsImtpZCI6IlNIQTI1NjpzS3dsMnlsV0VtMjVmcXhwTU40cWY4MXE2OWFFdWFyMnpLMUdhVGxjdWNZIiwidHlwIjoiSldUIn0.eyJzdWIiOiJ1c2VyIiwiZXhwIjoxNzA2MDUyMTcyLjUxMTMsImlhdCI6MTcwNTk2NTc3Mi41MTEyOTksImp0aSI6InNsQy1DOXJsZXZvdTlHN3E0dGRTVW8taWFQeFdIQSIsImNpZCI6Il9nUGdwZmtEaVdxd3R2Qm5Wb1VVRUEiLCJsaWQiOiJ0Ml9rbWtqNGR1bmciLCJhaWQiOiJ0Ml9rbWtqNGR1bmciLCJsY2EiOjE2OTU4NjYxNjg5NjUsInNjcCI6ImVKeUtWdEpTaWdVRUFBRF9fd056QVNjIiwiZmxvIjo5fQ.anXUnrB-gpXT-HZH0c0TRWvZzrkH8aW6dgbzZw7fVclaJnnzKJ5ZYso1QzOl5vesE8f8ms6J-lnCybTUj3Q3PiEexmbw6QLlepAp5-PZrJq803kpnmvSg7GN_guj8VpTSbJ6zDPYvGK-fuNDrOx7aHchGkvWGnt8Rs3_pCdWbE95ysWguHLPKQSxcRpEYZbUhBRMa8PGByKEgEQB6x6BT2ZnA-gZ90tBj3tqgSYF08eWybMzgMP47ylUsQknEoKBr6kjODyIaP7TGhtX84vDQOiV_aDG953AYBupRyQ-TqZd1Dyhqi6bFyWmyxQPirxMdk-H3-TTG52hZ7sazpxNXA", null);

                reddit = new RedditClient("_gPgpfkDiWqwtvBnVoUUEA", null, null, "yJhbGciOiJSUzI1NiIsImtpZCI6IlNIQTI1NjpzS3dsMnlsV0VtMjVmcXhwTU40cWY4MXE2OWFFdWFyMnpLMUdhVGxjdWNZIiwidHlwIjoiSldUIn0.eyJzdWIiOiJ1c2VyIiwiZXhwIjoxNzA2MDUyMTcyLjUxMTMsImlhdCI6MTcwNTk2NTc3Mi41MTEyOTksImp0aSI6InNsQy1DOXJsZXZvdTlHN3E0dGRTVW8taWFQeFdIQSIsImNpZCI6Il9nUGdwZmtEaVdxd3R2Qm5Wb1VVRUEiLCJsaWQiOiJ0Ml9rbWtqNGR1bmciLCJhaWQiOiJ0Ml9rbWtqNGR1bmciLCJsY2EiOjE2OTU4NjYxNjg5NjUsInNjcCI6ImVKeUtWdEpTaWdVRUFBRF9fd056QVNjIiwiZmxvIjo5fQ.anXUnrB-gpXT-HZH0c0TRWvZzrkH8aW6dgbzZw7fVclaJnnzKJ5ZYso1QzOl5vesE8f8ms6J-lnCybTUj3Q3PiEexmbw6QLlepAp5-PZrJq803kpnmvSg7GN_guj8VpTSbJ6zDPYvGK-fuNDrOx7aHchGkvWGnt8Rs3_pCdWbE95ysWguHLPKQSxcRpEYZbUhBRMa8PGByKEgEQB6x6BT2ZnA-gZ90tBj3tqgSYF08eWybMzgMP47ylUsQknEoKBr6kjODyIaP7TGhtX84vDQOiV_aDG953AYBupRyQ-TqZd1Dyhqi6bFyWmyxQPirxMdk-H3-TTG52hZ7sazpxNXA", null);

                subreddits = reddit.Account.MySubscribedSubreddits();
                toppostsofalltime = subreddits[0].Posts.GetTop("all");
                //logger.LogDebug("Setup Complete");
            }
            catch (Exception ex)
            {
                logger.LogDebug(ex.Message);
                
            }
        }


        public void Process()
        {
            try
            {
                Console.WriteLine(subreddits[0].Name);

                Console.WriteLine(toppostsofalltime.First().UpVotes.ToString());

                Console.WriteLine(subreddits[0].Posts.GetTop("all").First().Author);
            }
            catch (Exception ex)
            {
                logger.LogDebug(ex.Message);
            }
        }
    }
}
