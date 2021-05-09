using Utilities.CustomException;
using Utilities.ExtensionMethods;

namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// StepsNext
    /// </summary>
    public class StepsNext : Common.BaseBusinessRules<Entities.StepsNext, DataAccess.Interfaces.IStepsNext>, Interfaces.IStepsNext
    {
        public StepsNext(DataAccess.Common.Interfaces.IMainContext repositoryContext): base(new DataAccess.Dao.StepsNext(repositoryContext)) { }
        /// <summary>
        /// Validations To Create Steps Next
        /// </summary>
        /// <param name="entity">Is Valid</param>
        protected override void ValidationsToCreate(Entities.StepsNext entity)
        {
            if (entity.IdStep.Equals(entity.IdStepNext))
            {
                ThrowException();
            }
        }
        /// <summary>
        /// Validations To Edit Steps Next
        /// </summary>
        /// <param name="entity">Is Valid</param>
        protected override void ValidationsToEdit(Entities.StepsNext entity)
        {
            if (entity.IdStep.Equals(entity.IdStepNext))
            {
                ThrowException();
            }
        }

        /// <summary>
        /// Throw Exception
        /// </summary>
        private static void ThrowException()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to create a record because the step and the next step are the same.");
        }
    }
}
