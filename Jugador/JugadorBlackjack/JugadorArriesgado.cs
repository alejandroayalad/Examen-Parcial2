using System;



public class JugadorArriesgado : JugadorBlackjack
{
public JugadorArriesgado(int id, string nombre) : base(id, nombre)
    {
    }

    public override void JugarTurno(IContextoBlackjack contexto)
    {
        Console.WriteLine($"{Nombre} está jugando su turno.");

        while (ObtenerPuntajeMano() < 21)
        {
            ICarta cartaRobada = contexto.RobarCartaDelMazo();
            this.AñadirCartaAMano(cartaRobada);
            Console.WriteLine($"{Nombre} roba una carta: {cartaRobada}");
        }
        Console.WriteLine($"{Nombre} ha terminado su turno.");
    }
}
