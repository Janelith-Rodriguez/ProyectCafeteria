using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.Shared.DTO
{
    public class CrearOrdenDTO
    {
        [Required(ErrorMessage = "La fecha de la orden obligatorio.")]
        public DateTime Fecha_Orden { get; set; }

        [Required(ErrorMessage = "El total de la orden es obligatorio.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "El estado de la orden es obligatorio.")]
        [MaxLength(15, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El usuario de la orden es obligatorio.")]
        public int UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
    }
}
