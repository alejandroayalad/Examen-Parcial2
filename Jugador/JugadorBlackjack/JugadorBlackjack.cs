using System;
using System.Security.Cryptography;



public abstract class JugadorBlackjack : Jugador // Lo mínimo de Jugador BlackJack
{

    public JugadorBlackjack(int id, string nombre) : base(id, nombre)
    {
        // Base viene de Jugador
    }

    public abstract void JugarTurno(IContextoBlackJack contexto);

    public int ObtenerPuntuajeMano() //Para la sumatoria de los valores de las cartas del Jugador
    {
        int puntuajeBase = 0;
        int numeroDeAses = 0;

        foreach (var carta in MiMano.Cartas)
        {
            if (carta is cartaBlackjack cartaBj)
            {
                int valorCarta = cartaBj.ObtenerPuntaje();// Es de carta
                if (valorCarta == 11)
                {
                    numeroDeAses++;
                }
               // Checa si es As
                else
                {
                    puntuajeBase += valorCarta;

                }
                //Si no es, suma el puntuaje de los Enums
            }
        }
        for (int i= 0; i < numeroDeAses; i++) //Para ver cuando usar 1 y 11 para As
        {
            if (puntuajeBase + 11 > 21)
            {
                puntuajeBase += 1;
            }
            else
            {
                puntuajeBase += 11;
            }
        }
        return puntuajeBase;
    }
    public bool SePasoDe21()//Acaba el juego para el jugador que tiene más de 21
    {
        return false;
    }
}
