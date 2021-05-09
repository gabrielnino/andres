namespace DataAccess.Dao
{
    /// <summary>
    /// Fields
    /// </summary>
    public class Fields : Common.RepositoryBaseDao<Entities.Fields>, Interfaces.IFields
    {
        public Fields(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
