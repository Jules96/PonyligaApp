﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Ponyliga.ViewModels;

namespace Ponyliga.Test
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
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
        public void WelcomeTextIsDisplayed()
        {
            //ARRANGE
            

            //ACT
            //StopWatch stopWatch = new StopWatch();

            // AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));

            //ASSERT
        }
    }
}
