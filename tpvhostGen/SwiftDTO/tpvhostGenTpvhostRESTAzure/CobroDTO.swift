	
		//
		// CobroDTO.swift
		// 
		// Code autogenerated. Do not modify this file.
		//
		
		import Foundation
		import SwiftyJSON
	
		 class CobroDTO 	    {
		 
				var id: Int?;
				    	 
		 
				var monto: Float?;
				    	 
		 
				var comanda_oid: Int?;
				    	 
		 
				var cliente_oid: Int?;
				    	 
		 
				var tipoDeCobro: String?;
				    	 
		 
				var tipoCobro_oid: Int?;
				    	 
		 
				var caja_oid: [Int]?;
				    	 
		 
				var numeroTransaccion: String?;
				    	 
	   	   
			// MARK: - Constructor
			
			
		
			init ()
			{
				// Empty constructor
			}
			 func toDictionary() -> [String : AnyObject]
		
		   
			{
				var dictionary: [String : AnyObject] = [:];
				
			


				
					dictionary["id"] = self.id;
				

				
					dictionary["monto"] = self.monto;
				

					dictionary["comanda_oid"] = self.comanda_oid;
			

					dictionary["cliente_oid"] = self.cliente_oid;
			

				
					dictionary["tipoDeCobro"] = self.tipoDeCobro;
				

					dictionary["tipoCobro_oid"] = self.tipoCobro_oid;
			

					dictionary["caja_oid"] = self.caja_oid;
			

				
					dictionary["numeroTransaccion"] = self.numeroTransaccion;
				
						
				return dictionary;
			}
		}
		
	