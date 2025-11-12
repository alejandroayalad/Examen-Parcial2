using System;
using System.Collections.Generic;

public class AdministradorDeTurnos
{
    private readonly List<JugadorUno> _jugadores;
    private int _indiceJugadorActual;
    private bool _sentidoHorario;

    public AdministradorDeTurnos(List<JugadorUno> jugadores)
    {
        _jugadores = jugadores;
        Resetear();
    }


    public void Resetear()
    {
        _indiceJugadorActual = 0;
        _sentidoHorario = true;
    }


    public JugadorUno ObtenerJugadorActual()
    {
        return _jugadores[_indiceJugadorActual];
    }

   
    public JugadorUno ObtenerSiguienteJugador()
    {
        int indiceSiguiente;
        if (_sentidoHorario)
        {
            indiceSiguiente = (_indiceJugadorActual + 1) % _jugadores.Count;
        }
        else
        {
            indiceSiguiente = _indiceJugadorActual - 1;
            if (indiceSiguiente < 0)
            {
                indiceSiguiente = _jugadores.Count - 1;
            }
        }
        return _jugadores[indiceSiguiente];
    }

   
    public void AvanzarTurno()
    {
        if (_sentidoHorario)
        {
            _indiceJugadorActual = (_indiceJugadorActual + 1) % _jugadores.Count;
        }
        else
        {
            _indiceJugadorActual--;
            if (_indiceJugadorActual < 0)
            {
                _indiceJugadorActual = _jugadores.Count - 1;
            }
        }
    }

   
    public void InvertirSentido()
    {
        _sentidoHorario = !_sentidoHorario;
        Console.WriteLine($"Sentido invertido. Ahora: {(_sentidoHorario ? "Horario" : "Anti-horario")}");
    }

    
    public string ObtenerNombreJugadorActual()
    {
        return ObtenerJugadorActual().Nombre;
    }

   
    public string ObtenerNombreSiguienteJugador()
    {
        return ObtenerSiguienteJugador().Nombre;
    }
}
