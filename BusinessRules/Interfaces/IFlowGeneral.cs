using Entities.Dto;
using System.Threading.Tasks;

namespace BusinessRules.Interfaces
{
    /// <summary>
    /// IFlowGeneral
    /// </summary>
    public interface IFlowGeneral
    {
        Task<FlowGeneral> SearchAsyncById(int idFlow);
        Task<FlowGeneral> SearchAsyncById(int idFlow, int idUser);
        Task<bool> CreateAsync(FieldsValueByUserFlow fieldsValueByUserFlow);
    }
}
