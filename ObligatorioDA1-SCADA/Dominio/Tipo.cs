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
                if (!String.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    this.nombre = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
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
                if (!String.IsNullOrEmpty(value) && contieneCaracteresAlfabeticos(value))
                {
                    this.descripcion = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private bool contieneCaracteresAlfabeticos(string unValor)
        {
            Regex caracteresAlfabeticos = new Regex(@"[A-Z]", RegexOptions.IgnoreCase);
            return caracteresAlfabeticos.IsMatch(unValor);
        }

        private Tipo()
        {
            this.nombre = "Nombre inválido";
            this.descripcion = "Descripción inválida";
        }

        private Tipo(string unNombre, string unaDescripcion)
        {
            this.Nombre = unNombre;
            this.Descripcion = unaDescripcion;
        }

        public static Tipo TipoInvalido()
        {
            return new Tipo();
        }

        public static Tipo ConNombreDescripcion(string unNombre, string unaDescripcion)
        {
            return new Tipo(unNombre, unaDescripcion);
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
                return this.nombre == aComparar.Nombre;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}