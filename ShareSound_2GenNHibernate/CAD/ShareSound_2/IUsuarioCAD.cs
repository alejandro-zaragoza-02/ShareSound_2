
using System;
using ShareSound_2GenNHibernate.EN.ShareSound_2;

namespace ShareSound_2GenNHibernate.CAD.ShareSound_2
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);



void SeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs);

void DejarSeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs);

void SeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs);

void DejarSeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs);

void SeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs);

void DejarSeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs);

System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> DameUsuarioPorEmail (string email);
}
}
