using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase.Configuration
{
    public class ExplosiveDataConfiguration : IEntityTypeConfiguration<ExplosiveData>
    {
        public void Configure(EntityTypeBuilder<ExplosiveData> builder)
        {
            builder.HasKey(explosiveData => explosiveData.Id);
        }
    }
}