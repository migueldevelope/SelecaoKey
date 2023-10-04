using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SelecaoKey.Services.Auth;
using SelecaoKey.Test.Commons;
using SelecaoKey.Views.BusinessCrud;
using SelecaoKey.Views.BusinessList;
using Xunit;

namespace SelecaoKey.Test.Services.Auth
{
    public class AutheticationTest : TestCommons
    {
        private readonly ServiceAuthentication service;
        public AutheticationTest()
        {
            service = new ServiceAuthentication(context);
        }

        [Fact]
        public void Auth()
        {
            try
            {
                ViewAuthentication view = new ViewAuthentication();

                Exception ex = Assert.ThrowsException<Exception>(() => service.Auth(view));
                // mail invalid 
                Assert.Equals("AUTHENTICATION01", ex.Message);
                view.Mail = "test@ploomes.com.br";

                // pass invalid
                ex = Assert.ThrowsException<Exception>(() => service.Auth(view));
                Assert.Equals("AUTHENTICATION02", ex.Message);

                view.Password = "123";
                // authentication
                ViewListAuthentication auth = service.Auth(view);
                Assert.IsTrue(auth != null);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
