using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Entities
{
    public class CommentEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        public int PostId { get; set; }



        public PostEntity Post { get; set; }
    }

    public class CommentEntityConfiguration : BaseConfiguration<CommentEntity>
    {
        public override void Configure(EntityTypeBuilder<CommentEntity> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(75);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(75);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(500);
            

            base.Configure(builder);
        }
    }
}
