namespace HarshaBank.Configuration
{
    /// <summary>
    /// Represents application-wide configuration settings used across the system.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Represents the starting customer code value.
        /// This value can be incremented when creating new customers.
        /// </summary>
        public static long BaseCustomerCode { get; set; } = 10000;


        /// <summary>
        /// Represents the starting account number used as a base for generating new accounts.
        /// </summary>
        public static long BaseAccountCode { get; set; } = 1000;
    }
}
