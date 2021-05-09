using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    /// <summary>
    /// Fields By User Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FieldsByUserController : BaseController<Entities.FieldsByUser, BusinessRules.Interfaces.IFieldsByUser>
    {
        public FieldsByUserController(BusinessRules.Interfaces.IFieldsByUser repoBusinessRules) : base(repoBusinessRules)
        {

        }

        /// <summary>
        /// Get an entity FieldsByUser by Id
        /// </summary>d
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
                async () => ResultApi(await RepoBusinessRules.ToListAsync(x => x.IdUser.Equals(id)).ConfigureAwait(false))
            );
        }
    }
}
