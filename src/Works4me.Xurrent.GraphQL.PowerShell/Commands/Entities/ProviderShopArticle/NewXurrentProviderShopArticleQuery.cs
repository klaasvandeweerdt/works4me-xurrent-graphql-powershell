using System;
using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="ProviderShopArticleQuery"/> object for building Xurrent <see cref="ProviderShopArticle"/> queries.<br/>
    /// This cmdlet is used to define related objects to include when querying <see cref="ProviderShopArticle"/> data through the Xurrent GraphQL API.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentProviderShopArticleQuery")]
    [OutputType(typeof(ProviderShopArticleQuery))]
    public class NewXurrentProviderShopArticleQuery : XurrentCmdletBase
    {
        /// <summary>
        /// Specifies the <see cref="ProviderShopArticle"/> fields to include in the query result.<br/>
        /// This parameter is mandatory and determines which <see cref="ProviderShopArticle"/> data is returned from the Xurrent GraphQL API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNull]
        public ProviderShopArticleField[] Properties { get; set; } = Array.Empty<ProviderShopArticleField>();

        /// <summary>
        /// Executes the cmdlet processing logic.<br/>
        /// Builds a <see cref="ProviderShopArticleQuery"/> based on the provided parameters and writes the configured query object to the pipeline.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            ProviderShopArticleQuery query = new();

            query.Select(Properties);
            WriteObject(query);
        }
    }
}
