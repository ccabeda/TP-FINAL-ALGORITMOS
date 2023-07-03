using System;
using System.Collections;

namespace proyecto
{
	class Program
	{
		public static void Main(string[] args)
		{
			//creo empresa
			Empresa emp = new Empresa();			
			
			//pre cargas
			preCargas(emp);
			
			DateTime fechaActual = DateTime.Now;
			DateTime fechaLimite = new DateTime(2022,12,12);
			int k, maximoOfertas = 5;
			int ultNC = emp.ListaClientes.Count;
			int ultNT = emp.ListaTecnicos.Count;
			bool oferta = false;
			
			while(true)
			try {
				Console.WriteLine("********************************************************");
	            Console.WriteLine("****               Empresa Proveedora               ****");
	            Console.WriteLine("****           de Telefonia Movil y Cable           ****");
	            Console.WriteLine("********************************************************");
	            Console.WriteLine("");
	            Console.WriteLine("¿A que modulo desea ingresar?");
	            Console.WriteLine("");
	            Console.WriteLine("1. Agregar cliente");
	            Console.WriteLine("2. Modificar cantidad de minutos consumidos por cliente");
	            Console.WriteLine("3. Eliminar Cliente");
	            Console.WriteLine("4. Ver tecnico en area especifica");
	            Console.WriteLine("5. Listado de clientes");
	            Console.WriteLine("6. Agregar tecnico");
	            Console.WriteLine("7. Impresion de facturas");
	            Console.WriteLine("8. Listado de tecnicos");
	            Console.WriteLine("9. Salir");
	            k = int.Parse(Console.ReadLine());
	            
	            switch(k)
	            {
	            	case 1:
	            		Console.Clear ();
	          			Console.WriteLine("Ingrese los datos del nuevo cliente");
	            		Console.Write("Nombre: ");
	            		string nombreC = Console.ReadLine();
	            		nombreC = char.ToUpper(nombreC[0]) + nombreC.Substring(1);
	            		Console.Write("Apellido: ");
	            		string apellidoC = Console.ReadLine();
	            		apellidoC = char.ToUpper(apellidoC[0]) + apellidoC.Substring(1);
	            		Console.Write("DNI: ");
	            		int dni = int.Parse(Console.ReadLine());
	
						Console.Clear ();
						
						Combo combo = elegirCombo(emp.ListaCombos);
						
						if (fechaActual < fechaLimite)
						{				
							Console.WriteLine ("");
							Console.WriteLine ("Agregar oferta por tiempo limitado?  s/n");
							Console.WriteLine ("Esta posee el pack futbol y Disney Channel por el mismo precio!");
							Console.WriteLine ("");
							
							while(true)
							{
								string ofertaEleccion = Console.ReadLine();
								
								if(ofertaEleccion == "s")
								{
									oferta = checkOferta(maximoOfertas);
									break;
								}
								else if (ofertaEleccion == "n")
								{
									break;
								}
								Console.WriteLine("Caracter incorrecto, vuelva a intentarlo... (s/n)");
							}
						}
						
						int minutosConsumidos = 0;           
						
	            		Console.Clear();
						Console.Write ("Ingrese el número de su area:");
						Console.WriteLine ("");
						
						Area objArea = mostrarZonas(emp.ListaAreas);				
						bool tecnicoEncontrado = mostrarTecnicos(objArea, emp.ListaTecnicos);
						Tecnico tecnicoElegido;
						
						if (tecnicoEncontrado == false)
						{   
							Console.WriteLine ("");
							Console.WriteLine ("1. Agregar Tecnico");
							Console.WriteLine ("2. Salir");
							Console.WriteLine ("");	
							
							string opcion = Console.ReadLine();
							Console.Clear();
							
							if(opcion=="1")
							{
	          					tecnicoElegido = crearTecnico(emp.ListaTecnicos, emp.ListaAreas, ultNT, objArea);
	          					emp.agregarTecnico(tecnicoElegido);
							}	
							else
							{
								break;
							}
						}
						else
						{
							tecnicoElegido = elegirTecnico(objArea, emp.ListaTecnicos);
						}
						
						Console.Clear();
	                    Console.WriteLine("Fecha de alta del cliente");
	            		Console.Write("Dia: ");
	            		int dia = int.Parse(Console.ReadLine());
	            		Console.Write("Mes (numero): ");
	            		int mes = int.Parse(Console.ReadLine());
	            		Console.Write("Año: ");
	            		int año = int.Parse(Console.ReadLine());
	            		DateTime fechaAlta = new DateTime (año, mes, dia);
	            		
	            		//creo un cliente y lo agrego a listaClientes
	            		Cliente cliente = new Cliente();
	            		cliente.NroCliente = ultNC+1;
	            		cliente.Nombre = nombreC;
	            		cliente.Apellido = apellidoC;
	            		cliente.Dni = dni;
	            		cliente.MinutosConsumidos = minutosConsumidos;
	            		cliente.FechaAlta = fechaAlta;
	            		cliente.PlanVigente = combo;
	            		cliente.Oferta = oferta;
	            		cliente.TecnicoAsignado = tecnicoElegido;
	            		emp.agregarCliente(cliente);
	            		ultNC++;
	            		
	            		Console.WriteLine ("El cliente fue creado exitosamente.");
	            		Console.WriteLine ("");
						Console.WriteLine ("Continuar...");
						Console.ReadKey ();
						Console.Clear();
	            		break;
	            		
        			case 2:
	            		if (emp.totalClientes() != 0)
	            		{
	            			Console.Clear();
	            			Console.WriteLine("Ingrese Nº de cliente a cambiar los minutos consumidos:");
	            			Cliente cliCMinutos = elegirCliente(emp.ListaClientes);
	            			cliCMinutos.MinutosConsumidos = cambiarMinutosConsumidos(cliCMinutos);
	            			break;
	            		}
	            		else
	            		{
	            			Console.Clear();
							Console.WriteLine("No se encontraron clientes.");
							Console.WriteLine ("");
							Console.WriteLine ("Continuar...");
							Console.ReadKey();
							Console.Clear();
		            		break;
	            		}
	            		
	            	case 3:
	            		if (emp.totalClientes() != 0) 
	            		{
	            			Console.Clear ();
							Console.Write ("Ingrese numero de cliente a eliminar:");
							Console.WriteLine ("");
							Cliente cliAEliminar = elegirCliente(emp.ListaClientes);
							
							string nombreCE = cliAEliminar.Nombre + " " + cliAEliminar.Apellido;
							emp.eliminarCliente(cliAEliminar);
							Console.WriteLine("Cliente " + nombreCE + " eliminado con exito.");
							Console.ReadKey();
							Console.Clear();
		
							break;
	            
	            		}
	            		else
	            		{
	            			Console.Clear();
							Console.WriteLine("No se encontraron clientes.");
							Console.WriteLine ("");
							Console.WriteLine ("Continuar...");
							Console.ReadKey();
							Console.Clear();
		            		break;
	            		}
	            		
	            		
	            	 case 4:
	            		Console.Clear ();
						Console.WriteLine ("Listado de areas");
						Console.WriteLine ("");
						
						Area zonareas = mostrarZonas(emp.ListaAreas);
						mostrarTecnicos(zonareas, emp.ListaTecnicos);
						
						Console.WriteLine ("");
						Console.WriteLine ("Continuar...");
						Console.ReadKey ();
						Console.Clear();
						break;
					
					case 5:
						listadoClientes(emp.ListaClientes);
						break;
						
					case 6:
						Tecnico tec = crearTecnico(emp.ListaTecnicos, emp.ListaAreas, ultNT);
						emp.agregarTecnico(tec);
						break;
						
					case 7:
						if (emp.totalClientes() != 0)
	            		{
	            			verFactura(emp.ListaClientes, fechaActual);
						break;
	            		}
	            		else
	            		{
	            			Console.Clear();
							Console.WriteLine("No se encontraron clientes.");
							Console.WriteLine ("");
							Console.WriteLine ("Continuar...");
							Console.ReadKey();
							Console.Clear();
		            		break;
	            		}
	            		
	            	case 8:
	            		Console.Clear ();
	            		if (emp.totalTecnicos() != 0)
	            		{
							Console.WriteLine ("Listado de tecnicos");
							Console.WriteLine ("");
							emp.todosTecnicos();
	            		}
	            		else
	            		{
	            			Console.Clear();
							Console.WriteLine("No se encontraron tecnicos.");
							Console.WriteLine ("");
	            		}
						Console.WriteLine ("");
						Console.WriteLine ("Continuar...");
						Console.ReadKey ();
						Console.Clear();
						break;

	            		
	            	default:
	            		Console.Clear ();
	                    Console.WriteLine("Opcion invalida, por favor ingrese nuevamente...");
						Console.ReadKey ();
						Console.Clear();
	                    break;
            		
	            }
	            
	            
				
			} catch (Exception ex) {
				Console.Clear();
				Console.WriteLine ("*********************************************************");
				Console.WriteLine ("Error: " + ex.Message);
				Console.WriteLine ("*********************************************************");
				Console.WriteLine ("");
				Console.WriteLine ("Continuar...");
				Console.ReadKey();
				Console.Clear();
			}
		}
		
