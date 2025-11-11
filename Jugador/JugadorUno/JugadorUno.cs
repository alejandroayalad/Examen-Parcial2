using System;



public abstract class JugadorUno : Jugador
{

    public JugadorUno(int id, string nombre) : base(id, nombre)
    {
    }
    

    public void GritarUNO()
    {
        if (MiMano.ContarCartas() == 1)
        {
            Console.WriteLine($"{Nombre} grita UNO!");
        }
    }
    public abstract void JugarTurno(IContextoJugadorUno contexto);

}
