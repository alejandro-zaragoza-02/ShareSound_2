using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Assemblers
{
    public class CancionAssembler
    {
        public CancionViewModel ConvertENToViewModelUI(CancionEN en)
        {
            CancionViewModel cvm = new CancionViewModel();

            cvm.Id = en.Id;
            cvm.Titulo = en.Titulo;
            cvm.SongExt = en.Fichero;
            cvm.N_likes = en.Usuarios_gustados.Count;
            cvm.N_repros = en.Reproducciones;
            cvm.Duracion = en.Duracion;
            cvm.Album = new BasicAlbumAssembler().ConvertENToModelUI(en.Album);
            cvm.Usuario = new BasicUsuarioAssembler().ConvertENToModelUI(en.Album.Usuario);
            cvm.UsuariosGustados = new BasicUsuarioAssembler().ConvertListENToModel(en.Usuarios_gustados);

            return cvm;
        }

        public IList<CancionViewModel> ConvertListENToViewModel(IList<CancionEN> len)
        {
            IList<CancionViewModel> lcvm = new List<CancionViewModel>();
            foreach (CancionEN cen in len)
            {
                lcvm.Add(ConvertENToViewModelUI(cen));
            }
            return lcvm;
        }
    }
    public class BasicCancionAssembler
    {
        public BasicCancionViewModel ConvertENToViewModelUI(CancionEN en)
        {
            BasicCancionViewModel cvm = new BasicCancionViewModel();


            cvm.Id = en.Id;
            cvm.Titulo = en.Titulo;
            cvm.SongExt = en.Fichero;
            cvm.N_likes = en.Usuarios_gustados.Count;
            cvm.N_repros = en.Reproducciones;
            cvm.Duracion = en.Duracion;
            cvm.Album = new BasicAlbumAssembler().ConvertENToModelUI(en.Album);
            cvm.Usuario = new BasicUsuarioAssembler().ConvertENToModelUI(en.Album.Usuario);
            cvm.UsuariosGustados = new BasicUsuarioAssembler().ConvertListENToModel(en.Usuarios_gustados);

            return cvm;
        }

        public IList<BasicCancionViewModel> ConvertListENToViewModel(IList<CancionEN> len)
        {
            IList<BasicCancionViewModel> lcvm = new List<BasicCancionViewModel>();
            foreach (CancionEN cen in len)
            {
                lcvm.Add(ConvertENToViewModelUI(cen));
            }
            return lcvm;
        }
    }

}