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
    public class MesaConfiguration : EntityTypeConfiguration<Mesa>
    {
        public MesaConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Mesas");
            HasKey(a => a.MesaId);
            Property(c => c.MesaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
