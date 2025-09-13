using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="AccountDesignQuery"/> object for building Xurrent <see cref="AccountDesign"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="AccountDesign"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAccountDesignQuery")]
    [OutputType(typeof(AccountDesignQuery))]
    public class NewXurrentAccountDesignQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="AccountDesign"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="AccountDesign"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountDesignField[] Properties { get; set; } = Array.Empty<AccountDesignField>();

        /// <summary>
        /// Includes a nested <see cref="AccountQuery"/> in the <see cref="AccountDesignQuery"/>, allowing related <see cref="Account"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public AccountQuery? Account { get; set; }

        /// <summary>
        /// Includes a nested <see cref="TranslationQuery"/> in the <see cref="AccountDesignQuery"/>, allowing related <see cref="Translation"/> data to be retrieved as part of the query.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public TranslationQuery? Translations { get; set; }

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="AccountDesignQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            AccountDesignQuery query = new();

            if (Account is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Account)))
                query.SelectAccount(Account);

            if (Translations is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Translations)))
                query.SelectTranslations(Translations);

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
