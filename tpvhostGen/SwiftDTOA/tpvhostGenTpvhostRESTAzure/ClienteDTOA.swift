//
// ClienteDTOA.swift
// 
// Code autogenerated. Do not modify this file.
//

import Foundation
import SwiftyJSON
		
class ClienteDTOA : DTOA
{
	// MARK: - Properties

	var id: Int?;
	
	var nombre: String?;
	var apellidos: String?;
	var dni: String?;
	
	
	
	
	
	// MARK: - Constructor
	
	init ()
	{
		// Empty constructor
	}
	
	
	
	// MARK: - JSON <-> DTOA
	
	required init (fromJSONObject json: JSON)
	{
		self.id = json["Id"].object as? Int
		
	
		self.nombre = json["Nombre"].object as? String;
		self.apellidos = json["Apellidos"].object as? String;
		self.dni = json["Dni"].object as? String;
		
		
	}
	
	func toDictionary() -> [String : AnyObject]
	{
		var dictionary: [String : AnyObject] = [:];
		
		dictionary["Id"] = self.id;
		
	

	
		dictionary["Nombre"] = self.nombre;
	
	

	
		dictionary["Apellidos"] = self.apellidos;
	
	

	
		dictionary["Dni"] = self.dni;
	
	
		
		
		
		return dictionary;
	}
}

	