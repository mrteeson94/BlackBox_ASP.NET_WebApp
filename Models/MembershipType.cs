using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace blackBox.Models
{
    public class MembershipType
    {
        public MembershipType()
        {
            this.Customers = new HashSet<Customer>();
        }

        public int MembershipTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string TitleMembershipType { get; set; }
        [Required]
        public short SignUpFee { get; set; }
        [Required]
        public byte DurationInMonths { get; set; }
        [Required]
        public byte DiscountRate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
    }
}