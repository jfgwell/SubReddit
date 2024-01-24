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

    }
}