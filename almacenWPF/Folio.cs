using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
namespace almacenWPF.Models
{
    [Table("folio")]
    public class Folio : BaseModel
    {
        [PrimaryKey("id_folio", false)]
        public long IdFolio { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("fecha_salida")]
        public DateTime FechaSalida { get; set; }

        [Column("fecha_entrega")]
        public DateTime FechaEntrega { get; set; }
    }
}
