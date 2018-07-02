using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortal
{
    public class JobClass 
    {
        private readonly ITest _test;
        public JobClass(ITest test)
        {
            _test = test;
        }


        public void jobTest()
        {
            _test.Hello("Testing Job");
        }
    }
}