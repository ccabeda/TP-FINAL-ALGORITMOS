using System;

namespace proyecto
{
	public class Persona
	{
		//atributos
		private string nombre = null;
		private string apellido= null;
		
		//metodos
		public string Nombre
		{
			get { return nombre; }
         	set { nombre = value; }
		}
		
		public string Apellido
		{
			get { return apellido; }
         	set { apellido = value; }
		}
		
	}
}