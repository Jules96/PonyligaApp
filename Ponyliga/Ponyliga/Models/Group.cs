using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

using System;
using System.Collections.Generic;
using System.Text;

namespace Ponyliga.Models
{
    public class Group
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public String name { get; set; }
        public int rule { get; set; }
        public ICollection<Team> teams { get; set; }
        public int groupSize { get; set; }
        public String participants { get; set; }

    }
}
