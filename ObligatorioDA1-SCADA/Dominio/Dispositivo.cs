using Excepciones;

namespace Dominio
{
    public class Dispositivo : Componente
    {
        private Tipo tipoDispositivo;

        public override Tipo Tipo
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

        public override bool EnUso
        {
            get
            {
                return Auxiliar.NoEsNulo(elementoPadre);
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

        public static Dispositivo NombreTipo(string unNombre, Tipo unTipo)
        {
            return new Dispositivo(unNombre, unTipo);
        }

        internal static Dispositivo DispositivoInvalido()
        {
            return new Dispositivo();
        }

        internal override void IncrementarAlarmas(int valor = 1)
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

        internal override void IncrementarAdvertencias(int valor = 1)
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

        public override void AgregarDependencia(ElementoSCADA elementoAAgregar)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle componentes a un dispositivo.");
        }

        public override void EliminarDependencia(ElementoSCADA elementoAEliminar)
        {
            throw new ElementoSCADAExcepcion("No es posible asignarle componentes a un dispositivo (ni eliminarlos por ende).");
        }

        private Dispositivo() : base()
        {
            nombre = "Dispositivo inválido.";
            tipoDispositivo = Tipo.TipoInvalido();
        }

        private Dispositivo(string unNombre, Tipo unTipo) : base(unNombre)
        {
            Tipo = unTipo;
        }

        public override string ToString()
        {
            return nombre + " (D)";
        }
    }
}