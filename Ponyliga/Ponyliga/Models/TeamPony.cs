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
    public class TeamPony
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int teamId { get; set; }
        public Team team { get; set; }
        public int ponyId { get; set; }
        public Pony pony { get; set; }

    }
}
