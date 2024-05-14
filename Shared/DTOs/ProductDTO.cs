using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
        public int Id { get; set; }
    }
}
