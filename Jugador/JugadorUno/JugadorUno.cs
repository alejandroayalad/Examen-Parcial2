using System;



public abstract class JugadorUno : Jugador
{

    public JugadorUno(int id, string nombre) : base(id, nombre)
    {
        
    }
    protected Color ElegirMejorColorSegunMano()
    {
        var conteoPorColor = new Dictionary<Color, int>
    {
        { Color.Rojo, 0 }, { Color.Azul, 0 }, { Color.Verde, 0 }, { Color.Amarillo, 0 }
    };

        foreach (var carta in MiMano.Cartas)
        {
            if (carta is CartaUno cartaUno && cartaUno.Color.HasValue)
            {
                conteoPorColor[cartaUno.Color.Value]++;
            }
        }


        Color? mejorColor = null;
        int maxConteo = -1;

        foreach (var par in conteoPorColor)
        {

            if (par.Value > maxConteo)
            {
                maxConteo = par.Value;
                mejorColor = par.Key;
            }
        }


        if (maxConteo <= 0 || !mejorColor.HasValue)
        {
            Console.WriteLine($" {Nombre} no tiene cartas de color, elige al azar.");
            return (Color)random.Next(0, 4);
        }

        Console.WriteLine($"{Nombre} elige {mejorColor.Value} (tiene {maxConteo} cartas).");
        return mejorColor.Value;
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


