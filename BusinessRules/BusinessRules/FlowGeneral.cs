using Entities.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.CustomException;
using System.Linq;
using Utilities.TypeField;

namespace BusinessRules.BusinessRules
{
    /// <summary>
    /// Flow General
    /// </summary>
    public class FlowGeneral :  Interfaces.IFlowGeneral
    {
        DataAccess.Common.Interfaces.IMainContext RepositoryContext;
        public FlowGeneral(DataAccess.Common.Interfaces.IMainContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        /// <summary>
        /// SearchAsync Flow By Id 
        /// </summary>
        /// <param name="idFlow"></param>
        /// <returns></returns>
        public Task<Entities.Dto.FlowGeneral> SearchAsyncById(int idFlow)
        {
            var flow = new Flows(RepositoryContext).SearchAsync(x => x.Id.Equals(idFlow));
            if (flow.Result == null)
            {
                ThrowExceptionFlow();
            }
            var secuences = new Secuences(RepositoryContext).ToListAsync((x => x.IdFlow.Equals(idFlow)));
            if (secuences.Result == null)
            {
                ThrowExceptionSecuences();
            }
            return Task.FromResult
            (
                new Entities.Dto.FlowGeneral()
                {
                    Id = flow.Result.Id,
                    Name = flow.Result.Name,
                    StepsGeneral = GetStepsByFlow(secuences.Result).ToArray()
                }
            );
        }
        /// <summary>
        /// SearchAsync Flow By idFlow and idUser
        /// </summary>
        /// <param name="idFlow">id Flow</param>
        /// <param name="idUser">id User</param>
        /// <returns></returns>
        public Task<Entities.Dto.FlowGeneral> SearchAsyncById(int idFlow,int idUser)
        {
           
            var flow = new Flows(RepositoryContext).SearchAsync(x => x.Id.Equals(idFlow));
            if (flow.Result == null)
            {
                ThrowExceptionFlow();
            }
            var secuences = new Secuences(RepositoryContext).ToListAsync((x => x.IdFlow.Equals(idFlow)));
            if (secuences.Result == null)
            {
                ThrowExceptionSecuences();
            }
            return Task.FromResult
            (
                new Entities.Dto.FlowGeneral()
                {
                    Id = flow.Result.Id,
                    Name = flow.Result.Name,
                    StepsGeneral = GetStepsByFlow(secuences.Result,idUser).ToArray()
                }
            );
        }
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="fieldsValueByUserFlow"></param>
        /// <returns>Is Create</returns>
        public Task<bool> CreateAsync(FieldsValueByUserFlow fieldsValueByUserFlow)
        {
            var fieldsByUserFlow = SearchAsyncById(fieldsValueByUserFlow.IdFlow, fieldsValueByUserFlow.IdUser);
            if (fieldsByUserFlow.Result == null)
            {
                ThrowExceptionFlowByUser();
            }
            if (!CheckContainsAllFields(fieldsValueByUserFlow, fieldsByUserFlow.Result))
            {
                ThrowExceptionCheckContainsAllFieldr();
            }
            if (!ValidType(fieldsValueByUserFlow))
            {
                ThrowExceptionCheckValueTypeByField();
            }
           
            if (!SaveFieldValueByUser(fieldsValueByUserFlow))
            {
                return Task.FromResult
                (
                    false
                );
            }
            return Task.FromResult
            (
                true
            );
        }
        /// <summary>
        /// SaveField Value ByUser
        /// </summary>
        /// <param name="fieldsValueByUserFlow">fields Value ByUser Flow</param>
        /// <returns>Is Save</returns>
        private bool SaveFieldValueByUser(FieldsValueByUserFlow fieldsValueByUserFlow)
        {
            var result = true;
            var fieldsByUser = new FieldsByUser(this.RepositoryContext);
            foreach (FieldsValue fieldsValue in fieldsValueByUserFlow.fieldsValue)
            {
                var idFields = fieldsByUser.CreateAsync(GetFieldsByUser(fieldsValueByUserFlow, fieldsValue));
                if (idFields.Result == null) 
                { 
                    result = false; 
                    break; 
                }
            }
            return result;
        }
        /// <summary>
        /// Get Fields By User
        /// </summary>
        /// <param name="fieldsValueByUserFlow">fields Value By User Flow</param>
        /// <param name="fieldsValue">fields Value</param>
        /// <returns></returns>
        private static Entities.FieldsByUser GetFieldsByUser(FieldsValueByUserFlow fieldsValueByUserFlow, FieldsValue fieldsValue)
        {
            return new Entities.FieldsByUser()
            {
                IdUser = fieldsValueByUserFlow.IdUser,
                IdField = fieldsValue.Id,
                Value = fieldsValue.Value
            };
        }
        /// <summary>
        /// Valid Type
        /// </summary>
        /// <param name="fieldsValueByUserFlow">fields Value By User Flow</param>
        /// <returns>Is Valid Type</returns>
        private bool ValidType(FieldsValueByUserFlow fieldsValueByUserFlow)
        {
            var result = true;
            var fieldConnection = new Fields(this.RepositoryContext);
            foreach (FieldsValue fieldsValue in fieldsValueByUserFlow.fieldsValue)
            {
                var field = fieldConnection.SearchAsync(x=>x.Id.Equals(fieldsValue.Id));
                if(field.Result == null)
                {
                    ThrowExceptionField();
                }

                var strategy = new ValidationTypeFielStrategy(BuilderType.GetStratey(GetTypeField.GetTypeById(field.Result.IdTypeField??default)));
                if(!strategy.Validate(new TypeField() { FieldValue = fieldsValue.Value }))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        /// <summary>
        /// Check Contains All Fields
        /// </summary>
        /// <param name="fieldsValueByUserFlow">fields Value By User Flow</param>
        /// <param name="result">result</param>
        /// <returns>Is Check</returns>
        private static bool CheckContainsAllFields(FieldsValueByUserFlow fieldsValueByUserFlow, Entities.Dto.FlowGeneral result)
        {
            var isValid = true;
            foreach (StepsGeneral step in result.StepsGeneral)
            {
                foreach (FieldGeneral field in step.FieldGeneral)
                {
                    var fieldFound = fieldsValueByUserFlow.fieldsValue.Where(x => x.Id.Equals(field.Id));
                    if (fieldFound.Count().Equals(0))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (!isValid)
                {
                    break;
                }
            }
            return isValid;
        }
        /// <summary>
        /// Get Steps By Flow
        /// </summary>
        /// <param name="steps">steps</param>
        /// <returns>List StepsGeneral</returns>
        private List<StepsGeneral> GetStepsByFlow(List<Entities.Secuences> steps)
        {
            return GetStepsByFlow(steps, null);
        }
        /// <summary>
        /// Get Steps By Flow
        /// </summary>
        /// <param name="steps">steps</param>
        /// <param name="idUser">idUser</param>
        /// <returns>List Steps General</returns>
        private List<StepsGeneral> GetStepsByFlow(List<Entities.Secuences> steps,int? idUser)
        {
            var flowSteps = new List<StepsGeneral>();
            steps.ForEach(delegate (Entities.Secuences step)
            {
                var stepsNext = GetStepsNext(step);
                var stepsInFields = new StepsInFields(RepositoryContext).ToListAsync(x => x.IdStep == step.IdStep);
                if (stepsInFields.Result == null)
                {
                    ThrowExceptionField();
                }
                List<FieldGeneral> fieldsByStep = GetFildGeneralBySteps(stepsInFields.Result);
                if(idUser != null)
                {
                    var listFields = new List<int>();
                    fieldsByStep.ForEach(delegate (FieldGeneral field)
                    {
                        listFields.Add(field.Id);
                    }
                    );
                    var fieldsByUser = new FieldsByUser(RepositoryContext).ToListAsync
                    (
                        x => x.IdUser.Equals(idUser) && listFields.Contains(x.IdField)
                    );
                    var listFieldsNotExist = new List<int>();
                    fieldsByUser.Result.ForEach(delegate (Entities.FieldsByUser field)
                    {
                        listFieldsNotExist.Add(field.IdField);
                    }
                    );
                    if (fieldsByUser.Result != null)
                    {
                        fieldsByStep = fieldsByStep.Where(x => !listFieldsNotExist.Contains(x.Id)).ToList();
                    }
                }
                flowSteps.Add(GetStepsGeneral(step, stepsNext, fieldsByStep));
            });
            return flowSteps;
        }
        /// <summary>
        /// GetStepsNext
        /// </summary>
        /// <param name="step">step</param>
        /// <returns>List int</returns>
        private static List<int> GetStepsNext(Entities.Secuences step)
        {
            return (from Entities.StepsNext stepNext in step.StepsNext
                    select stepNext.IdStepNext).ToList();
        }
        /// <summary>
        /// Get Steps General
        /// </summary>
        /// <param name="step">step</param>
        /// <param name="stepsNext">steps Next</param>
        /// <param name="fieldsByStep">fields By Step</param>
        /// <returns></returns>
        private static StepsGeneral GetStepsGeneral(Entities.Secuences step, List<int> stepsNext, List<FieldGeneral> fieldsByStep)
        {
            return new StepsGeneral()
            {
                Id = step.IdStep,
                Code = step.IdStepNavigation.Code,
                Name = step.IdStepNavigation.Name,
                IsFirts = step.IsFirts,
                IdStepsNext = stepsNext.ToArray(),
                FieldGeneral = fieldsByStep.ToArray()
            };
        }
        /// <summary>
        /// GetFildGeneralBySteps
        /// </summary>
        /// <param name="stepsInFieldsByStep">steps In Fields By Step</param>
        /// <returns></returns>
        private List<FieldGeneral> GetFildGeneralBySteps(List<Entities.StepsInFields> stepsInFieldsByStep)
        {
            var fieldsByStep = new List<FieldGeneral>();
            stepsInFieldsByStep.ForEach(delegate (Entities.StepsInFields fields)
            {
                var field = new Fields(RepositoryContext).Search(x => x.Id == fields.IdField);
                var typeFields = new TypeFields(RepositoryContext).Search(x => x.Id == field.IdTypeField);
                fieldsByStep.Add(new FieldGeneral() { Id = field.Id, Code = field.Code, Name = field.Name, IdTypeField = typeFields.Id, TypeFieldName= typeFields.Name});
            }
            );
            return fieldsByStep;
        }
        /// <summary>
        /// Throw Exception Flow
        /// </summary>
        private static void ThrowExceptionFlow()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to find a record.");
        }
        /// <summary>
        /// Throw Exception Secuences
        /// </summary>
        private static void ThrowExceptionSecuences()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to find a secuence.");
        }
        /// <summary>
        /// Throw Exception Field
        /// </summary>
        private static void ThrowExceptionField()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to find a fields.");
        }
        /// <summary>
        /// Throw Exception Flow By User
        /// </summary>
        private static void ThrowExceptionFlowByUser()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to find a flow by user validate the configuration");
        }
        /// <summary>
        /// Throw Exception Check Contains All Field
        /// </summary>
        private static void ThrowExceptionCheckContainsAllFieldr()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to create flow, check contains all fields, it has failed.");
        }
        /// <summary>
        /// Throw Exception Check Value Type By Field
        /// </summary>
        private static void ThrowExceptionCheckValueTypeByField()
        {
            throw new CustomException(TypeCustomException.Validation, "It is impossible to create flow, check type fields, it has failed.");
        }
    }
}
