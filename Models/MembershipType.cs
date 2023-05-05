using System;
using System.Collections.Generic;
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
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}