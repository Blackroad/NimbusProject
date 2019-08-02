//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect generic tests for all catheters
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests.Generic
{
    [CodedUITest]
    public class LeftSideControlGeneric : TestsBaseLogic
    {
        //Run one time before class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            AppsRunner.StartCatheter();
        }

        [TestMethod]
        public void TC5881_TimeValueIs0AfterOpeningTherapyPage()
        {

            Assert.AreEqual("0", LeftSideControls.TextCatheterTimeCounter().DisplayText);
            ScreenShotHelper.CaptureDesktop();
        }

        [TestMethod]
        public void TC5990_LocatorValueIsDoubleDash()
        {
            Assert.AreEqual("--", LeftSideControls.TextCatheterLocation().DisplayText);
            ScreenShotHelper.CaptureDesktop();
        }

        [TestMethod]
        public void TC6118_CatheterNameDoNotExceed25Chars()
        {
            Assert.IsTrue(LeftSideControls.LabelCatheterInformation().DisplayText.Length <= 25, "The Catheter Name Length greater than 25");
            ScreenShotHelper.CaptureDesktop();
        }
    }
}