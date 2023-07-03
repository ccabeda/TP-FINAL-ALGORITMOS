using System;

namespace proyecto
{
	public class Cliente : Persona
	{		
		//atributos
		private int nroCliente;
		private int dni;
		private DateTime fechaAlta;
		private Combo planVigente;
		private int minutosConsumidos;
		private Tecnico tecnicoAsignado;
		private bool promocion;
		private bool oferta;
		
		//metodos
		public int Dni
		{
			get { return dni; }
        	set { dni = value; }
		}
		
		public int NroCliente
		{
			get { return nroCliente; }
        	set { nroCliente = value; }
		}
		
		public DateTime FechaAlta
		{
			get { return fechaAlta; }
        	set { fechaAlta = value; }
		}
		
		public Combo PlanVigente
		{
			get { return planVigente; }
        	set { planVigente = value; }
		}
		
		public int MinutosConsumidos
		{
			get { return minutosConsumidos; }
        	set { minutosConsumidos = value; }
		}
		
		public Tecnico TecnicoAsignado
		{
			get { return tecnicoAsignado; }
        	set { tecnicoAsignado = value; }
		}
		
		public bool Promocion
		{
			get { return promocion; }
        	set { promocion = value; }
		}
		
		public bool Oferta
		{
			get { return oferta; }
        	set { oferta = value; }
		}
		
		public string mostrarCliente(){
			return this.NroCliente +": " + this.Nombre  + " " + this.Apellido;
		}
			
	}
}