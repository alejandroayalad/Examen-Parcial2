using System;





public class JuegoBlackjack : Juego, IContextoBlackjack
{

     private Dealer dealer;
    private List<JugadorBlackjack> jugadoresBlackjack; 
     
    public JuegoBlackjack(Dealer dealer, List<JugadorBlackjack> jugadores, MazoDeCartas mazo) : base(jugadores.Cast<Jugador>().ToList(), mazo)
    {
        this.dealer = dealer;
        this.jugadoresBlackjack = jugadores;

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

    public ICarta RobarCartaMazo()
    {
        throw new NotImplementedException();
    }
    
}
