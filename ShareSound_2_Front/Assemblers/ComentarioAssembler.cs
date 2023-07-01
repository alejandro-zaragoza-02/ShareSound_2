using ShareSound_2_Front.Models;
using ShareSound_2GenNHibernate.CEN.ShareSound_2;
using ShareSound_2GenNHibernate.EN.ShareSound_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareSound_2_Front.Assemblers
{
    public class ComentarioAssembler
    {
        public ComentarioViewModel ConvertENToModelUI(ComentarioEN en)
        {
            ComentarioViewModel vm = new ComentarioViewModel();
            ComentarioCEN albumCEN = new ComentarioCEN();

            vm.Id = en.Id;
            vm.Contenido = en.Contenido;
            vm.Fecha = (DateTime) en.Fecha;
            vm.Cancion = en.Cancion;
            vm.Usuario = en.Usuario;

            return vm;
        }
        public IList<ComentarioViewModel> ConvertListENToModel(IList<ComentarioEN> len)
        {
            IList<ComentarioViewModel> lcvm = new List<ComentarioViewModel>();
            foreach (ComentarioEN cen in len)
            {
                lcvm.Add(ConvertENToModelUI(cen));
            }
            return lcvm;
        }
    }
}