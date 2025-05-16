using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace almacenWPF.Models
{
    [Table("usuario")]
    public class Usuario : BaseModel
    {
        [PrimaryKey("id_user", false)]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Column("fecha_nac")]
        public DateTime FechaNac { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }
    }
}