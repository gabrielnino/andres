namespace Entities.Dto
{
    public class FlowGeneral
    {
        /// <summary>
        /// Id Identify the entity 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Entity's name  
        /// </summary>
        public string Name { get; set; }
        public StepsGeneral[] StepsGeneral { get; set; }
    }
}
