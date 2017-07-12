using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Persistence.Repositories
{
    public class MesaRepository : Repository<Mesa>, IMesaRepository
    {
        public MesaRepository(DeleiteDbContext context):base(context)
		{

		}
    }
}
