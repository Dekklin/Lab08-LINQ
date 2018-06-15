using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lab08_Linq
{

    public class FeaturesObj
    { 
        [JsonProperty]
        public List<Features> Features { get; set; }

        [JsonProperty]
        public List<Properties> Properties { get; set; }
    }
}
