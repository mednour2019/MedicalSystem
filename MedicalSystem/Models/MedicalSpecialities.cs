using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.Models
{
    [Table("MedicSpecialities", Schema = "DC")]

    public class MedicalSpecialities
    {
        
            [Key]
            [Display(Name = "Id")]
            public int? specId
            { get; set; }

            [Required]
            [Display(Name = "Specialite NAME")]
            [Column(TypeName = "varchar(200)")]
            public string? specName
            { get; set; }
        }
    }

