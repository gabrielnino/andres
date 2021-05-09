using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Utilities.CustomException;

namespace Api.Insttantt.Bases
{
    /// <summary>
    /// Base Utilities
    /// </summary>
    public class BaseUtilities : ControllerBase
    {
        /// <summary>
        /// Result Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objResult"></param>
        /// <returns>Action Result</returns>
        protected IActionResult ResultApi<T>(T objResult)
        { 
            return StatusCode(StatusCodes.Status200OK, objResult); 
        }
        /// <summary>
        /// Exception BehaviorAsync
        /// </summary>
        /// <param name="fnCallBack"></param>
        /// <returns>Action Result</returns>
        protected async Task<IActionResult> ExceptionBehaviorAsync(Func<Task<IActionResult>> fnCallBack)
        {
            try
            {
                return await fnCallBack().ConfigureAwait(false);
            }
            catch (CustomException ex) 
            { 
                return ExceptionResultApi(ex); 
            }
        }
        /// <summary>
        /// ExceptionBehavior
        /// </summary>
        /// <param name="fnCallBack"></param>
        /// <returns>Action Result</returns>
        protected IActionResult ExceptionBehavior(Func<IActionResult> fnCallBack)
        {
            try
            {
                return fnCallBack();
            }
            catch (CustomException ex) 
            { 
                return ExceptionResultApi(ex); 
            }
        }
        /// <summary>
        /// ResultResponseApi
        /// </summary>
        /// <param name="statusCodes"></param>
        /// <param name="messages"></param>
        /// <returns>Action Result</returns>
        private IActionResult ResultResponseApi(int statusCodes, string messages)
        {
            return StatusCode(statusCodes, messages);
        }
        /// <summary>
        /// ResultResponseApi
        /// </summary>
        /// <param name="statusCodes">status codes</param>
        /// <param name="message">message</param>
        /// <param name="tags">tags</param>
        /// <returns>Action Result</returns>
        private IActionResult ResultResponseApi(int statusCodes, TypeCustomException message, string[] tags)
        {
            return StatusCode(statusCodes, new ResponseApi(message, tags));
        }
        /// <summary>
        /// ResponseApi
        /// </summary>
        internal class ResponseApi
        {
            /// <summary>
            /// Type Custom Exception
            /// </summary>
            private TypeCustomException message;
            /// <summary>
            /// tags
            /// </summary>
            private readonly string[] tags;

            /// <summary>
            /// ResponseApi
            /// </summary>
            /// <param name="message">message</param>
            /// <param name="tags">tags</param>
            public ResponseApi(TypeCustomException message, string[] tags)
            {
                this.message = message;
                this.tags = tags;
            }
        }
        /// <summary>
        /// Exception ResultApi
        /// </summary>
        /// <param name="cusException"></param>
        /// <returns>Action Result</returns>
        protected IActionResult ExceptionResultApi(CustomException cusException)
        {
            
            if (cusException != null)
            {
                return ResultResponseApi
                (
                        (
                            cusException.TypeException == TypeCustomException.Validation ?
                            StatusCodes.Status400BadRequest :
                            StatusCodes.Status500InternalServerError
                         ),
                        cusException.Message
                );
            }

            return ResultResponseApi(StatusCodes.Status500InternalServerError, "General error");
        }
    }


}
