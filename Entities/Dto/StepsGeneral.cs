namespace Entities.Dto
{
    public class StepsGeneral
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
        /// Stepts's is firt
        /// </summary>
        public bool IsFirts { get; set; }
        public int[] IdStepsNext { get; set; }
        public FieldGeneral[] FieldGeneral { get; set; }
    }
}
