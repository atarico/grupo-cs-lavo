using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Proyecto> proyectos = new List<Proyecto>();
    const string archivoProyectos = "proyectos.txt"; // Nombre del archivo para guardar los proyectos

    static void Main(string[] args)
    {
        MostrarMenu();
    }

    static void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("1. Agregar Proyecto");
            Console.WriteLine("2. Mostrar Proyectos");
            Console.WriteLine("3. Editar Proyecto");
            Console.WriteLine("4. Eliminar Proyecto");
            Console.WriteLine("5. Guardar Proyectos en Archivo");
            Console.WriteLine("6. Cargar Proyectos desde Archivo");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProyecto(); // Agregar proyectos nuevos
                    break;
                case 2:
                    MostrarProyectos(); // Mostrar proyectos creados
                    break;
                case 3:
                    EditarProyecto(); // Editar proyecto por nombre
                    break;
                case 4:
                    EliminarProyecto(); // Eliminar proyecto por nombre
                    break;
                case 5:
                    GuardarProyectos(); // Guardar proyectos en archivo
                    break;
                case 6:
                    CargarProyectos(); // Cargar proyectos desde archivo
                    break;
            }
        } while (opcion != 7);
    }

    static void AgregarProyecto()
    {
        Console.Write("Ingrese el nombre del proyecto: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Estado del proyecto (0: Planificacion, 1: En Desarrollo, 2: En Pruebas, 3: Completado, 4: Cancelado): ");
        EstadoProyecto estado = (EstadoProyecto)int.Parse(Console.ReadLine());

        Console.Write("Cantidad de desarrolladores: ");
        int desarrolladores = int.Parse(Console.ReadLine());

        Console.Write("Fecha de inicio (dd/mm/yyyy): ");
        DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Tipo de Proyecto (1: Web, 2: Móvil): ");
        int tipo = int.Parse(Console.ReadLine());

        if (tipo == 1)
        {
            Console.Write("Tecnología principal: ");
            string tecnologia = Console.ReadLine();
            proyectos.Add(new ProyectoWeb(nombre, estado, desarrolladores, fechaInicio, tecnologia));
        }
        else if (tipo == 2)
        {
            Console.Write("Plataforma objetivo: ");
            string plataforma = Console.ReadLine();
            proyectos.Add(new ProyectoMovil(nombre, estado, desarrolladores, fechaInicio, plataforma));
        }
    }

    static void MostrarProyectos()
    {
        foreach (var proyecto in proyectos)
        {
            Console.WriteLine($"Nombre: {proyecto.Nombre}, Estado: {proyecto.Estado}, Desarrolladores: {proyecto.CantidadDesarrolladores}, Fecha de Inicio: {proyecto.FechaInicio}, Duración estimada: {proyecto.CalcularDuracion()} meses");
        }
    }

    static void EditarProyecto()
    {
        Console.Write("Ingrese el nombre del proyecto que desea editar: ");
        string nombre = Console.ReadLine();
        Proyecto proyecto = BuscarProyectoPorNombre(nombre);

        if (proyecto != null)
        {
            Console.Write("Nuevo nombre del proyecto (deje vacío para no cambiar): ");
            string nuevoNombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                proyecto.Nombre = nuevoNombre;
            }

            Console.WriteLine("Nuevo estado del proyecto (0: Planificacion, 1: En Desarrollo, 2: En Pruebas, 3: Completado, 4: Cancelado, deje vacío para no cambiar): ");
            string estadoInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(estadoInput))
            {
                proyecto.Estado = (EstadoProyecto)int.Parse(estadoInput);
            }

            Console.Write("Nueva cantidad de desarrolladores (deje vacío para no cambiar): ");
            string desarrolladoresInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(desarrolladoresInput))
            {
                proyecto.CantidadDesarrolladores = int.Parse(desarrolladoresInput);
            }

            Console.Write("Nueva fecha de inicio (dd/mm/yyyy, deje vacío para no cambiar): ");
            string fechaInicioInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(fechaInicioInput))
            {
                proyecto.FechaInicio = DateTime.Parse(fechaInicioInput);
            }

            if (proyecto is ProyectoWeb proyectoWeb)
            {
                Console.Write("Nueva tecnología principal (deje vacío para no cambiar): ");
                string nuevaTecnologia = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaTecnologia))
                {
                    proyectoWeb.Tecnologia = nuevaTecnologia;
                }
            }
            else if (proyecto is ProyectoMovil proyectoMovil)
            {
                Console.Write("Nueva plataforma objetivo (deje vacío para no cambiar): ");
                string nuevaPlataforma = Console.ReadLine();
                if (!string.IsNullOrEmpty(nuevaPlataforma))
                {
                    proyectoMovil.Plataforma = nuevaPlataforma;
                }
            }

            Console.WriteLine("El proyecto ha sido actualizado.");
        }
        else
        {
            Console.WriteLine("No se encontró un proyecto con ese nombre.");
        }
    }

    static void EliminarProyecto()
    {
        Console.Write("Ingrese el nombre del proyecto que desea eliminar: ");
        string nombre = Console.ReadLine();
        Proyecto proyecto = BuscarProyectoPorNombre(nombre);

        if (proyecto != null)
        {
            proyectos.Remove(proyecto);
            Console.WriteLine("El proyecto ha sido eliminado.");
        }
        else
        {
            Console.WriteLine("No se encontró un proyecto con ese nombre.");
        }
    }

    static Proyecto BuscarProyectoPorNombre(string nombre)
    {
        foreach (var proyecto in proyectos)
        {
            if (proyecto.Nombre == nombre)
            {
                return proyecto;
            }
        }
        return null;
    }

    // Función para guardar los proyectos en un archivo de texto
    static void GuardarProyectos()
    {
        using (StreamWriter writer = new StreamWriter(archivoProyectos))
        {
            foreach (var proyecto in proyectos)
            {
                if (proyecto is ProyectoWeb proyectoWeb)
                {
                    writer.WriteLine($"Web,{proyecto.Nombre},{proyecto.Estado},{proyecto.CantidadDesarrolladores},{proyecto.FechaInicio},{proyectoWeb.Tecnologia}");
                }
                else if (proyecto is ProyectoMovil proyectoMovil)
                {
                    writer.WriteLine($"Movil,{proyecto.Nombre},{proyecto.Estado},{proyecto.CantidadDesarrolladores},{proyecto.FechaInicio},{proyectoMovil.Plataforma}");
                }
            }
        }
        Console.WriteLine("Los proyectos se han guardado correctamente.");
    }

    // Función para cargar los proyectos desde un archivo de texto
    static void CargarProyectos()
    {
        if (File.Exists(archivoProyectos))
        {
            using (StreamReader reader = new StreamReader(archivoProyectos))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    string[] datos = linea.Split(',');
                    string tipo = datos[0];
                    string nombre = datos[1];
                    EstadoProyecto estado = (EstadoProyecto)Enum.Parse(typeof(EstadoProyecto), datos[2]);
                    int desarrolladores = int.Parse(datos[3]);
                    DateTime fechaInicio = DateTime.Parse(datos[4]);

                    if (tipo == "Web")
                    {
                        string tecnologia = datos[5];
                        proyectos.Add(new ProyectoWeb(nombre, estado, desarrolladores, fechaInicio, tecnologia));
                    }
                    else if (tipo == "Movil")
                    {
                        string plataforma = datos[5];
                        proyectos.Add(new ProyectoMovil(nombre, estado, desarrolladores, fechaInicio, plataforma));
                    }
                }
            }
            Console.WriteLine("Los proyectos se han cargado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró un archivo de proyectos. Iniciando con una lista vacía.");
        }
    }
}
