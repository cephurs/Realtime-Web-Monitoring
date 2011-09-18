﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WebMonitoringSink
{
	[RunInstaller(true)]
	public class WindowsServiceInstaller : Installer
	{
		public WindowsServiceInstaller()
		{
			ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
			ServiceInstaller serviceInstaller = new ServiceInstaller();

			//# Service Account Information
			serviceProcessInstaller.Account = ServiceAccount.NetworkService;

			//# Service Information
			serviceInstaller.DisplayName = "Realtime Monitoring Event Service";
			serviceInstaller.StartType = ServiceStartMode.Automatic;

			//# This must be identical to the WindowsService.ServiceBase name
			//# set in the constructor of WindowsService.cs
			serviceInstaller.ServiceName = "WebEventSinkService";
			serviceInstaller.Description = "This service monitors events from port 514 that are generated by web server collectors.  Events are logged into a local MongoDB database.";

			this.Installers.Add(serviceProcessInstaller);
			this.Installers.Add(serviceInstaller);
		}
	}
}
