
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
public class LineaCompraProveedorDTOA extends DTOA
{
	// region - Members, getters and setters

	
	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }
	
	private Integer cantidad;
	public Integer getCantidad () { return cantidad; }
	public void setCantidad (Integer cantidad) { this.cantidad = cantidad; }
	
	private Double costo;
	public Double getCosto () { return costo; }
	public void setCosto (Double costo) { this.costo = costo; }
	
	
	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public LineaCompraProveedorDTOA ()
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

			if (!JSONObject.NULL.equals(json.opt("Cantidad")))
			{
			 
				this.cantidad = (Integer) json.opt("Cantidad");
			 
			}

			if (!JSONObject.NULL.equals(json.opt("Costo")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Costo"));
 				this.costo = Double.parseDouble(stringDouble);
			 
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
			
		
		  if (this.id != null)
			json.put("Id", this.id.intValue());
		
		
		  if (this.cantidad != null)
			json.put("Cantidad", this.cantidad.intValue());
		
		
		  if (this.costo != null)
			json.put("Costo", this.costo);
		
			
			
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
		LineaCompraProveedorDTO dto = new LineaCompraProveedorDTO ();
		
		// Attributes
		
		
	dto.setId (this.getId());

	dto.setCantidad (this.getCantidad());

	dto.setCosto (this.getCosto());

		
		
		// Roles
		
		
		return dto;
	}

	// endregion
}

	