using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="StandardServiceRequestQuery"/> object for building Xurrent <see cref="StandardServiceRequest"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="StandardServiceRequest"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentStandardServiceRequestQuery")]
    [OutputType(typeof(StandardServiceRequestQuery))]
    public class NewXurrentStandardServiceRequestQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="StandardServiceRequest"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="StandardServiceRequest"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public StandardServiceRequestField[] Properties { get; set; } = Array.Empty<StandardServiceRequestField>();

        /// <summary>
        /// Includes a nested <see cref="RequestTemplateQuery"/> in the <see cref="StandardServiceRequestQuery"/>, allowing related <see cref="RequestTemplate"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public RequestTemplateQuery? RequestTemplate { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="StandardServiceRequestQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResolutionTargetNotificationScheme { get; set; }

        /// <summary>
        /// Includes a nested <see cref="SlaNotificationSchemeQuery"/> in the <see cref="StandardServiceRequestQuery"/>, allowing related <see cref="SlaNotificationScheme"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public SlaNotificationSchemeQuery? ResponseTargetNotificationScheme { get; set; }

        /// <summary>
        /// Includes a nested <see cref="ServiceOfferingQuery"/> in the <see cref="StandardServiceRequestQuery"/>, allowing related <see cref="ServiceOffering"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ServiceOfferingQuery? ServiceOffering { get; set; }

        /// <summary>
        /// Includes a nested <see cref="CalendarQuery"/> in the <see cref="StandardServiceRequestQuery"/>, allowing related <see cref="Calendar"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public CalendarQuery? SupportHours { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="StandardServiceRequestQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            StandardServiceRequestQuery query = new();

            if (RequestTemplate is not null && MyInvocation.BoundParameters.ContainsKey(nameof(RequestTemplate)))
                query.SelectRequestTemplate(RequestTemplate);

            if (ResolutionTargetNotificationScheme is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResolutionTargetNotificationScheme)))
                query.SelectResolutionTargetNotificationScheme(ResolutionTargetNotificationScheme);

            if (ResponseTargetNotificationScheme is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ResponseTargetNotificationScheme)))
                query.SelectResponseTargetNotificationScheme(ResponseTargetNotificationScheme);

            if (ServiceOffering is not null && MyInvocation.BoundParameters.ContainsKey(nameof(ServiceOffering)))
                query.SelectServiceOffering(ServiceOffering);

            if (SupportHours is not null && MyInvocation.BoundParameters.ContainsKey(nameof(SupportHours)))
                query.SelectSupportHours(SupportHours);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
