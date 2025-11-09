using System;
using System.Drawing;

namespace Examen_Juego.Juego;

public interface IContextoJugadorUno : IContextoJuego
{
    CartaUno VerCartaDescarte();
    int ObtenerCantidadCartasEnMano ();
    void JugarCartaMesa ();
    Color? ObtenerColor ();
}

public interface IGestorJuegoUno
{
    void InvertirSentido();
    void SaltarTurnoSiguiente();
    void SiguienteJugadorRoba(int cantidad);
    void EstablecerColor(Color color);
}

public class JuegoUno
{

}
