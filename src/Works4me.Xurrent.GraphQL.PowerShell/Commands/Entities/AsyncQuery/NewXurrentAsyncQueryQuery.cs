using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AsyncQueryQuery"/> object for building Xurrent <see cref="AsyncQuery"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AsyncQuery"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAsyncQueryQuery")]
    [OutputType(typeof(AsyncQueryQuery))]
    public class NewXurrentAsyncQueryQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AsyncQuery"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AsyncQuery"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AsyncQueryField[] Properties { get; set; } = Array.Empty<AsyncQueryField>();

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AsyncQueryQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="PersonQuery"/> in the <see cref="AsyncQueryQuery"/>, allowing related <see cref="Person"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public PersonQuery? Person { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AsyncQueryQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AsyncQueryQuery query = new();

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Person is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Person)))
                query.SelectPerson(Person);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
