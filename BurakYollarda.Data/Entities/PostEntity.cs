using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Entities
{
    public class PostEntity:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public string? ImagePath { get; set; }
		public int CategoryId { get; set; }
		public int? SubCategoryId { get; set; }

      





        
        public List<CommentEntity> Comments { get; set; }
        public CategoryEntity Category { get; set; }
        public SubCategoryEntity SubCategory { get; set; }


    }

    public class PostEntityConfiguration : BaseConfiguration<PostEntity>
    {
        public override void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Summary).IsRequired();
            builder.Property(x => x.ImagePath).IsRequired(false);
            
            base.Configure(builder);
        }
    }
}
