using Examen_Juego.Juego;
using System;

namespace Examen_Juego.Cartas;

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

public class CartaUno
{

}
