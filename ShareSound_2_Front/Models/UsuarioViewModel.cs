using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Models
{
    public class UsuarioViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "El número de caracteres de {0} no debe superar {1} carácteres.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Imagen de perfil")]
        public HttpPostedFileBase Imagen { get; set; }

        [ScaffoldColumn(false)]
        public string ImagenExt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public System.DateTime Fecha { get; set; }

        public List<CancionEN> CancionesGustadas { get; set; }

        public List<UsuarioEN> Seguidores { get; set; }

        public List<UsuarioEN> Seguidos { get; set; }

        public List<PlaylistEN> PlaylistCreadas { get; set; }

        public List<PlaylistEN> PlaylistSeguidas { get; set; }

        public List<AlbumEN> AlbumsCreados { get; set; }

        public List<AlbumEN> AlbumsSeguidos { get; set; }

        public List<ComentarioEN> Comentarios { get; set; }
    }

    public class BasicUserViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ImagenExt { get; set; }
    }
}