		//funciones de clientes
		public static void listadoClientes(ArrayList listaClientes)
		{
			Console.Clear();
			Console.WriteLine ("Listado de clientes");
			foreach (Cliente cli in listaClientes) {
				Console.WriteLine (cli.mostrarCliente());
			}
			
			while(true)
			{
				int nroCliente = int.Parse(Console.ReadLine());
				
				foreach (Cliente cli in listaClientes) {
					if(nroCliente == cli.NroCliente)
					{
						Console.Clear();
						Console.WriteLine("Datos del cliente");
						Console.WriteLine("");
						Console.WriteLine("Numero: " + cli.NroCliente);
						Console.WriteLine("Nombre: " + cli.Nombre);
						Console.WriteLine("Apellido: " + cli.Apellido);
						Console.WriteLine("DNI: " + cli.Dni);
						Console.WriteLine("");
						Console.WriteLine("Plan vigente");
						Console.WriteLine("Numero: " + cli.PlanVigente.NumeroCombo);
						Console.WriteLine("Precio: $" + cli.PlanVigente.Precio);
						Console.WriteLine("Minutos disponibles: " + cli.PlanVigente.Minutos);
						Console.WriteLine("Minutos consumidos: " + cli.MinutosConsumidos);
						Console.WriteLine("Tecnico asignado: " + cli.TecnicoAsignado.Nombre + " " + cli.TecnicoAsignado.Apellido);
						Console.WriteLine("");
						Console.WriteLine("Continuar...");
						Console.ReadKey();
						Console.Clear();
						return;
					}
				}
				Console.WriteLine("Cliente no encontrado, intente nuevamente.");
			}
		}
		
		
		
