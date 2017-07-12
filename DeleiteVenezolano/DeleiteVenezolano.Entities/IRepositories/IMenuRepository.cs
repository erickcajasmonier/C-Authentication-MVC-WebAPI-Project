using DeleiteVenezolano.Entities.Entities;
using DeleiteVenezolano.Entities.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleiteVenezolano.Entities.IRepositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        //Obtener relacion de menu por tipo de menu
        //IEnumerable<Menu> GetMenuByTipoMenu(TipoMenu tipoMenu);
    }
}
