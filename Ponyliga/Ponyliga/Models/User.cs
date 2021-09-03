using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ponyliga.Models
{
    public class User
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        public String firstName { get; set; }
        public String surName { get; set; }
        public String loginName { get; set; }
        public String passwordHash { get; set; }
        public int userPrivileges { get; set; }
    }
}
