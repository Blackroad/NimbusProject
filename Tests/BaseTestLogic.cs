//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect all basic logic and methods for all tests
 */

using CodedUITestProject.Controls;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests
{
    [CodedUITest]
    public class BaseTestLogic
    {
        //NOT USED FOR NOW
        //VTLibrary VtLibrary { get; set; }
        //public TestContext TestContext { get; set; }

        //public VTLibrary SetVtLib()
        //{
        //    VtLibrary = VTLibrary.Instance;
        //    VtLibrary.Debug = true;
        //    VtLibrary.CodedUI.Initialize(TestContext);
        //    return VtLibrary;
        //}

        public TreatmentPageControls TreatmentPageControls { get; set; }
        public MainPageControls MainPageControls { get; set; }
        public ReusableMethods ReusableMethods { get; set; }

        public void ClickButton(WpfControl button)
        {
            ReusableMethods.ClickWpfControl(button);
        }

        public BaseTestLogic()
        {
            TreatmentPageControls = new TreatmentPageControls();
            ReusableMethods = new ReusableMethods();
            MainPageControls = new MainPageControls();
        }
        //Run before each test method. Precondition
        [TestInitialize]
        public void TestInitialize()
        {
            ClickButton(MainPageControls.TreatmentButton());
        }
        //Run after each test method
        [TestCleanup]
        public void TestCleanup()
        {
            ClickButton(TreatmentPageControls.ButtonEndTreatment());
        }
    }
}
