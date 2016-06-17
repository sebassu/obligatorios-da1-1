using Excepciones;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PruebasUnitarias")]
[assembly: AssemblyVersion("2.0")]
namespace Dominio
{
    public abstract class Componente : ElementoSCADA
    {
        protected List<Variable> variables;
        public override List<Variable> Variables
        {
            get
            {
                return variables;
            }
            protected set
            {
                variables = value;
            }
        }

        public override void AgregarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Add(unaVariable);
                variables.Sort();
                unaVariable.ElementoPadre = this;
            }
            else
            {
                throw new ElementoSCADAExcepcion("Variable nula recibida.");
            }
        }

        public override void EliminarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Remove(unaVariable);
                variables.Sort();
            }
            else
            {
                throw new ElementoSCADAExcepcion("Variable nula recibida.");
            }
        }

        protected Componente(string unNombre) : base(unNombre)
        {
            variables = new List<Variable>();
        }

        public Componente() : base()
        {
            variables = new List<Variable>();
        }
    }
}
