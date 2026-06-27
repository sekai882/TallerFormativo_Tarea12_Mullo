using System;

namespace DesignPatterns.Models
{
    /// <summary>
    /// View model used to convey error information to the user interface.
    /// Follows the Single Responsibility Principle (SRP) by handling only
    /// error-related presentation data.
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
