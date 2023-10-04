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
using Assert = NUnit.Framework.Assert;

namespace SelecaoKey.Test.Services.Auth
{
    [TestClass]
    public class RatingTest : TestCommons
    {
        private readonly ServiceRating service;
        public RatingTest()
        {
            service = new ServiceRating(context);
        }

        [TestMethod]
        [Fact]
        public void CrudRating()
        {
            try
            {
                ViewCrudRating view = new ViewCrudRating() { IdUser = null, IdMovie = null };

                // user not found 
                Exception ex = Assert.Throws<Exception>(() => service.New(view));
                Assert.AreEqual("Rating02", ex.Message);

                view.IdUser = 1;
                // movie not found
                ex = Assert.Throws<Exception>(() => service.New(view));
                Assert.AreEqual("Rating03", ex.Message);

                view.IdMovie = 2;
                // score invalid
                ex = Assert.Throws<Exception>(() => service.New(view));
                Assert.AreEqual("Rating04", ex.Message);

                view.Score = 3;
                Assert.AreEqual("Rating05", service.New(view));

                view = new ViewCrudRating() { IdUser = null, IdMovie = null };
                // name invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Rating02", ex.Message);

                view.IdUser = 1;
                // score invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Rating03", ex.Message);

                view.IdMovie = 2;
                // score invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Rating04", ex.Message);

                view.Score = 3;
                // id invalid
                ex = Assert.Throws<Exception>(() => service.Update(view));
                Assert.AreEqual("Rating06", ex.Message);

                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update rating
                Assert.AreEqual("Rating07", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListRating> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);


            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

