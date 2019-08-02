//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect generic tests for all catheters
 */


using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using Nimbus.VTLibrary;

namespace CodedUITestProject.Tests.Generic
{
    [CodedUITest]
    public class LeftSideControlGeneric : BaseTestLogic
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
        public void TC5881_TimeValueIs0AfterOpeningTherapyPage()
        {

            Assert.AreEqual(TreatmentPageControls.TimeValue().DisplayText, "0");
        }

        [TestMethod]
        public void TC6118_CatheterNameDoNotExceed25Chars()
        {
            Assert.IsTrue(TreatmentPageControls.CatheterName().DisplayText.Length <= 25, "The Catheter Name Length greater than 25");
        }

        [TestMethod]
        public void TCXXXX_CheckLocatorValue()
        {
            Assert.AreEqual(TreatmentPageControls.LocatorValue().DisplayText, "--");
        }
    }
}