using DeleiteVenezolano.Entities;
using DeleiteVenezolano.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Persistence.EntitiesConfigurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Clientes");
            HasKey(a => a.ClienteId);
            Property(c => c.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nombre).IsRequired().HasMaxLength(15);
            Property(c => c.Apellido).IsRequired().HasMaxLength(15);
            Property(c => c.Email).IsRequired().HasMaxLength(20);


            //Configuracion de las relaciones
            HasMany(a => a.Reservas)
                .WithRequired(a => a.Cliente);
        }
    }
}
