namespace SubRedditLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISubRedditLogic
    {
        public Result Setup(int choice);

        public Result Process();
    }
}
