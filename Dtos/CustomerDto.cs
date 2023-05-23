using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using blackBox.Models;

namespace blackBox.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //[Min18YearsIfMember]
        public Nullable<DateTime> BirthDate { get; set; }

        //Foreign key
        [Required]
        public Nullable<int> MembershipTypeId { get; set; }

        public virtual MembershipTypeDto MembershipType { get; set; }
    }
}