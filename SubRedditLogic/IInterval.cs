namespace SubRedditLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IInterval
    {
        void PreSetup();
        void Setup(int choice);
        void Run();
    }
}
