
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );


ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);
}
}
