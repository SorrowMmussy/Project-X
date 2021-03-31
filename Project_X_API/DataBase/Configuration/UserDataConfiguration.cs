using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase.Configuration
{
    public class UserDataConfiguration : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.HasOne(userData => userData.User).WithOne(user => user.UserData).HasForeignKey<UserData>(userData => userData.UserId);
            builder.HasKey(userData => userData.Id);
            builder.Property(userData => userData.UserId).IsRequired(false);
        }
    }
}