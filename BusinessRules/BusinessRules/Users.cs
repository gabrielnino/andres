namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Users
    /// </summary>
    public class Users : Common.BaseBusinessRules<Entities.Users, DataAccess.Interfaces.IUsers>, Interfaces.IUsers
    {
        /// <summary>
        /// New Users
        /// </summary>
        /// <param name="repositoryContext">repositoryContext</param>
        public Users(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.Users(repositoryContext)) { }
    }
}
