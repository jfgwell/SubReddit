namespace SubRedditLogic
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Reddit.Controllers;

    /// <summary>
    /// Class Interval which uses the Subreddit class to call the neccessary methods at a specific interval.
    /// </summary>
    public class Interval : IInterval
    {
        private static SubRedditLogic? redditLogic;
        private Result? result = null;
        private int TimerIntervalInSeconds = 5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// Constructor for class.
        /// </summary>
        public Interval()
        {
            this.result = new Result();

            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            this.TimerIntervalInSeconds = Convert.ToInt32(configuration["MyAppSettings:TimeIntervalInSeconds"] ?? "5");
        }

        public void PreSetup()
        {
            redditLogic = new SubRedditLogic();
            this.result = redditLogic.PreSetup();
            int i = 0;
            string? choice = null;
            int choiceint = 0;

            Console.WriteLine("Please choose the index from the following subreddits:");

            foreach (Subreddit s in result.Subreddits)
            {
                Console.WriteLine(i.ToString() + " " + s.Name.ToString());
                i++;
            }

            choice = Console.ReadLine();
            choiceint = this.Verifychoice(choice ?? "0");

            this.Setup(choiceint < i ? choiceint : 0);
        }

        private int Verifychoice(string choice)
        {
            int number;
            var success = int.TryParse(choice, out number);
            if (success)
            { return number; }
            else
            { return 0; }

        }

        /// <summary>
        /// Setup SubRedditLogic class.
        /// </summary>
        public void Setup(int choice)
        {
                this.result = redditLogic.Setup(choice);
                Console.WriteLine(this.result.ErrorMessage);
        }

        /// <summary>
        /// Method for timer.
        /// </summary>
        public void Run()
        {
            try
            {
                Timer timer = new Timer(this.TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(this.TimerIntervalInSeconds));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Keep the program running
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        private void TimerCallback(object state)
        {
            try
            {
               var result = redditLogic.Process();
               Console.WriteLine("Subreddit name - " + result.SubRedditName);
               Console.WriteLine("Posts with most up votes - " + result.TopPosts);
               Console.WriteLine("Users with most posts - " + result.TopPoster);
            }
            catch (Exception ex)
            {
                this.result.ErrorMessage = ex.Message;
                Console.WriteLine(this.result.ErrorMessage);
            }
        }
    }
}