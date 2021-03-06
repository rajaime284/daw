	
		package tpvhostGenTpvhostRESTAzure.uiModels.DTO;
		
		import java.util.ArrayList;
		
		import org.json.JSONArray;
		import org.json.JSONException;
		import org.json.JSONObject;
		import  tpvhostGenTpvhostRESTAzure.uiModels.DTO.utils.*;
		import  tpvhostGenTpvhostRESTAzure.uiModels.DTO.enumerations.*;
		
		
		/**
		 * Code autogenerated. Do not modify this file.
		 */
		
		
		public class DuenyoDTO 	    implements IDTO
	    {
				private String dni;
				public String getDni () { return dni; } 
				public void setDni  (String value) { dni = value;  } 
				    	 
				private ArrayList<Integer> empresa_oid;
				public ArrayList<Integer>  getEmpresa_oid () { return empresa_oid; } 
				public void setEmpresa_oid (ArrayList<Integer> value) { empresa_oid = value;  } 
				    	 
				private String nombre;
				public String getNombre () { return nombre; } 
				public void setNombre  (String value) { nombre = value;  } 
				    	 
				private String apellido;
				public String getApellido () { return apellido; } 
				public void setApellido  (String value) { apellido = value;  } 
				    	 
				private String telefono;
				public String getTelefono () { return telefono; } 
				public void setTelefono  (String value) { telefono = value;  } 
				    	 
				private String pass;
				public String getPass () { return pass; } 
				public void setPass  (String value) { pass = value;  } 
				    	 
				private Integer id;
				public Integer getId () { return id; } 
				public void setId  (Integer value) { id = value;  } 
				    	 
	   
			    public JSONObject toJSON ()
				{
					JSONObject json = new JSONObject();
					
					try
					{
				
						  json.put("Dni", this.dni);
				

						if (this.empresa_oid != null)
						{
							JSONArray jsonArray = new JSONArray();
							for (int i = 0; i < this.empresa_oid.size(); ++i)
							{
								jsonArray.put(this.empresa_oid.get(i));
							}
							json.put("Empresa_oid", jsonArray);
						}
		
				
						  json.put("Nombre", this.nombre);
				
				
						  json.put("Apellido", this.apellido);
				
				
						  json.put("Telefono", this.telefono);
				
				
						  json.put("Pass", this.pass);
				
				
						  json.put("Id", this.id.intValue());
				
						
					}
					catch (JSONException e)
					{
						e.printStackTrace();
					}
				
				return json;
			}
		
			// endregion
		}
	   
	   
	   
		
	