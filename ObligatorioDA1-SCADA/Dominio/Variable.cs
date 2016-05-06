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

        private bool estaFueraDeRango;
        public bool EstaFueraDeRango
        {
            get
            {
                return estaFueraDeRango;
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
                if (Auxiliar.NoEsNulo(dispositivoPadre))
                {
                    if (!estaFueraDeRango && ValorFueraDeRango(value))
                    {
                        dispositivoPadre.IncrementarAlarmas();

                    }
                    else if (estaFueraDeRango && !ValorFueraDeRango(value))
                    {
                        dispositivoPadre.DecrementarAlarmas();
                    }
                }
                estaFueraDeRango = ValorFueraDeRango(value);
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

        private Dispositivo dispositivoPadre;
        public Dispositivo DispositivoPadre
        {
            get
            {
                return dispositivoPadre;
            }
            set
            {
                if (Auxiliar.NoEsNulo(value) && value.Variables.Contains(this))
                {
                    dispositivoPadre = value;
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

        private bool ValorFueraDeRango(double unValor)
        {
            return unValor < minimo || unValor > maximo;
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