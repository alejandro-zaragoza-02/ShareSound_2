using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertENToModelUI(UsuarioEN en)
        {
            UsuarioViewModel vm = new UsuarioViewModel();
            UsuarioCEN albumCEN = new UsuarioCEN();

            vm.Id = en.Id;
            vm.Nombre = en.Nombre;
            vm.Descripcion = en.Descripcion;
            vm.Fecha = (DateTime) en.Fecha;
            vm.ImagenExt = en.Imagen;
            vm.Email = en.Email;
            vm.AlbumsCreados = en.Albums_creados.ToList();
            vm.AlbumsSeguidos = en.Albums_seguidos.ToList();
            vm.PlaylistCreadas = en.Playlists_creadas.ToList();
            vm.PlaylistSeguidas = en.Playlists_seguidas.ToList();
            vm.CancionesGustadas = en.Canciones_gustadas.ToList();
            vm.Seguidores = en.Seguidores.ToList();
            vm.Seguidos = en.Seguidos.ToList();
            vm.Comentarios = en.Comentarios.ToList();

            return vm;
        }
        public IList<UsuarioViewModel> ConvertListENToModel(IList<UsuarioEN> len)
        {
            IList<UsuarioViewModel> lcvm = new List<UsuarioViewModel>();
            foreach (UsuarioEN cen in len)
            {
                lcvm.Add(ConvertENToModelUI(cen));
            }
            return lcvm;
        }
    }

    public class BasicUsuarioAssembler
    {
        public BasicUserViewModel ConvertENToModelUI(UsuarioEN en)
        {
            BasicUserViewModel vm = new BasicUserViewModel();

            vm.Id = en.Id;
            vm.Nombre = en.Nombre;
            vm.ImagenExt = en.Imagen;

            return vm;
        }
        public IList<BasicUserViewModel> ConvertListENToModel(IList<UsuarioEN> len)
        {
            IList<BasicUserViewModel> lcvm = new List<BasicUserViewModel>();
            foreach (UsuarioEN cen in len)
            {
                lcvm.Add(ConvertENToModelUI(cen));
            }
            return lcvm;
        }
    }
}