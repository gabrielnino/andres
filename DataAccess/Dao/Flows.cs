namespace DataAccess.Dao
{
    /// <summary>
    /// Flows
    /// </summary>
    public class Flows : Common.RepositoryBaseDao<Entities.Flows>, Interfaces.IFlows
    {
        public Flows(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
