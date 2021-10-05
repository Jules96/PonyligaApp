using System;
using System.Collections.Generic;
using System.Text;

namespace Ponyliga.Models
{
    public class TeamResult
    {

        public int id { get; set; }
        public String gameDate { get; set; }
        public String game { get; set; }
        public String position { get; set; }
        public String time { get; set; }
        public int score { get; set; }
        public string scoreAll { get; set; }
        public int teamId { get; set; }
        public Team team { get; set; }
        public String penaltyTime { get; set; }
        public string club { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public string consultor { get; set; }
        public int teamSize { get; set; }
        public int? groupId { get; set; }


    }
}
