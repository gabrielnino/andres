using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    /// <summary>
    /// Flows Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FlowsController :BaseController<Entities.Flows, BusinessRules.Interfaces.IFlows>
    {
        public FlowsController(BusinessRules.Interfaces.IFlows repoBusinessRules) : base(repoBusinessRules)
        {

        }

        /// <summary>
        /// Get an entity Flows by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> SearchAsync(int id)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.ToListAsync(x => x.Id.Equals(id)).ConfigureAwait(false))
            );
        }
    }
}
