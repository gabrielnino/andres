namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Fields
    /// </summary>
    public class Fields : Common.BaseBusinessRules<Entities.Fields, DataAccess.Interfaces.IFields>, Interfaces.IFields
    {
        public Fields(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.Fields(repositoryContext)) { }
    }
}
