using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityApartment : EntityBase
    {
        public int IdDepartamento { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Piso { get; set; }
        public string Ubicacion { get; set; }
    }
}
