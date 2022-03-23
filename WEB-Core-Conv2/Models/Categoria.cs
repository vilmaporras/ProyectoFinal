using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_Core_Conv2.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria
        {
            get;
            set;
        }
        [StringLength(100)]
        [Required]
        public string Nombre
        {
            get;
            set;
        }

        public string Descripcion
        {
            get;
            set;
        }
        public DateTime FechaCreacion
        {
            get;
            set;
        }
        
    }
}
