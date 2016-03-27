using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinuxMonitorLib
{
	public class Monitor
	{
		public static string LinuxMonitor()
		{
			List<LinuxMonitorLib.Sensors> TempInputList = thermal.TempCurrent();
			List<LinuxMonitorLib.ThermalZones> TempZonelist = thermal.TempMax();
			
			string json = JsonConvert.SerializeObject(new {Temperature = TempInputList, Zones = TempZonelist});
			return json;
		}
	}
	
	public class GetDirectory
	{
		public static string[] TemperatureDirectory(string name)
		{
			string[] dirs = Directory.GetFiles(@"/sys/class/hwmon/hwmon0", name);
			return dirs;
		}
	}
}