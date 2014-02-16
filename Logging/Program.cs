﻿using Common;
using Ninject;
using System;
using System.Xml.Linq;

namespace Logging
{
    class Program
    {
        private static readonly ILogger log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            RegisterUnHandledExceptions(log);
            log.Info("Start program...");
            IKernel kernel = new StandardKernel(new Startup());

            IService service = kernel.Get<IService>();

            Person p = new Person
            {
                Id = 9009,
                FirstName = "Tenzin",
                LastName = "Kabzang",
                Age = 21,
                Xml = BuildXml()
            };

            var address1 = new Address
            {
                Id = 1111,
                Address1 = "1234 Bangerter way",
                City = "West Valley",
                State = "UT",
                Zip = "84115",
                Country = "US"
            };

            var address2 = new Address
            {
                Id = 2222,
                Address1 = "Martin Luther Road",
                City = "Provo",
                State = "UT",
                Zip = "84115",
                Country = "US"
            };

            service.Save(p, new[] { address1, address2 });

            Person person = service.GetByAddresses(9009, address1);

            log.InfoFormat("Done program...");
            Console.ReadLine();
        }

        private static string BuildXml()
        {
            const string xml = "<Xml><Id>222</Id><FirstName>Tenzin</FirstName><LastName>Kabsang</LastName></Xml>";
            XDocument xDoc = XDocument.Parse(xml);
            string result = xDoc.ToString(SaveOptions.DisableFormatting);
            return result;
        }

        private static void RegisterUnHandledExceptions(ILogger logger)
        {
            AppDomain.CurrentDomain.UnhandledException += (obj, ex) =>
                logger.Error(string.Format("A {0}fatal unhandled exception has occurred", ex.IsTerminating ? string.Empty : "non-"), ex.ExceptionObject as Exception);
        }
    }
}
