using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialModule1
{
    public interface IDITest1
    {
        string Print();
    }
    public class DITest1 : IDITest1
    {
        public string Print()
        {
            return "This is IDITest1";
        }
    }

    public class DITest2 : IDITest1
    {
        public string Print()
        {
            return "This is IDITest2";
        }
    }


    //以下为IDITest1的服务类
    public class IDITest1Service
    {
        private readonly IDITest1 _dITest1;

        public IDITest1Service(IDITest1 dITest1)
        {
            _dITest1 = dITest1;
        }

        public string WriteDownStr()
        {
            return _dITest1.Print();
        }
    }



}
