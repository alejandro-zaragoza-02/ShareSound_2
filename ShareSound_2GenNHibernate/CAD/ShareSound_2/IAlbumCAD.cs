
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface IAlbumCAD
{
AlbumEN ReadOIDDefault (int id
                        );

void ModifyDefault (AlbumEN album);

System.Collections.Generic.IList<AlbumEN> ReadAllDefault (int first, int size);



int New_ (AlbumEN album);

void Modify (AlbumEN album);


void Destroy (int id
              );


AlbumEN ReadOID (int id
                 );


System.Collections.Generic.IList<AlbumEN> ReadAll (int first, int size);
}
}
