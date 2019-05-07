using System;
using System.Configuration;


// ReSharper disable once CheckNamespace
namespace Inkit.Core
{
	public abstract class SettingsBase
	{
		public static T Get<T>(string key)
		{
			return Get(key, false, default(T));
		}

		public static string GetString(string key)
		{
			return Get<string>(key, false, null);
		}

		public static T Get<T>(string key, bool allowNull, T defaultValue)
		{
			
			var value = ConfigurationManager.AppSettings[key];

			if (string.IsNullOrEmpty(value))
			{
				if (!allowNull)
					throw new ConfigurationErrorsException($@"Missing configuration setting ""{key}""");

				return defaultValue;
			}

			return (T) Convert.ChangeType(value, typeof(T));
		}
	}
}