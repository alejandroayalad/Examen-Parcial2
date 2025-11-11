using System;



public class JugadorCauteloso : JugadorBlackjack
{

    private int _umbralPuntaje;

    public JugadorCauteloso(int id, string nombre, int umbral) : base(id, nombre)
    {
        _umbralPuntaje = umbral;
    }

}

