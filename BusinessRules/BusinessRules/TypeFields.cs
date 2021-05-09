namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Type Fields
    /// </summary>
    public class TypeFields : Common.BaseBusinessRules<Entities.TypeFields, DataAccess.Interfaces.ITypeFields>, Interfaces.ITypeFields
    {
        /// <summary>
        /// New Type Fields
        /// </summary>
        /// <param name="repositoryContext"></param>
        public TypeFields(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.TypeFields(repositoryContext)) { }
    }
}
