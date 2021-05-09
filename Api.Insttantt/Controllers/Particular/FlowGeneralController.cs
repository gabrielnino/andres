using Api.Insttantt.Bases;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowGeneralController : BaseUtilities
    {
        BusinessRules.Interfaces.IFlowGeneral RepoBusinessRules;
        public FlowGeneralController(BusinessRules.Interfaces.IFlowGeneral repoBusinessRules)
        {
            RepoBusinessRules = repoBusinessRules;
        }

        /// <summary>
        /// Get an entity TypeFields by Id
        /// </summary>
        /// <param name="idFlow"></param>
        /// <returns>Entity found</returns>
        [HttpGet("{idFlow}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> SearchAsync(int idFlow)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.SearchAsyncById(idFlow).ConfigureAwait(false))
            );
        }

        /// <summary>
        /// Get an entity TypeFields by Id idFlow and idUser
        /// </summary>
        /// <param name="idFlow"></param>
        /// <param name="idUser"></param>
        /// <returns>Entity found Flow</returns>
        [HttpGet("{idFlow}/{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> SearchAsync(int idFlow, int idUser)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.SearchAsyncById(idFlow, idUser).ConfigureAwait(false))
            );
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> CreateAsync([FromBody] FieldsValueByUserFlow fieldsValueByUserFlow)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.CreateAsync(fieldsValueByUserFlow).ConfigureAwait(false))
            );
        }
    }
}
