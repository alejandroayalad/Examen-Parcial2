using System;



public class JugadorCauteloso : JugadorBlackjack
{

    private int _umbralPuntaje;

    public JugadorCauteloso(int id, string nombre, int umbral) : base(id, nombre)
    {
        _umbralPuntaje = umbral;
    }

    public override void JugarTurno(IContextoBlackjack contexto)
    {
          Console.WriteLine($"{Nombre} está jugando su turno.");
        while (ObtenerPuntajeMano() < _umbralPuntaje)
        {
            ICarta cartaRobada = contexto.RobarCartaDelMazo();
            this.AñadirCartaAMano(cartaRobada);
            Console.WriteLine($"{Nombre} roba una carta: {cartaRobada}");
        }
        Console.WriteLine($"{Nombre} ha terminado su turno.");
    }   
}

