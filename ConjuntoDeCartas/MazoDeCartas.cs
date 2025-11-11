using Examen_Parcial;
using System;



public class MazoDeCartas : ConjuntoDeCartas
{
    public MazoDeCartas() : base()
    {

    }

    public ICarta RobarCarta()
    {
        if (cartas.Count == 0)
        {
            throw new Exception("El mazo de cartas esta vacío.");
        }
        ICarta cartaRobada = cartas[cartas.Count - 1];
        cartas.RemoveAt(cartas.Count - 1);
        return cartaRobada;
    }
    public void Barajar()
    {
        int n = cartas.Count;
        while  (n > 0)
        {
            int k = random.Next(n--);
            ICarta temp = cartas[n];
            cartas[n] = cartas[k];
            cartas[k] = temp;

        }
    }
}