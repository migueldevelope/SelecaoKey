using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SelecaoKey.Services.Auth;
using SelecaoKey.Test.Commons;
using SelecaoKey.Views.BusinessCrud;
using Xunit;
using SelecaoKey.Views.BusinessList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelecaoKey.Test.Commons;
using SelecaoKey.Services.Business;
using SelecaoKey.Views.Enumns;
using Assert = NUnit.Framework.Assert;

namespace SelecaoKey.Test.Services.Auth
{
    [TestClass]
    public class MovieTest : TestCommons
    {
        private readonly ServiceMovie service;
        public MovieTest()
        {
            service = new ServiceMovie(context);
        }

        [Fact]
        [TestMethod]
        public void CrudMovie()
        {
            try
            {
                ViewCrudMovie view = new ViewCrudMovie();
                view.Genre = EnumGenre.Adventure;
                view.Release = DateTime.Now;
                view.IdStreaming = 1;

                // name invalid 
                Exception ex = Assert.Throws<Exception>(() => service.New(view));
                Assert.AreEqual("Movie02", ex.Message);

                view.Name = "test1";
                
                // new movie
                Assert.AreEqual("Movie04", service.New(view));

                view.Name = "";
                // name invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Movie02", ex.Message);

                view.Id = 0;
                view.Name = "abc";
                // id invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Movie03", ex.Message);

                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update movie
                Assert.AreEqual("Movie05", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListMovie> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);


            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

