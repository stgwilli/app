using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommands
    {
        IEnumerable<IProcessOneRequest> the_commands;

        public CommandRegistry(IEnumerable<IProcessOneRequest> the_commands)
        {
            this.the_commands = the_commands;
        }

        public IProcessOneRequest get_the_command_that_can_process(IContainRequestInformation request)
        {
            return the_commands.FirstOrDefault(x => x.can_process(request));
        }
    }
}