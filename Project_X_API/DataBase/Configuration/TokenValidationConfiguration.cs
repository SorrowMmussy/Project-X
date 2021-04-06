using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase.Configuration
{
    public class TokenValidationConfiguration : IEntityTypeConfiguration<TokenValidation>
    {
        public void Configure(EntityTypeBuilder<TokenValidation> builder)
        {
            builder.HasOne(token => token.User).WithMany(user => user.Tokens);
            builder.HasKey(email => email.Id);
        }
    }
}