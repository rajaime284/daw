	
		//
		// EmpleadoDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class EmpleadoDTO 	    {
		 
				var rol_oid: [Int]?;
				    	 
		 
				var negocio_oid: Int?;
				    	 
		 
				var dNI: Int?;
				    	 
		 
				var nombre: String?;
				    	 
		 
				var apellidos: String?;
				    	 
		 
				var pass: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


					dictionary["rol_oid"] = self.rol_oid;
			

					dictionary["negocio_oid"] = self.negocio_oid;
			

				
					dictionary["dNI"] = self.dNI;
				

				
					dictionary["nombre"] = self.nombre;
				

				
					dictionary["apellidos"] = self.apellidos;
				

				
					dictionary["pass"] = self.pass;
				
						
				return dictionary;
			}
		}
		
	