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
        public void RunTest()
        {
            var subreddittest = new SubRedditLogic();

            var result = subreddittest.Process();

            Assert.IsNotNull(result);
            Assert.IsNull(result.SubRedditName);
            Assert.IsNull(result.TopPosts);
            Assert.IsNull(result.TopPoster);
            Assert.IsNotNull(result.ErrorMessage);
        }
    }
}
