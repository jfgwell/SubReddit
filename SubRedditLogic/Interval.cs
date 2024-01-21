using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SubRedditLogic
{
    public class Interval : IInterval
    {
        private static System.Timers.Timer timer;
        private static SubRedditLogic redditLogic;
        private readonly ILogger<Interval> logger;
        private readonly ILogger<SubRedditLogic> subredditlogger;
        IServiceProvider provider = null;

        public Interval(ILogger<Interval> _logger)
        {
            logger = _logger;

            provider = new ServiceCollection()
                .AddTransient<ISubRedditLogic, SubRedditLogic>()
                .BuildServiceProvider();
        }

        public Interval()
        { }
        public void Setup()
        {
            

            redditLogic = new SubRedditLogic(subredditlogger);
            redditLogic.Setup();


        }
        public void Run()
        {
            Timer timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));


            // Keep the program running
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        


        private static void TimerCallback(object state)
        {
            // Call the Process() method at the specified interval
            redditLogic.Process();

        }
    }
}