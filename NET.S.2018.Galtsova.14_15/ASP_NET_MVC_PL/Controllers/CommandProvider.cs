using System;
using System.Collections.Generic;
using ASP_NET_MVC_PL.Controllers.Command.Implementation;

namespace ASP_NET_MVC_PL.Controllers
{
    /// <summary>
    /// Represents a command provider.
    /// </summary>
    public class CommandProvider
    {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public CommandProvider()
        {
            SetCommand(new RefillCommand(), "Refill");
            SetCommand(new WithdrawalCommand(), "Withdrawal");
        }

        /// <summary>
        /// Sets a command to the list of commands.
        /// </summary>
        /// <param name="command">A command to add.</param>
        /// <param name="commandName">A command name to add.</param>
        public void SetCommand(ICommand command, String commandName)
        {
            _commands.Add(commandName, command);
        }

        /// <summary>
        /// Gets a command from the list of commands by the <paramref name="commandName"/>.
        /// </summary>
        /// <param name="commandName">A command name to get.</param>
        /// <returns>A command from the list of commands.</returns>
        public ICommand GetCommand(String commandName)
        {
            return _commands[commandName];
        }
    }
}