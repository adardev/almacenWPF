using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace almacenWPF.Models
{
    [Table("usuario")]
    public class Usuario : BaseModel
    {
        [PrimaryKey("id_user", false)]
        public long IdUser { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("fecha_nac")]
        public string FechaNacimiento { get; set; } // Mejor usar DateTime si el campo es tipo fecha en la BD

        [Column("tipo")]
        public string Tipo { get; set; } // "admin", "usuario", etc.
    }
}
