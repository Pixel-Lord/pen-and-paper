using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PenAndPaper.NUnit.HelpClasses.Screenshots
{
    internal class Screencamera
    {
        private static IWebDriver Driver { get; set; }
        private static readonly string path = Path.GetFullPath
            (Path.Combine
            (AppDomain.CurrentDomain.BaseDirectory,
                @"..\..\HelpClasses\Screenshots\UnitTestPictures\"));


    }
}
