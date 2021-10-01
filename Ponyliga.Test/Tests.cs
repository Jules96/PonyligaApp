using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Ponyliga.Views;

namespace PonyLiga.Test
{
    [TestFixture(Platform.Android)]
    
    public class Tests
    {
       IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void UserPageFillList()
        {
            //Arrange

            //Act
            UserPage userPage = new UserPage();
            userPage.FillUserList();
            //Assert
            //AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            //AppResult[] results = app.
            app.Screenshot("Filled User Table");

            //Assert.IsTrue(results.Any());
        }
    }
}
