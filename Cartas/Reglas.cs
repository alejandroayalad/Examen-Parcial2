using System;



public class ReglaNumerica : IReglaJuego
{
    public bool EsMovimientoValido(CartaUno cartaJugador, CartaUno cartaDescarte, Color? colorActual)
    {

        if (cartaJugador == null) 
            throw new ArgumentNullException(nameof(cartaJugador));
        if (cartaDescarte == null) 
            throw new ArgumentNullException(nameof(cartaDescarte));
        
        // Si la carta del jugador no tiene color (comodín), no debería usar esta regla
        if (!cartaJugador.Color.HasValue)
            return false;
            
     
        Color colorComparar = colorActual ?? cartaDescarte.Color 
            ?? throw new InvalidOperationException(
                "No se puede determinar el color de referencia");
        
    
        return cartaJugador.Color.Value == colorComparar ||
               (cartaJugador.Numero >= 0 && cartaJugador.Numero == cartaDescarte.Numero);
    }
}

public class ReglaComodin : IReglaJuego
{
    public bool EsMovimientoValido(CartaUno cartaJugador, CartaUno cartaDescarte, Color? colorActual)
    {
        return true;
    }
}

public class ReglaEspecial : IReglaJuego 
{
    public bool EsMovimientoValido(CartaUno cartaJugador, CartaUno cartaDescarte, Color? colorActual)
    {
    
        if (cartaJugador == null) 
            throw new ArgumentNullException(nameof(cartaJugador));
        if (cartaDescarte == null) 
            throw new ArgumentNullException(nameof(cartaDescarte));
        if (!colorActual.HasValue)
            throw new InvalidOperationException(
                "Las cartas especiales requieren un color actual definido");
        
    
        if (!cartaJugador.Color.HasValue)
            return false;
        
      
        return cartaJugador.Color.Value == colorActual.Value ||
               cartaJugador.Tipo == cartaDescarte.Tipo;
    }
}
