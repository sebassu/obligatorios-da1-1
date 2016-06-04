﻿using System.Collections;
using System.Collections.Generic;
using Excepciones;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Dispositivo : Componente
    {
        private Tipo tipoDispositivo;

        [NotMapped]
        public Tipo Tipo
        {
            get
            {
                return tipoDispositivo;
            }
            set
            {
                if (Auxiliar.NoEsNulo(value))
                {
                    tipoDispositivo = value;
                }
                else
                {
                    throw new ElementoSCADAExcepcion("Tipo inválido.");
                }
            }
        }

        private bool enUso;
        public override bool EnUso
        {
            get
            {
                return enUso;
            }
            set
            {
                if (Auxiliar.NoEsNulo(elementoPadre))
                {
                    CorregirAlarmasActivasPadres(value);
                }
                enUso = value;
            }
        }

        private void CorregirAlarmasActivasPadres(bool pasaAUsarse)
        {
            if (enUso && !pasaAUsarse)
            {
                RestarTotalAlarmasYAdvertenciasPadre();
            }
            else if (!enUso && pasaAUsarse)
            {
                SumarTotalAlarmasYAdvertenciasPadre();
            }
        }

        private void RestarTotalAlarmasYAdvertenciasPadre()
        {
            elementoPadre.DecrementarAlarmas(cantidadAlarmasActivas);
            elementoPadre.DecrementarAdvertencias(cantidadAdvertenciasActivas);
        }

        private void SumarTotalAlarmasYAdvertenciasPadre()
        {
            elementoPadre.IncrementarAlarmas(cantidadAlarmasActivas);
            elementoPadre.IncrementarAdvertencias(cantidadAdvertenciasActivas);
        }

        public override IList Dependencias
        {
            get
            {
                return new List<Componente>();
            }
        }

        public static Dispositivo NombreTipoEnUso(string unNombre, Tipo unTipo, bool estaEnUso = false)
        {
            return new Dispositivo(unNombre, unTipo, estaEnUso);
        }

        internal static Dispositivo DispositivoInvalido()
        {
            return new Dispositivo();
        }

        internal override void IncrementarAlarmas(uint valor = 1)
        {
            if (Auxiliar.EsListaVacia(variables))
            {
                throw new ElementoSCADAExcepcion("La lista de variables controladas es vacía.");
            }
            else
            {
                base.IncrementarAlarmas(valor);
            }
        }

        internal override void IncrementarAdvertencias(uint valor = 1)
        {
            if (Auxiliar.EsListaVacia(variables))
            {
                throw new ElementoSCADAExcepcion("La lista de variables controladas es vacía.");
            }
            else
            {
                base.IncrementarAdvertencias(valor);
            }
        }

        public override void AgregarDependencia(IElementoSCADA elementoAAgregar)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle componentes a un dispositivo.");
        }

        public override void EliminarDependencia(IElementoSCADA elementoAEliminar)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle componentes a un dispositivo (ni eliminarlos por ende).");
        }

        private Dispositivo() : base()
        {
            nombre = "Dispositivo inválido.";
            tipoDispositivo = Tipo.TipoInvalido();
        }

        private Dispositivo(string unNombre, Tipo unTipo, bool estaEnUso) : base(unNombre)
        {
            Tipo = unTipo;
            enUso = estaEnUso;
        }

        public override string ToString()
        {
            return nombre + " (D)";
        }

        // A efectos del correcto funcionamiento del Entity Framework.
        [Required]
        protected virtual Tipo TipoAuxiliar
        {
            get
            {
                return tipoDispositivo;
            }
            set
            {
                tipoDispositivo = value;
            }
        }
    }
}