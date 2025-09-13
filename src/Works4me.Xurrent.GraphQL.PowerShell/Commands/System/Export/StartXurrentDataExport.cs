using System;
using System.Management.Automation;
using Works4me.Xurrent.GraphQL.PowerShell.Client;
using Works4me.Xurrent.GraphQL.PowerShell.Enums;

namespace Works4me.Xurrent.GraphQL.PowerShell.Commands
{
    /// <summary>
    /// Starts a bulk data export job in Xurrent.<br/>
    /// The cmdlet can export data either in <c>CSV</c> or <c>Excel (XLSX)</c> format.<br/>
    /// Returns an export token string that can be used to monitor or download the export.<br/>
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "XurrentDataExport", DefaultParameterSetName = ExportCsv)]
    [OutputType(typeof(string))]
    public class StartXurrentDataExport : XurrentCmdletBase
    {
        private const string ExportCsv = "csv";
        private const string ExportExcel = "xlsx";

        /// <summary>
        /// The format of the export: <see cref="DataExportFormat.CSV"/> or <see cref="DataExportFormat.Excel"/>.<br/>
        /// Determines which export method will be invoked in the Xurrent API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportExcel)]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportCsv)]
        [ValidateNotNull]
        public DataExportFormat Format { get; set; } = DataExportFormat.CSV;

        /// <summary>
        /// Defines which line separator should be used in the CSV export.<br/>
        /// Only applicable when <see cref="Format"/> is set to <see cref="DataExportFormat.CSV"/>.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportCsv)]
        [ValidateNotNull]
        public ExportLineSeparator LineSeparator { get; set; } = ExportLineSeparator.LineFeed;

        /// <summary>
        /// The types of records to include in the export.<br/>
        /// These are passed directly to the bulk export API.<br/>
        /// </summary>
        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportExcel)]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportCsv)]
        [ValidateNotNull]
        public string[] Types { get; set; } = Array.Empty<string>();

        /// <summary>
        /// The lower bound of the export, expressed as a <see cref="DateTime"/>.<br/>
        /// Only records created or updated on or after this date will be included.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 2, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportExcel)]
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportCsv)]
        [ValidateNotNull]
        public DateTime? From { get; set; }

        /// <summary>
        /// Specifies the <see cref="XurrentPowerShellClient"/> instance to use for the export.<br/>
        /// If omitted, the first created client instance or active connection will be used.<br/>
        /// </summary>
        [Parameter(Mandatory = false, Position = 3, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportExcel)]
        [Parameter(Mandatory = false, Position = 4, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportCsv)]
        [ValidateNotNull]
        public XurrentPowerShellClient? Client { get; set; }

        /// <summary>
        /// Executes the export request against the Xurrent Bulk API.<br/>
        /// Depending on <see cref="Format"/>, either a CSV or Excel export job is started.<br/>
        /// Writes the export token string to the pipeline.<br/>
        /// Throws a terminating error if the request fails.<br/>
        /// </summary>
        protected override void OnProcessRecord()
        {
            try
            {
                XurrentPowerShellClient client = Client ?? XurrentPowerShellClientManager.GetClient();
                string token;
                if (Format == DataExportFormat.Excel)
                {
                    if (From is not null && MyInvocation.BoundParameters.ContainsKey(nameof(From)))
                        token = client.Client.Bulk.StartExcelExportAsync(Types, From.Value).GetAwaiter().GetResult();
                    else
                        token = client.Client.Bulk.StartExcelExportAsync(Types).GetAwaiter().GetResult();
                }
                else
                {
                    if (From is not null && MyInvocation.BoundParameters.ContainsKey(nameof(From)))
                        token = client.Client.Bulk.StartCsvExportAsync(Types, LineSeparator, From.Value).GetAwaiter().GetResult();
                    else
                        token = client.Client.Bulk.StartCsvExportAsync(Types, LineSeparator).GetAwaiter().GetResult();
                }
                WriteObject(token, false);
            }
            catch (XurrentException ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(StartXurrentDataExport), ErrorCategory.NotSpecified, this));
            }
            catch (Exception ex)
            {
                ThrowTerminatingError(new ErrorRecord(ex, nameof(StartXurrentDataExport), ErrorCategory.NotSpecified, this));
            }
        }
    }
}
