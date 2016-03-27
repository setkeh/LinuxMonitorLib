using System;
using NUnit.Framework;
using Should;
using LinuxMonitorLib;

namespace LinuxMonitorLib.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public static void Main()
        { 
			Console.WriteLine(Monitor.LinuxMonitor());
        }
    }
}
