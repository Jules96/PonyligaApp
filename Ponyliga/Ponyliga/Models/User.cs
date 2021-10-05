using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Ponyliga.Models
{
    public class User
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int id { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public String firstName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public String surName { get; set; }
        public String loginName { get; set; }
        public String passwordHash { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]

        // 0= Admin
        // 1= User
        public int userPrivileges { get; set; }



    }
}
