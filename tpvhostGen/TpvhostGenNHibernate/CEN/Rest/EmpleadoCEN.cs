

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
 *      Definition of the class EmpleadoCEN
 *
 */
public partial class EmpleadoCEN
{
private IEmpleadoCAD _IEmpleadoCAD;

public EmpleadoCEN()
{
        this._IEmpleadoCAD = new EmpleadoCAD ();
}

public EmpleadoCEN(IEmpleadoCAD _IEmpleadoCAD)
{
        this._IEmpleadoCAD = _IEmpleadoCAD;
}

public IEmpleadoCAD get_IEmpleadoCAD ()
{
        return this._IEmpleadoCAD;
}

public int Nuevo (int p_negocio, string p_nombre, string p_apellidos, String p_pass)
{
        EmpleadoEN empleadoEN = null;
        int oid;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();

        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids DNI
                empleadoEN.Negocio = new TpvhostGenNHibernate.EN.Rest.NegocioEN ();
                empleadoEN.Negocio.Id = p_negocio;
        }

        empleadoEN.Nombre = p_nombre;

        empleadoEN.Apellidos = p_apellidos;

        empleadoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to EmpleadoCAD

        oid = _IEmpleadoCAD.Nuevo (empleadoEN);
        return oid;
}

public void Modificar (int p_Empleado_OID, string p_nombre, string p_apellidos, String p_pass)
{
        EmpleadoEN empleadoEN = null;

        //Initialized EmpleadoEN
        empleadoEN = new EmpleadoEN ();
        empleadoEN.DNI = p_Empleado_OID;
        empleadoEN.Nombre = p_nombre;
        empleadoEN.Apellidos = p_apellidos;
        empleadoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        //Call to EmpleadoCAD

        _IEmpleadoCAD.Modificar (empleadoEN);
}

public void Eliminar (int DNI
                      )
{
        _IEmpleadoCAD.Eliminar (DNI);
}

public EmpleadoEN ReadOID (int DNI
                           )
{
        EmpleadoEN empleadoEN = null;

        empleadoEN = _IEmpleadoCAD.ReadOID (DNI);
        return empleadoEN;
}

public System.Collections.Generic.IList<EmpleadoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<EmpleadoEN> list = null;

        list = _IEmpleadoCAD.ReadAll (first, size);
        return list;
}
public string Login (int p_Empleado_OID, string p_pass)
{
        string result = null;
        EmpleadoEN en = _IEmpleadoCAD.ReadOIDDefault (p_Empleado_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.DNI);

        return result;
}




private string Encode (int DNI)
{
        var payload = new Dictionary<string, object>(){
                { "DNI", DNI }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int DNI)
{
        EmpleadoEN en = _IEmpleadoCAD.ReadOIDDefault (DNI);
        string token = Encode (en.DNI);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerDNI (decodedToken);

                EmpleadoEN en = _IEmpleadoCAD.ReadOIDDefault (id);

                if (en != null && ((long)en.DNI).Equals (ObtenerDNI (decodedToken))
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


public long ObtenerDNI (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long dni = (long)results ["DNI"];
                return dni;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
