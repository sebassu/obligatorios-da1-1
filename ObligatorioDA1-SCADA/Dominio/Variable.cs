using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Variable
    {
        private static uint ProximaIdAAsignar;

        private string nombre;
        private double valorActual;
        private double minimo;
        private double maximo;
        private DateTime fechaUltimaModificacion;
        private IList historicoDeValores;
        private bool fueSeteada;
        private uint id;

        public double ValorActual
        {
            get
            {
                return valorActual;
            }
            set
            {
                if (fueSeteada)
                {
                    Tuple<DateTime, double> elementoAAgregar = Tuple.Create(fechaUltimaModificacion, valorActual);
                    historicoDeValores.Add(elementoAAgregar);
                }
                fechaUltimaModificacion = DateTime.Now;
                valorActual = value;
                fueSeteada = true;
            }
        }

        public IList Historico
        {
            get
            {
                return historicoDeValores;
            }
        }

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

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
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

        private bool contieneCaracteresAlfabeticos(string unValor)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unValor);
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