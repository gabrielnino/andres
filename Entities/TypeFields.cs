using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities
{
    public class TypeFields
    {
        public TypeFields()
        {
            Fields = new HashSet<Fields>();
        }
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// Fields
        /// </summary>
        [InverseProperty("IdTypeFieldNavigation")]
        [JsonIgnore]
        public virtual ICollection<Fields> Fields { get; set; }
    }
}
