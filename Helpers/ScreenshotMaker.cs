//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Class for making screenshots
 */

using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace CodedUITestProject.Helpers
{
    public class ScreenShotHelper
    {
        private readonly string _relativePath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory?.Parent?.Parent?.Parent?.FullName;

        public void CaptureDesktop()
        {
            var getMethodName = new StackTrace().GetFrame(1).GetMethod().Name;
            Regex regex = new Regex(@"^TC(\d*)", RegexOptions.IgnoreCase);
            var folderName = regex.Match(getMethodName);
            // create name of screen shot with format (-,:/\) - not allowed
            var screenshotName = folderName + "_" + DateTime.Now.ToString("MM-dd-yyyy_hh-mm-ss-tt") + ".jpg";
            //invoke CodedUITEst project folder
            var resultsFolder = Path.Combine(_relativePath, "results", folderName.ToString());
            CreateFolderIfNotExist(resultsFolder);
            var pathToResults = Path.Combine(resultsFolder, screenshotName);
            Image image = UITestControl.Desktop.CaptureImage();
            image.Save(pathToResults);
        }


        public void CaptureControl(params WpfControl[] controls)
        {
            var resultsFolder = Path.Combine(_relativePath, "Master");
            CreateFolderIfNotExist(resultsFolder);
            foreach (var control in controls)
            {
                var pathToResults = control.AutomationId == "" ? Path.Combine(resultsFolder, control.ClassName + ".jpg") : Path.Combine(resultsFolder, control.AutomationId + ".jpg");
                Image image = control.CaptureImage();
                image.Save(pathToResults);
            }
        }

        private void CreateFolderIfNotExist(string folderPath)
        {
            bool testFolderExist = Directory.Exists(folderPath);
            if (!testFolderExist)
            {
                Directory.CreateDirectory(folderPath);
            }
        }
    }
}
