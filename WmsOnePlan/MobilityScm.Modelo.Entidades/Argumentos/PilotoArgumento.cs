using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class PilotoArgumento : EventArgs
    {
        public IList<Piloto> Pilotos { get; set; }
        public IList<Usuario> Usuarios { get; set; }
        public RolDeUsuario RolDeUsuario { get; set; }
        public UsuarioPorPiloto UsuarioPorPiloto { get; set; }
        //public Usuario Usuario { get; set; }
        public Piloto Piloto { get; set; }
    }
}