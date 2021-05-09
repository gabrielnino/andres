using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Fields
    {
        public Fields()
        {
            FieldsByUser = new HashSet<FieldsByUser>();
            StepsInFields = new HashSet<StepsInFields>();
        }

        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        /// <summary>
        /// Entity's code  
        /// </summary>
        public string Code { get; set; }
        [StringLength(20)]
        /// <summary>
        /// Entity's name  
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Entity's type field  
        /// </summary>
        public int? IdTypeField { get; set; }
        
        [ForeignKey(nameof(IdTypeField))]
        [InverseProperty(nameof(TypeFields.Fields))]
        [JsonIgnore]
        public virtual TypeFields IdTypeFieldNavigation { get; set; }
        
        [InverseProperty("IdFieldNavigation")]
        [JsonIgnore]
        public virtual ICollection<FieldsByUser> FieldsByUser { get; set; }
        
        [InverseProperty("IdFieldNavigation")]
        [JsonIgnore]
        public virtual ICollection<StepsInFields> StepsInFields { get; set; }
    }
}
