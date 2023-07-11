
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface ICancionCAD
{
CancionEN ReadOIDDefault (int id
                          );

void ModifyDefault (CancionEN cancion);

System.Collections.Generic.IList<CancionEN> ReadAllDefault (int first, int size);



int New_ (CancionEN cancion);

void Modify (CancionEN cancion);


void Destroy (int id
              );


CancionEN ReadOID (int id
                   );


System.Collections.Generic.IList<CancionEN> ReadAll (int first, int size);



System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> BuscarPorTitulo (string titulo);


System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorReproducciones ();



System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.CancionEN> OrdenarPorTitulo ();


void RecibirMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs);

void QuitarMeGusta (int p_Cancion_OID, System.Collections.Generic.IList<int> p_usuarios_gustados_OIDs);
}
}
