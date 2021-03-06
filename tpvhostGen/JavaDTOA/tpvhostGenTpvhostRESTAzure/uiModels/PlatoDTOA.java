
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
public class PlatoDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private Double precio;
	public Double getPrecio () { return precio; }
	public void setPrecio (Double precio) { this.precio = precio; }
	
	
	/* Rol: Plato o--> LineaPlato */
	private ArrayList<LineaPlatoDTOA> lineasPlato;
	public ArrayList<LineaPlatoDTOA> getLineasPlato () { return lineasPlato; }
	public void setLineasPlato (ArrayList<LineaPlatoDTOA> lineasPlato) { this.lineasPlato = lineasPlato; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public PlatoDTOA ()
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

			if (!JSONObject.NULL.equals(json.opt("Precio")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Precio"));
 				this.precio = Double.parseDouble(stringDouble);
			 
			}
			

			JSONArray arrayLineasPlato = json.optJSONArray("LineasPlato");
			if (arrayLineasPlato != null)
			{
				this.lineasPlato = new ArrayList<LineaPlatoDTOA>();
				for (int i = 0; i < arrayLineasPlato.length(); ++i)
				{
					JSONObject subJson = (JSONObject) arrayLineasPlato.opt(i);
					LineaPlatoDTOA tmp = new LineaPlatoDTOA();
					tmp.setFromJSON(subJson);
					this.lineasPlato.add(tmp);
				}
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
		
		
		  if (this.precio != null)
			json.put("Precio", this.precio);
		
			

			if (this.lineasPlato != null)
			{
				JSONArray jsonArray = new JSONArray();
				for (int i = 0; i < this.lineasPlato.size(); ++i)
				{
					jsonArray.put(this.lineasPlato.get(i).toJSON());
				}
				json.put("LineasPlato", jsonArray);
			}

			
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
		PlatoDTO dto = new PlatoDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setPrecio (this.getPrecio());

		
		
		// Roles
					// TODO: from DTOA [ LineasPlato ] (dataType : ArrayList<LineaPlatoDTOA>) to DTO [ LineaPlato ]
		
		
		return dto;
	}

	// endregion
}

	