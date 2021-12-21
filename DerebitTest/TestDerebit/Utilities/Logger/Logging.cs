using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Serilog;
using Serilog.Sinks.SystemConsole;

namespace TestDerebit.Utilities.Logger
{
    class Logging
    {
        protected ILogger Logger;


        [OneTimeSetUp]
        public void LoadConfiguration()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Logger = new LoggerConfiguration().WriteTo
                .Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            Log.Logger = Logger;
        }

        [SetUp]
        public async Task OnSetup()
        {
            Logger.Information($"{TestContext.CurrentContext.Test.FullName} Started");
        }

        private async Task LogResult()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome;
            if (outcome == ResultState.Error)
            {
                Logger.Error($"Failed: {TestContext.CurrentContext.Result.Message}");
                return;
            }

            Logger.Information($"{TestContext.CurrentContext.Test.FullName} Finished with outcome: {outcome}");
        }
        [TearDown]
        public async Task OnTearDown()
        {
            await LogResult();
        }

        [OneTimeTearDown]
        public void FlushLogger()
        {
            Trace.Flush();
        }
    }
}

