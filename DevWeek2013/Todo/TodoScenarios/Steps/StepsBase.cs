using System;
using FluentAutomation;
using TechTalk.SpecFlow;

namespace TodoScenarios.Steps
{
    [Binding]
    public class StepsBase : FluentTest
    {
        public StepsBase()
        {
            Settings.ScreenshotOnFailedExpect = false;
            Settings.ScreenshotOnFailedAction = false;
            Settings.DefaultWaitTimeout = TimeSpan.FromSeconds(1);
            Settings.DefaultWaitUntilTimeout = TimeSpan.FromSeconds(30);
            Settings.MinimizeAllWindowsOnTestStart = true;            
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            SeleniumWebDriver.Bootstrap();
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
         //   TeardownDriver();
        }
    }
}