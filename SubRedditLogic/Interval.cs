namespace SubRedditLogic
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Class Interval which uses the Subreddit class to call the neccessary methods at a specific interval.
    /// </summary>
    public class Interval : IInterval
    {
        private static SubRedditLogic? redditLogic;
        private Result? result = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// Constructor for class.
        /// </summary>
        public Interval()
        {
            this.result = new Result();
        }

        /// <summary>
        /// Setup SubRedditLogic class.
        /// </summary>
        public void Setup()
        {
                redditLogic = new SubRedditLogic();
                this.result = redditLogic.Setup();
                Console.WriteLine(this.result.ErrorMessage);
        }

        /// <summary>
        /// Method for timer.
        /// </summary>
        public void Run()
        {
            try
            {
                Timer timer = new Timer(this.TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
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
               Console.WriteLine(result.SubRedditName);
               Console.WriteLine(result.TopPosts);
               Console.WriteLine(result.TopPoster);
            }
            catch (Exception ex)
            {
                this.result.ErrorMessage = ex.Message;
                Console.WriteLine(this.result.ErrorMessage);
            }
        }
    }
}