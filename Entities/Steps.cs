using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class Steps
    {
        public Steps()
        {
            Secuences = new HashSet<Secuences>();
            StepsInFields = new HashSet<StepsInFields>();
            StepsNext = new HashSet<StepsNext>();
        }
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Entity's code  
        /// </summary>
        [StringLength(10)]
        public string Code { get; set; }
        /// <summary>
        /// Entity's name  
        /// </summary>
        [StringLength(10)]
        public string Name { get; set; }

        /// <summary>
        /// Secuences  
        /// </summary>
        [InverseProperty("IdStepNavigation")]
        [JsonIgnore]
        public virtual ICollection<Secuences> Secuences { get; set; }

        /// <summary>
        /// Steps in fields  
        /// </summary>
        [InverseProperty("IdStepsNavigation")]
        [JsonIgnore]
        public virtual ICollection<StepsInFields> StepsInFields { get; set; }

        /// <summary>
        /// Steps next 
        /// </summary>
        [InverseProperty("IdStepNextNavigation")]
        [JsonIgnore]
        public virtual ICollection<StepsNext> StepsNext { get; set; }
    }
}