		public static Cliente elegirCliente(ArrayList listaClientes)
		{
			foreach (Cliente cli in listaClientes) {
				Console.WriteLine(cli.mostrarCliente());
			}
			
			while(true)
			{
				int numeroCliente = int.Parse(Console.ReadLine ());
				
				if(numeroCliente != 0)
				{
					foreach (Cliente c in listaClientes) 
					{
						if(numeroCliente == c.NroCliente)
						{
							return c;
						}
					}
				}
				Console.WriteLine("Cliente no encontrado, vuelva a intentarlo... ");
			}
		}
		
		
		public static int cambiarMinutosConsumidos (Cliente cli)
		{
			Console.Clear();
			int minutos = 0;
			Console.Write("Ingrese los minutos consumidos por " + cli.Nombre + " " + cli.Apellido +": ");
			
			while(true)
			{
				minutos = int.Parse(Console.ReadLine());
				
				if(minutos < cli.PlanVigente.Minutos)
				{
					cli.MinutosConsumidos = minutos;
					Console.WriteLine("Minutos consumidos de " + cli.Nombre + " " + cli.Apellido +" actualizados a " + cli.MinutosConsumidos + " con exito.");
					Console.WriteLine("");
					Console.WriteLine("Continuar...");
					Console.WriteLine("");
					Console.ReadKey();
					Console.Clear();
					return minutos;
				}	
				else
				{
					Console.Write("El combo de " + cli.Nombre + " " + cli.Apellido +" no puede superar los " + cli.PlanVigente.Minutos + " minutos, intente nuevamente: ");					
				}		
			}
		}
		
		
		public static void verFactura (ArrayList listaClientes, DateTime fecha)
		{
			Console.Clear ();
			Console.WriteLine ("Ver factura de Cliente:");
			Console.WriteLine ("");
			
			foreach (Cliente cli in listaClientes) {
				Console.WriteLine (cli.mostrarCliente());
			}
			
			Cliente cliente = null;
			bool existe = false;
			
			while(!existe)
			{
				int nroCliente = int.Parse(Console.ReadLine ());
				
				foreach (Cliente a in listaClientes) 
				{	
					if(nroCliente == a.NroCliente)
					{
						cliente = a;
						existe=true;
						break;
					}
				}
				Console.WriteLine("Cliente inexistente, por favor ingrese un numero valido.");
			}
			
			bool promocion = false;
					
			if( (cliente.PlanVigente.Minutos * 0.85) >= cliente.MinutosConsumidos)
			{
				promocion = true;	
			}
			
			Console.Clear();
			Console.WriteLine("================================================================");
			Console.WriteLine("                           * FACTURA *                          ");
			Console.WriteLine("================================================================");
			Console.WriteLine("");
			Console.WriteLine("Nombre: " + cliente.Nombre + " " + cliente.Apellido);
			Console.WriteLine("Apellido: " + cliente.Apellido);
			Console.WriteLine("DNI: " + cliente.Dni);
			Console.WriteLine("Fecha: " + fecha);
			Console.WriteLine("");
			Console.WriteLine("================================================================");
			Console.WriteLine("");
			if(promocion == true)
			{
				Console.WriteLine("Plan de " + cliente.PlanVigente.Minutos + " minutos: $" + cliente.PlanVigente.Precio + ".00");
				if(cliente.Oferta == true)
				{
					Console.WriteLine("Combo PLUS: $0.00");
				}
				Console.WriteLine("Descuento: $" + (cliente.PlanVigente.Precio * 0.15) + ".00");
				Console.WriteLine("");
				Console.WriteLine("================================================================");
				Console.WriteLine("");
				Console.WriteLine("Precio total: $" + (cliente.PlanVigente.Precio * 0.85) + ".00");
				
			}
			else
			{
				Console.WriteLine("Plan de " + cliente.PlanVigente.Minutos + " minutos: $" + cliente.PlanVigente.Precio);
				if(cliente.Oferta == true)
				{
					Console.WriteLine("Combo PLUS: $0.00");
				}
				Console.WriteLine("");
				Console.WriteLine("================================================================");
				Console.WriteLine("");
				Console.WriteLine("Precio total: $" + cliente.PlanVigente.Precio);
			}
			
			Console.ReadKey();
			Console.Clear();
		}
		
		
		//funciones de tecnicos
		public static bool mostrarTecnicos(Area objeto, ArrayList listaTecnicos)
		{
			bool tecnicoEncontrado = false;
			Console.Clear();
			
			foreach (Tecnico tec in listaTecnicos) 
			{			
				if(tec.Area.CodigoArea == objeto.CodigoArea)
				{			
					Console.WriteLine ("Tecnicos disponibles en "+ objeto.NombreArea + ": ");
					Console.WriteLine ("");
					Console.WriteLine (tec.CodigoTecnico + ": " + tec.Nombre + " " + tec.Apellido + ".");
					tecnicoEncontrado = true;
					return tecnicoEncontrado;
				}			
			}
			Console.WriteLine("No se encontraron tecnicos en " + objeto.NombreArea);
			return tecnicoEncontrado;
		}
		
