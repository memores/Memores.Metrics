﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using Memores.NetAPMAgent.Configuration.Model;
using Memores.NetAPMAgent.Contracts;
using Microsoft.Extensions.Configuration;


namespace Memores.NetAPMAgent.Configuration
{
    public class NetApmAgentConfigurationManager : IConfigurationManager
    {
        public NetApmAgentConfiguration GetCurrentConfiguration() {
            SystemInfo systemInfo = new SystemInfo()
            {
                Architecture = Environment.Is64BitOperatingSystem ? "x64" : "x32",
                Hostname = Environment.MachineName,
                Platform = Environment.OSVersion.VersionString
            };

            Service service = new Service() {
                Name = Assembly.GetExecutingAssembly().GetName().Name,
                Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Environment = default(string), //todo: get env value
                Runtime = new Runtime() {
                    Name = default(string), //todo: get that
                    Version = default(string) //todo: get that
                },
                Framework = new Framework {
                    Name = default(string), //todo: get that
                    Version = default(string) //todo: get that
                },
                Language = new Language() {
                    Name = default(string), //todo: get that
                    Version = default(string) //todo: get that
                },
                Agent = new Agent() {
                    Name = "Memores.NetAPMAgent",
                    Version = "0.0.1-alpha1"
                }
            };

            Process process = new Process()
            {
                Pid = System.Diagnostics.Process.GetCurrentProcess().Id,
                Ppid = default(int), //todo: get that
                Title = default(string), //todo: get that
            };

            return new NetApmAgentConfiguration {
                SystemInfo = systemInfo,
                Service = service,
                Process = process
            };
        }
    }
}