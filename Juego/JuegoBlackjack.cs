using System;
using System.Collections;
using System.Collections.Generic;
public class JuegoBlackjack : Juego, IContextoBlackjack
{

    private Dealer dealer;
    private List<JugadorBlackjack> jugadoresBlackjack;

    public JuegoBlackjack(Dealer dealer, List<JugadorBlackjack> jugadores, MazoDeCartas mazo) : base(jugadores.Cast<Jugador>().ToList(), mazo)
    {
        this.dealer = dealer;
        this.jugadoresBlackjack = jugadores;

    }

    public override void InicializarJuego()
    {
        Console.WriteLine("\n INICIANDO JUEGO DE BLACKJACK \n");

        // Limpiar manos de la ronda anterior
        dealer.LimpiarMano();

        foreach (var jugador in jugadoresBlackjack)
        {
            jugador.LimpiarMano();
        }


        dealer.RepartirRonda(mazo, jugadores.Cast<JugadorBlackjack>().ToList());

        Console.WriteLine("\n--- Estado inicial ---");
        dealer.MostrarEstado();
        foreach (var jugador in jugadoresBlackjack)
        {
            jugador.MostrarEstado();

            Console.WriteLine($"Puntaje: {jugador.ObtenerPuntajeMano()}");
        }

        juegoTerminado = false;
    }


    public override void JugarRonda()
    {
        Console.WriteLine("\n--- TURNOS DE JUGADORES---");

        foreach (var jugador in jugadoresBlackjack)
        {

            if (!jugador.SePasoDe21())
            {
                jugador.JugarTurno(this);
                Console.WriteLine($"Puntaje final de {jugador.Nombre}: {jugador.ObtenerPuntajeMano()}");
            }
        }


        Console.WriteLine("\n--- TURNO DEL DEALER---");
        dealer.JugarTurno(this);
        Console.WriteLine($"Puntaje final del dealer: {dealer.ObtenerPuntajeMano()}");

        juegoTerminado = true;
    }


    public int ObtenerPuntuajeDealer()
    {
        throw new NotImplementedException();
    }

    public ICarta RobarCartaDelMazo()
    {
        if (mazo.EstaVacio())
        {
            throw new InvalidOperationException("El mazo está vacío. No se pueden robar más cartas.");
        }
        return mazo.RobarCarta();
    }

    public override void MostrarResultados()
    {
        Console.WriteLine("\n--*!!! RESULTADOS FINALES !!!*--");
        
        int puntajeDealer = dealer.ObtenerPuntajeMano();
        bool dealerSePaso = dealer.SePasoDe21();
        
        Console.WriteLine($"Dealer: {puntajeDealer} puntos {(dealerSePaso ? "(SE PASÓ)" : "")}");
        
        foreach (var jugador in jugadoresBlackjack)
        {
           
        
            int puntajeJugador = jugador.ObtenerPuntajeMano();
            bool jugadorSePaso = jugador.SePasoDe21();
            
            string resultado;
            if (jugadorSePaso)
            {
                resultado = "PIERDE (Se pasó de 21)";
            }
            else if (dealerSePaso)
            {
                resultado = "GANA (Dealer se pasó)";
            }
            else if (puntajeJugador > puntajeDealer)
            {
                resultado = "GANA";
            }
            else if (puntajeJugador == puntajeDealer)
            {
                resultado = "EMPATE";
            }
            else
            {
                resultado = "PIERDE";
            }
            
            Console.WriteLine($"{jugador.Nombre}: {puntajeJugador} puntos - {resultado}");
        }
    }



}
