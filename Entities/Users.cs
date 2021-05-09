using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Entities
{
    public class Users
    {
        public Users()
        {
            FieldsByUser = new HashSet<FieldsByUser>();
        }
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Entity's user name  
        /// </summary>
        [StringLength(150)]
        public string UserName { get; set; }
        /// <summary>
        /// Fields by user
        /// </summary>
        [InverseProperty("IdUserNavigation")]
        [JsonIgnore]
        public virtual ICollection<FieldsByUser> FieldsByUser { get; set; }
    }
}
