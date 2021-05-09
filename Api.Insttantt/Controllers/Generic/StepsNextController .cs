using Api.Insttantt.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    /// <summary>
    /// Steps In Fields Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StepsNextController : BaseController<Entities.StepsNext, BusinessRules.Interfaces.IStepsNext>
    {
        public StepsNextController(BusinessRules.Interfaces.IStepsNext repoBusinessRules):base(repoBusinessRules)
        {

        }

        /// <summary>
        /// Get an entity StepsNext by Id
        /// </summary>
        /// <param name="idFlow"></param>
        /// <returns>Entity found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> SearchAsync(int idFlow)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.ToListAsync(x => x.IdFlow.Equals(idFlow)).ConfigureAwait(false))
            );
        }
    }
}
