using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ApplicationCore.Services
{
    public sealed class FindVersion
    {
        public string Version { get; set; }
        private static readonly Lazy<FindVersion>
        lazy =
        new Lazy<FindVersion>
            (() => new FindVersion());

        public static FindVersion Instance { get { return lazy.Value; } }

        private FindVersion()
        {
            Version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
    }
}
