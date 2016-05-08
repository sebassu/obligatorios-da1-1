﻿using System.Collections;

namespace Dominio
{
    public interface ISistemaSCADA
    {
        IList ComponentesPrimarios { get; }
        IList Tipos { get; }

        void RegistrarTipo(Tipo unTipo);
        void RegistrarComponente(Componente unComponente);
        bool EliminarTipo(Tipo unTipo);
        bool EliminarComponente(Componente unComponente);
    }
}