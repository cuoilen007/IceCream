using System;
using System.Collections.Generic;

#nullable disable

namespace IceCreamApi.Models
{
    public partial class BookPayment
    {
        public int Id { get; set; }
        public int? IdMember { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Fullname { get; set; }
        public byte[] Phone { get; set; }

        public virtual Member IdMemberNavigation { get; set; }
    }
}
