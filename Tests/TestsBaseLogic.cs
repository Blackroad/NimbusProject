//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Basic logic and methods for all tests
 */

using CodedUITestProject.Controls.MainPage;
using CodedUITestProject.Controls.TreatmentPage;
using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestProject.Tests
{
    [CodedUITest]
    public class TestsBaseLogic
    {
        public LeftSideControls LeftSideControls { get; set; }
        public RightSideControls RightSideControls { get; set; }
        public MainPageControls MainPageControls { get; set; }
        public CommonMethods CommonMethods { get; set; }
        public ScreenShotHelper ScreenShotHelper { get; set; }
        public AppsRunner AppsRunner { get; set; }

        public TestsBaseLogic()
        {
            LeftSideControls = new LeftSideControls();
            RightSideControls = new RightSideControls();
            CommonMethods = new CommonMethods();
            MainPageControls = new MainPageControls();
            ScreenShotHelper = new ScreenShotHelper();
            AppsRunner = new AppsRunner();
        }

        //Run before each test method.Precondition
        [TestInitialize]
        public void TestInitialize()
        {
            Mouse.Click(MainPageControls.ButtonOpenTreatmentScreen());
        }
        //Run after each test method
        [TestCleanup]
        public void TestCleanup()
        {
            Mouse.Click(RightSideControls.ButtonEndTreatment());
        }

    }
}
