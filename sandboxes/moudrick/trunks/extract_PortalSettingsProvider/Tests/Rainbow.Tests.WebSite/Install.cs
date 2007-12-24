using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WatiN.Core;

namespace Rainbow.Tests.WebSite
{
    [TestFixture]
    public class Install
    {
        [Test]
        [Category("Prepare")]
        public void Simple()
        {
            IE.Settings.WaitForCompleteTimeOut = 300;
            IE ie = new IE();
            ie.ClearCookies("http://localhost/Rainbow/");
            ie.GoTo("http://localhost/Rainbow/");
            ie.WaitForComplete();
            Assert.AreEqual(ie.Url, "http://localhost/Rainbow/Setup/Update.aspx");
            ie.Button(Find.ByName("UpdateDatabaseCommand")).Click();
            ie.WaitForComplete();
            ie.Button(Find.ByName("FinishButton")).Click();
            ie.WaitForComplete();

            ie.TextField(Find.ByName("ctl04$DesktopThreePanes1$ThreePanes$ctl03$email")).TypeText("admin@rainbowportal.net");
            ie.TextField(Find.ByName("ctl04$DesktopThreePanes1$ThreePanes$ctl03$password")).TypeText("admin");
            ie.Button(Find.ByName("ctl04$DesktopThreePanes1$ThreePanes$ctl03$LoginBtn")).Click();
            Assert.AreEqual("Administration ", 
                ie.Link(Find.ByUrl("http://localhost/Rainbow/site/100/Default.aspx")).Text, 
                @"innerText does not match");
            ie.Close();
        }
    }
}
