using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context context;
        public ProductoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
