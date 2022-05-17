
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
public class MenuDTOA extends DTOA
{
	// region - Members, getters and setters

	private Integer id;
	public Integer getId () { return id; }
	public void setId (Integer id) { this.id = id; }

	
	private String nombre;
	public String getNombre () { return nombre; }
	public void setNombre (String nombre) { this.nombre = nombre; }
	
	private Double stock;
	public Double getStock () { return stock; }
	public void setStock (Double stock) { this.stock = stock; }
	
	
	/* Rol: Menu o--> LineaMenu */
	private ArrayList<LineaMenuDTOA> lineasMenu;
	public ArrayList<LineaMenuDTOA> getLineasMenu () { return lineasMenu; }
	public void setLineasMenu (ArrayList<LineaMenuDTOA> lineasMenu) { this.lineasMenu = lineasMenu; }

	
	
	// endregion
	
	
	
	// region - Constructor and JSON <-> DTOA <-> DTO
	
	public MenuDTOA ()
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

			if (!JSONObject.NULL.equals(json.opt("Stock")))
			{
			 
			 	String stringDouble = String.valueOf(json.opt("Stock"));
 				this.stock = Double.parseDouble(stringDouble);
			 
			}
			

			JSONArray arrayLineasMenu = json.optJSONArray("LineasMenu");
			if (arrayLineasMenu != null)
			{
				this.lineasMenu = new ArrayList<LineaMenuDTOA>();
				for (int i = 0; i < arrayLineasMenu.length(); ++i)
				{
					JSONObject subJson = (JSONObject) arrayLineasMenu.opt(i);
					LineaMenuDTOA tmp = new LineaMenuDTOA();
					tmp.setFromJSON(subJson);
					this.lineasMenu.add(tmp);
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
		
		
		  if (this.stock != null)
			json.put("Stock", this.stock);
		
			

			if (this.lineasMenu != null)
			{
				JSONArray jsonArray = new JSONArray();
				for (int i = 0; i < this.lineasMenu.size(); ++i)
				{
					jsonArray.put(this.lineasMenu.get(i).toJSON());
				}
				json.put("LineasMenu", jsonArray);
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
		MenuDTO dto = new MenuDTO ();
		
		// Attributes
		
	dto.setId (this.getId());

		
	dto.setNombre (this.getNombre());

	dto.setStock (this.getStock());

		
		
		// Roles
					// TODO: from DTOA [ LineasMenu ] (dataType : ArrayList<LineaMenuDTOA>) to DTO [ LineaMenu ]
		
		
		return dto;
	}

	// endregion
}

	