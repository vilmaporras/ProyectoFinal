using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_Core_Conv2.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto
        {
            get;
            set;
        }

        [Required]
        public int IdCategoria
        {
            get;
            set;
        }

        [ForeignKey("IdCategoria")]

        public Categoria Categoria { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage ="El campo Nombre es requerido")]
        public string Nombre
        {
            get;
            set;
        }
        public float Precio
        {
            get;
            set;
        }

        [StringLength(200)]
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
