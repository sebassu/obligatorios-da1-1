using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class Variable
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
                    throw new ArgumentException("Nombre inválido.");
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

        private double valorActual;
        public double ValorActual
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
                    validarActivacionesDeAlarma(nuevoValorFueraDeRango);
                }
                alarmaActivada = nuevoValorFueraDeRango;
                fechaUltimaModificacion = DateTime.Now;
                valorActual = value;
                fueSeteada = true;
            }
        }

        private void validarActivacionesDeAlarma(bool nuevoValorFueraDeRango)
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

        private List<Tuple<DateTime, double>> historicoDeValores;
        private void RegistrarValorAnterior()
        {
            if (fueSeteada)
            {
                Tuple<DateTime, double> elementoAAgregar = Tuple.Create(fechaUltimaModificacion, valorActual);
                historicoDeValores.Add(elementoAAgregar);
            }
        }

        public IList Historico
        {
            get
            {
                return historicoDeValores.AsReadOnly();
            }
        }

        private double maximo;
        public double Maximo
        {
            get
            {
                return maximo;
            }
            set
            {
                if (minimo > value)
                {
                    throw new InvalidOperationException("Máximo inferior al mínimo registrado");
                }
                else
                {
                    maximo = value;
                }
            }
        }

        private double minimo;
        public double Minimo
        {
            get
            {
                return minimo;
            }
            set
            {
                if (maximo < value)
                {
                    throw new InvalidOperationException("Mínimo superior al máximo registrado");
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
                    throw new ArgumentException("El dispositivo a asignar no contiene a la variable.");
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
            historicoDeValores = new List<Tuple<DateTime, double>>();
        }

        public static Variable NombreMinimoMaximo(string unNombre, double valorMinimo, double valorMaximo)
        {
            return new Variable(unNombre, valorMinimo, valorMaximo);
        }

        private Variable(string unNombre, double valorMinimo, double valorMaximo)
        {
            if (valorMinimo > valorMaximo)
            {
                throw new ArgumentException("Rango mínimo-máximo inválido.");
            }
            else
            {
                Nombre = unNombre;
                minimo = valorMinimo;
                maximo = valorMaximo;
                id = ProximaIdAAsignar++;
                historicoDeValores = new List<Tuple<DateTime, double>>();
            }
        }

        private bool FueraDelIntervaloMenorMayor(double unValor)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}