using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Dto
{
    public class PostDto
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Summary { get; set; }
		public string? ImagePath { get; set; }
		public int? SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
