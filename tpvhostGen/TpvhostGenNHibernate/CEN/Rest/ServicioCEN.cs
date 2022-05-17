

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
 *      Definition of the class ServicioCEN
 *
 */
public partial class ServicioCEN
{
private IServicioCAD _IServicioCAD;

public ServicioCEN()
{
        this._IServicioCAD = new ServicioCAD ();
}

public ServicioCEN(IServicioCAD _IServicioCAD)
{
        this._IServicioCAD = _IServicioCAD;
}

public IServicioCAD get_IServicioCAD ()
{
        return this._IServicioCAD;
}

public int Nuevo (int p_negocio, string p_nombre, int p_categoriaServicio)
{
        ServicioEN servicioEN = null;
        int oid;

        //Initialized ServicioEN
        servicioEN = new ServicioEN ();

        if (p_negocio != -1) {
                // El argumento p_negocio -> Property negocio es oid = false
                // Lista de oids id
                servicioEN.Negocio = new TpvhostGenNHibernate.EN.Rest.NegocioEN ();
                servicioEN.Negocio.Id = p_negocio;
        }

        servicioEN.Nombre = p_nombre;


        if (p_categoriaServicio != -1) {
                // El argumento p_categoriaServicio -> Property categoriaServicio es oid = false
                // Lista de oids id
                servicioEN.CategoriaServicio = new TpvhostGenNHibernate.EN.Rest.CategoriaServicioEN ();
                servicioEN.CategoriaServicio.Id = p_categoriaServicio;
        }

        //Call to ServicioCAD

        oid = _IServicioCAD.Nuevo (servicioEN);
        return oid;
}

public void Modificar (int p_Servicio_OID, string p_nombre)
{
        ServicioEN servicioEN = null;

        //Initialized ServicioEN
        servicioEN = new ServicioEN ();
        servicioEN.Id = p_Servicio_OID;
        servicioEN.Nombre = p_nombre;
        //Call to ServicioCAD

        _IServicioCAD.Modificar (servicioEN);
}

public void Eliminar (int id
                      )
{
        _IServicioCAD.Eliminar (id);
}

public ServicioEN ReadOID (int id
                           )
{
        ServicioEN servicioEN = null;

        servicioEN = _IServicioCAD.ReadOID (id);
        return servicioEN;
}

public System.Collections.Generic.IList<ServicioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ServicioEN> list = null;

        list = _IServicioCAD.ReadAll (first, size);
        return list;
}
}
}
