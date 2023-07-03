using System;

namespace proyecto
{
	public class Combo
	{
		//atributos
		private int minutos;
		private int precio;
		private int numeroCombo;
		
	
		//constructor
		public Combo (int NumeroCombo) 
		{
			this.numeroCombo=NumeroCombo;
		}
					
		
		//metodos
		public int Minutos
		{
			get { return minutos; }
         	set { minutos = value; }
		}
	
		public int Precio
		{
			get { return precio; }
         	set { precio = value; }
		}
		
		
		public int NumeroCombo
		{
			get { return numeroCombo; }
         	set { numeroCombo = value; }
		}
		
		
		public string mostrarCombo(){
			return "Nº" + NumeroCombo + ": " + Minutos + " minutos por $" + Precio + " por mes.";
		}	
	}
}