using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper2.Services.Utility
{
    interface ILogger
    {
        // Debug method with optional second argument for message
        void Debug(string message, string arg = null);
        // Info method with optional secud arguement for message
        void Info(String message, string arg = null);
        // Warning method with optional second arguemtn for message
        void Warning(string message, string arg = null);
        // Error method with optional second argument for msessage
        void Error(string message, string arg = null);
    }
}
