using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blackBox.Dtos
{
    public class RentalDto
    {
        //composite entity to Customer & Movie tables which have many-many relationship
        public int CustomerId { get; set; }
        public List<int> MovieId { get; set; }
    }
}