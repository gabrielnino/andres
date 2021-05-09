using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities
{
    public class FieldsByUser
    {
        /// <summary>
        /// Id user
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int IdUser { get; set; }
        /// <summary>
        /// Id Field
        /// </summary>
        [Key]
        [Column(Order = 2)]
        public int IdField { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [StringLength(30)]
        public string Value { get; set; }
        /// <summary>
        /// Fields by user
        /// </summary>
        [ForeignKey(nameof(IdField))]
        [InverseProperty(nameof(Fields.FieldsByUser))]
        [JsonIgnore]
        public virtual Fields IdFieldNavigation { get; set; }
        /// <summary>
        /// Fields by user
        /// </summary>
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(Users.FieldsByUser))]
        [JsonIgnore]
        public virtual Users IdUserNavigation { get; set; }
    }
}
