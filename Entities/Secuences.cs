using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public  class Secuences
    {
        public Secuences()
        {
            StepsNext = new HashSet<StepsNext>();
        }
        /// <summary>
        /// Id Flow
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int IdFlow { get; set; }
        /// <summary>
        /// Id Step
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public int IdStep { get; set; }
        /// <summary>
        /// Is Firts
        /// </summary>
        public bool IsFirts { get; set; }

        /// <summary>
        /// Secuences
        /// </summary>
        [ForeignKey(nameof(IdFlow))]
        [InverseProperty(nameof(Flows.Secuences))]
        [JsonIgnore]
        public virtual Flows IdFlowNavigation { get; set; }
        /// <summary>
        /// Id Step Navigation
        /// </summary>
        [ForeignKey(nameof(IdStep))]
        [InverseProperty(nameof(Steps.Secuences))]
        [JsonIgnore]
        public virtual Steps IdStepNavigation { get; set; }

        /// <summary>
        /// Steps Next
        /// </summary>
        [InverseProperty("Id")]
        [JsonIgnore]
        public virtual ICollection<StepsNext> StepsNext { get; set; }
    }
}
