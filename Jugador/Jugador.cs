using System;



public abstract class Jugador
{
    protected static Random random = new Random(); 
    private readonly int _id;
    private readonly string _nombre;
    private readonly Mano miMano;
    
    public int Id
    {
        get => _id;
        init => _id = value;
    }
    public string Nombre
    {
        get => _nombre;
        init => _nombre = value;
    }

     protected Mano MiMano 
    { 
        get => miMano;
        init => miMano = value;
    }

    protected Jugador(int id, string nombre)
    {
        _id = id;
        _nombre = nombre;
        miMano = new Mano();
    }
    public virtual void AñadirCartaAMano(ICarta cartaParaAñadir)
    {
            MiMano.AgregarCarta(cartaParaAñadir);
    }
    public virtual void MostrarEstado()
    {

    }
    public virtual List<ICarta> LimpiarMano()
    {
        return MiMano.Limpiar();
    }
    public int ObtenerConteoCartas()
    {
        return MiMano.ContarCartas();
    }

}
