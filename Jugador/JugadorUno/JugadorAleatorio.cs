using System;



public class JugadorAleatorio : JugadorUno
{
    public JugadorAleatorio(int id, string nombre) : base(id, nombre)
    {
    }

    public override void JugarTurno(IContextoJugadorUno contexto)
    {
        Console.WriteLine($"{Nombre} está jugando su turno.");
        CartaUno cartaEnDescarte = contexto.VerCartaDescarte();

        Color? colorActual = contexto.ObtenerColor();
        List<ICarta> cartasJugables = ObtenerCartasJugables(cartaEnDescarte, colorActual);
        Console.WriteLine($"{Nombre} - cartas jugables encontradas: {cartasJugables.Count}");

        if (cartasJugables.Count > 0)
        {
            int indiceAleatorio = random.Next(cartasJugables.Count);
            ICarta cartaParaJugar = cartasJugables[indiceAleatorio];
            Color? colorParaPasar = null;

            if (cartaParaJugar is CartaUno cartaUno && 
                (cartaUno.Tipo == TipoCarta.CambioColor || cartaUno.Tipo == TipoCarta.MasCuatro))
            {
                colorParaPasar = ElegirMejorColorSegunMano();
            }

            MiMano.RemoverCarta(cartaParaJugar); 
            contexto.JugarCartaEnMesa(cartaParaJugar, colorParaPasar);
            Console.WriteLine($"{Nombre} juega la carta: {cartaParaJugar}");
        }
        else
        {
            Console.WriteLine($"{Nombre} no tiene cartas jugables y debe robar.");
            ICarta cartaRobada = contexto.RobarCartaDelMazo();
            this.AñadirCartaAMano(cartaRobada);
            Console.WriteLine($"{Nombre} roba una carta: {cartaRobada}");
        }

        GritarUNO();
        Console.WriteLine($"{Nombre} ha terminado su turno.");
    }
}
