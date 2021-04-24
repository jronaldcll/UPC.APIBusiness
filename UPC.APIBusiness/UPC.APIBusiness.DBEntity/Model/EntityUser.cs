using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int IdUsuario { get; set; } // MEJORA: Reemplazar por Key, ID - Alias BD
        //public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public string LoginUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string DocumentoIdentidad { get; set; }
        /*  public string Nombres { get; set; }
          public string Apellidos { get; set; }
          public string Contrasenia { get; set; }
          public string Documento { get; set; }
          public DateTime FechaUltimoAcceso { get; set; }
          public DateTime FechaInactivo { get; set; }
          public string Correo { get; set; }
          public string TipoAcceso { get; set; }
          public int NroIntento { get; set; }
          public int NroSesiones { get; set; }
          public int IdUsuarioRolAplicacion { get; set; }*/

    }
}
