using System;
using System.Collections;

namespace proyecto
{
	public class Empresa
	{
		private ArrayList listaClientes;
		private ArrayList listaTecnicos;
		private ArrayList listaCombos;
		private ArrayList listaAreas;
		
		//constructor
		public Empresa()
		{
			listaClientes = new ArrayList();
			listaTecnicos = new ArrayList();
			listaCombos = new ArrayList();
			listaAreas = new ArrayList();
		}
		
		//getters
		public ArrayList ListaClientes
		{ get {return listaClientes;} }
		
		public ArrayList ListaTecnicos
		{ get {return listaTecnicos;} }
		
		public ArrayList ListaCombos
		{ get {return listaCombos;} }
		
		public ArrayList ListaAreas
		{ get {return listaAreas;} }
		
		
		
		//cliente
		public void agregarCliente(Cliente cliente)
		{
			listaClientes.Add(cliente);
		}
		
		public void eliminarCliente(Cliente cliente)
		{
			listaClientes.Remove(cliente);
		}
		
		public void todosClientes()
		{
			foreach (Cliente cli in listaClientes) {
				Console.WriteLine(cli.mostrarCliente());
			}
		}
		
		public int totalClientes()
		{
			return listaClientes.Count;
		}
		
		
		
		//tecnico
		public void agregarTecnico(Tecnico tecnico)
		{
			listaTecnicos.Add(tecnico);
		}
		
		public void eliminarTecnico(Tecnico tecnico)
		{
			listaTecnicos.Remove(tecnico);
		}
		
		public void todosTecnicos()
		{
			foreach (Tecnico tecnico in listaTecnicos) {
				Console.WriteLine(tecnico.mostrarTecnico());
			}
		}
		
		public int totalTecnicos()
		{
			return listaTecnicos.Count;
		}
		
		
		
		//combo
		public void agregarCombo(Combo combo)
		{
			listaCombos.Add(combo);
		}
		
		public void eliminarCombo(Combo combo)
		{
			listaCombos.Remove(combo);
		}
		
		public void todosCombos()
		{
			foreach (Combo combo in listaCombos) {
				Console.WriteLine(combo.mostrarCombo());
			}
		}
		
		public int totalCombos()
		{
			return listaCombos.Count;
		}
		
		
		
		//area
		public void agregarArea(Area area)
		{
			listaAreas.Add(area);
		}
		
		public void eliminarArea(Area area)
		{
			listaAreas.Remove(area);
		}
		
		public void todasAreas()
		{
			foreach (Area area in listaAreas) {
				Console.WriteLine(area.mostrarArea());
			}
		}
		
		public int totalAreas()
		{
			return listaAreas.Count;
		}
	}
}
