namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// BaseBusinessRules Secuences
    /// </summary>
    public class Secuences : Common.BaseBusinessRules<Entities.Secuences, DataAccess.Interfaces.ISecuences>, Interfaces.ISecuences
    {
        
        public Secuences(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.Secuences(repositoryContext)) { }
    }
}
