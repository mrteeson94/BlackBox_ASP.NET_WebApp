using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blackBox.Dtos
{
    public class MembershipTypeDto
    {
        //public MembershipTypeDto()
        //{
        //    this.Customers = new HashSet<CustomerDto>();
        //}

        public int MembershipTypeId { get; set; }
        public string TitleMembershipType { get; set; }
        //public virtual ICollection<CustomerDto> Customers { get; set; }
    }
}