using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Models
{
    public class ComentarioViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe escribir algo")]
        [Display(Name = "Contenido del mensaje")]
        [DataType(DataType.MultilineText)]
        public string Contenido { get; set; }

        public DateTime Fecha { get; set; }

        public UsuarioEN Usuario { get; set; }

        public CancionEN Cancion { get; set; }
    }
}