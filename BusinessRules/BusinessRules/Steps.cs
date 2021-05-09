namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// BaseBusinessRules Steps
    /// </summary>
    public class Steps : Common.BaseBusinessRules<Entities.Steps, DataAccess.Interfaces.ISteps>, Interfaces.ISteps
    {
        public Steps(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.Steps(repositoryContext)) { }
    }
}
