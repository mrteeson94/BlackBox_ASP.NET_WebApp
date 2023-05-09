using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blackBox.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        public Nullable<DateTime> BirthDate { get; set; }

        //Foreign key
        [Display(Name = "Account Membership Type")]
        public Nullable<int> MembershipTypeId { get; set; }
        //Reference property
        public virtual MembershipType MembershipType { get; set; }
    }
}