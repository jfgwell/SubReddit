namespace SubRedditLogic
{
    using Reddit.Controllers;
    using Reddit.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Result
    {
        public string? SubRedditName { get; set; }
        public string? TopPosts { get;set; }

        public string? TopPoster { get; set; }

        public string? ErrorMessage { get; set;}

        public List<Subreddit>? Subreddits { get; set; }
    }
}
