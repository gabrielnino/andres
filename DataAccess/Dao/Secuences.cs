namespace DataAccess.Dao
{
    /// <summary>
    /// Secuences
    /// </summary>
    public class Secuences : Common.RepositoryBaseDao<Entities.Secuences>, Interfaces.ISecuences
    {
        public Secuences(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
