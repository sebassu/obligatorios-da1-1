using System;
using System.Collections.Generic;
using Dominio;

namespace Persistencia
{
    class StrategyArchivoDeTexto : Strategy
    {
        private List<Incidente> incidentes;
        public override void Actualizar(Incidente entidadAActualizar)
        {
            throw new NotImplementedException();
        }

        public override void Eliminar(Incidente entidadAEliminar)
        {
            throw new NotImplementedException();
        }

        public override void Insertar(Incidente entidad)
        {
            string fecha = entidad.Fecha.ToString();
            string nivelGravedad = entidad.NivelGravedad.ToString();

            string[] lineas = new string[] { entidad.Descripcion, fecha, nivelGravedad };

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(lineas);

            file.Close();
        }

        public override List<Incidente> Obtener()
        {
            throw new NotImplementedException();
        }
    }
}
