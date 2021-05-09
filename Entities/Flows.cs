 using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities
{
    public class Flows
    {
        public Flows()
        {
            Secuences = new HashSet<Secuences>();
        }
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        /// <summary>
        /// Entity's name  
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Secuences
        /// </summary>
        [InverseProperty("IdFlowNavigation")]
        [JsonIgnore]
        public virtual ICollection<Secuences> Secuences { get; set; }
    }
}
