using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalSystem.Models
{
    [Table("Doctors", Schema = "DC")]

    public class Doctor
    {

        [Key]
        [Display(Name = "Id")]
        public int? doctorId { get; set; }



        [Display(Name = "Full Name")]
            [Column(TypeName = "varchar(200)")]
            public string fullName{ get; set; }

          
            [Display(Name = "Image User")]
            [Column(TypeName = "varchar(250)")]
            public string? imageUser
            { get; set; }

           
            [Display(Name = "SEXE")]
            [Column(TypeName = "varchar(200)")]
            public string sexe
            { get; set; }

           
            [Display(Name = "Age")]
            [Column(TypeName = "varchar(200)")]
            public string age
            { get; set; }

           
            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime birthDay
            { get; set; }

            
            [Display(Name = "Passeport")]
            [MaxLength(8)]
            [MinLength(8)]
            [Column(TypeName = "varchar(8)")]
            public string cin
            { get; set; }

            public int? Specialiteid
            { get; set; }

            [ForeignKey("Specialiteid")]

            public MedicalSpecialities?  medicalSpecialities
            { get; set; }
        }
    }

