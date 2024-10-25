using System;
using TechInnovate;


public class ProyectoMovil : Proyecto
{
    public string Plataforma { get; set; }

    public ProyectoMovil(string nombre, EstadoProyecto estado, int cantidadDesarrolladores, DateTime fechaInicio, string plataforma)
        : base(nombre, estado, cantidadDesarrolladores, fechaInicio)
    {
        Plataforma = plataforma;
    }

    public override double CalcularDuracion()
    {
        return CantidadDesarrolladores * 2.0; // Fórmula simple para duración
    }
}
