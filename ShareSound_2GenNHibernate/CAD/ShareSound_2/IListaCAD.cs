
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface IListaCAD
{
ListaEN ReadOIDDefault (int id
                        );

void ModifyDefault (ListaEN lista);

System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size);



int New_ (ListaEN lista);

void Modify (ListaEN lista);


void Destroy (int id
              );


ListaEN ReadOID (int id
                 );


System.Collections.Generic.IList<ListaEN> ReadAll (int first, int size);
}
}
