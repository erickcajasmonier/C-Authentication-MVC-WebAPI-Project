using DeleiteVenezolano.Entities;
using DeleiteVenezolano.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Persistence.EntitiesConfigurations
{
    public class ReservaConfiguration : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Reservas");
            HasKey(a => a.ReservaId);
            Property(c => c.ReservaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Configuracion de las relaciones
            HasMany(a => a.Mesas)
                .WithRequired(a => a.Reserva);
        }
    }
}
