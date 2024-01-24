using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SubRedditLogic
{
    public class Interval : IInterval
    {
        private static System.Timers.Timer timer;
        private static SubRedditLogic redditLogic;

        IServiceProvider provider = null;
        Result result = null;

        public Interval()
        {
            result = new Result();
        }

        public void Setup()
        {
 
                redditLogic = new SubRedditLogic();
                result = redditLogic.Setup();
            Console.WriteLine(result.ErrorMessage);

        }
        public void Run()
        {
            try
            {
                Timer timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Keep the program running
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

    

        private  void TimerCallback(object state)
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
                Console.WriteLine(result.ErrorMessage);
            }

        }
    }
}