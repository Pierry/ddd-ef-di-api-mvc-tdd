using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SpaUserControl.Domain.Entities;

namespace SpaUserControl.Data.Context.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            
        }
    }
}