using System;

namespace Examen_Juego.Cartas;

public class EfectoNulo : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        //Sirve para pasar el turno sin ning�n efecto.
    }
}

public class EfectoInvertirSentido : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        gestor.InvertirSentido();
        // Sirve para invertir el sentido los turnos en el juego
    }
}

public class EfectoBloqueo : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        gestor.SaltarTurnoSiguiente();
        // Sirve para saltar el turno de un jugador
    }
}

public class EfectoMasDos : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        gestor.SiguienteJugadorRoba(2);
        gestor.SaltarTurnoSiguiente();
 // hace que el jugador siguiente al que usa la carta coma dos, ya que gestor.SiguienteJugadorRoba,recibe de parametro la cantidad 2
 // Tambi�n salta el turno del siguiente jugador al que la usa
    }
}

public class EfectoMasCuatro : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        gestor.SiguienteJugadorRoba(4);
        gestor.SaltarTurnoSiguiente();
 // hace que el jugador siguiente al que usa la carta coma dos, ya que gestor.SiguienteJugadorRoba,recibe de parametro la cantidad 4
 // Tambi�n salta el turno del siguiente jugador al que la usa
    }
}

public class EfectoCambioColor : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        if (colorElegido.HasValue)
        {
            gestor.EstablecerColorActual(colorElegido.Value);
            //Solo se ejecuta si ColorElegido tiene un valor asignado
            //Sirve para cambiar de color por el que eligio el jugador, solo se pueden elegir colores que esten dentro de Color
        }
        else
        {
            Console.WriteLine("Error: Se jug� el Cambio de color, pero no se eligi� color");
            //En casa de que el jugador no haya elegido color 
        }
    }
}
