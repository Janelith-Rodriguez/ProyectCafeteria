using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Repositorio
{
    public class CarritoRepositorio : Repositorio<Carrito>, ICarritoRepositorio
    {
        private readonly Context context;
        public CarritoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
