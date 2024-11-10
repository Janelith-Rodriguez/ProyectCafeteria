using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.BD.Data.Entity
{
    public class Orden : EntityBase
    {
        public DateTime Fecha_Orden { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        //public int UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
    }
}
