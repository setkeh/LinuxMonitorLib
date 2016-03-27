using System;
using System.IO;
using System.Collections.Generic;

namespace LinuxMonitorLib
{
    public class Sensors
    {
        public string Sensor { get; set; }
        public float Value { get; set; }
    }

	public class ThermalZones
	{
		public string Zone { get; set; }
		public float Max { get; set; }
		public float Crit { get; set; }
	}

    public class thermal
    {
		static string[] InputDirs = GetDirectory.TemperatureDirectory("*_input");
		static string[] MaxDirs = GetDirectory.TemperatureDirectory("*_max");
		static string[] CritDirs = GetDirectory.TemperatureDirectory("*_crit");
		
		public static List<Sensors> TempCurrent()
        {
			List<Sensors> InputList = new List<Sensors>();
            try {

				foreach (string dir in InputDirs)
                {
                    string Val = File.ReadAllText(dir);
                    Sensors sensors = new Sensors();

					sensors.Sensor = dir.Substring(24, 5);
                    sensors.Value = float.Parse(Val) / 1000;

                    InputList.Add(sensors);
				}

				return InputList;
				//string json = JsonConvert.SerializeObject(new {Temperature = InputList, Zones = Zoneslist});
                //return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

		public static List<ThermalZones> TempMax()
		{
			List<ThermalZones> Zoneslist = new List<ThermalZones>();

			try
			{
			foreach (string dir in MaxDirs)
			{
				foreach (string dir2 in CritDirs)
				{
					string Val = File.ReadAllText(dir);
					string Val1 = File.ReadAllText(dir2);
					ThermalZones sensors = new ThermalZones();

					sensors.Zone = dir.Substring(24, 5);
					sensors.Max = float.Parse(Val) / 1000;
					sensors.Crit = float.Parse(Val1) / 1000;

					Zoneslist.Add(sensors);
				}
			}
				return Zoneslist;
			} 
			catch (Exception ex) 
			{
				return null;
			}
		}
    }
}
