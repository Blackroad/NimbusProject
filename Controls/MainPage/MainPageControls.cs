//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect controls on the Main menu page
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUITestProject.Controls.MainPage
{
    public class MainPageControls : ControlsBaseLogic
    {
        public WpfControl ButtonOpenTreatmentScreen()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonOpenTreatmentScreen");
        }

        public WpfControl ButtonShutdown()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonShutdown");
        }
    }
}
