
using System;




public abstract class Juego
{
    protected MazoDeCartas mazo;
    protected List<Jugador> jugadores;
    protected bool juegoTerminado;

    protected Juego(List<Jugador> jugadores, MazoDeCartas mazo)
    {
        this.jugadores = jugadores;
        this.mazo = mazo;
        this.juegoTerminado = false;
    }
}
