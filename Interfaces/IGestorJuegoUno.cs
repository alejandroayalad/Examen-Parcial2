using System;



public interface IGestorJuegoUno
{
    void InvertirSentido();
    void SaltarTurnoSiguiente();
    void SiguienteJugadorRoba(int cantidad);
    void EstablecerColorActual(Color color);
}
