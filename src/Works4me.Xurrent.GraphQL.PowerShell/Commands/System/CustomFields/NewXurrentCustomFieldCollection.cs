using System.Management.Automation;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Creates a new <see cref="CustomFieldCollection"/>.<br/>
    /// If an existing collection is provided via <see cref="Collection"/>, a copy of it is created.<br/>
    /// Otherwise, a new empty collection is returned.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentCustomFieldCollection")]
    [OutputType(typeof(CustomFieldCollection))]
    public sealed class NewXurrentCustomFieldCollectionCommand : XurrentCmdletBase
    {
        /// <summary>
        /// An optional <see cref="CustomFieldCollection"/> to clone.<br/>
        /// If specified, the cmdlet returns a new collection initialized with the same values.<br/>
        /// If omitted, the cmdlet returns a new, empty collection.<br/>
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, Position = 0)]
        [ValidateNotNull]
        public CustomFieldCollection? Collection { get; set; }

        /// <summary>
        /// Creates and writes a new <see cref="CustomFieldCollection"/> to the pipeline.<br/>
        /// If <see cref="Collection"/> was provided, a new copy of it is emitted; otherwise, a new empty collection is emitted.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            CustomFieldCollection result;

            if (Collection is not null && MyInvocation.BoundParameters.ContainsKey(nameof(Collection)))
                result = new CustomFieldCollection(Collection);
            else
                result = new CustomFieldCollection();

            WriteObject(result, false);
        }
    }
}