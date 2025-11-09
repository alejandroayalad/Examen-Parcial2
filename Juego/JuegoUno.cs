using System;




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
    void EstablecerColorActual(Color? color);
}

public class JuegoUno
{


}


