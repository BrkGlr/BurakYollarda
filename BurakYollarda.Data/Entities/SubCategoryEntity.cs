using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Entities
{
    public class SubCategoryEntity:BaseEntity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
       



        public CategoryEntity Category { get; set; }
        public List<PostEntity> Posts { get; set; }

    }
    
    public class SubCategoryEntityConfiguration : BaseConfiguration<SubCategoryEntity>
    {
        public override void Configure(EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            

            base.Configure(builder);
        }
    }
}
