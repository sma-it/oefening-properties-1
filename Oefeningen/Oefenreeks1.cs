using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First
{
	/*
	 * Oefening 1
	 * 
	 * Voeg aan de class Customer deze readonly properties toe:
	 * - Name (geeft de volledige naam)
	 * - Age (geeft de leeftijd als integer)
	 */ 

	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }

	}

	/* 
	 * Oefening 2
	 * 
	 * Maak een class Coordinate, met properties X en Y (float)
	 * Maak ook een functie 'Set' waar je de X en Y coordinaat mee
	 * kan instellen via twee argumenten.
	 */ 



	/*
	 * Oefening 3
	 * 
	 * Maak een class 'Circle' met deze properties:
	 * - Radius (float)
	 * - Pos (gebruik de Coordinate class uit de vorige oefening)
	 * 
	 * Maak de volgende readonly properties
	 * - Area (float)
	 * - Perimeter (float)
	 */
	 

	/*
	 * Oefening 4
	 * 
	 * Maak een class 'Rectangle' met deze properties:
	 * - Width (float)
	 * - Height (float)
	 * - Pos (gebruik de Coordinate class uit de vorige oefening)
	 * 
	 * Maak de volgende readonly properties:
	 * - UpperLeft
	 * - UpperRight
	 * - LowerLeft
	 * - LowerRight
	 * Al deze properties hebben het type Coordinate. Je berekent deze 
	 * coordinaten als volgt: Neem de positie en tel daar de helft van de hoogte
	 * en breedte bij of af. Voor UpperLeft zal je bijvoorbeeld de helft van de 
	 * hoogte bijtellen, en de helft van de breedte aftrekken.
	 * (De positie is dus het midden van de rechthoek.)
	 * 
	 * - Area
	 * - Perimeter
	 */

}
