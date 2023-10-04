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

namespace SelecaoKey.Test.Services.Auth
{
    public class UserTest : TestCommons
    {
        private readonly ServiceUser service;
        public UserTest()
        {
            service = new ServiceUser(context);
        }

        [Fact]
        public void CrudUser()
        {
            try
            {
                ViewCrudUser view = new ViewCrudUser();

                // name invalid 
                Exception ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("USER02", ex.Message);

                view.Name = "test1";
                // mail invalid
                ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("USER03", ex.Message);

                view.Mail = "test1@ploomes.com.br";
                // pass invalid
                ex = Assert.ThrowsException<Exception>(() => service.New(view));
                Assert.Equals("USER04", ex.Message);

                view.Password = "123";
                // new user
                Assert.Equals("USER05", service.New(view));

                view = new ViewCrudUser();
                // name invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("USER02", ex.Message);

                view.Name = "test1";
                // mail invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("USER03", ex.Message);

                view.Mail = "test1@ploomes.com.br";
                // pass invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("USER04", ex.Message);

                view.Password = "123";
                // id invalid
                ex = Assert.ThrowsException<Exception>(() => service.Update(view));
                Assert.Equals("USER06", ex.Message);

                view.Id = service.List(999, 1, "").LastOrDefault().Id;
                // update user
                Assert.Equals("USER07", service.Update(view));

                // get id
                view = service.Get(view.Id);
                Assert.IsTrue(view != null);

                //list
                List<ViewListUser> list = service.List(10, 1, "");
                Assert.IsTrue(list.Count > 0);

                //delete
                Assert.Equals("USER01", service.Delete(view.Id));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

