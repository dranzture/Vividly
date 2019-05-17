using System.Collections.Generic;

namespace Vividly.DTOs
{
    public class RentalsDTO
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}