

using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Customer
    {
        public int Id { get; set; }


        public string? Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }

    }

}