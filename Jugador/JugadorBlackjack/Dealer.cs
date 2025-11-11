using System;
using System.Security.Cryptography.X509Certificates;



public class Dealer : JugadorBlackjack
{

    public Dealer(int id, string nombre) : base(id, nombre)
    {
    }
    public void RepartirRonda(MazoDeCartas mazo, List<JugadorBlackjack> jugadores )
    {
        Console.WriteLine("El dealer inicia la ronda");
        mazo.Barajar();
        Console.WriteLine("El dealer ha barajado el mazo");
        for int i = 0; i < 2; i++)
        {
            foreach (var jugador in jugadores)
            {
                ICarta cartaRobada = mazo.RobarCarta();
                jugador.AñadirCartaAMano(cartaRobada);
            }
        }
        for (int i = 0; i < 2;i++)
        {
            ICarta carta = mazo.RobarCarta();
            AñadirCartaAMano(carta);
        }
        Console.WriteLine("Dealer ha repartido 2 cartas a todos los participantes (incluyendose).");

    }
    public override void JugarTurno(IContextoBlackJack contexto)
    {
        Console.WriteLine("Turno del dealer.");
        while (ObtenerPuntuajeMano() <17)
        {
            ICarta cartaRobada = contexto.RobarCartaMazo();
            this.AñadirCartaAMano(cartaRobada);
            Console.WriteLine("El dealer ha terminado su turno");
        }

    }


}
