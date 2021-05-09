using Api.Insttantt.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    /// <summary>
    /// Secuences Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SecuencesController : BaseController<Entities.Secuences, BusinessRules.Interfaces.ISecuences>
    {
        public SecuencesController(BusinessRules.Interfaces.ISecuences repoBusinessRules) :base(repoBusinessRules)
        {

        }

        /// <summary>
        /// Get an entity Secuences by Id
        /// </summary>
        /// <param name="idFlow">Entity found</param>
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
                async () => ResultApi(await this.RepoBusinessRules.ToListAsync(x => x.IdFlow.Equals(idFlow)).ConfigureAwait(false))
            );
        }
    }
}
