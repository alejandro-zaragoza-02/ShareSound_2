using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Models
{
    public class CancionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Título de la canción", Description = "Título de la canción", Name = "Título")]
        [Required(ErrorMessage = "Debe indicar un título para la canción")]
        [StringLength(maximumLength: 100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Titulo { get; set; }

        [Display(Name = "Fichero", Description = "Fichero mp3 de la canción")]
        [Required(ErrorMessage = "Debe subir un archivo mp3.")]
        public HttpPostedFileBase Fichero_mp3 { get; set; }

        [ScaffoldColumn(false)]
        public string SongExt { get; set; }

        public int N_likes { get; set; }

        public int N_repros { get; set; }

        public int Duracion { get; set; }


        [Required(ErrorMessage = "Debe elegir un álbum válido")]
        public string idAlbumSeleccionado { get; set; }

        public BasicListaViewModel Album { get; set; }

        public BasicUserViewModel Usuario { get; set; }

        [ScaffoldColumn(false)]
        public IList<BasicUserViewModel> UsuariosGustados { get; set; }
    }

    public class BasicCancionViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string SongExt { get; set; }

        public int N_likes { get; set; }

        public int N_repros { get; set; }

        public int Duracion { get; set; }

        public BasicListaViewModel Album { get; set; }

        public BasicUserViewModel Usuario { get; set; }

        public IList<BasicUserViewModel> UsuariosGustados { get; set; }

    }
}