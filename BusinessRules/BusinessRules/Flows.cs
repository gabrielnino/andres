namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// BaseBusinessRules Flows
    /// </summary>
    public class Flows : Common.BaseBusinessRules<Entities.Flows, DataAccess.Interfaces.IFlows>, Interfaces.IFlows
    {
        public Flows(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.Flows(repositoryContext)) { }
    }
}
