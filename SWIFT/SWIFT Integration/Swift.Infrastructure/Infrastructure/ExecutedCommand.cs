using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swift.Infrastructure.Infrastructure.Box.Interfaces;

namespace Swift.Infrastructure.Infrastructure
{
    public class ExecutedCommand<TCommandResult> : IContent<IOptional<TCommandResult>>
    {
        private readonly List<TCommandResult> _results = new List<TCommandResult>();
        public ExecutedCommand(ICommand<TCommandResult> command)
        {
            _results.Add(command.Execute());
        }

        IOptional<TCommandResult> IContent<IOptional<TCommandResult>>.Content()
        {
            throw new NotImplementedException();
        }
    }
}
