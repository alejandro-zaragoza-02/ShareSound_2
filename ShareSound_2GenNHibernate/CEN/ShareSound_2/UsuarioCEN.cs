

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ShareSound_2GenNHibernate.Exceptions;

using ShareSound_2GenNHibernate.EN.ShareSound_2;
using ShareSound_2GenNHibernate.CAD.ShareSound_2;


namespace ShareSound_2GenNHibernate.CEN.ShareSound_2
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public int New_ (String p_pass, string p_nombre, string p_descripcion, string p_imagen, string p_email, Nullable<DateTime> p_fecha)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Descripcion = p_descripcion;

        usuarioEN.Imagen = p_imagen;

        usuarioEN.Email = p_email;

        usuarioEN.Fecha = p_fecha;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, String p_pass, string p_nombre, string p_descripcion, string p_imagen, string p_email, Nullable<DateTime> p_fecha)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Id = p_Usuario_OID;
        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Descripcion = p_descripcion;
        usuarioEN.Imagen = p_imagen;
        usuarioEN.Email = p_email;
        usuarioEN.Fecha = p_fecha;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (int id
                     )
{
        _IUsuarioCAD.Destroy (id);
}

public UsuarioEN ReadOID (int id
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (id);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public void SeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.SeguirUsuario (p_Usuario_OID, p_seguidos_OIDs);
}
public void DejarSeguirUsuario (int p_Usuario_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DejarSeguirUsuario (p_Usuario_OID, p_seguidos_OIDs);
}
public void SeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.SeguirPlaylist (p_Usuario_OID, p_playlists_seguidas_OIDs);
}
public void DejarSeguirPlaylist (int p_Usuario_OID, System.Collections.Generic.IList<int> p_playlists_seguidas_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DejarSeguirPlaylist (p_Usuario_OID, p_playlists_seguidas_OIDs);
}
public void SeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.SeguirAlbum (p_Usuario_OID, p_albums_seguidos_OIDs);
}
public void DejarSeguirAlbum (int p_Usuario_OID, System.Collections.Generic.IList<int> p_albums_seguidos_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DejarSeguirAlbum (p_Usuario_OID, p_albums_seguidos_OIDs);
}
public System.Collections.Generic.IList<ShareSound_2GenNHibernate.EN.ShareSound_2.UsuarioEN> DameUsuarioPorEmail (string email)
{
        return _IUsuarioCAD.DameUsuarioPorEmail (email);
}



private string Encode (int id)
{
        var payload = new Dictionary<string, object>(){
                { "id", id }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int id)
{
        UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);
        string token = Encode (en.Id);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerID (decodedToken);

                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerID (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long id = (long)results ["id"];
                return id;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
