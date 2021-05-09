namespace DataAccess.Dao
{
    /// <summary>
    /// Steps
    /// </summary>
    public class Steps : Common.RepositoryBaseDao<Entities.Steps>, Interfaces.ISteps
    {
        public Steps(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
