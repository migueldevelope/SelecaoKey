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
    public class RatingTest : TestCommons
    {
        private readonly ServiceRating service;
        public RatingTest()
        {
            service = new ServiceRating(context);
        }

        [Fact]
        public void CrudRating()
        {
            try
            {
                ViewCrudRating view = new ViewCrudRating();
                
                // name invalid 
                Exception ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Rating02", ex.Message);

                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("Rating03", ex.Message);

                
                view = new ViewCrudRating();
                // name invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Rating02", ex.Message);

                // company invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Rating03", ex.Message);

                // id invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("Rating05", ex.Message);

                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update hq
                Assert.Equals("Rating06", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListRating> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);

                //delete
                Assert.Equals("Rating01", service.Delete(view.Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

