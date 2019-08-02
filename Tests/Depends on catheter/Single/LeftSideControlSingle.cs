//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect tests for single-focal catheter
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests.Depends_on_catheter.Single
{
    [CodedUITest]
    public class LeftSideControlSingle : TestsBaseLogic
    {
        //Run one time before class. Run application
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            AppsRunner.StartCatheter("FocalSingleCatheterPersonality");
        }

        [TestMethod]
        public void TC6261_TimeValueIs0AfterClickingStartButton()
        {
            Mouse.Click(RightSideControls.ButtonEnableVacuum());
            Mouse.Click(RightSideControls.ButtonStartAblation());
            var timeValue = LeftSideControls.TextCatheterTimeCounter().DisplayText;
            while (timeValue != "0")
            {
                timeValue = LeftSideControls.TextCatheterTimeCounter().DisplayText;
            }
            Assert.AreEqual("0", timeValue);
            ScreenShotHelper.CaptureDesktop();
            Mouse.Click(RightSideControls.ButtonStopAblation());
        }

        [TestMethod]
        public void TC6262_TimeValueDoNotChangeAfterClickingStopButton()
        {
            Mouse.Click(RightSideControls.ButtonEnableVacuum());
            Mouse.Click(RightSideControls.ButtonStartAblation());
            Mouse.Click(RightSideControls.ButtonStopAblation());
            //Assert "Time value" is not changeable
            CommonMethods.AssertControlValuesNotChangeable(LeftSideControls.TextCatheterTimeCounter());
            ScreenShotHelper.CaptureDesktop();
        }
    }
}