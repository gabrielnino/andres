namespace DataAccess.Dao
{
    /// <summary>
    /// StepsInFields
    /// </summary>
    public class StepsInFields : Common.RepositoryBaseDao<Entities.StepsInFields>, Interfaces.IStepsInFields
    {
        public StepsInFields(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
