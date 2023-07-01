using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Models
{
    public class ListaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe indicar el titulo")]
        [Display(Name = "Titulo")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "El titulo tiene que tener entre 5 y 50 caracteres")]
        public string Titulo { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 500, ErrorMessage = "La Descripcion tiene un maximo de 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe indicar la Imagen")]
        [Display(Name = "Imagen")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Imagen { get; set; }

        [ScaffoldColumn(false)]
        public string ImagenExt { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Fecha { get; set; }

        [ScaffoldColumn(false)]
        public List<BasicCancionViewModel> Canciones { get; set; }


        [ScaffoldColumn(false)]
        public BasicUserViewModel Usuario { get; set; }

        [ScaffoldColumn(false)]
        public IList<BasicUserViewModel> Seguidores { get; set; }
    }

    public class BasicListaViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string ImagenExt { get; set; }

        public BasicUserViewModel Usuario { get; set; }

    }
}