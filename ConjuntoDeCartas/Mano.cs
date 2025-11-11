using System;
using Examen_Parcial;



public class Mano : ConjuntoDeCartas
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