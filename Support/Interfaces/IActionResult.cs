#region namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Support.Interfaces;

#endregion

/// <summary>
/// interface for HttpActionResult
/// </summary>
public interface IActionResult : IHttpActionResult
{
    /// <summary>
    /// Gets or sets the RequestQuery
    /// </summary>
    IRequestQuery RequestQuery { get; set; }

    /// <summary>
    /// Gets or sets the RequestMessage
    /// </summary>
    HttpRequestMessage RequestMessage { get; set; }

    /// <summary>
    /// Gets or sets HttpStatusCode
    /// </summary>
    HttpStatusCode HttpStatusCode { get; set; }

    /// <summary>
    /// Gets or sets Model
    /// </summary>
    object Model { get; set; }
}