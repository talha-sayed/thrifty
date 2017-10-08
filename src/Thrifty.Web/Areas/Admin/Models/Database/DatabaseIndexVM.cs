using System.Collections.Generic;

namespace Thrifty.Web.Areas.Admin.Models.Database
{
    public class DatabaseIndexVM
    {
        public List<string> ScriptsExecuted { get; set; }
        public List<string> ScriptsToExecute { get; set; }
    }
}
