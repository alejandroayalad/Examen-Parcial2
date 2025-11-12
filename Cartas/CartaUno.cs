
using System;
using Examen_Juego.Cartas;

public enum TipoCarta
{
    Numero,
    Reversa,
    CambioColor,
    MasDos,
    MasCuatro,
    Bloqueo
}

public enum Color
{
    Rojo,
    Verde,
    Amarillo,
    Azul
}


public class CartaUno : ICarta
{

    private readonly IEfecto _efectoCarta;

    private readonly IReglaJuego _reglaJuego;
    private int? _numero;

    public int? Numero
    {
        get => _numero;
        private set
        {
            if (value.HasValue && (value.Value < 0 || value.Value > 9))
            {
                throw new ArgumentOutOfRangeException(nameof(Numero), $"El número debe estar entre 0 y 9. Valor recibido: {value.Value}");
            }
            _numero = value;
        }
    }
    public Color? Color { get; private init; }
    public TipoCarta Tipo { get; private init; }
   

    //Numerica
    public CartaUno(Color color, TipoCarta tipo, int numero)
    {
        if (tipo != TipoCarta.Numero)
        {
         throw new ArgumentException( $"Este constructor es solo para cartas numéricas. Tipo recibido: {tipo}", nameof(tipo));
        }       
        Color = color;
        Tipo = tipo;
        Numero = numero;
        _efectoCarta = new EfectoNulo();
        _reglaJuego = new ReglaNumerica();
    }
    

    //Especial
    public CartaUno(Color color, TipoCarta tipo, IEfecto efectoCarta, IReglaJuego reglaJuego)
    {

        if (tipo == TipoCarta.Numero || tipo == TipoCarta.CambioColor || tipo == TipoCarta.MasCuatro){
            throw new ArgumentException($"Tipo de carta inválido para constructor de especiales: {tipo}",  nameof(tipo));
        }
            
        Color = color;
        Tipo = tipo;
        _efectoCarta = efectoCarta;
        _reglaJuego = reglaJuego;
        Numero = null;
    }

//comodin

    public CartaUno(TipoCarta tipo, IEfecto efectoCarta, IReglaJuego reglaJuego)
    {

        if (tipo != TipoCarta.CambioColor && tipo != TipoCarta.MasCuatro)
        {
            throw new ArgumentException($"Este constructor es solo para comodines. Tipo recibido: {tipo}", nameof(tipo));
        }
        Color = null;
        Tipo = tipo;
        _efectoCarta = efectoCarta;
        _reglaJuego = reglaJuego;
        Numero = null;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine(this.ToString());
    }

    public void EjecutarEfecto(IGestorJuegoUno contexto, Color? colorElegido) 
    {
        _efectoCarta.EjecutarEfecto(contexto, colorElegido);
    }

    public bool EsMovimientoValido(ICarta cartaDescarte, Color? colorActual)
{
    if (cartaDescarte is CartaUno cartaDescarteUno)
    {
        return _reglaJuego.EsMovimientoValido(this, cartaDescarteUno, colorActual);
    }
    return false;
}

   public override string ToString()
    {
       
        if (Numero.HasValue) 
        {
            return $"Carta de {Numero.Value} {Color}"; 
        }
        else 
        {
            if (!Color.HasValue) 
            {
                return $"Carta de {Tipo}";
            }
            return $"Carta de {Tipo} {Color}";
        }
    }
}
