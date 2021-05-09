namespace DataAccess.Dao
{
    /// <summary>
    /// StepsNext
    /// </summary>
    public class StepsNext : Common.RepositoryBaseDao<Entities.StepsNext>, Interfaces.IStepsNext
    {
        public StepsNext(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
