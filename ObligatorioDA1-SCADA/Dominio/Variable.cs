using System;
using System.Collections;

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
                fechaUltimaModificacion = DateTime.Now;
                valorActual = value;
                fueSeteada = true;
            }
        }

        private IList historicoDeValores;
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
                return historicoDeValores;
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

        public static Variable VariableInvalida()
        {
            return new Variable();
        }

        private Variable()
        {
            nombre = "Nombre inválido.";
            id = ProximaIdAAsignar++;
            historicoDeValores = new ArrayList();
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
                historicoDeValores = new ArrayList();
            }
        }

        public bool ValorFueraDeRango()
        {
            return valorActual < minimo || valorActual > maximo;
        }

        public override bool Equals(object unObjeto)
        {
            Variable variableAComparar = unObjeto as Variable;
            if (variableAComparar == null)
            {
                return false;
            }
            else
            {
                return id == variableAComparar.id;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}