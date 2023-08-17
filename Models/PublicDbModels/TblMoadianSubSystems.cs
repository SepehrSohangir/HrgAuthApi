using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrgAuthApi.Models.PublicDbModels
{
    public class TblMoadianSubSystems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string MoadianSubSystem { get; set; } = string.Empty;
    }
}
