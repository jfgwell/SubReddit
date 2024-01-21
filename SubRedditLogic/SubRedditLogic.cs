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
            //using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            //ILogger logger = factory.CreateLogger("Program");

            this.logger = _logger;
        }
        public void Setup()
        {
            reddit = new RedditClient("_gPgpfkDiWqwtvBnVoUUEA", null, null, "eyJhbGciOiJSUzI1NiIsImtpZCI6IlNIQTI1NjpzS3dsMnlsV0VtMjVmcXhwTU40cWY4MXE2OWFFdWFyMnpLMUdhVGxjdWNZIiwidHlwIjoiSldUIn0.eyJzdWIiOiJ1c2VyIiwiZXhwIjoxNzA1ODc1MDE4LjI0NDcyOSwiaWF0IjoxNzA1Nzg4NjE4LjI0NDcyOSwianRpIjoicUN3SXNwalRpRGFJazJxbHVtM1NTZG1VelF5M1Z3IiwiY2lkIjoiX2dQZ3Bma0RpV3F3dHZCblZvVVVFQSIsImxpZCI6InQyX2tta2o0ZHVuZyIsImFpZCI6InQyX2tta2o0ZHVuZyIsImxjYSI6MTY5NTg2NjE2ODk2NSwic2NwIjoiZUp5S1Z0SlNpZ1VFQUFEX193TnpBU2MiLCJmbG8iOjl9.TdyQWQlxqS48MUjHJJsxRBh25y0coeueIlfPTJeNahIbvLPb4YxGpSAkNKQCfFKAK3LW5_qLQUu0kHfvj3jK1V57b7SBeU62Em24zWB9wWrSR0OtLy4AOiqSZsq2EeHbsZ2IjeLpXQdD2Hjv0NqoGP9sAsvwJZ8QHRuCHDfK0UE0R1TsIt7nZ1eVE6yaaclktvhccTGftfQ7RXmK5Ozdtf5td3KaAl3qGArsqRCsWFntuBHS3Gm1-hmSy1M5x98TxlFho42P56r2VYXg7wfKxlVMwmHhxlQ7O96VeFgYuSOlT18R0txm_cGxV1ZQsE_w2CBuTiACi02TnW9tE5p0vg", null);
            subreddits = reddit.Account.MySubscribedSubreddits();
            toppostsofalltime = subreddits[0].Posts.GetTop("all");
        }


        public void Process()
        {
            Console.WriteLine(subreddits[0].Name);

            Console.WriteLine(toppostsofalltime.First().UpVotes.ToString());

            Console.WriteLine(subreddits[0].Posts.GetTop("all").First().Author);
        }
    }
}
