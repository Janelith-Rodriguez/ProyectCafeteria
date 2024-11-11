using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.Shared.DTO
{
    public class CrearCarritoDTO
    {
        [Required(ErrorMessage = "El usuario del carrito es obligatorio.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "La orden del carrito es obligatorio.")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "La cantidad del carrito es obligatorio.")]
        public int Cantidad { get; set; }
    }
}
