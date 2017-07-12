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
    public class EmpleadoConfiguration : EntityTypeConfiguration<Empleado>
    {
        public EmpleadoConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Empleados");
            HasKey(a => a.EmpleadoId);
            Property(c => c.EmpleadoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nombre).IsRequired().HasMaxLength(15);
            Property(c => c.Apellido).IsRequired().HasMaxLength(15);
            Property(c => c.Correo).IsRequired().HasMaxLength(20);
            Property(c => c.Direccion).IsRequired().HasMaxLength(15);

        }
    }
}
