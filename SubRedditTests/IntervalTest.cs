using Microsoft.Extensions.Logging.Abstractions;
using SubRedditLogic;
using Shouldly;

namespace SubRedditTests
{
    [TestClass]
    public class IntervalTest
    {

        [TestMethod]
        public void Setup_Should_Not_Throw_Exception()
        {
            // Arrange
            var interval = new Interval();

            // Act & Assert
            Should.NotThrow(() => interval.Setup());
        }

        //[TestMethod]
        //public void Run_Should_Not_Throw_Exception()
        //{
        //    // Arrange
        //    var interval = new Interval();

        //    // Act & Assert
        //    Should.NotThrow(() => interval.Run());

        //}


        //[TestMethod]
        //public void TestMethod1()
        //{

        //}


        //[TestMethod]
        //public void Setup_Success()
        //{
        //    // Arrange
        //    var logger = new NullLogger<SubRedditLogic.SubRedditLogic>();
        //    var subRedditLogic = new SubRedditLogic.SubRedditLogic(logger);



        //    // Act
        //    subRedditLogic.Setup();

        //    // Assert
        //    //Assert.IsNotNull(subRedditLogic.GetRedditClient());
        //    //Assert.IsNotNull(subRedditLogic.GetSubscribedSubreddits());
        //    //Assert.IsNotNull(subRedditLogic.GetTopPostsOfAllTime());
        //}

        //[TestMethod]
        //public void Process_Success()
        //{
        //    // Arrange
        //    var logger = new NullLogger<SubRedditLogic>();
        //    var subRedditLogic = new SubRedditLogic(logger);

        //    // Act
        //    subRedditLogic.Setup();
        //    subRedditLogic.Process();

        //    // Assert
        //    // You can add assertions based on the expected behavior of Process method
        //}
    }
}