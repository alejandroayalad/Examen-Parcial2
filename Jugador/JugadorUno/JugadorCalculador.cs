using System;
using System.ComponentModel.Design;



public class JugadorCalculador : JugadorUno
{
    public JugadorCalculador(int id, string nombre) : base(id, nombre)
    {
    }
    public override void JugarTurno(IContextoJugadorUno contexto)
    {
        Console.WriteLine("${ Nombre} está jugando su turno");
        var cartaEnDescarte = contexto.VerCartaDescarte();
        Color? colorActual = contexto.ObtenerColor();
        var cartasJugables = ObtenerCartasJugables(cartaEnDescarte, colorActual);
        Console.WriteLine($"[DEBUG] {Nombre} - cartas jugables encontradas: {cartasJugables.Count}");
        int cartasDelSiguienteJugador = contexto.ObtenerCantidadCartasEnMano();

        ICarta? cartaParaJugar;

        if (cartasJugables.Count() > 0)
        {
            if (cartasDelSiguienteJugador == 1)

            {
                cartaParaJugar = SeleccionarCartaQueMaximizaImpacto(cartasJugables);
            }
            else
            {
                cartaParaJugar = SeleccionarCartaDeMenorImpacto(cartasJugables);
            }
            Color? colorParaPasar = null;
            if (cartaParaJugar is CartaUno cartaUno &&
                (cartaUno.Tipo == TipoCarta.CambioColor || cartaUno.Tipo == TipoCarta.MasCuatro))
            {
                colorParaPasar = ElegirMejorColorSegunMano();
            }
            Console.WriteLine($"{Nombre} juega la carta {cartaParaJugar}");
            MiMano.RemoverCarta(cartaParaJugar);
            contexto.JugarCartaMesa(cartaParaJugar, colorParaPasar);
            GritarUNO();
            Console.WriteLine($"{Nombre} ha terminado su turno");
            return;
        }

        Console.WriteLine($"{Nombre} no tiene una jugada directa, debe robar.");
        ICarta cartaRobada = contexto.RobarCartaDelMazo();
        this.AñadirCartaAMano(cartaRobada);

        if (cartaRobada is CartaUno cRobada && cRobada.EsMovimientoValido(cartaEnDescarte, colorActual)
        {
            bool jugarCarta = false; 
            if (cartasDelSiguienteJugador == 1)
            {
                if (cRobada.Tipo != TipoCarta.Numero)
                {
                    jugarCarta = true;
                }
            }
            else
            {
                jugarCarta = true;

            }
            if (jugarCarta)
            {
                Console.WriteLine($"{Nombre} robó y juega inmediatamente : {cartaRobada}");
                Color? colorParaPasar = null;
                if (cRobada.Tipo == TipoCarta.CambioColor || cRobada.Tipo == TipoCarta.MasCuatro)
                {
                    colorParaPasar = ElegirMejorColorSegunMano();
                }
                MiMano.RemoverCarta(cartaRobada);
                contexto.JugarCartaMesa(cartaRobada, colorParaPasar);
                GritarUNO();
                Console.WriteLine($"{Nombre} ha terminado su turno");
                return;
            }
        }
        Console.WriteLine($"{Nombre} robó y termina su turno sin jugar.");
        GritarUNO();
        Console.WriteLine($"{Nombre} ha terminado su turno.");
    }
    
    private ICarta? SeleccionarCartaQueMaximizaImpacto(List<ICarta> cartasJugables)
    {

        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.MasCuatro) return carta;
        }
        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.MasDos) return carta;
        }
        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.Bloqueo) return carta;
        }
        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.Reversa) return carta;
        }
        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.CambioColor) return carta;
        }

        return cartasJugables[0];
    }
    private ICarta? SeleccionarCartaDeMenorImpacto(List<ICarta> cartasJugables)
    {

        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.Numero)
            {
                return carta;
            }
        }

        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.CambioColor) return carta;
        }
        foreach (var carta in cartasJugables)
        {
            if (carta is CartaUno cartaUno && cartaUno.Tipo == TipoCarta.Reversa) return carta;
        }

        return cartasJugables[0];
    }
}
