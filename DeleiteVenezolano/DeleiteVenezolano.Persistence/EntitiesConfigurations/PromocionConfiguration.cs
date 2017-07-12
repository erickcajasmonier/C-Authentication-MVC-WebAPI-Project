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
    class PromocionConfiguration : EntityTypeConfiguration<Promocion>
    {
        public PromocionConfiguration()
        {
            //Configuracion de la tabla
            ToTable("Promociones");
            HasKey(a => a.PromocionId);
            Property(c => c.PromocionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nombre).IsRequired().HasMaxLength(25);
        }
    }
}
