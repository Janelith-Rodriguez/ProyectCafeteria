using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Repositorio
{
    public class OrdenRepositorio : Repositorio<Orden>, IOrdenRepositorio
    {
        private readonly Context context;
        public OrdenRepositorio(Context context) : base(context)
        {
            this.context = context;   
        }
    }
}
