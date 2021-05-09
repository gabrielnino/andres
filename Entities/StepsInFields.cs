using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities
{
    public class StepsInFields
    {
        /// <summary>
        /// Id Step
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int IdStep { get; set; }
        /// <summary>
        /// Id Field
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public int IdField { get; set; }

        /// <summary>
        /// Steps In Fields
        /// </summary>
        [ForeignKey(nameof(IdField))]
        [InverseProperty(nameof(Fields.StepsInFields))]
        [JsonIgnore]
        public virtual Fields IdFieldNavigation { get; set; }
        /// <summary>
        /// Steps In Fields
        /// </summary>
        [ForeignKey(nameof(IdStep))]
        [InverseProperty(nameof(Steps.StepsInFields))]
        [JsonIgnore]
        public virtual Steps IdStepsNavigation { get; set; }
    }
}
