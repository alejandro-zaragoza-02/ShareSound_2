using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Assemblers
{
    public class PlaylistAssembler
    {
        public ListaViewModel ConvertENToModelUI(PlaylistEN en)
        {
            ListaViewModel vm = new ListaViewModel();
            PlaylistCEN albumCEN = new PlaylistCEN();

            vm.Id = en.Id;
            vm.Titulo = en.Titulo;
            vm.Descripcion = en.Descripcion;
            vm.Fecha = en.Fecha;
            vm.ImagenExt = en.Imagen;
            vm.Usuario = new BasicUsuarioAssembler().ConvertENToModelUI(en.Usuario);
            vm.Canciones = new BasicCancionAssembler().ConvertListENToViewModel(en.Canciones).ToList();
            vm.Seguidores = new BasicUsuarioAssembler().ConvertListENToModel(en.Seguidores);

            return vm;
        }
        public IList<ListaViewModel> ConvertListENToModel(IList<PlaylistEN> len)
        {
            IList<ListaViewModel> lcvm = new List<ListaViewModel>();
            foreach (PlaylistEN cen in len)
            {
                lcvm.Add(ConvertENToModelUI(cen));
            }
            return lcvm;
        }
    }

    public class BasicPlaylistAssembler
    {
        public BasicListaViewModel ConvertENToModelUI(PlaylistEN en)
        {
            BasicListaViewModel vm = new BasicListaViewModel();

            vm.Id = en.Id;
            vm.Titulo = en.Titulo;
            vm.ImagenExt = en.Imagen;

            return vm;
        }
        public IList<BasicListaViewModel> ConvertListENToModel(IList<PlaylistEN> len)
        {
            IList<BasicListaViewModel> lcvm = new List<BasicListaViewModel>();
            foreach (PlaylistEN cen in len)
            {
                lcvm.Add(ConvertENToModelUI(cen));
            }
            return lcvm;
        }
    }
}