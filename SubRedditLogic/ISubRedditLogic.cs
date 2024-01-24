using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubRedditLogic
{
    public interface ISubRedditLogic
    {
        public Result Setup();

        public Result Process();
    }
}
