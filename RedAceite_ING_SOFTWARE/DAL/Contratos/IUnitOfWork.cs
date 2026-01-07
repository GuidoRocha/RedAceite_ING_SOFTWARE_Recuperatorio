using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contratos
{
    public interface IUnitOfWork : IDisposable
    {
        //iproductorepository productos { get; }
        //icomprarepository compras { get; }
        //iventarepository ventas { get; }
        //imovimientostockrepository movimientos { get; }
        //iclienterepository clientes { get; }
        //idetalleventarepository detallesventa { get; }
        //idetallecomprarepository detallescompra { get; }
        int Complete(); // SaveChanges
    }
}
