using System;

namespace proyecto
{
	public class Area
	{
		//atributos
		private int codigoArea = 0;
		private string nombreArea;
		
		
		//constructor
		public Area (int CodigoArea,string NombreArea){
			this.codigoArea = CodigoArea;
			this.nombreArea = NombreArea;
		}
		
		//metodos
		public int CodigoArea
		{
			get { return codigoArea; }
         	set { codigoArea = value; }
		}
		
		public string NombreArea
		{
			get { return nombreArea; }
         	set { nombreArea = value; }
		}
		
		public string mostrarArea(){
			return this.codigoArea +": " + this.NombreArea;
		}
		
	}
}