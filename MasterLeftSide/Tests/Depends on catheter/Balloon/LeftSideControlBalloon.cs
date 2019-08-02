//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect tests for balloon catheter
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests.Depends_on_catheter.Balloon
{
    [CodedUITest]
    public class LeftSideControlBalloon : TestsBaseLogic
    {

        //Run one time before class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            //Close Application if it existed
            CommonMethods.CloseProcess();
            //Run application
            CommonMethods.StartCatheter("nimstart_balloon.bat");
        }

        [TestMethod]
        public void TC5882_TimeValueIs0AfterClickingStartButton()
        {
            Mouse.Click(RightSideControls.ButtonEnableVacuum());

            Mouse.Click(RightSideControls.ButtonStartInflation());
            Mouse.Click(RightSideControls.ButtonStartAblation());
            //Wait for Time become 0
            if (LeftSideControls.TextCatheterTimeCounter().DisplayText != "0")
            {
                Playback.Wait(200);
            }
            Assert.AreEqual("0", LeftSideControls.TextCatheterTimeCounter().DisplayText);
            ScreenShotHelper.CaptureDesktop();
            Mouse.Click(RightSideControls.ButtonStopAblation());
        }

        [TestMethod]
        public void TC5883_TimeValueDoNotChangeAfterClickingDeflateButton()
        {
            Mouse.Click(RightSideControls.ButtonEnableVacuum());
            Mouse.Click(RightSideControls.ButtonStartInflation());
            Mouse.Click(RightSideControls.ButtonStartDeflation());
            //Assert "Time value" is not changeable
            UICommonMethods.AssertControlValuesNotChangeable(LeftSideControls.TextCatheterTimeCounter());
            ScreenShotHelper.CaptureDesktop();
        }

        [TestMethod]
        public void TC5989_TimeValueDoNotChangeAfterClickingStopButton()
        {
            Mouse.Click(RightSideControls.ButtonEnableVacuum());
            Mouse.Click(RightSideControls.ButtonStartInflation());
            Mouse.Click(RightSideControls.ButtonStartAblation());
            Mouse.Click(RightSideControls.ButtonStopAblation());
            //Assert "Time value" is not changeable
            UICommonMethods.AssertControlValuesNotChangeable(LeftSideControls.TextCatheterTimeCounter());
            ScreenShotHelper.CaptureDesktop();
        }

        [TestMethod]
        public void TC6120_CatheterSizeDoNotExceed10Chars()
        {
            Assert.IsTrue(LeftSideControls.LabelCatheterSize().DisplayText.Length <= 10, "The Catheter Size Length greater than 10");
            ScreenShotHelper.CaptureDesktop();
        }

    }
}