using System;



public class JuegoUno : Juego, IContextoJugadorUno, IGestorJuegoUno
{
    private PilaDeDescarte pilaDescarte;
    private List<JugadorUno> jugadoresUno;
    private int indiceJugadorActual;
    private bool sentidoHorario;
    private bool saltarSiguienteTurno;
    private int cartasParaRobar;
    private Color? colorActual;

    public JuegoUno(List<JugadorUno> jugadores, MazoDeCartas mazo) : base(jugadores.Cast<Jugador>().ToList(), mazo)
    {

        pilaDescarte = new PilaDeDescarte();
        jugadoresUno = jugadores;
        indiceJugadorActual = 0;
        sentidoHorario = true;
        saltarSiguienteTurno = false;
        cartasParaRobar = 0;
    }

   
    public override void InicializarJuego()
    {
        Console.WriteLine("\n=== INICIANDO JUEGO DE UNO ===");


        foreach (var jugador in jugadoresUno)
        {
            jugador.LimpiarMano();
        }


        mazo.Barajar();

        for (int i = 0; i < 2; i++)
        {
            foreach (var jugador in jugadoresUno)
            {
                ICarta carta = mazo.RobarCarta();
                jugador.AñadirCartaAMano(carta);
            }
        }


        ICarta primeraCartaDescarte;

        do
        {
            primeraCartaDescarte = mazo.RobarCarta();
        } while (primeraCartaDescarte is CartaUno cU && (cU.Tipo == TipoCarta.CambioColor || cU.Tipo == TipoCarta.MasCuatro));

        pilaDescarte.AgregarCarta(primeraCartaDescarte);

        if (primeraCartaDescarte is CartaUno cartaInicial)
        {
            colorActual = cartaInicial.Color;
        }

        Console.WriteLine($"Carta inicial en descarte: {primeraCartaDescarte}");
        Console.WriteLine($"Color actual: {colorActual}");

        indiceJugadorActual = 0;
        sentidoHorario = true;
        juegoTerminado = false;

        Console.WriteLine($"\nEmpieza: {jugadoresUno[indiceJugadorActual].Nombre}");
    }

    public override void JugarRonda()
    {
        if (juegoTerminado)
            return;

        var jugadorActual = jugadoresUno[indiceJugadorActual];

        Console.WriteLine($"\n--- Turno de {jugadorActual.Nombre} ---");
        jugadorActual.MostrarEstado();
        Console.WriteLine($"Carta en mesa: {pilaDescarte.VerCartaSuperior()}");
        Console.WriteLine($"Color actual: {colorActual}");



        // Verificar si debe robar cartas por castigo
        if (cartasParaRobar > 0)
        {
            Console.WriteLine($"{jugadorActual.Nombre} debe robar {cartasParaRobar} cartas.");
            for (int i = 0; i < cartasParaRobar; i++)
            {
                ICarta carta = RobarCartaDelMazo();
                jugadorActual.AñadirCartaAMano(carta);
            }
            cartasParaRobar = 0;
        }
        
        
        // Verificar si debe saltarse el turno
        if (saltarSiguienteTurno)
        {
            Console.WriteLine($"{jugadorActual.Nombre} pierde su turno.");
            saltarSiguienteTurno = false;
            AvanzarTurno();
            return;
        }
        
       
        // Jugador juega su turno
        jugadorActual.JugarTurno(this);
        
        // Verificar si el jugador ganó
        if (jugadorActual.ObtenerConteoCartas() == 0)
        {
            Console.WriteLine($"\n¡¡¡ {jugadorActual.Nombre} HA GANADO !!!");
            juegoTerminado = true;
            return;
        }
        
        // Avanzar al siguiente jugador
        AvanzarTurno();
    }

    private void AvanzarTurno()
    {
        if (sentidoHorario)
        {
            indiceJugadorActual = (indiceJugadorActual + 1) % jugadores.Count;
        }
        else
        {
            indiceJugadorActual--;
            if (indiceJugadorActual < 0)
            {
                indiceJugadorActual = jugadoresUno.Count - 1;
            }
        }
    }

    private int ObtenerIndiceSiguienteJugador()
    {
        int indiceSiguiente;
        if (sentidoHorario)
        {
            indiceSiguiente = (indiceJugadorActual + 1) % jugadoresUno.Count;
        }
        else
        {
            indiceSiguiente = indiceJugadorActual - 1;
            if (indiceSiguiente < 0)
            {
                indiceSiguiente = jugadoresUno.Count - 1;
            }
        }
        return indiceSiguiente;
    }

