using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xamarin.Forms;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;



namespace Ponyliga.Models
{
    public class Result
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public String gameDate { get; set; }
        public String game { get; set; }
        public int position { get; set; }
        public String finishingTime { get; set; }
        public String startingTime { get; set; }
        public String timeSum { get; set; }
        public int score { get; set; }
        public int teamId { get; set; }
        public Team team { get; set; }

    }
}
