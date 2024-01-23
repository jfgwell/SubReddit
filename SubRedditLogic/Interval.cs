using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SubRedditLogic
{
    public class Interval : IInterval
    {
        private static System.Timers.Timer timer;
        private static SubRedditLogic redditLogic;
        private readonly ILogger logger;
        private readonly ILogger<SubRedditLogic> subredditlogger;
        IServiceProvider provider = null;

        public Interval()
        {
            //logger = _logger;

            provider = new ServiceCollection()
                .AddTransient<ISubRedditLogic, SubRedditLogic>()
                .BuildServiceProvider();


        //    var loggerFactory = LoggerFactory.Create(
        //    builder => builder
        //                // add console as logging target
        //                .AddConsole()
        //                // add debug output as logging target
        //                .AddDebug()
        //                // set minimum level to log
        //                .SetMinimumLevel(LogLevel.Debug)
        //);

        //    // create a logger
        //    var logger = loggerFactory.CreateLogger<Interval>();


        }

        //public Interval()
        //{
            

        //}
        public void Setup()
        {
            try
            {
                redditLogic = new SubRedditLogic(subredditlogger);
                redditLogic.Setup();
                
            }
            catch(Exception ex)
            {
                //logger.LogDebug(ex.Message);
            }

        }
        public void Run()
        {
            try
            {
                Timer timer = new Timer(TimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
               // logger.LogDebug(ex.Message);
            }


            // Keep the program running
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        


        private static void TimerCallback(object state)
        {
            try
            {
                redditLogic.Process();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

        }
    }
}