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
    public class Team
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public string club { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public string consultor { get; set; }
        public int teamSize { get; set; }
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? groupId { get; set; }
        public Group group { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string totalScore { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string game { get; set; }

        public ICollection<Pony> ponies { get; set; }
        public ICollection<TeamMember> teamMembers { get; set; }
        public ICollection<Result> results { get; set; }
        public ICollection<TeamPony> teamPonies { get; set; }

    }
}
