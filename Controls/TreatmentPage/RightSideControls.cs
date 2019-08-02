//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect controls on the Right side of the Treatment page
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUITestProject.Controls.TreatmentPage
{
    public class RightSideControls : ControlsBaseLogic
    {

        // WPF BUTTONS
        public WpfControl ButtonEnableVacuum()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonEnableVacuum");
        }
        public WpfControl ButtonDisableVacuum()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonDisableVacuum");
        }
        public WpfControl ButtonStartInflation()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonStartInflation");
        }
        public WpfControl ButtonStartDeflation()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonStartDeflation");
        }
        public WpfControl ButtonStartMapping()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonStartMapping");
        }
        public WpfControl ButtonStartAblation()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonStartAblation");
        }
        public WpfControl ButtonStopAblation()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonStopAblation");
        }
        public WpfControl ButtonEndTreatment()
        {
            return ButtonLocator(PropertyType.AutomationId, "ButtonEndTreatment");
        }
    }
}
