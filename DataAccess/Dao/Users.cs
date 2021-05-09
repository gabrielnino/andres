namespace DataAccess.Dao
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users : Common.RepositoryBaseDao<Entities.Users>, Interfaces.IUsers
    {
        public Users(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
