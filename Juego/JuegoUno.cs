using System;

namespace Examen_Juego.Juego;

public interface IContextoJuegoUno : IContextoJuego
{
    CartaUno VerCartaDescarte();
    int ObtenerCantidadCartasEnMano ();
    void JugarCartaMesa ();
    Color? ObtenerColor ();
}

public class JuegoUno
{

}
