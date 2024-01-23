using FakeItEasy;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubRedditTests
{
    [TestClass]
    public class SubRedditTest
    {


        [TestMethod]
        public void RunTest()
        {
            //var lollipop = A.Fake<ICandy>();

            var subreddittest = A.Fake<SubRedditLogic.SubRedditLogic>();
            // A.CallTo(() => shop.GetTopSellingCandy()).Returns(lollipop);
            A.CallTo(() => subreddittest.Setup()).MustHaveHappened();
          //  A.CallTo(() => subreddittest.Process()).MustNotHaveHappened();
        }
    }
}
