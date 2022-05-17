

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using TpvhostGenNHibernate.Exceptions;

using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CAD.Rest;


namespace TpvhostGenNHibernate.CEN.Rest
{
/*
 *      Definition of the class DuenyoCEN
 *
 */
public partial class DuenyoCEN
{
private IDuenyoCAD _IDuenyoCAD;

public DuenyoCEN()
{
        this._IDuenyoCAD = new DuenyoCAD ();
}

public DuenyoCEN(IDuenyoCAD _IDuenyoCAD)
{
        this._IDuenyoCAD = _IDuenyoCAD;
}

public IDuenyoCAD get_IDuenyoCAD ()
{
        return this._IDuenyoCAD;
}

public int Nuevo (string p_dni, string p_nombre, string p_apellido, string p_telefono, String p_pass)
{
        DuenyoEN duenyoEN = null;
        int oid;

        //Initialized DuenyoEN
        duenyoEN = new DuenyoEN ();
        duenyoEN.Dni = p_dni;

        duenyoEN.Nombre = p_nombre;

        duenyoEN.Apellido = p_apellido;

        duenyoEN.Telefono = p_telefono;

        duenyoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to DuenyoCAD

        oid = _IDuenyoCAD.Nuevo (duenyoEN);
        return oid;
}

public void Modificar (int p_Duenyo_OID, string p_dni, string p_nombre, string p_apellido, string p_telefono, String p_pass)
{
        DuenyoEN duenyoEN = null;

        //Initialized DuenyoEN
        duenyoEN = new DuenyoEN ();
        duenyoEN.Id = p_Duenyo_OID;
        duenyoEN.Dni = p_dni;
        duenyoEN.Nombre = p_nombre;
        duenyoEN.Apellido = p_apellido;
        duenyoEN.Telefono = p_telefono;
        duenyoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to DuenyoCAD

        _IDuenyoCAD.Modificar (duenyoEN);
}

public void Eliminar (int id
                      )
{
        _IDuenyoCAD.Eliminar (id);
}

public string Login (int p_Duenyo_OID, string p_pass)
{
        string result = null;
        DuenyoEN en = _IDuenyoCAD.ReadOIDDefault (p_Duenyo_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Id);

        return result;
}

public DuenyoEN ReadOID (int id
                         )
{
        DuenyoEN duenyoEN = null;

        duenyoEN = _IDuenyoCAD.ReadOID (id);
        return duenyoEN;
}

public System.Collections.Generic.IList<DuenyoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DuenyoEN> list = null;

        list = _IDuenyoCAD.ReadAll (first, size);
        return list;
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
        DuenyoEN en = _IDuenyoCAD.ReadOIDDefault (id);
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

                DuenyoEN en = _IDuenyoCAD.ReadOIDDefault (id);

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
