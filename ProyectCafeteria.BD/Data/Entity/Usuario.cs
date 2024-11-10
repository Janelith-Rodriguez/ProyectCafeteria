using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectCafeteria.BD.Data.Entity
{
    [Index(nameof(Nombre), Name = "Usuario_UQ", IsUnique = true)]
    public class Usuario : EntityBase
    {
        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email del usuario es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password del usuario es obligatorio.")]
        [MaxLength(100, ErrorMessage = "Maximo numero de caracteres{1}.")]
        public string Password { get; set; }
        //public List<Orden> Ordenes { get; set; }
        //public List<Carrito> Carritos { get; set; }
    }
}
