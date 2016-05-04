using System;
using System.Text.RegularExpressions;

namespace Dominio
{
    public class Tipo
    {
        private string nombre;
        private string descripcion;

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
                    throw new ArgumentException("Nombre inválido.");
                }
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    descripcion = value.Trim();
                }
                else
                {
                    throw new ArgumentException("Descripción inválida.");
                }
            }
        }

        private bool contieneCaracteresAlfabeticos(string unValor)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unValor);
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
        }

        private Tipo(string unNombre, string unaDescripcion)
        {
            Nombre = unNombre;
            Descripcion = unaDescripcion;
        }

        public override bool Equals(object unObjeto)
        {
            Tipo aComparar = unObjeto as Tipo;
            if (aComparar == null)
            {
                return false;
            }
            else
            {
                return nombre == aComparar.Nombre;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}