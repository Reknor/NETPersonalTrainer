using System.Collections.Generic;
using System.Linq;

namespace BartlomiejJagielloLab2ZadDom.Database
{
    /// <summary>
    /// Contains all possible entry log messages
    /// </summary>
    class EntryLogMessage
    {
        // Possible message types to use
        public enum MessageType {CorrectLogin = 0, FailedLogin = 1}
        // Message text that will be put into database
        private static readonly List<string> MessageText = new List<string>()
        {
            "Correct login",
            "Failed attempt to login"
        };

        // Returns message of correct type
        public string this[int messageType]
        {
            get => MessageText.ElementAt(messageType);
        }
    }
}
