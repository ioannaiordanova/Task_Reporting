using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace SanityTests
{
    [SetUpFixture]
   public class SetUpClass
    {
        [OneTimeSetUp]
        public void  RunBeforeAnyTests()
        {
            string ConfigFile = "conf.json";
            if (File.Exists(ConfigFile))
                MainMenuPage.Config = (ConfigurationRoot)new ConfigurationBuilder().AddJsonFile(ConfigFile).Build();
            else
                Environment.Exit(2);
        }
    }
}
