using System;
using System.Collections;
using System.Collections.Generic;

namespace Dominio
{
    public class Dispositivo
    {

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
                    throw new ArgumentException("Tipo inválido.");
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
                enUso = value;
            }
        }

        private List<Variable> variables;
        public IList Variables
        {
            get
            {
                return variables.AsReadOnly();
            }
        }

        private uint cantidadAlarmasActivas;
        public uint CantidadAlarmasActivas
        {
            get
            {
                return cantidadAlarmasActivas;
            }
        }

        public void IncrementarAlarmas()
        {
            if (variables.Count == 0)
            {
                throw new InvalidOperationException("La lista de variables controladas es vacía.");
            }
            else
            {
                cantidadAlarmasActivas = cantidadAlarmasActivas + 1;
            }
        }

        public void DecrementarAlarmas()
        {
            if (cantidadAlarmasActivas == 0)
            {
                throw new InvalidOperationException("La cantidad de alarmas activas es cero.");
            }
            else
            {
                cantidadAlarmasActivas = cantidadAlarmasActivas - 1;
            }
        }

        public void AgregarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Add(unaVariable);
                unaVariable.DispositivoPadre = this;
            }
            else
            {
                throw new ArgumentException("Variable nula recibida.");
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

        private Dispositivo()
        {
            nombre = "Nombre inválido.";
            tipoDispositivo = Tipo.TipoInvalido();
        }

        private Dispositivo(string unNombre, Tipo unTipo, bool estaEnUso)
        {
            Nombre = unNombre;
            Tipo = unTipo;
            enUso = estaEnUso;
            variables = new List<Variable>();
        }
    }
}
