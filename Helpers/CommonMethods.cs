//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * This class is used for creating reusable methods for current Test framework
 */

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodedUITestProject.Helpers
{

    public enum PropertyType
    {
        AutomationId,
        Name,
        ClassName
    }

    public class CommonMethods
    {
        public T GetControl<T>(PropertyType propertyType, string propertyValue, WpfControl parent = null) where T : WpfControl
        {
            var control = (T)Activator.CreateInstance(typeof(T), parent);

            switch (propertyType)
            {
                case PropertyType.AutomationId:
                    control.SearchProperties[WpfControl.PropertyNames.AutomationId] = propertyValue;
                    break;
                case PropertyType.ClassName:
                    control.SearchProperties[UITestControl.PropertyNames.ClassName] = propertyValue;
                    break;
                case PropertyType.Name:
                    control.SearchProperties[UITestControl.PropertyNames.Name] = propertyValue;
                    break;
            }
            return control;
        }

        public WpfControl WaitControlForEnable(WpfControl control)
        {
            for (int i = 0; i < 60; i++)
            {
                if (control.Enabled)
                {
                    return control;
                }

                Playback.Wait(1000);
            }

            if (!control.Enabled)
            {
                throw new ArgumentNullException();
            }

            return null;
        }

        public void AssertControlValuesNotChangeable(WpfText control)
        {
            string firstTime = control.DisplayText;
            Playback.Wait(1500);
            string secondTime = control.DisplayText;
            Assert.AreEqual(firstTime, secondTime);
        }
    }
}