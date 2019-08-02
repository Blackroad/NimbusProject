//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect tests for balloon catheter
 */

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using Nimbus.VTLibrary;

namespace CodedUITestProject.Tests.Depends_on_catheter.Balloon
{
    [CodedUITest]
    public class LeftSideControlBalloon : BaseTestLogic
    {

        //Run one time before class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            //Close Application if it existed
            ReusableMethods.CloseProcess("VirtualConsoleApp");
            ReusableMethods.CloseProcess("NimbusPlatformService");
            ReusableMethods.CloseProcess("NimbusApp");
            //Run application
            ReusableMethods.StartCatheter("nimstart_balloon.bat");
        }

        [TestMethod]
        public void TC5882_TimeValueIs0AfterClickingStartButton()
        {
            ClickButton(TreatmentPageControls.EnableVacuumButton());
            ClickButton(TreatmentPageControls.StartInflateButton());
            ClickButton(TreatmentPageControls.StartAblationButton());
            //Wait 1 sec for TimeValue became 0
            //ReusableMethods.WaitForRequiredValue(TreatmentPageControls.TimeValue(), "0");
            Assert.AreEqual(TreatmentPageControls.TimeValue().DisplayText, "0");
            ClickButton(TreatmentPageControls.StopAblationButton());
        }

        [TestMethod]
        public void TC5883_TimeValueDoNotChangeAfterClickingDeflateButton()
        {
            ClickButton(TreatmentPageControls.EnableVacuumButton());
            ClickButton(TreatmentPageControls.StartInflateButton());
            ClickButton(TreatmentPageControls.StartDeflateButton());
            //Assert "Time value" is not changeable
            ReusableMethods.AssertControlValuesNotChangeable(TreatmentPageControls.TimeValue());
        }

        [TestMethod]
        public void TC5989_TimeValueDoNotChangeAfterClickingStopButton()
        {
            ClickButton(TreatmentPageControls.EnableVacuumButton());
            ClickButton(TreatmentPageControls.StartInflateButton());
            ClickButton(TreatmentPageControls.StartAblationButton());
            ClickButton(TreatmentPageControls.StopAblationButton());
            //Assert "Time value" is not changeable
            ReusableMethods.AssertControlValuesNotChangeable(TreatmentPageControls.TimeValue());
        }

        [TestMethod]
        public void TC6120_CatheterSizeDoNotExceed10Chars()
        {
            Assert.IsTrue(TreatmentPageControls.CatheterSize().DisplayText.Length <= 10, "The Catheter Size Length greater than 10");
        }
    }
}