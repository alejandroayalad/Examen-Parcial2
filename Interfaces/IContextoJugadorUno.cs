using System;

public interface IContextoJugadorUno : IContextoJuego
{
    CartaUno VerCartaDescarte();
    int ObtenerCantidadDeCartasEnMano();
    void JugarCartaEnMesa (ICarta carta, Color? nuevoColor = null);
    Color? ObtenerColor ();
}
