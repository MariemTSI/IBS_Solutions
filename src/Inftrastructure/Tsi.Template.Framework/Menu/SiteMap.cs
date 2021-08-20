using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsi.Template.Framework.Menu
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SiteMapNode
    {
        [JsonProperty("-SystemName")]
        public string SystemName { get; set; }

        [JsonProperty("-tsiResource")]
        public string TsiResource { get; set; }

        [JsonProperty("-controller")]
        public string Controller { get; set; }

        [JsonProperty("-action")]
        public string Action { get; set; }

        [JsonProperty("-IconClass")]
        public string IconClass { get; set; }

        [JsonProperty("-self-closing")]
        public string SelfClosing { get; set; }

        [JsonProperty("-PermissionNames")]
        public string PermissionNames { get; set; }
        public List<SiteMapNode> siteMapNode { get; set; }
    }

    public class SiteMap
    {
        public SiteMapNode siteMapNode { get; set; }
    }

    public class Root
    {
        public SiteMap siteMap { get; set; }
    }



}
