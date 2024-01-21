using SubRedditLogic;
using Microsoft.Extensions.DependencyInjection;

namespace SubReddit
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var ServiceProvider = BuildServiceProvider();

            
            Interval I = new Interval();
            I.Setup();
            I.Run();

            //ServiceProvider.GetRequiredService<IInterval>().Setup();
            //ServiceProvider.GetRequiredService<IInterval>().Run();

        }

        private static IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IInterval,Interval>()
                .BuildServiceProvider();

        }
    }
}