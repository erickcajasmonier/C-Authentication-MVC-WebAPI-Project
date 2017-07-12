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
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            //Configuracion de las tablas
            ToTable("Pedidos");
            HasKey(a => a.PedidoId);
            Property(c => c.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //Configuracion de las relaciones
            HasRequired(a => a.Cliente)
                .WithMany(a => a.Pedidos);

            HasMany(a => a.Promociones)
                .WithMany(a => a.Pedidos)
                .Map(m =>
                {
                    m.ToTable("PedidoPromociones");
                    m.MapLeftKey("PedidoId");
                    m.MapRightKey("PromocionId");
                });

            HasMany(a => a.Menus)
               .WithMany(a => a.Pedidos)
               .Map(m =>
               {
                   m.ToTable("PedidoMenus");
                   m.MapLeftKey("PedidoId");
                   m.MapRightKey("MenuId");
               });

            HasRequired(a => a.Empleado)
                .WithMany(a => a.Pedidos);

            HasRequired(a => a.Comprobante)
                .WithRequiredPrincipal(a => a.Pedido);
        }

    }
}
