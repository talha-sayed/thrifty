using System.Collections.Generic;
using System.Linq;
using DbUp;
using DbUp.Engine;
using Microsoft.EntityFrameworkCore;
using Thrifty.Data;

namespace Thrifty.Application.Database
{
    public class DatabaseMigrator
    {
        private readonly ThriftyDbContext _context;

        private UpgradeEngine _upgrader;

        public List<string> ExecutedScripts => _upgrader.GetExecutedScripts();

        public List<string> ScriptsToExecute => _upgrader.GetScriptsToExecute().Select(x=>x.Name).ToList();

        public DatabaseMigrator(ThriftyDbContext context)
        {
            _context = context;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;

            _upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(Thrifty.Database.Program).Assembly)
                .WithTransactionPerScript()
                .LogToConsole()
                .Build();
        }

        public void Migrate()
        {
            _upgrader.PerformUpgrade();
        }
    }
}
