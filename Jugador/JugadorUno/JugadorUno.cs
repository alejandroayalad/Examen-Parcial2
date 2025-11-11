using System;



public abstract class JugadorUno : Jugador
{

    public JugadorUno(int id, string nombre) : base(id, nombre)
    {
        
    }
    protected Color ElegirColorAleatorio()
{
    int colorIndex = random.Next(4);
    return (Color)colorIndex;
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


