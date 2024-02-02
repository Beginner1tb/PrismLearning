using System;
using System.Collections.Generic;
using System.Text;
using RegionNavigator1.Services;

namespace RegionNavigator1.Services
{
    public class Book : IBook
    {
        public List<string> GetBookNames()
        {
            return new List<string>
            {
                "aisda",
                "sads",
                "qweqwe",
            };
        }
    }
}
