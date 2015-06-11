using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPIAuthentication.SelfHostService.Controllers
{
    public class ContextValidationController : ApiController
    {
        
        [HttpGet]
        public async Task<IHttpActionResult> TestAsync()
        {
           
            Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
               , IdentityClaimsReader.GetInstallId()
               , "Controller"
               , Thread.CurrentThread.ManagedThreadId);

            var contextwriter = new ContextWriter();
            
            contextwriter.UsingParallelForEach();
            contextwriter.UsingTpl();
            contextwriter.UsingOldShcoolThreading();

            await contextwriter.UsingAsync();

            return Ok();
        }
    }
}
