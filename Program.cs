using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualBasic;

namespace Examen_Parcial;

class Program
{
    static void Main(string[] args)
    {

        var MazoBlackJack = FabricaDeMazos.CrearMazoBlackjack();

        var JugadoresBJ = new List<JugadorBlackjack>
        {
            new JugadorCauteloso (1 , "Felipe", 17),
            new JugadorArriesgado (2, "Pepe")
        };

        var DealerBJ = new Dealer(1, "Dealer");

        var JuegoBJ = new JuegoBlackjack(DealerBJ, JugadoresBJ, MazoBlackJack);


         var mazoUno = FabricaDeMazos.CrearMazoUno();

        var jugadoresUno = new List<JugadorUno>
        {
            new JugadorAleatorio(1, "Jugador 1"),
            new JugadorAleatorio(2, "Jugador 2"),
            new JugadorCalculador(3, "Jugador 3")
        };

        var juego = new JuegoUno(jugadoresUno, mazoUno);

        juego.InicializarJuego();

        while (!juego.JuegoTerminado())
        {
            juego.JugarRonda();
        }
        
        juego.MostrarResultados();

    }
}