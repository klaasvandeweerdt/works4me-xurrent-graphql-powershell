using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RecurrenceQuery"/> object for building Xurrent <see cref="Recurrence"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="Recurrence"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRecurrenceQuery")]
    [OutputType(typeof(RecurrenceQuery))]
    public class NewXurrentRecurrenceQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="Recurrence"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="Recurrence"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RecurrenceField[] Properties { get; set; } = Array.Empty<RecurrenceField>();

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="RecurrenceQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? Calendar { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RecurrenceQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RecurrenceQuery query = new();

            if (Calendar is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Calendar)))
                query.SelectCalendar(Calendar);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
