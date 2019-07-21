using System;
using System.ComponentModel.DataAnnotations;

namespace VIdly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "MembershipType Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsOfAge]
        public DateTime? Birthdate { get; set; }
    }
}