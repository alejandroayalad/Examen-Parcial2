using System;

namespace Examen_Juego.Jugador;

public abstract class Jugador
{
    private int _id;
    public int Id
    {
        get { return _id; }
    }

    protected Mano miMano;
    protected string _nombre;

    public string Nombre
    {
        get { return _nombre; }
    }

    protected Jugador(int id, string nombre)
    {
        _id = id;
        _nombre = nombre;
        miMano = new Mano();
    }
    public virtual void AñadirCartaAMano(ICarta cartaParaAñadir)
    {

    }
    public virtual void MostrarEstado()
    {

    }
    public virtual List<ICarta> LimpiarMano()
    {

    }
    public int ObtenerConteoCartas()
    {

    }
}
