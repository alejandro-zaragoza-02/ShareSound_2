
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface IPlaylistCAD
{
PlaylistEN ReadOIDDefault (int id
                           );

void ModifyDefault (PlaylistEN playlist);

System.Collections.Generic.IList<PlaylistEN> ReadAllDefault (int first, int size);



int New_ (PlaylistEN playlist);

void Modify (PlaylistEN playlist);


void Destroy (int id
              );


PlaylistEN ReadOID (int id
                    );


System.Collections.Generic.IList<PlaylistEN> ReadAll (int first, int size);


void AnyadirCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs);

void QuitarCancion (int p_Playlist_OID, System.Collections.Generic.IList<int> p_canciones_OIDs);

System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.PlaylistEN> BuscarPorTitulo (string titulo);
}
}
