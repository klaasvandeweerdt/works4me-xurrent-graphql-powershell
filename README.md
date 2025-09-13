# PowerShell Module for Xurrent GraphQL

A PowerShell Module for accessing the [Xurrent GraphQL API](https://developer.xurrent.com/graphql/), [Bulk API](https://developer.xurrent.com/v1/bulk/) and [Events API](https://developer.xurrent.com/v1/requests/events/).

## Table of Contents
- [PowerShell Gallery](#powershell-gallery)
- [Quick Example](#quick-example)
- [Introduction](#introduction)
- [Client](#client)
  - [Key properties (runtime-tunable)](#key-properties-runtime-tunable)
  - [Authentication](#authentication)
  - [Multiple tokens & rate limits](#multiple-tokens-rate-limits)
  - [Discoverability & help aligned with the GraphQL schema](#discoverability-help-aligned-with-the-graphql-schema)
- [Querying](#querying)
  - [Selecting properties](#selecting-properties)
  - [Nested selections](#nested-selections)
  - [Filtering](#filtering)
  - [Search & custom filters (entity-specific)](#search-custom-filters-entity-specific)
  - [Views (scope)](#views-scope)
  - [Sorting](#sorting)
  - [Pagination](#pagination)
  - [Custom Fields](#custom-fields)
  - [Date & time exceptions (ISO8601Timestamp)](#date-time-exceptions-iso8601timestamp)
  - [Interface-based fields](#interface-based-fields)
  - [Client selection](#client-selection)
- [Mutations](#mutations)
  - [Return shape (-ResponseQuery)](#return-shape-responsequery)
  - [Partial updates (only what you pass)](#partial-updates-only-what-you-pass)
  - [Client selection](#client-selection-1)
- [Attachments](#attachments)
- [Events API](#events-api)
- [Bulk API](#bulk-api)
- [Examples](#examples)
  - [Queries](#queries)
  - [Mutations](#mutations-1)
  - [Attachments](#attachments-1)
  - [Create a New Event via the Events API](#create-a-new-event-via-the-events-api)
  - [Bulk Import and Export](#bulk-import-and-export)
  

## PowerShell Gallery

The stable version of the module is hosted on the [PowerShell Gallery](https://www.powershellgallery.com/packages/Works4me.Xurrent.GraphQL). You can install it easily using the following command:
```powershell
Install-Module -Name Works4me.Xurrent.GraphQL
```

## Quick Example

```powershell
Import-Module Works4me.Xurrent.GraphQL

$client = New-XurrentClient -AccountId 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -PersonalAccessToken '***'

New-XurrentMeQuery -Properties Id,Name,PrimaryEmail,Disabled | Invoke-XurrentMeQuery
```

Want more? See the full [Examples](#examples) section below.

## Introduction
The module provides PowerShell cmdlets that map closely to the Xurrent GraphQL .NET SDK.
It allows you to:
- Connect to Xurrent with multiple authentication methods
- Build and execute GraphQL queries and mutations from PowerShell
- Work with custom fields, attachments, and events
- Start and download bulk data exports
- Start and await bulk data imports

## Client
The PowerShell module wraps the SDK in a session-managed client: `XurrentPowerShellClient`.
You create it via `New-XurrentClient`; the client is then registered in a per-session manager so other cmdlets can reuse it (the first registered client is used by default when a `-Client` parameter isn't provided).

### Key properties (runtime-tunable):
- `AccountId`: Active account ID for the client. You can change this after creation to switch accounts. 
- `MaximumRequestsPerQuery`: Max number of follow-up requests the SDK may issue automatically to page large result sets. Default: 1000, valid range 1...10000. Use a lower value to reduce risk of rate-limit hits on large queries. 
- `DefaultItemsPerRequest`: Items per page when the SDK fetches lists. Default: 100, valid range 1...100. 
- `MaximumConnectionDepth`: Max depth for nested connection fields in a single GraphQL query. Default: 2, valid range 1...13. Increasing this can reduce performance on deeply nested queries. 

Under the hood, clients and tokens are disposed when the XurrentPowerShellClient is disposed.

### Authentication
Create a client with `New-XurrentClient`. The cmdlet supports multiple parameter sets:
- **OAuth2**: `-ClientId` + `-ClientSecret`
- **PersonalAccessToken**: `-PersonalAccessToken`
- **Credential**: `-Credential` (PSCredential; maps to OAuth2 client credentials)
- **AuthenticationToken**: `-Tokens` (array) — pass prebuilt tokens from `New-XurrentToken`

Each set requires `-AccountId`, `-EnvironmentRegion` and `-EnvironmentType`.

#### Behavior & tuning flags
- **MaximumRequestsPerQuery**:  <1...10000> - if provided, sets the client's MaximumRequestsPerQuery (otherwise the client keeps its default 1000). 
- **DefaultItemsPerRequest**: <1...100> - sets the client's default page size (otherwise 100). 
- **MaximumConnectionDepth**: <1...13> - sets depth limit for nested connection fields (otherwise 2). 

After creation, the client is added to the session manager and becomes the implicit default for all invoking cmdlets (unless you pass `-Client`).

### Multiple tokens & rate limits
Example using multiple OAuth2 authentication tokens:

```powershell
$token1 = New-XurrentToken -ClientId 'id' -ClientSecret 'secret'
$token2 = New-XurrentToken -ClientId 'id' -ClientSecret 'secret'

$client = New-XurrentClient -AccountId 'accountID' -EnvironmentType Production -EnvironmentRegion EU -Tokens @($token1, $token2)
```

You can pass multiple tokens to a single client via `-Tokens`, which is helpful when you need more headroom for rate and query-cost limits.
The module includes `Test-XurrentClientTokenQuota` to quickly check whether any token on the client still meets your thresholds before kicking off a heavy job (defaults: `MinRateRemaining=50` and `MinCostRemaining=100`).

### Discoverability & help aligned with the GraphQL schema
Cmdlets ship with help text that mirrors the GraphQL schema where possible.
- Each `New-Xurrent<Entity>Query` exposes `-Properties` typed to `<Entity>Field` enums whose names map 1:1 to schema fields (with the same intent and descriptions).
- Related enums follow the same pattern: <Entity>OrderField, <Entity>FilterField, <Entity>View, etc.
- Use built-in help to explore what's available and how to use it:
  - `Get-Help New-XurrentPersonQuery -Detailed`
  - `Get-Help New-XurrentPersonQuery -Parameter Properties`
  - Tab-complete after `-Properties` to discover valid field names.

This keeps the PowerShell experience consistent with the schema while remaining discoverable from the console.

## Querying
The module follows a **two-step** query flow that mirrors the SDK:
- Compose a query object with `New-Xurrent<Entity>Query` (choose fields, nested selections, filters, sort, view, etc.).
- Execute it with `Invoke-Xurrent<Entity>Query` to retrieve results.

See [Query Examples](#queries) for practical usage.

### Selecting properties
- The `-Properties` parameter is **mandatory** on every `New-Xurrent<Entity>Query`. You explicitly list the fields you want returned.
- For all entities, fields are provided as strongly-typed enums (e.g., PersonField). This keeps selections consistent with the schema.

### Nested selections
- Related data is included by passing child query objects to the respective parameters on the parent query (e.g., `-Organization`, `-Teams`, `-Site`).
- This yields a single result graph shaped to the fields you selected (no additional calls needed for those nested parts).

### Filtering
- Root queries accept one or more query filters created with `New-Xurrent<Entity>QueryFilter`.
  Filters specify `-Property`, `-Operator`, and the appropriate value type (text, integer, boolean, datetime, etc.).
- Apply filters via the `-Filters` parameter on the root query (e.g., `New-XurrentPersonQuery -Filters`).
  **Filters apply only to root queries**, not to nested child queries.
- Many entities also expose a **WithId** fast path: `-WithId` returns a single record by ID and ignores all other filter conditions.
  Use this when you already know the node ID.

### Search & custom filters (entity-specific)
- Some entities support a free-text `-Search` parameter (e.g., People). Use this for quick, broad lookups.
- Where available, `-CustomFilters` lets you filter by UI-extension filterable fields (name/operator/values).
  This is specific to entities that support custom filters (e.g., People).

### Views (scope)
- Root queries support a view switch to control scope (e.g., account-wide vs. broader scopes). Set it with `-View`.
  The enum is entity-specific (e.g., `PersonView`).

### Sorting
- Use `-OrderBy` with an entity-specific order-field enum (e.g., `PersonOrderField`) and optionally `-SortOrder` (ascending/descending).
- If you omit `-SortOrder`, the module defaults to ascending.

### Pagination
- Control page size per request with `-ItemsPerRequest` (valid range 1–100). The SDK handles fetching additional pages when needed.
- At the client level, `DefaultItemsPerRequest` sets the default page size; `MaximumRequestsPerQuery` sets how many follow-ups the client will allow while fetching large result sets. (See [Client](#client) chapter.)

### Custom Fields
Many objects can contain **Custom Fields** via **UI Extensions**. The module provides cmdlets to simplify working with them:
- `New-XurrentCustomFieldCollection` — create an empty collection to include in mutations.
- `Add-XurrentCustomField` — add/update a field by `Id`; use `-Value` (typed) or `-JsonValue` (raw JSON). Returns the updated collection.
- `Get-XurrentCustomField` — read a field from results; coerce with `-As` (`String`, numeric types, `Boolean`, `DateTime`, `Raw`, `JsonString`). For JSON arrays, emits one pipeline item per element (wrap in `@(...)` to capture as an array).
- **Attachments in custom fields** — upload with `New-XurrentAttachment`, then pass via `-CustomFieldsAttachments` alongside `-CustomFields` on create/update cmdlets.
- **Use in mutations** — pass the collection to `New-Xurrent<Person|...>` / `Set-Xurrent<Person|...>` via `-CustomFields`. Field `Id` values must match the UI Extension.

### Date & time exceptions (ISO8601Timestamp)
Xurrent can return special non-datetime values for certain timestamp fields (e.g., "best effort", "no target", "clock stopped").
The SDK converts these into fixed sentinel `[datetime]` values so your scripts don't crash on parse:
- `best_effort` -> `0001-01-01 01:01:01.111`
- `no_target` -> `0002-02-02 02:02:02.222`
- `clock_stopped` -> `0003-03-03 03:03:03.333`

### Interface-based fields
- Certain fields resolve to interfaces (they can return different concrete types).
- Include the matching nested selections for the specific type(s) you expect; will be `$null` in the result.

### Client selection
- Every query cmdlet supports an optional `-Client` parameter. If omitted, the first created client from the session manager is used.

## Mutations
Mutations are used to create, update or delete single records. Each entity typically exposes:
- `New-Xurrent<Entity>` — create a record (e.g., `New-XurrentPerson`). The cmdlet builds an `*CreateInput` from the parameters you pass and executes the mutation. Returns an `*CreatePayload`.
- `Set-Xurrent<Entity>` — update a record (e.g., `Set-XurrentPerson`). Requires the record Id and builds an `*UpdateInput` from the parameters you pass. Returns an `*UpdatePayload`.

Some entities expose:
- `Remove-Xurrent<Entity>` - Delete a record (e.g., `Remove-XurrentWebhook`). Requires the record Id and return `*DeleteMutationPayload` with a `Success` property.

[Discovered Configuration Items](https://developer.xurrent.com/graphql/mutation/discoveredconfigurationitems/) is currently not available via the PowerShell Module.

See [Mutation Examples](#mutations-1) for practical usage.

### Return shape (-ResponseQuery)
- Creation and update cmdlets accept a `-ResponseQuery` parameter of the corresponding `*Query` type (e.g., `PersonQuery`).
- This defines which fields of the `*Payload` are returned by the mutation. If omitted, a **default selection** is used.

### Partial updates (only what you pass)
- Update cmdlets set only the properties you provided; **unspecified fields are left unchanged**.
- Internally, parameters are mapped to the input object **only if they were bound** in the call.

### Client selection
- Every mutation cmdlet supports an optional `-Client` parameter. If omitted, the first created client from the session manager is used.

## Attachments
Use `New-XurrentAttachment` to **upload a file** to Xurrent and get an `AttachmentInput` you can pass to any mutation that supports attachments (e.g., info/remarks, notes, custom fields).
The cmdlet handles the upload and returns a ready-to-use input object.

### What it returns
- An `AttachmentInput` with the Key (server-side reference) and your chosen `Inline` flag.
  This is the object you pass to mutation parameters such as `NoteAttachments`, `InformationAttachments`, `RemarksAttachments`, or `CustomFieldsAttachments` on any object that supports attachments.
- Attachment-capable mutation parameters accept **one** `AttachmentInput` or **many** (`AttachmentInput[]`) in the same call.

### Parameter sets
- **By path**: `-Path <string>` + `-ContentType <string>` (optional `-Inline`, optional `-Client`). The cmdlet validates the file exists before upload.
- **By stream**: `-ContentStream <Stream>` + `-FileName <string>` + `-ContentType <string>` (optional `-Inline`, optional `-Client`).

### Inline vs. non-inline
- `-Inline:$true` marks the attachment as inline content (useful for images you intend to embed in rich-text/markdown fields).
- `-Inline:$false` treats the file as a regular (non-embedded) attachment.

### Content type
Always provide a correct MIME `-ContentType` (e.g., `image/png`, `application/pdf`) so the API can store and render the file appropriately.

## Events API
`New-XurrentEvent` creates a **Request** via the **Xurrent Events REST API** (not GraphQL). It returns the created `Request`.

### Identifier semantics (REST vs GraphQL)
- **REST identifiers** are numeric (e.g., member_id, service_instance_id, team_id).
- **GraphQL identifiers are opaque node IDs.**. In the REST API they're referred to as `nodeID`.
- The cmdlet accepts multiple selector forms for related records.
  Where supported, you can pass a **name**, an **identifier**, or the **object** itself; the builder maps it to the correct REST identifier automatically (e.g., Team, Supplier, Request Template, Workflow, Configuration Item; also CI by **source** + **sourceID** via a dedicated parameter set).

> Tip: Provide only one selector per relation (name **or** id **or** object) to avoid ambiguity at bind time.
> See `Get-Help New-XurrentEvent -Full` for the full parameter matrix.

For more details, see the official [Xurrent Events API documentation](https://developer.xurrent.com/v1/requests/events/).

## Bulk API
The module supports **bulk data export and import**.
Both flows are **token-based**: you start a job (receive a token) and then poll until it's ready to download the file (export) or retrieve the result summary (import).

### Export
- **Start** an export with `Start-XurrentDataExport` (CSV or Excel) and receive an export token.
- Key ideas from the API: you can request one or multiple types, optionally filter with a `from` date, and choose export_format (`csv` / `xlsx`) and line_separator (`lf` / `crlf`). 
- **Download** with `Save-XurrentDataExport` using the token; the file URL expires after a short period, so save immediately.

For details, see the official [Xurrent Export API documentation](https://developer.xurrent.com/v1/export/).

### Import
- Prepare & upload with `Start-XurrentDataImport`: provide the type (e.g., `people`, `cis`, ...) and a CSV/TSV file (UTF-8 or UTF-16LE).
- Wait for completion with `Wait-XurrentDataImport`: poll by token until `state` = `done` to retrieve the final result summary (created/updated/deleted/unchanged/failures/errors) and a **logfile** URL with row-level details.

For the exhaustive type list, file format rules, see the official [Xurrent Import API documentation](https://developer.xurrent.com/v1/import/).

## Verbose Output
Enable verbose logging with the `-Verbose` switch (per cmdlet) or set `$VerbosePreference = 'Continue'` (session-wide).

When verbose mode is enabled:
- **Parameter echo** – Each cmdlet prints a `Start`/`End` pair with all bound parameters (useful to verify what was actually passed).
- **HTTP diagnostics** (HTTP calls) – For each API call you'll see **two entries with the same identifier**:
  - The first shows the **AccountId**, **HTTP method**, **URL**, and the **request content**.
  - The second reports the **API response time in milliseconds**.

> Tip: Use this to troubleshoot requests, confirm payloads, and time your calls.
>
> Important: No HTTP logging is written to the UI when using chained or piped commands.

# Examples

## Minimum Example
```powershell
Import-Module Works4me.Xurrent.GraphQL

$client = New-XurrentClient -AccountId 'accountID' `
    -EnvironmentType Quality `
    -EnvironmentRegion EU `
    -ClientId '***' `
    -ClientSecret '***'
```

## Queries

### Get People
You must always specify the fields to include in the response for each object you want to retrieve.
In the following example, fields like `Id`, `Name`, `PrimaryEmail` and `Organization` are selected for the `Person` object.

```powershell
$query = New-XurrentPersonQuery -Properties Id,Name,PrimaryEmail,Organization
$people = Invoke-XurrentPersonQuery -Query $query
```
or
```powershell
$people = New-XurrentPersonQuery -Properties Id,Name,PrimaryEmail,Organization | Invoke-XurrentPersonQuery
```

To further refine the selection of fields by using a query for a specific object type field, in this case, `Organization`
By using the `New-XurrentOrganizationQuery` method on the `New-XurrentPersonQuery` object, you can specify the fields to include for the `Organization` field.
The example demonstrates the selection of fields like `Id`, `Name`, and `Disabled` for the `Organization` field, and the `Name` of the `Account`.

```powershell
$orgQuery = New-XurrentOrganizationQuery -Properties Id,Name,Disabled
$accQuery = New-XurrentAccountQuery -Properties Name
$query = New-XurrentPersonQuery -Properties Id,Name,PrimaryEmail -Account $accQuery -Organization $orgQuery
$people = Invoke-XurrentPersonQuery -Query $query
```

### Views

The `View` argument can only be specified on the top-level queries.
The example returns all people in the current account and its directory account.

```powershell
$query = New-XurrentPersonQuery -Properties Id,Name,PrimaryEmail,Organization -View All
$people = Invoke-XurrentPersonQuery -Query $query
```

### Nested Queries and ItemsPerRequest
- **Default per connection**: `ItemsPerRequest = 100.`
- **Global cap per request**: maximum **500,000 items total across all connections** in a single query.
- **Automatic paging**: Each connection level pages **independently**.

To stay under the 500,000 cap, adjust `-ItemsPerRequest` on the **root (top-level)** connection you invoke first (e.g., the Organization query in the example).
This reduces the fan-out for **all** nested levels and avoids over-pagination. Only tune deeper levels if you still exceed the cap.

**Rule of thumb**: estimate the max as the product of per-level item counts.
- Example (3 levels): `Organizations × People × ConfigurationItems`.
- Defaults: `100 × 100 × 100 = 1,000,000` (too high).
- Lower **root** to **49**: `49 × 100 × 100 = 490,000` (below the cap).
- (Choose a smaller number if you want extra headroom.)


```powershell
# Tune the root connection first to limit overall fan-out.
$ciQuery = New-XurrentConfigurationItemQuery -Properties Name,Label
$peQuery = New-XurrentPersonQuery -Properties Id,Name -ConfigurationItems $ciQuery
$orgQuery = New-XurrentOrganizationQuery -Properties Id,Name,Disabled -View All -People $peQuery -ItemsPerRequest 20

 # Increase depth if your graph requires it
$client.MaximumConnectionDepth = 3

$organizations = Invoke-XurrentOrganizationQuery -Query $orgQuery
```

> Tip: Start by lowering the **root** connection. Reduce inner connections only if necessary to keep the total **below 500,000**.

### Controlling Maximum Requests for Large Result Sets

The maximum number of consecutive requests the PowerShell module will make when retrieving large datasets is defined on the client using `MaximumRequestsPerQuery`.
This property limits how many follow-up requests the client will automatically perform to retrieve additional items for root-level queries. The default value is `1000`.

```powershell
New-XurrentClient -AccountId 'accountID' `
    -ClientId '***' `
    -ClientSecret '***' `
    -EnvironmentType Production `
    -EnvironmentRegion EU `
    -MaximumRequestsPerQuery 100
```

In most cases, the default value is sufficient. However, when working with very large datasets or when API rate limits (such as 3600 requests per hour per token) are a concern, lowering this setting can help control request volumes.

### Custom Fields
Many objects can contain **Custom Fields** created via **UI Extensions**.
In queries, these are returned as a `CustomFieldCollection` (a key/value bag where each value is JSON).

- Use `Get-XurrentCustomField` to extract a field and (optionally) coerce it to a specific .NET type:
- `-As Raw` (default) returns a `System.Text.Json.JsonElement`.
- `-As JsonString` returns the unmodified JSON text (scalar or array/object).
- Typed options (e.g., `String`, `Int32`, `Decimal`, `Boolean`, `DateTime`, `DateOnly`, `TimeOnly`, ...) convert the value to that type.
- Arrays are supported: when the field contains a JSON array and you use a typed -As, the cmdlet emits one pipeline item per element (use `@(...)` to capture as an array).

```powershell
# Fetch a record that includes CustomFields
$result = New-XurrentPersonQuery -Properties Id,CustomFields -WithId '...' | Invoke-XurrentPersonQuery

# Scalar -> typed value
Get-XurrentCustomField $result.CustomFields 'decimal_value' -As Decimal
# -> 0.5

# Array -> sequence of typed values (capture if you need an array)
$codes = @( Get-XurrentCustomField $result.CustomFields 'countries' -As String )
# $codes = 'BE','BZ'

# Need the raw JSON (array or object) as a single string
Get-XurrentCustomField $result.CustomFields 'countries' -As JsonString
# -> [ "BE", "BZ" ]

# Or work with the JsonElement directly
$raw = Get-XurrentCustomField $result.CustomFields 'link_to' -As Raw
$ps  = $raw.GetRawText() | ConvertFrom-Json
```

If the field is **missing** or explicitly **null**, typed `-As` returns `$null`.

### Filtering
Filters can be applied on **root/top-level** queries only (not in nested sub-queries).
You define a **field**, an **operator**, and one or more **value(s)** to match.
- Within a single filter, multiple values are combined with OR.
- Across multiple filters (passed via `-Filters`), conditions are combined with AND.
- Supported value parameters: `-TextValues`, `-IntegerValues`, `-BooleanValue`, and `-DateTimeValues`.

```powershell
$filter1 = New-XurrentPersonQueryFilter -Property Name -Operator Equals -TextValues @('Howard', 'James')
$filter2 = New-XurrentPersonQueryFilter -Property Disabled -Operator Equals -BooleanValue $true
$filter3 = New-XurrentPersonQueryFilter -Property CreatedAt -Operator GreaterThanOrEqualsTo (Get-Date '2012-01-01')

New-XurrentPersonQuery -Properties Id,Name -Filters @($filter1, $filter2, $filter3) | Invoke-XurrentPersonQuery
```

In this example:
- The `Name` field matches **Howard OR James**
- The `Billable` field must be `true`
- The `CreatedAt` date must be after January 1st, 2012

All `Filters` are combined using **AND**, meaning all conditions must be satisfied for a record to be returned.

#### Filter by Identifier
Many entities support a `-WithId` fast path on the root query.
It returns a single record by its GraphQL node ID and **ignores other filter conditions**.

```
# Using a known GraphQL ID (nodeID)
$id = 'NG1lLnFhL1BlcnNvbi8yMjMxMjE'
New-XurrentPersonQuery -Properties Id,Name -WithId $id | Invoke-XurrentPersonQuery
```

##### Why use `-WithId`?
It avoids building/combining filter conditions and is typically faster than filtering on `Id` with `-Property/-Operator`.

#### Custom Filters
Use the `-CustomFilters` parameter on root queries to filter by **UI Extension** fields marked as **Filterable**.

```powershell
$customFilter = New-XurrentCustomFilter -Name Age -Operator NotEquals -TextValues @($null)
New-XurrentPersonQuery -Properties Id,Name -CustomFilters $customFilter | Invoke-XurrentPersonQuery
```

The **name** must match the custom field's identifier in the UI Extension.

#### Search Filters
Where supported, use the `-Search` parameter on the root query to add a free-text filter—mirroring the quick search in the UI.
It narrows results based on the entity's search-enabled fields.

```powershell
New-XurrentPersonQuery -Properties Id,Name -Search 'Klaas' | Invoke-XurrentPersonQuery
```

#### Sorting
Apply sorting on root/top-level queries only (not in nested sub-queries).
Use `-OrderBy` with the entity's order-field, and optionally `-SortOrder`.

```powershell
New-XurrentPersonQuery -Properties Id,Name -OrderBy Name -SortOrder Ascending | Invoke-XurrentPersonQuery
```

If you omit `-SortOrder`, it defaults to **Ascending**.

#### Interface-Based Properties
Some fields in the Xurrent GraphQL schema are **interfaces** (their concrete type varies per record).
To retrieve data from such fields, you must add one or more type-specific selections via the query's `*As<Entity>` parameters.
Only the types you explicitly select will be populated; unspecified types return `$null`.

```powershell
$personQuery  = New-XurrentPersonQuery  -Properties Id,Name
$requestQuery = New-XurrentRequestQuery -Properties Id,Subject,Category

$query = New-XurrentTrashQuery -Properties Id `
  -TrashedAsPerson  $personQuery `
  -TrashedAsRequest $requestQuery

Invoke-XurrentTrashQuery -Query $query
```

##### Notes 
- You still need to specify -Properties on each type-specific subquery.
- Root-level filters/views apply at the root; interface type selections only shape the returned data.

## Mutations

### Create a Person
This example creates a new person and returns `Id` and `Name`.

```powershell
New-XurrentPerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail   'welcometopowershell@example.com' `
    -Disabled $false `
    -TimeFormat24h $true `
    -JobTitle 'Boss'
```

### Creating a person with a response query
This example creates a new person and returns `Id`, `Name`, and `Organization`.
```powershell
# Build the response selection (what the mutation should return)
$orgResp    = New-XurrentOrganizationQuery -Properties Id,Name
$personResp = New-XurrentPersonQuery       -Properties Id,Name -Organization $orgResp

New-XurrentPerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail   'welcometopowershell@example.com' `
    -Disabled $false `
    -TimeFormat24h $true `
    -JobTitle 'Boss' `
    -ResponseQuery  $personResp
```

> If you omit `-ResponseQuery`, the mutation returns a default selection. Use a response query to guarantee exactly which fields come back.

### Creating a person, including custom fields

```powershell
$hireDate = Get-Date -Year 2024 -Month 5 -Day 1

# Build the custom-field payload
$customFields = New-XurrentCustomFieldCollection
$customFields = Add-XurrentCustomField -Collection $customFields -Id 'Age'        -Value 25.0
$customFields = Add-XurrentCustomField -Collection $customFields -Id 'hire_date'  -Value $hireDate

# Optionally define a response query
$orgResp    = New-XurrentOrganizationQuery -Properties Id,Name
$personResp = New-XurrentPersonQuery       -Properties Id,Name -Organization $orgResp

New-XurrentPerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail   'welcometopowershell@example.com' `
    -CustomFields   $customFields `
    -ResponseQuery  $personResp
```
or (pipeline style for building the custom-field collection):
```powershell
$hireDate = Get-Date -Year 2024 -Month 5 -Day 1

$customFields = New-XurrentCustomFieldCollection |
  Add-XurrentCustomField -Id 'Age'       -Value 25.0 |
  Add-XurrentCustomField -Id 'hire_date' -Value $hireDate

$orgResp    = New-XurrentOrganizationQuery -Properties Id,Name
$personResp = New-XurrentPersonQuery       -Properties Id,Name -Organization $orgResp

New-XurrentPerson -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNjQ' `
    -PrimaryEmail   'welcometopowershell@example.com' `
    -CustomFields   $customFields `
    -ResponseQuery  $personResp
```

**Note**: `Add-XurrentCustomField` takes `-Collection` (the `CustomFieldCollection`) and returns the updated collection, so you can either reassign or chain with the pipeline.

### Updating an existing Person
```powershell
Set-XurrentPerson -Id 'NG1lLnFhL1BlcnNvbi8yMzEyNkl' `
    -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNkl'
```

> If you omit `-ResponseQuery`, the mutation returns a default selection. Use a response query to guarantee exactly which fields come back.

### Updating an existing Person with a response query
```powershell
# Build the response selection (what the mutation should return)
$orgResp    = New-XurrentOrganizationQuery -Properties Id,Name
$personResp = New-XurrentPersonQuery       -Properties Id,Name -Organization $orgResp

Set-XurrentPerson -Id 'NG1lLnFhL1BlcnNvbi8yMzEyNkl' `
    -Name 'Welcome to PowerShell' `
    -OrganizationId 'NG1lLnFhL09yZ2FuaXphdGlvbi8yMzEyNkl' `
    -ResponseQuery  $personResp
```

### Create a request

```powershell
New-XurrentRequest -Subject 'The subject' `
    -Note 'My note in **markdown**' `
    -TemplateId 'NG1lLnFhL3JlcXVlc3RfdGVtcGxhdGUvMTIz'
```

### Updating a configuration item
```powershell
Set-XurrentConfigurationItem -Id 'NG1lLnFhL0NpLzE4MjQ5MDU' -RamAmount 32.0 -Remarks 'Update via PowerShell'
```

**Important**

Only the custom fields provided will be added or updated; all other non-specified custom fields remain unchanged.
Custom fields cannot be removed; once added, they can only be updated or set to `null`.

## Attachments

### Add a note with embedded image to a task
```powershell
$img = New-XurrentAttachment -Path '.\diagram.png' -ContentType 'image/png' -Inline $true
$note = @"
Here is the diagram:

![]($($img.Key))
"@

New-XurrentNote -OwnerId 'NG1ZnwrBlcnNvbi4yMzEyNkl' -Attachments $img -Text $note
```

- `New-XurrentAttachment` uploads the file and returns an `AttachmentInput` with `Key` and `Inline`. Use `-Inline $true` for embedded images.
- `New-XurrentNote` has an `Attachments` parameter that accepts one or more `AttachmentInput` items for the `Note` field.

### Add a note with attachment to a request
```powershell
$doc = New-XurrentAttachment -Path '.\HelloWorld.txt' -ContentType 'text/plain'
$note = 'Please review the attached document.'
New-XurrentNote -OwnerId 'NG1lLnvbiBlcnNvkj' -Attachments $img -Text $note -Internal $true
```

- `New-XurrentAttachment` uploads the file and returns an `AttachmentInput` with `Key`.
- `New-XurrentNote` has an `Attachments` parameter that accepts one or more `AttachmentInput` items for the `Note` field.

## Create a New Event via the Events API
This creates a new **Request** using the **Xurrent Events REST API** and returns a `Request` object.

```powershell
New-XurrentEvent -Category Incident `
    -Note 'An event note' `
    -Subject 'PowerShell Test' `
    -Source 'Works4me.Xurrent.GraphQL' `
    -SourceID '1' `
    -ServiceInstanceId 120262 `
    -Impact Medium `
    -ConfigurationItemId 4801722 `
    -TeamId 17544
```

**Why numeric IDs**? The Events endpoint is **REST**, so related records use **REST identifiers** (numeric).
GraphQL node IDs aren't accepted here. Where supported, you can also pass a **name** or the **object** itself and the cmdlet will translate it for you (e.g., `-ServiceInstanceName`, `-TeamName`, `-ConfigurationItemName`; CI can also be selected by **source + sourceID** via `-ConfigurationItemSource` + `-ConfigurationItemSourceID`).

**Returned value**: a Request with at least the GraphQL `Id` and the request number `RequestId` available on the object.

**Same call, using names instead of numeric IDs (when you have them)**

```powershell
New-XurrentEvent -Category Incident `
    -Note 'Something went wrong.' `
    -Subject 'System Error' `
    -Source 'Monitoring' `
    -SourceID $env:COMPUTERNAME `
    -ServiceInstanceName 'Desktop support' `
    -Impact Medium `
    -TeamName 'Service desk'
```

## Bulk Import and Export
The Bulk API lets you export data to CSV/Excel and import data from CSV.

### Excel Export
Export all people **updated** in the last 20 days to an Excel file.

```powershell
$token = Start-XurrentDataExport -Format Excel -Types 'people' -From (Get-Date).AddDays(-20)
Save-XurrentDataExport -Token $token -Path .\people.xlsx -PollingInterval 10
```
or pipeline style:
```powershell
Start-XurrentDataExport -Format Excel -Types 'people' -From (Get-Date).AddDays(-20) |
    Save-XurrentDataExport -Path .\people.xlsx -PollingInterval 10
```

### Export CSV
```powershell
$token = Start-XurrentDataExport -Format CSV -LineSeparator LineFeed -Types 'people' -From (Get-Date).AddDays(-20)
Save-XurrentDataExport -Token $token -Path .\people.csv
```
or pipeline style:
```powershell
Start-XurrentDataExport -Format CSV -LineSeparator LineFeed -Types 'people' -From (Get-Date).AddDays(-20) |
    Save-XurrentDataExport -Path .\people.csv -PollingInterval 10
```
**Note**:
- `Save-XurrentDataExport -PollingInterval` is 10–120 seconds (default 30). `-Timeout` is 0–900 seconds (0 = wait indefinitely). 
- `Start-XurrentDataExport` supports `-Format` (CSV|Excel), optional `-LineSeparator` for CSV, required `-Types`, and optional `-From`.

### Multi-type exports
You can export **multiple types** in one job. When more than one type is requested, the result is a **ZIP** file containing one file per type (CSV or Excel, matching your `-Format`).

```powershell
# Excel (ZIP with one .xlsx per type)
Start-XurrentDataExport -Format Excel -Types 'people','cis' -From (Get-Date).AddDays(-20) |
    Save-XurrentDataExport -Path .\people_cis.zip -PollingInterval 10
```

```powershell
# CSV (ZIP with one .csv per type)
Start-XurrentDataExport -Format CSV -LineSeparator LineFeed -Types 'people','cis' -From (Get-Date).AddDays(-20) |
  Save-XurrentDataExport -Path .\people_cis.zip -PollingInterval 10
```

Tip: choose a `.zip` extension for `-Path` when exporting multiple types.

For details, see the official [Xurrent Export API documentation](https://developer.xurrent.com/v1/export/).

### CSV import

```powershell
$token  = Start-XurrentDataImport -Path .\people.csv -Type 'people'
$result = Wait-XurrentDataImport -Token $token -PollingInterval 15 -Timeout 300
```
or pipeline style:
```
$result = Start-XurrentDataImport -Path .\people.csv -Type 'people' |
    Wait-XurrentDataImport -PollingInterval 15 -Timeout 300
```

**Result object**
The returned object reports the server's import outcome and summary.
Expect fields for overall state/status, a summary of changes (created/updated/etc.), and a log file link with row-level details (field names can vary by version).
For the exact shape in your build, run:

```powershell
$result | Format-List *
$result.Results | Format-List *
```

For supported types, file format rules, and behavior details, see the official [Xurrent Import API documentation](https://developer.xurrent.com/v1/import/).
