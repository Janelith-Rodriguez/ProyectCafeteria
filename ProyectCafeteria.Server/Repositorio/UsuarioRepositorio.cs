using ProyectCafeteria.BD.Data;
using ProyectCafeteria.BD.Data.Entity;

namespace ProyectCafeteria.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Context context;
        public UsuarioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
