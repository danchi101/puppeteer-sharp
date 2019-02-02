﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace PuppeteerSharp.Tests.PageTests.Events
{
    [Collection("PuppeteerLoaderFixture collection")]
    public class ErrorTests : PuppeteerPageBaseTest
    {
        public ErrorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async Task ShouldThrowWhenPageCrashes()
        {
            string error = null;
            Page.Error += (sender, e) => error = e.Error;
            var errorTask = WaitForErrorAsync();
            var gotoTask = Page.GoToAsync("chrome://crash");

            await errorTask;
            Assert.Equal("Page crashed!", error);
        }
    }
}