using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VPNFinder
{
    internal class Program
    {
        public static string Ip { get; set; }
        static void Main(string[] args)
        {
            WebClient webclient = new WebClient();
            while (true)
            {
                Console.Write("ESCRIBE LA DIRECCION IP: ");
                string ip = Console.ReadLine();
                string data = webclient.DownloadString(string.Format("https://proxycheck.io/v2/{0}?vpn=1", ip));
                Ip = ip;
                try
                {
                    var desA = Deserialize<Root>(data, true);
                    Console.WriteLine(desA._1855423043.type.ToString());
                }
                catch { }
                
            }
            


        }

        // Serialize Json
        static string Serialize(object obj, bool newNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (newNames)
            {
                settings.ContractResolver = new CustomNamesContractResolver();
            }

            return JsonConvert.SerializeObject(obj, settings);
        }

        // Deserialize Json
        static T Deserialize<T>(string text, bool newNames)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            if (newNames)
            {
                settings.ContractResolver = new CustomNamesContractResolver();
            }

            return JsonConvert.DeserializeObject<T>(text, settings);
        }
    }
    class CustomNamesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties 
            // using the short names
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);

            // Now inspect each property and replace the 
            // short name with the real property name
            foreach (JsonProperty prop in list)
            {
                if (prop.UnderlyingName == "_1855423043") //change this to your implementation!
                    prop.PropertyName = Program.Ip;

            }

            return list;
        }
    }
}

