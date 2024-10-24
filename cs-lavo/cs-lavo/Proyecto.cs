using System;

public abstract class Proyecto
{
     public string Nombre { get; set; }
     public EstadoProyecto Estado { get; set; }
     public int CantidadDesarrolladores { get; set; }
     public DateTime FechaInicio { get; set; }

    public Proyecto(string nombre, EstadoProyecto estado, int cantidadDesarrolladores, DateTime fechaInicio)
    {
        Nombre = nombre;
        Estado = estado;
        CantidadDesarrolladores = cantidadDesarrolladores;
        FechaInicio = fechaInicio;
    }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Estado: {Estado}");
        Console.WriteLine($"Cantidad de desarrolladores: {CantidadDesarrolladores}");
        Console.WriteLine($"Fecha de inicio: {FechaInicio.ToShortDateString()}");
    }
}

