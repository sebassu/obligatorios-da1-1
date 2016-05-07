using System;

namespace Dominio
{
    public class Tipo
    {
        private static uint ProximaIdAAsignar;
        private uint id;

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

        private string descripcion;
        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (Auxiliar.EsTextoValido(value))
                {
                    descripcion = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Descripción inválida.");
                }
            }
        }

        public static Tipo TipoInvalido()
        {
            return new Tipo();
        }

        public static Tipo NombreDescripcion(string unNombre, string unaDescripcion)
        {
            return new Tipo(unNombre, unaDescripcion);
        }

        private Tipo()
        {
            nombre = "Nombre inválido.";
            descripcion = "Descripción inválida.";
            id = ProximaIdAAsignar++;
        }

        private Tipo(string unNombre, string unaDescripcion)
        {
            Nombre = unNombre;
            Descripcion = unaDescripcion;
            id = ProximaIdAAsignar++;
        }

        public override bool Equals(object unObjeto)
        {
            Tipo tipoAComparar = unObjeto as Tipo;
            if (Auxiliar.NoEsNulo(tipoAComparar))
            {
                return id == tipoAComparar.id || nombre == tipoAComparar.Nombre;
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