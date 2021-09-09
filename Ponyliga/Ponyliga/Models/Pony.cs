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
    public class Pony
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public String name { get; set; }
        public String race { get; set; }
        public String age { get; set; }

        public ICollection<Team> teams { get; set; }
        public ICollection<TeamPony> teamPonies { get; set; }

    }
}
