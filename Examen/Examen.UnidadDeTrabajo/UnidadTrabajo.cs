using Examen.Modelos;
using Examen.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.UnidadDeTrabajo
{
    public class UnidadTrabajo : IUnidadTrabajo
    {

        public UnidadTrabajo(string cadenaConexion)
        {
            Corporations = new Repositorio<Corporation>(cadenaConexion);
            Members = new Repositorio<Member>(cadenaConexion);
        }
                
        public IRepositorio<Corporation> Corporations { get; private set; }
        public IRepositorio<Member> Members { get; private set; }
    }
}
