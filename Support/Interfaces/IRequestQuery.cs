
namespace Support.Interfaces
{
    #region namespaces
    using System.Collections.Generic;
    using System.Net.Http;
    #endregion

    /// <summary>
    /// Interface for IAwRequestQuery
    /// This will hold all the required data for a request. Will be filled from ModelBinder
    /// </summary>
    public interface IRequestQuery
    {
        /// <summary>
        /// Gets or sets Query Parameters. For e.g. any query string parameters will be extracted to key,value pair and stored here.
        /// </summary>
        IDictionary<string, string> QueryParams { get; set; }

        /// <summary>
        /// Gets or sets RequestMethod. Will be used to write custom rules
        /// </summary>
        HttpMethod RequestMethod { get; set; }
    }
}