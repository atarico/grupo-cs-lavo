using System;
using TechInnovate;


public class ProyectoWeb : Proyecto
{
    public string Tecnologia { get; set; }

    public ProyectoWeb(string nombre, EstadoProyecto estado, int cantidadDesarrolladores, DateTime fechaInicio, string tecnologia)
        : base(nombre, estado, cantidadDesarrolladores, fechaInicio)
    {
        Tecnologia = tecnologia;
    }

    public override double CalcularDuracion()
    {
        return CantidadDesarrolladores * 1.5; // Fórmula simple para duración
    }
}
