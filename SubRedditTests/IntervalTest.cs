namespace SubRedditTests
{
    using Microsoft.Extensions.Logging.Abstractions;
    using Shouldly;
    using SubRedditLogic;

    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void InitializingIntervalObjectShouldNotBeNull()
        {
            // Arrange
            var interval = new Interval();

            // Act & Assert
            interval.ShouldNotBeNull();
        }

        [TestMethod]
        public void ShouldBeOfTypeInterval()
        {
            // Arrange
            var interval = new Interval();

            // Act & Assert
            interval.ShouldBeOfType<Interval>();
        }
    }
}