using Logica;
using Objetos;
using Obligatorio.Datos;
using Obligatorio2025.Objetos;
using System;
using System.Collections.Generic;


namespace Obligatorio2025.Presentacion
{
    public class Principal
    {
        static LogicaClientes cliente = new LogicaClientes();
        static LogicaProyecto proyecto = new LogicaProyecto();

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("            GESTION PRINCIPAL");
                    Console.WriteLine();
                    Console.WriteLine("1. Gestión de Clientes");
                    Console.WriteLine("2. Gestión de Proyectos");
                    Console.WriteLine("0. Salir");
                    Console.Write("\nSeleccione una opción: ");

                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuProyectos();
                            break;
                        case 0:
                            Console.WriteLine("\nSaliendo...");
                            break;
                        default:
                            Console.WriteLine("\nOpción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

       

        static void MenuClientes()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("         GESTIÓN DE CLIENTES");
                Console.WriteLine();
                Console.WriteLine("1. Listar clientes");
                Console.WriteLine("2. Agregar cliente");
                Console.WriteLine("3. Modificar cliente");
                Console.WriteLine("4. Eliminar cliente");
                Console.WriteLine("0. Volver");
                Console.Write("\nSeleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            ListarClientes();
                            break;
                        case 2:
                            AgregarCliente();
                            break;
                        case 3:
                            ModificarCliente();
                            break;
                        case 4:
                            EliminarCliente();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("\nOpción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("               LISTADO DE CLIENTES\n");

            List<Cliente> clientes = cliente.ListarClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados.");
            }
            else
            {
                foreach (Cliente item in clientes)
                {
                    Console.WriteLine($"ID: {item.IdCliente}");
                    Console.WriteLine($"Razón Social: {item.RazonSocial}");
                    Console.WriteLine($"RUT: {item.RUT}");
                    Console.WriteLine($"Dirección: {item.Direccion}");
                    Console.WriteLine("-------------------------------");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void AgregarCliente()
        {
            Console.Clear();
            Console.WriteLine("               AGREGAR CLIENTE\n");

            Console.Write("Razón Social: ");
            string razonSocial = Console.ReadLine();

            Console.Write("RUT: ");
            string rut = Console.ReadLine();

            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();

            Cliente nuevoCliente = new Cliente(razonSocial, rut, direccion);

            cliente.IngresarClientes(nuevoCliente);

            Console.WriteLine("\nCliente agregado exitosamente!");
            Console.ReadKey();
        }

        static void ModificarCliente()
        {
            Console.Clear();
            Console.WriteLine("               MODIFICAR CLIENTE\n");

            Console.Write("ID del cliente a modificar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente encontrado = cliente.BuscarCliente(id);

            if (encontrado == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nDatos actuales:");
            Console.WriteLine($"Razón Social: {encontrado.RazonSocial}");
            Console.WriteLine($"RUT: {encontrado.RUT}");
            Console.WriteLine($"Dirección: {encontrado.Direccion}");

            Console.Write("\nNueva Razón Social (Enter para dejar igual): ");
            string nuevaRazon = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaRazon))
                encontrado.RazonSocial = nuevaRazon;

            Console.Write("Nuevo RUT (Enter para dejar igual): ");
            string nuevoRUT = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoRUT))
                encontrado.RUT = nuevoRUT;

            Console.Write("Nueva Dirección (Enter para dejar igual): ");
            string nuevaDireccion = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDireccion))
                encontrado.Direccion = nuevaDireccion;

            cliente.ModificarClientes(encontrado);

            Console.WriteLine("\nCliente modificado exitosamente!");
            Console.ReadKey();
        }

        static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("               ELIMINAR CLIENTE\n");

            Console.Write("ID del cliente a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Cliente encontrado = cliente.BuscarCliente(id);

            if (encontrado == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nCliente: {encontrado.RazonSocial}");
            Console.Write("¿Confirmar eliminación? (S/N): ");
            string confirmacion = Console.ReadLine().ToUpper();

            if (confirmacion == "S")
            {
                cliente.EliminarCliente(id);
                Console.WriteLine("\nCliente eliminado exitosamente!");
            }
            else
            {
                Console.WriteLine("\nOperación cancelada.");
            }

            Console.ReadKey();
        }

        

        static void MenuProyectos()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("         GESTIÓN DE PROYECTOS");
                Console.WriteLine();
                Console.WriteLine("1. Listar proyectos");
                Console.WriteLine("2. Agregar proyecto");
                Console.WriteLine("3. Eliminar proyecto");
                Console.WriteLine("0. Volver");
                Console.Write("\nSeleccione una opción: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            ListarProyectos();
                            break;
                        case 2:
                            AgregarProyecto();
                            break;
                        case 3:
                            EliminarProyecto();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("\nOpción inválida");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static void ListarProyectos()
        {
            Console.Clear();
            Console.WriteLine("               LISTADO DE PROYECTOS\n");

            List<Proyecto> proyectos = proyecto.ListarProyecto();

            if (proyectos.Count == 0)
            {
                Console.WriteLine("No hay proyectos registrados.");
            }
            else
            {
                foreach (Proyecto p in proyectos)
                {
                    Console.WriteLine($"ID: {p.Id}");
                    Console.WriteLine($"Cliente ID: {p.IdCliente}");
                    Console.WriteLine($"Nombre: {p.NombreProyecto}");
                    Console.WriteLine($"Tipo: {p.Tipo}");
                    Console.WriteLine($"Presupuesto: {p.PresupuestoInicial}");
                    Console.WriteLine($"Fecha Inicio: {p.FechaInicio:dd/MM/yyyy}");
                    Console.WriteLine($"Estado: {p.Estado}");
                    Console.WriteLine("-------------------------------");
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void AgregarProyecto()
        {
            Console.Clear();
            Console.WriteLine("               AGREGAR PROYECTO\n");

            Console.Write("ID Cliente: ");
            int idCliente = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nombre del proyecto: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("\nTipos de proyecto:");
            foreach (var t in Enum.GetValues(typeof(EnumeradosProyecto.TipoProyecto)))
                Console.WriteLine($"- {t}");

            Console.Write("Seleccione tipo: ");
            EnumeradosProyecto.TipoProyecto tipo = (EnumeradosProyecto.TipoProyecto)Enum.Parse(typeof(EnumeradosProyecto.TipoProyecto), Console.ReadLine(), true);

            Console.Write("Presupuesto inicial: ");
            double presupuesto = Convert.ToDouble(Console.ReadLine());

            Console.Write("Fecha inicio (AAAA-MM-DD): ");
            DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

            Proyecto nuevo = new Proyecto(idCliente, nombre, tipo, presupuesto, fechaInicio);

            proyecto.AgregarProyecto(nuevo);

            Console.WriteLine("\nProyecto agregado exitosamente!");
            Console.ReadKey();
        }

        static void EliminarProyecto()
        {
            Console.Clear();
            Console.WriteLine("               ELIMINAR PROYECTO\n");

            Console.Write("ID proyecto a eliminar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            proyecto.EliminarProyecto(id);

            Console.WriteLine("\nProyecto eliminado exitosamente!");
            Console.ReadKey();
        }
    }
}
