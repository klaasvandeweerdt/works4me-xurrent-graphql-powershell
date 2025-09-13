using System;
using System.IO;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.Mutations;
using Works4me.Xurrent.GraphQL.PowerShell.Client;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Uploads a file to Xurrent and returns a corresponding <see cref="AttachmentInput"/>.<br/>
    /// Use this cmdlet to create an attachment that can be referenced in subsequent GraphQL mutations.<br/>
    /// </summary>
    [Cmdlet(VerbsCommon.New, "XurrentAttachment", DefaultParameterSetName = ByPath)]
    [OutputType(typeof(AttachmentInput))]
    public class NewXurrentAttachment : XurrentCmdletBase
    {
        private const string ByPath = "ByPath";
        private const string ByStream = "ByStream";

        /// <summary>
        /// The local file system path of the file to upload.
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByPath)]
        [Alias("FullName")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Raw content stream to upload (alternative to <c>-Path</c>).
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ByStream)]
        [ValidateNotNull]
        public Stream? ContentStream { get; set; }

        /// <summary>
        /// Optional file name to associate with the uploaded stream (used only with <c>-ContentStream</c>).
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByStream)]
        [ValidateNotNullOrEmpty]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// The MIME content type of the file (e.g., <c>image/png</c>, <c>application/pdf</c>).
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ByPath)]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByStream)]
        [ValidateNotNullOrEmpty]
        public string ContentType { get; set; } = string.Empty;

        /// <summary>
        /// Indicates whether the attachment should be treated as inline content.
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ByPath)]
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ByStream)]
        [ValidateNotNull]
        public bool Inline { get; set; } = false;

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for the upload.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ByPath)]
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = ByStream)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Uploads the file using the provided or default client and writes an <see cref="AttachmentInput"/> to the pipeline.<br/>
        /// Throws a terminating error if the upload fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                AttachmentUploadResponse response;
                if (ParameterSetName == ByPath)
                {
                    FileInfo fileInfo = new(Path);
                    if (!fileInfo.Exists)
                        throw new FileNotFoundException(Path);
                    response = client.Client.UploadAttachmentAsync(Path, ContentType).GetAwaiter().GetResult();
                    response.Size = fileInfo.Length;
                }
                else
                {
                    if (ContentStream is null || !ContentStream.CanRead)
                        throw new ArgumentException($"{nameof(ContentStream)} must be a readable stream.");

                    response = client.Client.UploadAttachmentAsync(ContentStream, ContentType, FileName).GetAwaiter().GetResult();
                }

                AttachmentInput attachmentInput = new()
                {
                    Key = response.Key,
                    Inline = Inline
                };
                WriteObject(attachmentInput, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAttachment), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(NewXurrentAttachment), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
