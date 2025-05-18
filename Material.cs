using Postgrest.Attributes;
using Postgrest.Models;

namespace almacenWPF.Models
{
    [Table("material")]
    public class Material : BaseModel
    {
        [PrimaryKey("id_mat", false)]
        public long IdMat { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; }  // "pieza" o "herramienta"

        [Column("cant_disp")]
        public int CantidadDisponible { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }

        [Column("precio")]
        public float Precio { get; set; }
    }
}
