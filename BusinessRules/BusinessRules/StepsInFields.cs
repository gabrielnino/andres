namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Steps In Fields
    /// </summary>
    public class StepsInFields : Common.BaseBusinessRules<Entities.StepsInFields, DataAccess.Interfaces.IStepsInFields>, Interfaces.IStepsInFields
    {
        public StepsInFields(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.StepsInFields(repositoryContext)) { }
    }
}
