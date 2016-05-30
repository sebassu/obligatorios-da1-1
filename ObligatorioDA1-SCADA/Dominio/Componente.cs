using Excepciones;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PruebasUnitarias")]
[assembly: AssemblyVersion("1.0")]
namespace Dominio
{
    public abstract class Componente : ElementoSCADA
    {
        protected List<Variable> variables;
        public IList Variables
        {
            get
            {
                return variables.AsReadOnly();
            }
        }

        public override void AgregarVariable(Variable unaVariable)
        {
            if (Auxiliar.NoEsNulo(unaVariable))
            {
                variables.Add(unaVariable);
                variables.Sort();
                unaVariable.ComponentePadre = this;
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
    }
}
