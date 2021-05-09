using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public  class StepsNext
    {
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
        /// Id Step Next
        /// </summary>
        [Key]
        [Column(Order = 3)]
        public int IdStepNext { get; set; }

        /// <summary>
        /// Id Secuences
        /// </summary>
        [ForeignKey("IdFlow,IdStep")]
        [InverseProperty(nameof(Secuences.StepsNext))]
        [JsonIgnore]
        public virtual Secuences Id { get; set; }


        /// <summary>
        /// Steps Next
        /// </summary>
        [ForeignKey(nameof(IdStepNext))]
        [InverseProperty(nameof(Steps.StepsNext))]
        [JsonIgnore]
        public virtual Steps IdStepNextNavigation { get; set; }
    }
}
