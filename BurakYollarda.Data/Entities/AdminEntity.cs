using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakYollarda.Data.Entities
{
    public class AdminEntity:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }



    }

    public class AdminEntityConfiguration : BaseConfiguration<AdminEntity>
    {
        public override void Configure(EntityTypeBuilder<AdminEntity> builder)
        {
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            base.Configure(builder);
        }
    }
}
