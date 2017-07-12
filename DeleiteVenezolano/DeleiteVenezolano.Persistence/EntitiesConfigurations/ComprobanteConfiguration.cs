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
    public class ComprobanteConfiguration : EntityTypeConfiguration<Comprobante>
    {
        public ComprobanteConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Comprobantes");
            HasKey(a => a.ComprobanteId);
            Property(c => c.ComprobanteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Direccion).IsRequired().HasMaxLength(20);

        }
    }
}
