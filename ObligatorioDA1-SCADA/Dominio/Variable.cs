using Excepciones;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Dominio
{
    public class Variable : IComparable
    {
        private static uint ProximaIdAAsignar;

        private uint id;
        private Tuple<decimal, decimal> rangoAdvertencia;
        private Tuple<decimal, decimal> rangoAlarma;
        private DateTime fechaUltimaModificacion;
        private bool fueSeteada;

        private string nombre;
        public string Nombre
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

        private bool alarmaActivada;
        public bool EstaFueraDeRango
        {
            get
            {
                return alarmaActivada;
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
                bool nuevoValorFueraDeRango = FueraDelIntervaloMenorMayor(value);
                if (Auxiliar.NoEsNulo(componentePadre))
                {
                    ValidarActivacionesDeAlarma(nuevoValorFueraDeRango);
                }
                alarmaActivada = nuevoValorFueraDeRango;
                fechaUltimaModificacion = DateTime.Now;
                valorActual = value;
                fueSeteada = true;
            }
        }

        private void ValidarActivacionesDeAlarma(bool nuevoValorFueraDeRango)
        {
            if (!alarmaActivada && nuevoValorFueraDeRango)
            {
                componentePadre.IncrementarAlarmas();

            }
            else if (alarmaActivada && !nuevoValorFueraDeRango)
            {
                componentePadre.DecrementarAlarmas();
            }
        }

        private List<Tuple<DateTime, decimal>> historicoDeValores;
        private void RegistrarValorAnterior()
        {
            if (fueSeteada)
            {
                Tuple<DateTime, decimal> elementoAAgregar = Tuple.Create(fechaUltimaModificacion, valorActual);
                historicoDeValores.Add(elementoAAgregar);
                historicoDeValores.Sort();
            }
        }

        public IList Historico
        {
            get
            {
                return historicoDeValores.AsReadOnly();
            }
        }

        public decimal MinimoAlarma
        {
            get
            {
                return rangoAlarma.Item1;
            }
        }

        public decimal MinimoAdvertencia
        {
            get
            {
                return rangoAdvertencia.Item1;
            }
        }

        public decimal MaximoAdvertencia
        {
            get
            {
                return rangoAdvertencia.Item2;
            }
        }

        public decimal MaximoAlarma
        {
            get
            {
                return rangoAlarma.Item2;
            }
        }

        private Componente componentePadre;
        public Componente ComponentePadre
        {
            get
            {
                return componentePadre;
            }
            set
            {
                if (Auxiliar.NoEsNulo(value) && value.Variables.Contains(this))
                {
                    componentePadre = value;
                }
                else
                {
                    throw new VariableExcepcion("El dispositivo a asignar no contiene a la variable.");
                }
            }
        }

        public static Variable VariableInvalida()
        {
            return new Variable();
        }

        private Variable()
        {
            nombre = "Nombre inválido.";
            id = ProximaIdAAsignar++;
            Tuple<decimal, decimal> tuplaAuxiliar = Tuple.Create(0M, 0M);
            rangoAdvertencia = tuplaAuxiliar;
            rangoAlarma = tuplaAuxiliar;
            historicoDeValores = new List<Tuple<DateTime, decimal>>();
        }

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
                Tuple<decimal, decimal> tuplaAuxiliar = Tuple.Create(valorMinimo, valorMaximo);
                rangoAdvertencia = tuplaAuxiliar;
                rangoAlarma = tuplaAuxiliar;
                id = ProximaIdAAsignar++;
                historicoDeValores = new List<Tuple<DateTime, decimal>>();
            }
        }

        public static Variable NombreRangosAdvertenciaAlarma(string nombre, Tuple<decimal, decimal> rangoAdvertencia,
            Tuple<decimal, decimal> rangoAlarma)
        {
            return new Variable(nombre, rangoAdvertencia, rangoAlarma);
        }

        private Variable(string unNombre, Tuple<decimal, decimal> rangoAdvertencia,
            Tuple<decimal, decimal> rangoAlarma)
        {

            id = ProximaIdAAsignar++;
            Nombre = unNombre;
            SetValoresLimites(rangoAdvertencia, rangoAlarma);
            historicoDeValores = new List<Tuple<DateTime, decimal>>();
        }

        private bool FueraDelIntervaloMenorMayor(decimal unValor)
        {
            return unValor < MinimoAlarma || unValor > MaximoAlarma;
        }

        public override bool Equals(object unObjeto)
        {
            Variable variableAComparar = unObjeto as Variable;
            if (Auxiliar.NoEsNulo(variableAComparar))
            {
                return id == variableAComparar.id;
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

        public int CompareTo(object unObjeto)
        {
            Variable variableAComparar = unObjeto as Variable;
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

        public void SetValoresLimites(Tuple<decimal, decimal> limitesAdvertenciaASetear, Tuple<decimal, decimal> limitesAlarmaASetear)
        {
            if (Auxiliar.ValoresMonotonosCrecientes(limitesAlarmaASetear.Item1, limitesAdvertenciaASetear.Item1, limitesAdvertenciaASetear.Item2, limitesAlarmaASetear.Item2))
            {
                rangoAdvertencia = limitesAdvertenciaASetear;
                rangoAlarma = limitesAlarmaASetear;
            }
            else
            {
                throw new VariableExcepcion("Valores límites inválidos recibidos.");
            }
        }
    }
}