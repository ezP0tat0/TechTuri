﻿namespace TechTuri.Model
{
    public class Profile
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public byte[] pwHash { get; set; }
        public byte[] pwSalt { get; set; }
        public DateTime joinDate { get; set; }
    }
}
