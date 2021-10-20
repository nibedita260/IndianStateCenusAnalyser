using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCenusAnalyser
{
    public class CenusAnalyserCustomException:Exception
    {
        public enum InvalidCenusdetails
        {
            FILE_NOT_FOUND,
            INCORRECT_FILE_TYPE,
            INVALID_HEADERS,
            INVALID_DELIMITER
        }
        public readonly InvalidCenusdetails error;
        /// <summary>
        /// creating a constructor and passing string message and exception type 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="message"></param>
        public CenusAnalyserCustomException(InvalidCenusdetails error, string message) : base(message)
        {
            this.error = error;
        }
    }
}
