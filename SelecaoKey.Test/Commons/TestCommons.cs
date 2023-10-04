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
            context = new DataContext("Server=45.231.132.153;Database=SelecaoKey;User Id=sa;Password=Bti9010.");
        }
    }
}
