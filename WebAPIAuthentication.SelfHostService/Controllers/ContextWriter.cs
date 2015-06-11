using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIAuthentication.SelfHostService.Controllers
{
    public class ContextWriter
    {
        public async Task UsingAsync()
        {
            Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
                , IdentityClaimsReader.GetInstallId()
                , "Async"
                , Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
        }

        public void UsingParallelForEach()
        {
            var numbers = new [] {1, 2, 3};
            Parallel.ForEach(numbers, current => Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
                , IdentityClaimsReader.GetInstallId()
                , "ParallelForEach"
                , Thread.CurrentThread.ManagedThreadId));
        }

        public void UsingTpl()
        {
            var numbers = new[] { 1, 2, 3 };

            List<Task> tasks = new List<Task>();
            CancellationTokenSource cancelToken = new CancellationTokenSource();

            string result = String.Empty;

            Task taskOne = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
                    , IdentityClaimsReader.GetInstallId()
                    , "TPL 1"
                    , Thread.CurrentThread.ManagedThreadId);
                cancelToken.Token.ThrowIfCancellationRequested();
            }, cancelToken.Token);

            Task taskTwo = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
                    , IdentityClaimsReader.GetInstallId()
                    , "TPL 2"
                    , Thread.CurrentThread.ManagedThreadId);
                cancelToken.Token.ThrowIfCancellationRequested();
            }, cancelToken.Token);

            tasks.Add(taskOne);
            tasks.Add(taskTwo);

            Task.WaitAny(tasks.ToArray());
             
        }

        public void UsingOldShcoolThreading()
        {
            Thread t1 = new Thread(() => Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
                , IdentityClaimsReader.GetInstallId()
                , "Old Shcool Threading"
                , Thread.CurrentThread.ManagedThreadId));

            Thread t2 = new Thread(() => Console.WriteLine("InstallId: {0}  ---Method:{1} ---ThreadId:{2}"
               , IdentityClaimsReader.GetInstallId()
               , "Old Shcool Threading"
               , Thread.CurrentThread.ManagedThreadId));

            t1.Start();
            t2.Start();
        }
    }

    public class IdentityClaimsReader
    {
        public static string GetInstallId()
        {
            var identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return "missing identity";

            var claim = identity.Claims.FirstOrDefault(x => x.Type == "InstallId");
            
            if (claim == null)
                return "InstallId Claim not found";

            return claim.Value;
        }
    }

}