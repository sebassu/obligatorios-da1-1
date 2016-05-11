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

        private decimal maximo;
        public decimal Maximo
        {
            get
            {
                return maximo;
            }
            set
            {
                if (minimo > value)
                {
                    throw new VariableExcepcion("Máximo inferior al mínimo registrado");
                }
                else
                {
                    maximo = value;
                }
            }
        }

        private decimal minimo;
        public decimal Minimo
        {
            get
            {
                return minimo;
            }
            set
            {
                if (maximo < value)
                {
                    throw new VariableExcepcion("Mínimo superior al máximo registrado");
                }
                else
                {
                    minimo = value;
                }
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
                minimo = valorMinimo;
                maximo = valorMaximo;
                id = ProximaIdAAsignar++;
                historicoDeValores = new List<Tuple<DateTime, decimal>>();
            }
        }

        private bool FueraDelIntervaloMenorMayor(decimal unValor)
        {
            return unValor < minimo || unValor > maximo;
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
            return nombre + ": " + valorActualAuxiliar + " (" + minimo + " - " + maximo + ")";
        }
    }
}