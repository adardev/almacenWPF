using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace almacenWPF.Models
{
    [Table("material")]
    public class Material : BaseModel
    {
        [PrimaryKey("id_mat", false)]
        public long IdMat { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }

        [Column("cant_disp")]
        public int CantidadDisponible { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("precio")]
        public float Precio { get; set; }
    }
}
