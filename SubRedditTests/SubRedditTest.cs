namespace SubRedditTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using FakeItEasy;
    using Microsoft.Extensions.Logging;
    using Shouldly;
    using SubRedditLogic;

    [TestClass]
    public class SubRedditTest
    {
        [TestMethod]
        public void TestInitializingSubRedditLogic()
        {
            var subreddittest = new SubRedditLogic();

            var result = subreddittest.Process();

            Assert.IsNotNull(result);
            Assert.IsNull(result.SubRedditName);
            Assert.IsNull(result.TopPosts);
            Assert.IsNull(result.TopPoster);
            Assert.IsNotNull(result.ErrorMessage);
        }


        [TestMethod]
        public void TestPreSetupSubRedditLogic()
        {
            var subreddittest = new SubRedditLogic();

            var result = subreddittest.PreSetup();

            Assert.IsNotNull(result);
            Assert.IsNull(result.SubRedditName);
            Assert.IsNull(result.TopPosts);
            Assert.IsNull(result.TopPoster);
            Assert.IsNull(result.ErrorMessage);
        }

        [TestMethod]
        public void TestSetupSubRedditLogic()
        {
            var subreddittest = new SubRedditLogic();

            var result = subreddittest.Setup(0);

            Assert.IsNotNull(result);
            Assert.IsNull(result.SubRedditName);
            Assert.IsNull(result.TopPosts);
            Assert.IsNull(result.TopPoster);
            Assert.IsNotNull(result.ErrorMessage);
        }
    }
}
