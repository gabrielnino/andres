namespace DataAccess.Dao
{
    /// <summary>
    /// FieldsByUser
    /// </summary>
    public class FieldsByUser : Common.RepositoryBaseDao<Entities.FieldsByUser>, Interfaces.IFieldsByUser
    {
        public FieldsByUser(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
