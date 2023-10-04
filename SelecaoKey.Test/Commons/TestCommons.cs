using System;
using System.Collections.Generic;
using System.Text;
using SelecaoKey.Data;

namespace SelecaoKey.Test.Commons
{
    public class TestCommons
    {
        public DataContext context;

        public TestCommons()
        {
            context = new DataContext("Server=SelecaoKey.database.windows.net;Database=SelecaoKey;User Id=test;Password=x14r53p5!a;");
        }
    }
}
