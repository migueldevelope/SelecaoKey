using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SelecaoKey.Test.Commons;
using SelecaoKey.Views.BusinessCrud;
using Xunit;
using SelecaoKey.Views.BusinessList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelecaoKey.Services.Business;

namespace SelecaoKey.Test.Services.Auth
{
    public class StreamingTest : TestCommons
    {
        private readonly ServiceStreaming service;
        public StreamingTest()
        {
            service = new ServiceStreaming(context);
        }

        [Fact]
        public void CrudStreaming()
        {
            try
            {
                ViewCrudStreaming view = new ViewCrudStreaming();
                
                // name invalid 
                Exception ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Streaming02", ex.Message);

                view.Name = "test1";
                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Streaming03", ex.Message);

                
                view = new ViewCrudStreaming();
                // name invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Streaming02", ex.Message);

                view.Name = "test1";
                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Streaming03", ex.Message);

                view.Name = "";
                // id invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Streaming05", ex.Message);

                view.Name = "test1"; 
                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update hq
                Assert.Equals("Streaming06", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListStreaming> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);

                //delete
                Assert.Equals("Streaming01", service.Delete(view.Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

