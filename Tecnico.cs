using System;

namespace proyecto
{
	public class Tecnico : Persona
	{
		//atributos
		private Area area;
		private int codigoTecnico = 0;	

		//metodos
		public int CodigoTecnico
		{
			get { return codigoTecnico; }
         	set { codigoTecnico = value; }
		}
		
		public Area Area 
		{
			get { return area; }
         	set { area = value; }
		}
	
		public string mostrarTecnico(){
			return CodigoTecnico + ": " + Nombre + " " + Apellido;
		}
	}
}