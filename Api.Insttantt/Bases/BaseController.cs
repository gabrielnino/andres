using Api.Insttantt.Bases;
using DataAccess.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Insttantt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T, TImplementacion> : BaseUtilities
    where T : class, new()
    where TImplementacion : IRepositoryBase<T>, BusinessRules.Common.Interfaces.IBaseBusinessRules<T>
    {
        protected readonly TImplementacion RepoBusinessRules;

        public BaseController(TImplementacion repoBusinessRules)
        {
            RepoBusinessRules = repoBusinessRules;
        }

        /// <summary>
        /// Get all entities available
        /// </summary>
        /// <returns>List all entities available</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> ToListAsync()
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.ToListAsync().ConfigureAwait(false))
            );
        }
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>The entity was created by return Id </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> CreateAsync([FromBody] T t)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.CreateAsync(t).ConfigureAwait(false))
            );
        }

        /// <summary>
        /// Edit a entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Result of operation</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> EditAsync([FromBody] T t)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.EditAsync(t).ConfigureAwait(false))
            );
        }

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <param name="t"></param>
        /// <returns>Result of operation</returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public Task<IActionResult> DeleteAsync([FromBody] T t)
        {
            return ExceptionBehaviorAsync
            (
                async () => ResultApi(await RepoBusinessRules.DeleteAsync(t).ConfigureAwait(false))
            );
        }

    }
}
