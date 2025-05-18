using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace almacenWPF.Models
{
    [Table("orden")]
    public class Orden : BaseModel
    {
        [PrimaryKey("id_orden", false)]
        public long IdOrden { get; set; }

        [Column("id_folio")]
        public long IdFolio { get; set; }

        [Column("id_material")]
        public long IdMaterial { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }
    }
}
