using System;
using System.IO;
using System.Reflection;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Common {
	// ReSharper disable UnusedMember.Global

	public abstract class ConfigurationFile<TConfiguration> where TConfiguration : ConfigurationFile<TConfiguration>, new() {
		protected abstract string ConfigurationFileName { get; }
		private string configurationFileDirectory;

		public static TConfiguration ReadConfiguration(string containingDirectory = "settings") {
			var configurationFileName = Path.Combine(containingDirectory, new TConfiguration().ConfigurationFileName);

			var configurationFileDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			while (!string.IsNullOrEmpty(configurationFileDirectory) && !File.Exists(Path.Combine(configurationFileDirectory, configurationFileName)))
				configurationFileDirectory = Path.GetDirectoryName(configurationFileDirectory);

			if (string.IsNullOrEmpty(configurationFileDirectory))
				return new TConfiguration { configurationFileDirectory = containingDirectory };

			try {
				var configuration = File.ReadAllBytes(Path.Combine(configurationFileDirectory, configurationFileName)).FromXml<TConfiguration>();
				configuration.configurationFileDirectory = Path.Combine(configurationFileDirectory, containingDirectory);
				return configuration;
			}
			catch (Exception) {
				return new TConfiguration { configurationFileDirectory = containingDirectory };
			}
		}
		public void WriteConfiguration() {
			File.WriteAllBytes(Path.Combine(configurationFileDirectory, ConfigurationFileName), this.ToXml());
		}
	}
}