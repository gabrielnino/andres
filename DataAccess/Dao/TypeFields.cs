namespace DataAccess.Dao
{
    /// <summary>
    /// TypeFields
    /// </summary>
    public class TypeFields : Common.RepositoryBaseDao<Entities.TypeFields>, Interfaces.ITypeFields
    {
        public TypeFields(Common.Interfaces.IMainContext contexto) : base(contexto) { }
    }
}
