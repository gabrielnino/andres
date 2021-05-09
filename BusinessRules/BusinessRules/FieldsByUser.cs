namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Fields By User
    /// </summary>
    public class FieldsByUser : Common.BaseBusinessRules<Entities.FieldsByUser, DataAccess.Interfaces.IFieldsByUser>, Interfaces.IFieldsByUser
    {
        public FieldsByUser(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.FieldsByUser(repositoryContext)) { }
    }
}
