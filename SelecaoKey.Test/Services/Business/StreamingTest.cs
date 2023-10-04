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
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace SelecaoKey.Test.Services.Auth
{
    [TestClass]
    public class StreamingTest : TestCommons
    {
        private readonly ServiceStreaming service;
        public StreamingTest()
        {
            service = new ServiceStreaming(context);
        }

        [TestMethod]
        [Fact]
        public void CrudStreaming()
        {
            try
            {
                ViewCrudStreaming view = new ViewCrudStreaming();
                
                
                Exception ex = Assert.Throws<Exception>(() => service.New(view));
                Assert.AreEqual("Streaming02", ex.Message);

                view.Name = "test1";
                // include
                Assert.AreEqual("Streaming04", service.New(view));


                view = new ViewCrudStreaming();
                // name invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Streaming02", ex.Message);

                view.Name = "test1";

                // id invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Streaming03", ex.Message);

                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update 
                Assert.AreEqual("Streaming05", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListStreaming> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);

                //delete
                Assert.AreEqual("Streaming01", service.Delete(view.Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

