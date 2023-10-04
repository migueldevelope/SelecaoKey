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

                // name invalid 
                Exception ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Movie02", ex.Message);

                view.Name = "test1";
                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Movie03", ex.Message);


                view.Genre = EnumGenre.Adventure;
                // new hq
                Assert.Equals("Movie04", service.New(view));

                view = new ViewCrudMovie();
                // name invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Movie02", ex.Message);

                view.Name = "test1";
                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Movie03", ex.Message);

                view.Genre = EnumGenre.Adventure;
                // id invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Movie05", ex.Message);

                view.Release = DateTime.Now;

                view.Genre = EnumGenre.Adventure;
                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update hq
                Assert.Equals("Movie06", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListMovie> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);

                //delete
                Assert.Equals("Movie01", service.Delete(view.Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

