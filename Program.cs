using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualBasic;

namespace Examen_Parcial;

class Program
{
    static void Main(string[] args)
    {

        


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