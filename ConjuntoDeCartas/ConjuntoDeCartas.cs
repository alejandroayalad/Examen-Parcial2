using System;
using System.Collections.Generic;

namespace Examen_Parcial;

public abstract class ConjuntoDeCartas
{

    protected List<ICarta> cartas;

    protected static Random random = new Random();


    protected ConjuntoDeCartas()
    {
        cartas = new List<ICarta>();
    }

    public IEnumerable<ICarta> Cartas
    {
        get { return cartas; }
    }

    public virtual void AgregarCarta(ICarta carta)
    {
        cartas.Add(carta);
    }

    public virtual int ContarCartas()
    {
        return cartas.Count;
    }

    public virtual bool EstaVacio()
    {
        return cartas.Count == 0;
    }

    public override string ToString()
    {
        return string.Join(", ", cartas);
    }
    

    public class Mano: ConjuntoDeCartas
    {
        public Mano() : base()
        {

        }

        public ICarta RemoverCarta(ICarta carta)
        {
            if (cartas.Remove(carta))
            {
                return carta;
            }
            throw new Exception("La carta no está en la mano.");
        }
        
        public List<ICarta> Limpiar()
        {
            List<ICarta> cartasLimpiadas = new List<ICarta>(cartas);
            cartas.Clear();
            return cartasLimpiadas;
        }
    }
}