		public static Tecnico elegirTecnico(Area objeto, ArrayList listaTecnicos) 
		{
			int CodigoTecnico = int.Parse(Console.ReadLine ());
			
			while(true)
			{
				foreach (Tecnico a in listaTecnicos)
				{			
					if(CodigoTecnico == a.CodigoTecnico & objeto == a.Area)
					{
						return a;
					}				
				}
			}	
		}
		
		public static Tecnico crearTecnico( ArrayList listaTecnicos, ArrayList listaAreas, int ultNT, Area area = null)
		{				
			Console.Clear ();
      		Console.WriteLine("Ingrese los datos del nuevo tecnico");
        	Console.Write("Nombre: ");
        	string nombreT = Console.ReadLine();
        	nombreT = char.ToUpper(nombreT[0]) + nombreT.Substring(1);
        	Console.Write("Apellido: ");
        	string apellidoT = Console.ReadLine();
        	nombreT = char.ToUpper(nombreT[0]) + nombreT.Substring(1);
        	
        	if(area == null)
        	{
	        	Console.WriteLine("");
	        	Console.WriteLine("Seleccione un area...");
	        	area = mostrarZonas(listaAreas);
        	}
        	
        	Tecnico tecnico = new Tecnico();
        	tecnico.Nombre = nombreT;
        	tecnico.Apellido = apellidoT;
        	tecnico.CodigoTecnico = ultNT+1;
        	tecnico.Area = area;
        	ultNT++;
        	
        		
        	Console.WriteLine ("El tecnico fue creado exitosamente.");
        	Console.WriteLine ("");
			Console.WriteLine ("Continuar...");
			Console.ReadKey ();
			Console.Clear();
			
			return tecnico;
		}
		
		//funciones de combos
		public static Combo elegirCombo(ArrayList listaCombos)
		{
			Console.WriteLine ("Los combos incluyen provisión de cable HD básica con 121 canales");
			Console.WriteLine ("");
			Console.WriteLine ("Ingrese el numero del combo que desee");
			Console.WriteLine ("");
			foreach (Combo com in listaCombos) 
			{
				Console.WriteLine (com.mostrarCombo());
			}
			
			while(true)
			{
				int numeroCombo = int.Parse(Console.ReadLine ());
						
				if(numeroCombo == 1 | numeroCombo == 2 | numeroCombo == 3 | numeroCombo == 4)
				{
					foreach (Combo a in listaCombos) 
					{
						if(numeroCombo == a.NumeroCombo)
						{
							return a;
						}
					}
				}
				Console.WriteLine("Caracter incorrecto, vuelva a intentarlo... ");
			}
		}
		
