using System.Collections;
using System.Collections.Generic;
using Excepciones;

namespace Dominio
{
    public class Instalacion : Componente
    {
        private static uint ProximaIdAAsignar;

        private List<Componente> dependencias;
        public override IList Dependencias
        {
            get
            {
                return dependencias.AsReadOnly();
            }
        }

        public override void AgregarComponente(Componente componenteAAgregar)
        {
            if (EsComponenteValido(componenteAAgregar))
            {
                dependencias.Add(componenteAAgregar);
                dependencias.Sort();
                componenteAAgregar.InstalacionPadre = this;
                uint cantidadDispositivosAVariar = DeterminarCambioDeDispositivos(componenteAAgregar);
                cantidadDispositivosHijos += cantidadDispositivosAVariar;
                SumarDispositivosEnJerarquia(cantidadDispositivosAVariar);
            }
            else
            {
                throw new ComponenteExcepcion("Componente inválido recibido.");
            }
        }

        public override void EliminarComponente(Componente componenteAEliminar)
        {
            if (EsComponenteValido(componenteAEliminar))
            {
                dependencias.Remove(componenteAEliminar);
                dependencias.Sort();
                uint cantidadDispositivosAVariar = DeterminarCambioDeDispositivos(componenteAEliminar);
                cantidadDispositivosHijos -= cantidadDispositivosAVariar;
                RestarDispositivosEnJerarquia(cantidadDispositivosAVariar);
            }
            else
            {
                throw new ComponenteExcepcion("Componente inválido recibido.");
            }
        }

        private static uint DeterminarCambioDeDispositivos(Componente componenteAAgregar)
        {
            uint cantidadDispositivosAVariar = 0;
            if (componenteAAgregar is Dispositivo)
            {
                cantidadDispositivosAVariar = 1;
            }
            else
            {
                Instalacion instalacionAAgregar = componenteAAgregar as Instalacion;
                if (Auxiliar.NoEsNulo(instalacionAAgregar))
                {
                    cantidadDispositivosAVariar = instalacionAAgregar.CantidadDispositivosHijos;
                }
            }
            return cantidadDispositivosAVariar;
        }

        private void SumarDispositivosEnJerarquia(uint cantidad)
        {
            Instalacion instalacionActual = instalacionPadre;
            while (Auxiliar.NoEsNulo(instalacionActual))
            {
                instalacionActual.cantidadDispositivosHijos += cantidad;
                instalacionActual = instalacionActual.instalacionPadre;
            }
        }

        private void RestarDispositivosEnJerarquia(uint cantidad)
        {
            Instalacion instalacionActual = instalacionPadre;
            while (Auxiliar.NoEsNulo(instalacionActual))
            {
                instalacionActual.cantidadDispositivosHijos -= cantidad;
                instalacionActual = instalacionActual.instalacionPadre;
            }
        }

        private bool EsComponenteValido(Componente unComponente)
        {
            return Auxiliar.NoEsNulo(unComponente) && !unComponente.Equals(this);
        }

        internal static Instalacion InstalacionInvalida()
        {
            return new Instalacion();
        }

        public static Instalacion ConstructorNombre(string unNombre)
        {
            return new Instalacion(unNombre);
        }

        private Instalacion()
        {
            nombre = "Nombre inválido.";
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        private Instalacion(string unNombre)
        {
            Nombre = unNombre;
            dependencias = new List<Componente>();
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        public override string ToString()
        {
            return nombre + " (I)";
        }

        private uint cantidadDispositivosHijos;
        public uint CantidadDispositivosHijos
        {
            get
            {
                return cantidadDispositivosHijos;
            }
        }
    }
}