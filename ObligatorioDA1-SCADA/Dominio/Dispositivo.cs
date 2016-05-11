using System.Collections;
using System.Collections.Generic;
using Excepciones;

namespace Dominio
{
    public class Dispositivo : Componente
    {
        public static uint ProximaIdAAsignar;

        private Tipo tipoDispositivo;
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
                    throw new ComponenteExcepcion("Tipo inválido.");
                }
            }
        }

        private bool enUso;
        public bool EnUso
        {
            get
            {
                return enUso;
            }
            set
            {
                if (Auxiliar.NoEsNulo(instalacionPadre))
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
                RestarTotalAlarmasPadre();
            }
            else if (!enUso && pasaAUsarse)
            {
                SumarTotalAlarmasPadre();
            }
        }

        private void RestarTotalAlarmasPadre()
        {
            for (int i = 0; i < cantidadAlarmasActivas; i++)
            {
                instalacionPadre.DecrementarAlarmas();
            }
        }

        private void SumarTotalAlarmasPadre()
        {
            for (int i = 0; i < cantidadAlarmasActivas; i++)
            {
                instalacionPadre.IncrementarAlarmas();
            }
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

        public static Dispositivo DispositivoInvalido()
        {
            return new Dispositivo();
        }

        public override void IncrementarAlarmas()
        {
            if (Auxiliar.EsListaVacia(variables))
            {
                throw new ComponenteExcepcion("La lista de variables controladas es vacía.");
            }
            else
            {
                base.IncrementarAlarmas();
            }
        }

        protected override void IncrementarAlarmasPadre()
        {
            if (enUso)
            {
                instalacionPadre.IncrementarAlarmas();
            }
        }

        public override void AgregarComponente(Componente unComponente)
        {
            throw new ComponenteExcepcion("No es posible asignarle componentes a un dispositivo.");
        }

        public override void EliminarComponente(Componente unComponente)
        {
            throw new ComponenteExcepcion("No es posible asignarle componentes a un dispositivo (ni eliminarlos por ende).");
        }

        private Dispositivo()
        {
            nombre = "Nombre inválido.";
            tipoDispositivo = Tipo.TipoInvalido();
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        private Dispositivo(string unNombre, Tipo unTipo, bool estaEnUso)
        {
            Nombre = unNombre;
            Tipo = unTipo;
            enUso = estaEnUso;
            variables = new List<Variable>();
            id = ProximaIdAAsignar++;
        }

        public override string ToString()
        {
            return nombre + " (D)";
        }
    }
}