//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect tests for dual-focal catheter
 */

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests.Depends_on_catheter.Dual
{
    [CodedUITest]
    public class LeftSideControlDual : BaseTestLogic
    {

        //Run one time before class. Run application
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            //Close Application if it existed
            ReusableMethods.CloseProcess("VirtualConsoleApp");
            ReusableMethods.CloseProcess("NimbusPlatformService");
            ReusableMethods.CloseProcess("NimbusApp");
            //Run application
            ReusableMethods.StartCatheter("nimstart_dual_focal.bat");
        }

        [TestMethod]
        public void TC6257_TimeValueIs0AfterClickingStartButton()
        {
            ClickButton(TreatmentPageControls.EnableVacuumButton());
            ClickButton(TreatmentPageControls.StartAblationButton());
            Assert.AreEqual(TreatmentPageControls.TimeValue().DisplayText, "0");
            ClickButton(TreatmentPageControls.StopAblationButton());
        }

        [TestMethod]
        public void TC6258_TimeValueDoNotChangeAfterClickingStopButton()
        {
            ClickButton(TreatmentPageControls.EnableVacuumButton());
            ClickButton(TreatmentPageControls.StartAblationButton());
            ClickButton(TreatmentPageControls.StopAblationButton());
            //Assert "Time value" is not changeable
            ReusableMethods.AssertControlValuesNotChangeable(TreatmentPageControls.TimeValue());
        }
    }
}