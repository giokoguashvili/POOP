using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Web.Api.Infrastructure;

namespace PeopleSearch.Web.Api.Domain
{
    public class ExecutedCommand
    {
        private readonly ICommand _command;

        public ExecutedCommand(ICommand command)
        {
            _command = command;
        }

        public bool Success
        {
            get
            {
                try
                {
                    _command.Execute();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }
}
