using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
    }
}
