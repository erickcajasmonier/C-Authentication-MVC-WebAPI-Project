using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Persistence.Repositories
{
    public class PromocionRepository : Repository<Promocion>, IPromocionRepository
    {
        public  PromocionRepository(DeleiteDbContext context):base(context)
		{

		}
    }
}
