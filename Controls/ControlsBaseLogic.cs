//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Basic logic for all controls
 */

using CodedUITestProject.Helpers;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace CodedUITestProject.Controls
{
    public abstract class ControlsBaseLogic
    {
        public CommonMethods UICommonMethods { get; set; }
        public WpfControl ParentControl { get; set; }

        public ControlsBaseLogic()
        {
            UICommonMethods = new CommonMethods();
            ParentControl = UICommonMethods.GetControl<WpfWindow>(PropertyType.Name, "MainWindow");
        }

        //Helper Methods
        public WpfText TextFieldLocator(PropertyType propertyType, string propertyValue)
        {
            return UICommonMethods.WaitControlForEnable(UICommonMethods.GetControl<WpfText>(propertyType, propertyValue, ParentControl)) as WpfText;
        }
        public WpfControl ButtonLocator(PropertyType propertyType, string propertyValue)
        {
            return UICommonMethods.WaitControlForEnable(UICommonMethods.GetControl<WpfButton>(propertyType, propertyValue, ParentControl));
        }
        public WpfControl CustomLocator(PropertyType propertyType, string propertyValue)
        {
            return UICommonMethods.WaitControlForEnable(UICommonMethods.GetControl<WpfCustom>(propertyType, propertyValue, ParentControl));
        }
        public WpfControl ImageLocator(PropertyType propertyType, string propertyValue)
        {
            return UICommonMethods.WaitControlForEnable(UICommonMethods.GetControl<WpfImage>(propertyType, propertyValue, ParentControl));
        }
    }
}
