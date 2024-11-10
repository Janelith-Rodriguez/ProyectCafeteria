using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.BD.Data.Entity
{
    public class Carrito : EntityBase
    {
        [Required(ErrorMessage = "El usuario del carrito es obligatorio.")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "La orden del carrito es obligatorio.")]
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        [Required(ErrorMessage = "La cantidad del carrito es obligatorio.")]
        public int Cantidad { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
