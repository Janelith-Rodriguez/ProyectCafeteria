using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Producto_UQ", IsUnique = true)]
    public class Producto : EntityBase
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Stock del producto es obligatorio.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "El carrito Id del producto es obligatorio.")]
        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }

    }
}
