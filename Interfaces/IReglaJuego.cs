using System;


public interface IReglaJuego
{
    bool EsMovimientoValido(CartaUno cartaJugador, CartaUno cartaDescarte, Color? colorActual);
}
