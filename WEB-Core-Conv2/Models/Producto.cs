using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEB_Core_Conv2.Data;

namespace WEB_Core_Conv2.Models
{

    public class Producto
    {
        private MyDbContext _context;

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

        //public Categoria Categoria { get; set; }


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
        //public List<Categoria> ObtenerCategorias()
        //{
        //    List<Categoria> lista = _context.Categoria.ToList();
        //    return lista;
        //}

    }
}