    public override void MostrarResultados()
    {
        Console.WriteLine("\n=== ESTADO FINAL DEL JUEGO ===");
        
        foreach (var jugador in jugadoresUno)
        {
           int conteo = jugador.ObtenerConteoCartas(); // Corregido para llamar al método correcto
        Console.WriteLine($"{jugador.Nombre}: {conteo} cartas restantes");
        }
    }

    
    public ICarta RobarCartaDelMazo()
    {
        Console.WriteLine($"Mazo tiene {mazo.ContarCartas()} cartas.");
        if (mazo.EstaVacio())
        {
            Console.WriteLine("El mazo está vacío. Reciclando pila de descarte...");
            ReciclarPilaDeDescarte();
        }
        return mazo.RobarCarta();
    }

   private void ReciclarPilaDeDescarte()
    {
        // DEBUG: Log para saber cuándo se activa el método y qué hay en la pila
        Console.WriteLine($"DEBUG: Reciclando... Pila de descarte tiene {pilaDescarte.ContarCartas()} cartas.");

        // Guardar la última carta
        ICarta ultimaCarta = pilaDescarte.VerCartaSuperior();
        
        // Mover todas las cartas excepto la última al mazo
        var cartasDescarte = new List<ICarta>();
        foreach (var carta in pilaDescarte.Cartas)
        {
            cartasDescarte.Add(carta);
        }
        
        // Limpiar descarte y dejar solo la última carta
        pilaDescarte = new PilaDeDescarte();
        pilaDescarte.AgregarCarta(ultimaCarta);
        
        // DEBUG: Log para ver cuántas cartas se van a intentar mover
        Console.WriteLine($"DEBUG: Se moverán {cartasDescarte.Count - 1} cartas al mazo.");

        
        if (cartasDescarte.Count > 1)
        {
     
            for (int i = 0; i < cartasDescarte.Count - 1; i++)
            {
                mazo.AgregarCarta(cartasDescarte[i]);
            }
            mazo.Barajar();
            
            
            Console.WriteLine($"DEBUG: Mazo reciclado y barajado. Nuevo conteo del mazo: {mazo.ContarCartas()}");
        }
        else
        {
            
            Console.WriteLine("DEBUG: No hay suficientes cartas en el descarte para reciclar. El mazo no se barajó.");
        }
        
    }
    public CartaUno VerCartaDescarte()
    {
        ICarta carta = pilaDescarte.VerCartaSuperior();

        if (carta is CartaUno cartaU)
        {
            return cartaU;
        }
        throw new InvalidOperationException("¡Error! La carta superior no es una CartaUno.");
    }


    public int ObtenerCantidadDeCartasEnMano()
    {
        int indiceSiguiente = ObtenerIndiceSiguienteJugador();
        var siguienteJugador = jugadoresUno[indiceSiguiente];
        
         return siguienteJugador.ObtenerConteoCartas();
    }

    public void JugarCartaEnMesa(ICarta carta, Color? nuevoColor = null)
    {
        pilaDescarte.AgregarCarta(carta);
        Console.WriteLine($"Carta jugada en mesa: {carta}");
        
        if (carta is CartaUno cartaU)
        {
            if (nuevoColor.HasValue)
            {
                colorActual = nuevoColor.Value;
                Console.WriteLine($"Nuevo color elegido: {colorActual}");
            }
            else if (cartaU.Color.HasValue)
            {
                colorActual = cartaU.Color.Value;
            }
            
            cartaU.EjecutarEfecto(this, nuevoColor);
        }
    }

    public void InvertirSentido()
    {
        sentidoHorario = !sentidoHorario;
        Console.WriteLine($"Sentido invertido. Ahora: {(sentidoHorario ? "Horario" : "Anti-horario")}");
    }

    public void SaltarTurnoSiguiente()
    {
        saltarSiguienteTurno = true;
        int indiceSiguiente = ObtenerIndiceSiguienteJugador();
        Console.WriteLine($"El siguiente jugador ({jugadores[indiceSiguiente].Nombre}) será bloqueado.");
    }

    public void SiguienteJugadorRoba(int cantidad)
    {
        cartasParaRobar = cantidad;
        int indiceSiguiente = ObtenerIndiceSiguienteJugador();
        Console.WriteLine($"{jugadores[indiceSiguiente].Nombre} deberá robar {cantidad} cartas.");
    }

    public void EstablecerColorActual(Color color)
    {
        colorActual = color;
        Console.WriteLine($"Color establecido: {color}");
    }

    public Color? ObtenerColor()
    {
    return colorActual;
    }
}



