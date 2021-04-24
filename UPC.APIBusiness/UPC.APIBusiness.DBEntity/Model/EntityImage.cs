using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityImage : EntityBase
    {
		public int IdImagen { get; set; }
		public string Nombre { get; set; }
		public string Ruta { get; set; }
		public string IdProyecto { get; set; }
		public int UdDepartamento { get; set; }
		public string Tipo { get; set; }
	}
}
