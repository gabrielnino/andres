using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Dto
{
    public class FieldGeneral
    {
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Entity's code  
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Entity's name  
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Name Identify the entity 
        /// </summary>
        public int IdTypeField { get; set; }
        /// <summary>
        /// Name Type field the entity 
        /// </summary>
        public string TypeFieldName { get; set; }
    }
}
