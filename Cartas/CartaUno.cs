
using System;



public enum TipoCarta
{
    Numero,
    Reversa,
    CambioColor,
    MasDos,
    MasCuatro,
    Bloqueo
}

public enum Color
{
    Rojo,
    Verde,
    Amarillo,
    Azul
}

public interface IEfecto
{
    void EjecutarEfecto(IGestorJuegoUno gestor, Color? color);
}

public interface IReglaJuego
{
    bool EsMovimientoValido(CartaUno cartaJugador, CartaUno cartaDescarte, Color? colorActual);
}

//Efectos que tendran las cartas

public class EfectoNulo : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        //Sirve para pasar el turno sin ningún efecto.
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
 // También salta el turno del siguiente jugador al que la usa
    }
}

public class EfectoMasCuatro : IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        gestor.SiguienteJugadorRoba(4);
        gestor.SaltarTurnoSiguiente();
 // hace que el jugador siguiente al que usa la carta coma dos, ya que gestor.SiguienteJugadorRoba,recibe de parametro la cantidad 4
 // También salta el turno del siguiente jugador al que la usa
    }
}

public class CambioColor :IEfecto
{
    public void EjecutarEfecto(IGestorJuegoUno gestor, Color? colorElegido)
    {
        if (colorElegido.HasValue)
        {
            gestor.EstablecerColorActual(colorElegido.Value);
            //Solo se ejecuta si ColorElegido tiene un valor asignado
            //Sirve para cambiar de color por el que eligió el jugador, solo se pueden elegir colores que esten dentro de Color
        }
        else
        {
            Console.WriteLine("Error: Se jugó el Cambio de color, pero no se eligió color");
            //En casa de que el jugador no haya elegido color 
        }
    }
}



public class CartaUno
{
    //minimal implementation
}
