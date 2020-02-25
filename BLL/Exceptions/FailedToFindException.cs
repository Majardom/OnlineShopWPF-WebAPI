using System;

namespace BLL.Exceptions
{
    /// <summary>
    /// Represents errors which occurs during requests to data base. 
    /// </summary>
    public class FailedToFindException : Exception
    {
        /// <summary>
        /// Creates instance of FailedToFindException.
        /// </summary>
        /// <param name="elementId">Element id.</param>
        public FailedToFindException(int elementId)
            : base($"Failed to find element with Id{elementId}")
        { }

        /// <summary>
        /// Creates instance of FailedToFindException.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public FailedToFindException(string message)
            : base(message)
        { }
    }
}
