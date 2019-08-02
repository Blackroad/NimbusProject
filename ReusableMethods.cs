//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * This class is used for creating reusable methods for current Test framework
 */

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace CodedUITestProject
{

    public enum PropertyType
    {
        AutomationId,
        Name,
        ClassName
    }

    public class ReusableMethods
    {
        private int _CountForScreenshots;


        public static void StartCatheter(string cat)
        {
            string relativePathToScripts = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory?.Parent?.Parent?.Parent?.Parent?.FullName;
            Process p = new Process();
            p.StartInfo.FileName = cat;
            p.StartInfo.WorkingDirectory = relativePathToScripts ?? throw new InvalidOperationException();
            p.Start();
        }

        public static void CloseProcess(string processName)
        {

            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                proc.Kill();
            }
        }

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

        public void CaptureDesktop()
        {
            string relativePathToScripts = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory?.Parent?.Parent?.Parent?.Parent?.FullName;
            var pathToResults = Path.Combine(relativePathToScripts ?? throw new InvalidOperationException(), @"results\" + ++_CountForScreenshots + ".jpg");
            Image image = UITestControl.Desktop.CaptureImage();
            image.Save(pathToResults);
        }

        public void WaitForRequiredValue(WpfText control, string value)
        {
            for (var i = 0; i < 10; i++)
            {
                if (control.DisplayText == "0")
                {
                    break;
                }
                Playback.Wait(100);
            }
        }

        public void AssertControlValuesNotChangeable(WpfText control)
        {
            string firstTime = control.DisplayText;
            Playback.Wait(1500);
            string secondTime = control.DisplayText;
            Assert.AreEqual(firstTime, secondTime);
        }

        public void ClickWpfControl(WpfControl control)
        {

            if (control.AutomationId == "ButtonShutdown")
            {
                Mouse.Click(control);
                return;
            }

            Mouse.Click(control);

            CaptureDesktop();
        }
    }
}