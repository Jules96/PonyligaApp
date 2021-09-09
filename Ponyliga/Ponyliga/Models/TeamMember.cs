using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Ponyliga.Models
{
    public class TeamMember
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public String firstName { get; set; }
        public String surName { get; set; }
        public int teamId { get; set; }
        public Team team { get; set; }

    }
}
