using System;


public enum Palo
{
Corazones,
Diamantes,
Treboles,
Picas
}

public enum Valor
{
Dos=2,
Tres=3,
Cuatro=4,
Cinco=5,
Seis=6,
Siete=7,
Ocho=8,
Nueve=9,
Diez=10,
Jack,
Queen,
King,
As
}



public class cartaBlackjack : ICarta
{
    private Palo _palo;
    private Valor _valor;

    public cartaBlackjack(Palo palo, Valor valor)
    {
        _palo = palo;
        _valor = valor;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine(this.ToString());
    }

    public int ObtenerPuntaje()
    {
        if (_valor == Valor.Jack || _valor == Valor.Queen || _valor == Valor.King)
        {
            return 10;
        }
        else if (_valor == Valor.As)
        {
            return 11;
        }
        else
        {
            return (int)_valor;
        }
    }

    public override string ToString()
    {
        return $"Carta de {_valor} de {_palo}";
    }
}
