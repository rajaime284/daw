
package tpvhostGenTpvhostRESTAzure.uiModels.DTOA;

import tpvhostGenTpvhostRESTAzure.uiModels.DTO.*;
import tpvhostGenTpvhostRESTAzure.uiModels.DTO.utils.*;
import tpvhostGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;

import java.util.ArrayList;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

/**
 * Code autogenerated. Do not modify this file.
 */
public class DuenyoRegistradoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private String apellido;
	public String getApellido () { return apellido; }
	public void setApellido (String apellido) { this.apellido = apellido; }
	
	private String dni;
	public String getDni () { return dni; }
	public void setDni (String dni) { this.dni = dni; }
	
	private String telefono;
	public String getTelefono () { return telefono; }
	public void setTelefono (String telefono) { this.telefono = telefono; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public DuenyoRegistradoDTOA ()
	{
		// Empty constructor
	}
	
	@Override
	public void setFromJSON (JSONObject json)
	{
		try
		{
			if (!JSONObject.NULL.equals(json.opt("Id")))
			{
				this.id = (Integer) json.opt("Id");
			}
			

			if (!JSONObject.NULL.equals(json.opt("Nombre")))
			{
			 
				this.nombre = (String) json.opt("Nombre");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Apellido")))
			{
			 
				this.apellido = (String) json.opt("Apellido");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Dni")))
			{
			 
				this.dni = (String) json.opt("Dni");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Telefono")))
			{
			 
				this.telefono = (String) json.opt("Telefono");
			 
			}
			
			
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public JSONObject toJSON ()
	{
		JSONObject json = new JSONObject();
		
		try
		{
			if (this.id != null){
				json.put("Id", this.id);
			}
			
		
		  if (this.nombre != null)
			json.put("Nombre", this.nombre);
		
		
		  if (this.apellido != null)
			json.put("Apellido", this.apellido);
		
		
		  if (this.dni != null)
			json.put("Dni", this.dni);
		
		
		  if (this.telefono != null)
			json.put("Telefono", this.telefono);
		
			
			
		}
		catch (JSONException e)
		{
			e.printStackTrace();
		}
		
		return json;
	}
	
	@Override 
	public IDTO toDTO ()
	{
		DuenyoDTO dto = new DuenyoDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setApellido (this.getApellido());

	dto.setDni (this.getDni());

	dto.setTelefono (this.getTelefono());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	