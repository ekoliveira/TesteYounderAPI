using System.Collections.Generic;
using System.Linq;

namespace TesteYounder.Application
{
    public abstract class CasoDeUsoResponseMessage
    {
        public IEnumerable<string> Errors { get; }

        public IEnumerable<string> Information { get; }

        protected CasoDeUsoResponseMessage(IEnumerable<string> messages, bool error = true)
        {
            if (error)
                Errors = messages;
            else
                Information = messages;
        }

        protected CasoDeUsoResponseMessage(string message, bool error = true)
        {
            var msg = new List<string> { message };

            if (error)
                Errors = msg;
            else
                Information = msg;
        }

        protected CasoDeUsoResponseMessage()
        {
        }

        public bool IsValid()
        {
            return Errors == null || !Errors.Any();
        }
    }
}