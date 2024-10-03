using Amazon.Auth.AccessControlPolicy;
using Application.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Domain.Model;

namespace Application.Providers
{
    public class ResourceServices : IResourceServices
    {
        public Dictionary<string,string> GetAllResources()
        {
            var culture = CultureInfo.CurrentUICulture;
            string CultureName = culture.Name;
            string resxFile = $"Resources/Resource.{CultureName}.resx";

            if (!System.IO.File.Exists(resxFile))
            {
                resxFile = "Resources/Resource.resx";
            }
            var doc = XDocument.Load(resxFile); // read the XML data

            var resources = new Dictionary<string, string>();
            var dataElements = doc.Root.Elements("data").OrderByDescending(e => e.Attribute("name").Value);

            foreach (var element in dataElements)
            {
                var key = element.Attribute("name").Value;
                var value = element.Element("value").Value;
                resources[key] = value;
            }
            return resources;
        }

    }
}
