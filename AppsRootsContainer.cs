//	Copyright (c) 2019 Medtronic, Inc. All rights reserved.
/*
 * Default location of application
 */

using System.IO;

namespace CodedUITestProject
{
    public class AppsRootsContainer
    {
        public static readonly string NimbusBuildLocation = System.Environment.GetEnvironmentVariable("NimbusBuildLocation");
        public static readonly string PlatformService = Path.Combine(NimbusBuildLocation, @"Computing\Platform\NimbusPlatformService\bin\Release\NimbusPlatformService.exe");
        public static readonly string NimbusApp = Path.Combine(NimbusBuildLocation, @"Computing\Application\NimbusApp\bin\Release\NimbusApp.exe");
        public static readonly string VirtualConsoleApp = Path.Combine(NimbusBuildLocation, @"Tools\VirtualConsoleApp\bin\Release\VirtualConsoleApp.exe");
    }
}