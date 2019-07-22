using System;
using System.ComponentModel.DataAnnotations;
using VIdly.Models;

namespace VIdly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsOfAge]
        public DateTime? Birthdate { get; set; }
    }
}