		//funciones de areas
		public static Area mostrarZonas(ArrayList listaAreas)
		{
			foreach (Area zona in listaAreas) 
			{
				Console.WriteLine (zona.CodigoArea +": "+ zona.NombreArea);			
			}
			
			while(true)
			{
				int CodigoArea = int.Parse(Console.ReadLine ());
				
				foreach (Area a in listaAreas) 
				{	
					if(CodigoArea == a.CodigoArea)
					{
						return a;
					}
				}
				Console.WriteLine("Area no encontrada, por favor ingrese un numero valido.");
			}
		}
		
		//oferta
		public static bool checkOferta(int maximoOfertas)
		{
			bool oferta = false;
			if(1 <= maximoOfertas)
			{
				oferta = true;
				maximoOfertas--;
				Console.WriteLine("Combo PLUS añadido con exito!");
			}
			else
			{
				Console.WriteLine("Cupo insuficiente.");
				Console.WriteLine("");
				Console.WriteLine("Se te asignara el combo estandar.");
			}
			return oferta;
		}
		
		//pre cargas
		public static void preCargas(Empresa emp)
		{
			//crea las areas
			Area area1 = new Area (1,"Quilmes");
			Area area2 = new Area (2,"Berazategui");
			Area area3 = new Area (3,"Varela");
			Area area4 = new Area (4,"Avellaneda");

			//agrega las areas a la listaAreas
			emp.agregarArea(area1);
			emp.agregarArea(area2);
			emp.agregarArea(area3);
			emp.agregarArea(area4);

			//crea los tecnicos
			Tecnico tecnico1 = new Tecnico ();
			Tecnico tecnico2 = new Tecnico ();

			//carga los datos de los tecnicos
			tecnico1.CodigoTecnico = 1;
			tecnico1.Nombre = "Alan";
			tecnico1.Apellido = "Varela";
			tecnico1.Area = area1;
				
			tecnico2.CodigoTecnico = 2;
			tecnico2.Nombre = "Aaron";
			tecnico2.Apellido = "Molinas";
			tecnico2.Area = area2;
		

			//agrega los tecnicos a la listaTecnicos
			emp.agregarTecnico(tecnico1);
			emp.agregarTecnico(tecnico2);
			
			//***********************************************************************
			
			//crea los combos
			Combo combo1 = new Combo (1);
			Combo combo2 = new Combo (2);
			Combo combo3 = new Combo (3);
			Combo combo4 = new Combo (4);
			
			//minutos del combo
			combo1.Minutos = 15000;
			combo2.Minutos = 20000;
			combo3.Minutos = 25000;
			combo4.Minutos = 30000;
			
			//precio del combo por mes
			combo1.Precio = 1000;
			combo2.Precio = 1300;
			combo3.Precio = 1700;
			combo4.Precio = 12000;
			
			
			//agrego los combos a listaCombos
			emp.agregarCombo(combo1);
			emp.agregarCombo(combo2);
			emp.agregarCombo(combo3);
			emp.agregarCombo(combo4);
			
			//***********************************************************************
			
			//creo los clientes
			Cliente cliente1 = new Cliente();
			Cliente cliente2 = new Cliente();
			
			//carga los datos de los clientes
			DateTime fecha = new DateTime (2023, 01, 01);
			cliente1.NroCliente = 1;
			cliente1.Nombre = "Marcos";
			cliente1.Apellido = "Rojo";
			cliente1.Dni = 34946913;
			cliente1.FechaAlta = fecha;
			cliente1.Oferta = true;
			cliente1.PlanVigente = combo1;
			cliente1.MinutosConsumidos = 1000;
			cliente1.TecnicoAsignado = tecnico2;
			
			
			cliente2.NroCliente = 2;
			cliente2.Nombre = "Dario";
			cliente2.Apellido = "Benedetto";
			cliente2.Dni = 34956747;
			cliente2.FechaAlta = fecha;
			cliente2.Oferta = false;
			cliente2.PlanVigente = combo2;
			cliente2.MinutosConsumidos = 16000;
			cliente2.TecnicoAsignado = tecnico1;
			
			//agrego los clientes a listaClientes
			emp.agregarCliente(cliente1);
			emp.agregarCliente(cliente2);
		}
		
		
	}
}