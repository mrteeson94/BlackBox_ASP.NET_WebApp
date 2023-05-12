using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace blackBox.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public Nullable<DateTime> BirthDate { get; set; }

        //Foreign key
        [Required(ErrorMessage = "Please select a subscription plan!")]
        [Display(Name = "Account Membership Type")]
        public Nullable<int> MembershipTypeId { get; set; }
        //Reference property
        public virtual MembershipType MembershipType { get; set; }
    }
}