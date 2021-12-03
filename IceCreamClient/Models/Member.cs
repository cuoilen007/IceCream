using System;

namespace IceCreamClient.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
        public bool? IsMember { get; set; }
        public DateTime? RegisterDay { get; set; }
        public int? IdMemberOption { get; set; }
        public string Username { get; set; }
    }
}
