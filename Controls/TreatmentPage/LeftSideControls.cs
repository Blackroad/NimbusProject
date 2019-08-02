//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Collect controls on the Left side of the Treatment page
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUITestProject.Controls.TreatmentPage
{
    public class LeftSideControls : ControlsBaseLogic
    {

        // WPF TEXT FIELDS
        public WpfText LabelTemperature()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelTemperature");
        }
        public WpfText TextCatheterTemperature()
        {
            return TextFieldLocator(PropertyType.AutomationId, "TextCatheterTemperature");
        }
        public WpfText LabelTime()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelTime");
        }
        public WpfText TextCatheterTimeCounter()
        {
            return TextFieldLocator(PropertyType.AutomationId, "TextCatheterTimeCounter");
        }
        public WpfText LabelLocation()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelLocation");
        }
        public WpfText TextCatheterLocation()
        {
            return TextFieldLocator(PropertyType.AutomationId, "TextCatheterLocation");
        }
        public WpfText LabelCatheterInformation()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelCatheterInformation");
        }
        public WpfText LabelCatheterSize()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelCatheterSize");
        }
        public WpfText LabelFlow()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelFlow");
        }
        public WpfText TextFlow()
        {
            return TextFieldLocator(PropertyType.AutomationId, "TextFlow");
        }
        public WpfText LabelInjectionPressure()
        {
            return TextFieldLocator(PropertyType.AutomationId, "LabelInjectionPressure");
        }
        public WpfText TextInjectionPressure()
        {
            return TextFieldLocator(PropertyType.AutomationId, "TextInjectionPressure");
        }

        //Image
        public WpfControl ImageBalloonIcon()
        {
            return ImageLocator(PropertyType.AutomationId, "ImageBalloonIcon");
        }

        public WpfControl ImageFocalIcon()
        {
            return ImageLocator(PropertyType.AutomationId, "ImageFocalIcon");
        }

        //Custom
        public WpfControl TempTimeView()
        {
            return CustomLocator(PropertyType.ClassName, "Uia.TempTimeView");
        }
        public WpfControl CatheterInfoView()
        {
            return CustomLocator(PropertyType.ClassName, "Uia.CatheterInfoView");
        }

        //All Baloon Controls
        public WpfControl[] GetAllBalloonLeftSideControls()
        {
            WpfControl[] controls =
            {
                LabelTemperature(), TextCatheterTemperature(), LabelTime(), TextCatheterTimeCounter(), LabelLocation(),
                TextCatheterLocation(), LabelCatheterInformation(), LabelCatheterSize(),LabelFlow(), TextFlow(),
                LabelInjectionPressure(), TextInjectionPressure(), ImageBalloonIcon(), TempTimeView(), CatheterInfoView()
            };
            return controls;
        }

        //All Focal Controls
        public WpfControl[] GetAllFocalLeftSideControls()
        {
            WpfControl[] controls =
            {
                LabelTemperature(), TextCatheterTemperature(), LabelTime(), TextCatheterTimeCounter(), LabelLocation(),
                TextCatheterLocation(), LabelCatheterInformation(), LabelFlow(), TextFlow(), LabelInjectionPressure(),
                TextInjectionPressure(), ImageFocalIcon(), TempTimeView(), CatheterInfoView()
            };
            return controls;
        }

    }
}
