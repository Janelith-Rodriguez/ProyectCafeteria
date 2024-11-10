using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectCafeteria.BD.Data.Entity
{
    [Index(nameof(UsuarioId), nameof(Fecha_Orden), Name = "Orden_UQ", IsUnique = true)]
    [Index(nameof(Total), nameof(Estado), Name = "Orden_Total_Estado", IsUnique = false)]
    public class Orden : EntityBase
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
        public Usuario Usuario { get; set; }
        public List<Carrito> Carritos { get; set; }
    }
}
