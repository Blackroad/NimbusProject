//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * This class is used for running applications
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace CodedUITestProject.Helpers
{
    public class AppsRunner
    {
        public static void StartCatheter(string catheterName = "BalloonCatheterPersonality")
        {
            string[] processNames = { AppsRootsContainer.PlatformService, AppsRootsContainer.NimbusApp, AppsRootsContainer.VirtualConsoleApp };
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            foreach (string proc in processNames)
            {
                //check if process already running and close it 
                Process[] pname = Process.GetProcessesByName(Regex.Match(Path.GetFileName(proc) ?? throw new InvalidOperationException(), @"\w*").Value);
                if (pname.Length != 0)
                {
                    foreach (var item in pname)
                    {
                        item.Kill();
                    }
                }
                // Start new process 
                if (proc == AppsRootsContainer.VirtualConsoleApp)
                {
                    processStartInfo.FileName = proc;
                    processStartInfo.WorkingDirectory = Path.GetDirectoryName(AppsRootsContainer.VirtualConsoleApp) ?? throw new InvalidOperationException();
                    processStartInfo.Arguments = catheterName + ".cs";
                    Process.Start(processStartInfo);
                }
                else
                {
                    Process.Start(proc);
                }
            }
        }
    }
}