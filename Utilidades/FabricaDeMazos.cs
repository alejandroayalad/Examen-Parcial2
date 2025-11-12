using System;
using Examen_Juego.Cartas;



public static class FabricaDeMazos
{
    public static MazoDeCartas CrearMazoBlackjack()
    {
        MazoDeCartas mazo = new MazoDeCartas();

        
        foreach (Palo p in Enum.GetValues(typeof(Palo)))
        {
            foreach (Valor v in Enum.GetValues(typeof(Valor)))
            {
                mazo.AgregarCarta(new cartaBlackjack(p, v));
            }
        }
        return mazo;
    }

    public static MazoDeCartas CrearMazoUno()
    {
        MazoDeCartas mazo = new MazoDeCartas();
        var colores = new[] { Color.Rojo, Color.Azul, Color.Verde, Color.Amarillo };

        foreach (var color in colores)
        {
        
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.Numero, 0));

           
            for (int num = 1; num <= 9; num++)
            {
                mazo.AgregarCarta(new CartaUno(color, TipoCarta.Numero, num));
                mazo.AgregarCarta(new CartaUno(color, TipoCarta.Numero, num));
            }

            
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.Bloqueo, new EfectoBloqueo(), new ReglaEspecial()));
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.Bloqueo, new EfectoBloqueo(), new ReglaEspecial()));

            
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.Reversa, new EfectoInvertirSentido(), new ReglaEspecial()));
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.Reversa, new EfectoInvertirSentido(), new ReglaEspecial()));
            
            
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.MasDos, new EfectoMasDos(), new ReglaEspecial()));
            mazo.AgregarCarta(new CartaUno(color, TipoCarta.MasDos, new EfectoMasDos(), new ReglaEspecial()));
        }

    
        for (int i = 0; i < 4; i++)
        {
            mazo.AgregarCarta(new CartaUno(TipoCarta.CambioColor, new EfectoCambioColor(), new ReglaComodin()));
        }

       
        for (int i = 0; i < 4; i++)
        {
            mazo.AgregarCarta(new CartaUno(TipoCarta.MasCuatro, new EfectoMasCuatro(), new ReglaComodin()));
        }

        return mazo;
    }
}
