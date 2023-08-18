using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrgAuthApi.Models.PublicDbModels
{
    [Table("TblMoadianSubSystems_H")]
    public class TblMoadianSubSystems_H
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string MoadianSubSystem { get; set; } = string.Empty;
    }
}
