using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Exeptions
{
    public class DataAccessException : Exception
    {
        public DataAccessException(Exception ex, string customMsg, ILogger logger)
        {
            logger.LogError($"main exception {ex.Message} developer custom exeption "
                + $"{customMsg}");
        }
    }
}
