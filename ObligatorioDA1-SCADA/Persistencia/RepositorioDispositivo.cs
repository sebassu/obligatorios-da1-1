﻿using Dominio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    internal class RepositorioDispositivo : Repositorio<Dispositivo>
    {
        internal RepositorioDispositivo(ContextoSCADA unContexto) : base(unContexto) { }

        public override List<Dispositivo> Obtener()
        {
            return coleccionEntidades.Include("ElementoPadre").Include("Tipo").ToList();
        }

        public override void Insertar(Dispositivo entidad)
        {
            contexto = new ContextoSCADA("name=ContextoSCADA");
            if (contexto.Entry(entidad.Tipo).State == EntityState.Detached)
            {
                contexto.Tipos.Attach(entidad.Tipo);
            }
            contexto.Dispositivos.Add(entidad);
            contexto.SaveChanges();
        }
    }
}

