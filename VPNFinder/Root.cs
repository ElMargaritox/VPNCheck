using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNFinder
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Policies
    {
        public string ad_filtering { get; set; }
        public string free_access { get; set; }
        public string paid_access { get; set; }
        public string port_forwarding { get; set; }
        public string logging { get; set; }
        public string anonymous_payments { get; set; }
        public string crypto_payments { get; set; }
        public string traceable_ownership { get; set; }
    }

    public class Operator
    {
        public string name { get; set; }
        public string url { get; set; }
        public string anonymity { get; set; }
        public string popularity { get; set; }
        public List<string> protocols { get; set; }
        public Policies policies { get; set; }
    }

    public class _1855423043
    {
        public string proxy { get; set; }
        public string type { get; set; }
        public Operator @operator { get; set; }
    }

    public class Root
    {

        public string status { get; set; }

        [JsonProperty(PropertyName = "_1855423043")]
        public _1855423043 _1855423043 { get; set; }
    }
}

