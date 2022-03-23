using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_Core_Conv2.Models
{
    public class Modulo
    {
        [Key]
        public int IdModulo
        {
            get;
            set;
        }

        public int IdPropietario
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
