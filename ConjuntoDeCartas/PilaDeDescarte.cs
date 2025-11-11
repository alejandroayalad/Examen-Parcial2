using Examen_Parcial;
using System;



public class PilaDeDescarte : ConjuntoDeCartas
{
    public PilaDeDescarte() : base()
    {

    }
    public ICarta VerCartaSuperior()
    {
        if (cartas.Count == 0)
        {
            throw new Exception("La pila de descarte esta vacía");
        }
        return cartas[cartas.Count - 1];
    }
}
