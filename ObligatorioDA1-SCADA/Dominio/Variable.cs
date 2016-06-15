using Excepciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Variable : IComparable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid ID { get; set; }

        private DateTime fechaUltimaModificacion;
        private bool fueSeteada;
        private decimal minimoAlarma;
        private decimal minimoAdvertencia;
        private decimal maximoAdvertencia;
        private decimal maximoAlarma;

        private string nombre;
        public virtual string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (Auxiliar.EsTextoValido(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new VariableExcepcion("Nombre inválido.");
                }
            }
        }

        private bool alarmaActiva;
        public virtual bool AlarmaActiva
        {
            get
            {
                return alarmaActiva;
            }
            protected set
            {
                alarmaActiva = value;
            }
        }

        private bool advertenciaActiva;
        public virtual bool AdvertenciaActiva
        {
            get
            {
                return advertenciaActiva;
            }
            protected set
            {
                advertenciaActiva = value;
            }
        }

        private decimal valorActual;
        public decimal ValorActual
        {
            get
            {
                return valorActual;
            }
            set
            {
                RegistrarValorAnterior();
                ValidarActivacionesRangos(value);
                fechaUltimaModificacion = DateTime.Now;
                valorActual = value;
                fueSeteada = true;
            }
        }

        private void ValidarActivacionesRangos(decimal valorAAnalizar)
        {
            bool fueraDeRangoAlarma = Auxiliar.EstaFueraDelRango(valorAAnalizar, minimoAlarma, maximoAlarma);
            bool fueraDeRangoAdvertencia = !fueraDeRangoAlarma && Auxiliar.EstaFueraDelRango(valorAAnalizar, minimoAdvertencia, maximoAdvertencia);
            if (Auxiliar.NoEsNulo(componentePadre))
            {
                ValidarActivacionesDeAlarma(fueraDeRangoAlarma);
                ValidarActivacionesDeAdvertencia(fueraDeRangoAdvertencia);
            }
            alarmaActiva = fueraDeRangoAlarma;
            advertenciaActiva = fueraDeRangoAdvertencia;
        }

        private void ValidarActivacionesDeAlarma(bool nuevoValorFueraDeRango)
        {
            if (!alarmaActiva && nuevoValorFueraDeRango)
            {
                componentePadre.IncrementarAlarmas();
            }
            else if (alarmaActiva && !nuevoValorFueraDeRango)
            {
                componentePadre.DecrementarAlarmas();
            }
        }

        private void ValidarActivacionesDeAdvertencia(bool nuevoValorFueraDeRango)
        {
            if (!advertenciaActiva && nuevoValorFueraDeRango)
            {
                componentePadre.IncrementarAdvertencias();
            }
            else if (advertenciaActiva && !nuevoValorFueraDeRango)
            {
                componentePadre.DecrementarAdvertencias();
            }
        }

        private List<Tuple<DateTime, decimal>> historicoDeValores;
        public virtual List<Tuple<DateTime, decimal>> Historico
        {
            get
            {
                return historicoDeValores;
            }
            set
            {
                historicoDeValores = value;
            }
        }

        private void RegistrarValorAnterior()
        {
            if (fueSeteada)
            {
                Tuple<DateTime, decimal> elementoAAgregar = Tuple.Create(fechaUltimaModificacion, valorActual);
                historicoDeValores.Add(elementoAAgregar);
                historicoDeValores.Sort();
            }
        }

        public void SetValoresLimites(decimal minimoAlarmaASetear, decimal minimoAdvertenciaASetear, decimal maximoAdvertenciaASetear, decimal maximoAlarmaASetear)
        {
            if (Auxiliar.ValoresMonotonosCrecientes(minimoAlarmaASetear, minimoAdvertenciaASetear, maximoAdvertenciaASetear, maximoAlarmaASetear))
            {
                minimoAlarma = minimoAlarmaASetear;
                minimoAdvertencia = minimoAdvertenciaASetear;
                maximoAdvertencia = maximoAdvertenciaASetear;
                maximoAlarma = maximoAlarmaASetear;
                ValidarActivacionesRangos(valorActual);
            }
            else
            {
                throw new VariableExcepcion("Valores límites inválidos recibidos.");
            }
        }

        public decimal MinimoAlarma
        {
            get
            {
                return minimoAlarma;
            }
            protected set
            {
                minimoAlarma = value;
            }
        }

        public decimal MinimoAdvertencia
        {
            get
            {
                return minimoAdvertencia;
            }
            protected set
            {
                minimoAdvertencia = value;
            }
        }

        public decimal MaximoAdvertencia
        {
            get
            {
                return maximoAdvertencia;
            }
            protected set
            {
                maximoAdvertencia = value;
            }
        }

        public decimal MaximoAlarma
        {
            get
            {
                return maximoAlarma;
            }
            protected set
            {
                maximoAlarma = value;
            }
        }

        private Componente componentePadre;

        [InverseProperty("Variables")]
        public Componente ComponentePadre
        {
            get
            {
                return componentePadre;
            }
            internal set
            {
                componentePadre = value;
            }
        }

        internal static Variable VariableInvalida()
        {
            return new Variable();
        }

        private Variable() : this("Variable inválida.", 0M, 0M) { }

        public static Variable NombreMinimoMaximo(string unNombre, decimal valorMinimo, decimal valorMaximo)
        {
            return new Variable(unNombre, valorMinimo, valorMaximo);
        }

        private Variable(string unNombre, decimal valorMinimo, decimal valorMaximo)
        {
            if (valorMinimo > valorMaximo)
            {
                throw new VariableExcepcion("Rango mínimo-máximo inválido.");
            }
            else
            {
                Nombre = unNombre;
                minimoAlarma = valorMinimo;
                minimoAdvertencia = valorMinimo;
                maximoAdvertencia = valorMaximo;
                maximoAlarma = valorMaximo;
                ID = Guid.NewGuid();
                historicoDeValores = new List<Tuple<DateTime, decimal>>();
            }
        }

        public static Variable NombreRangosAdvertenciaAlarma(string nombre, decimal minimoAlarmaASetear, decimal minimoAdvertenciaASetear,
            decimal maximoAdvertenciaASetear, decimal maximoAlarmaASetear)
        {
            return new Variable(nombre, minimoAlarmaASetear, minimoAdvertenciaASetear, maximoAdvertenciaASetear, maximoAlarmaASetear);
        }

        private Variable(string unNombre, decimal minimoAlarmaASetear, decimal minimoAdvertenciaASetear,
            decimal maximoAdvertenciaASetear, decimal maximoAlarmaASetear)
        {
            ID = Guid.NewGuid();
            Nombre = unNombre;
            SetValoresLimites(minimoAlarmaASetear, minimoAdvertenciaASetear, maximoAdvertenciaASetear, maximoAlarmaASetear);
            historicoDeValores = new List<Tuple<DateTime, decimal>>();
        }

        public override bool Equals(object obj)
        {
            Variable variableAComparar = obj as Variable;
            if (Auxiliar.NoEsNulo(variableAComparar))
            {
                return ID.Equals(variableAComparar.ID);
            }
            else
            {
                return false;
            }
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Variable variableAComparar = obj as Variable;
            if (Auxiliar.NoEsNulo(variableAComparar))
            {
                return nombre.CompareTo(variableAComparar.Nombre);
            }
            else
            {
                throw new VariableExcepcion("Comparación de tipos incompatibles.");
            }
        }

        public override string ToString()
        {
            string valorActualAuxiliar = (fueSeteada ? valorActual + "" : "N/A");
            return nombre + ": " + valorActualAuxiliar + " (" + MinimoAlarma + ", " +
                MinimoAdvertencia + ", " + MaximoAdvertencia + ", " + MaximoAlarma + ")";
        }
    }
}