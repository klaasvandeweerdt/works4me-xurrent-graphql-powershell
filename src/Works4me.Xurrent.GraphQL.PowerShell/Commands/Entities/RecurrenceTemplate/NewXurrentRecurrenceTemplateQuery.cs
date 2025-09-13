using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="RecurrenceTemplateQuery"/> object for building Xurrent <see cref="RecurrenceTemplate"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="RecurrenceTemplate"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentRecurrenceTemplateQuery")]
    [OutputType(typeof(RecurrenceTemplateQuery))]
    public class NewXurrentRecurrenceTemplateQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="RecurrenceTemplate"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="RecurrenceTemplate"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RecurrenceTemplateField[] Properties { get; set; } = Array.Empty<RecurrenceTemplateField>();

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="RecurrenceTemplateQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? Calendar { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="RecurrenceTemplateQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            RecurrenceTemplateQuery query = new();

            if (Calendar is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Calendar)))
                query.SelectCalendar(Calendar);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
