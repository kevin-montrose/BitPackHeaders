using System;

namespace BitPackHeaders
{
    internal class FieldHeaders
    {
        public string? A_IM { get; set; }
        public string? AddResourcePropertiesToResponse { get; set; }
        public string? AllowTentativeWrites { get; set; }
        public string? Authorization { get; set; }
        public string? BinaryId { get; set; }
        public string? BinaryPassthroughRequest { get; set; }
        public string? BindReplicaDirective { get; set; }
        public string? BuilderClientIdentifier { get; set; }
        public string? CanCharge { get; set; }
        public string? CanOfferReplaceComplete { get; set; }
        public string? CanThrottle { get; set; }
        public string? ChangeFeedStartFullFidelityIfNoneMatch { get; set; }
        public string? ChangeFeedWireFormatVersion { get; set; }
        public string? ClientRetryAttemptCount { get; set; }
        public string? CollectionChildResourceContentLimitInKB { get; set; }
        public string? CollectionChildResourceNameLimitInBytes { get; set; }
        public string? CollectionPartitionIndex { get; set; }
        public string? CollectionRemoteStorageSecurityIdentifier { get; set; }
        public string? CollectionRid { get; set; }
        public string? CollectionServiceIndex { get; set; }
        public string? CollectionTruncate { get; set; }
        public string? ConsistencyLevel { get; set; }
        public string? ContentSerializationFormat { get; set; }
        public string? Continuation { get; set; }
        public string? CorrelatedActivityId { get; set; }
        public string? DisableRUPerMinuteUsage { get; set; }
        public string? EffectivePartitionKey { get; set; }
        public string? EmitVerboseTracesInQuery { get; set; }
        public string? EnableDynamicRidRangeAllocation { get; set; }
        public string? EnableLogging { get; set; }
        public string? EnableLowPrecisionOrderBy { get; set; }
        public string? EnableScanInQuery { get; set; }
        public string? EndEpk { get; set; }
        public string? EndId { get; set; }
        public string? EntityId { get; set; }
        public string? EnumerationDirection { get; set; }
        public string? ExcludeSystemProperties { get; set; }
        public string? FanoutOperationState { get; set; }
        public string? FilterBySchemaResourceId { get; set; }
        public string? ForceQueryScan { get; set; }
        public string? ForceSideBySideIndexMigration { get; set; }
        public string? GatewaySignature { get; set; }
        public string? GetAllPartitionKeyStatistics { get; set; }
        public string? HttpDate { get; set; }
        public string? IfMatch { get; set; }
        public string? IfModifiedSince { get; set; }
        public string? IfNoneMatch { get; set; }
        public string? IgnoreSystemLoweringMaxThroughput { get; set; }
        public string? IncludePhysicalPartitionThroughputInfo { get; set; }
        public string? IncludeTentativeWrites { get; set; }
        public string? IndexingDirective { get; set; }
        public string? IntendedCollectionRid { get; set; }
        public string? IsAutoScaleRequest { get; set; }
        public string? IsBatchAtomic { get; set; }
        public string? IsBatchOrdered { get; set; }
        public string? IsClientEncrypted { get; set; }
        public string? IsFanoutRequest { get; set; }
        public string? IsInternalServerlessRequest { get; set; }
        public string? IsMaterializedViewBuild { get; set; }
        public string? IsMaterializedViewSourceSchemaReplaceBatchRequest { get; set; }
        public string? IsOfferStorageRefreshRequest { get; set; }
        public string? IsReadOnlyScript { get; set; }
        public string? IsRetriedWriteRequest { get; set; }
        public string? IsRUPerGBEnforcementRequest { get; set; }
        public string? IsServerlessStorageRefreshRequest { get; set; }
        public string? IsThroughputCapRequest { get; set; }
        public string? IsUserRequest { get; set; }
        public string? MaxPollingIntervalMilliseconds { get; set; }
        public string? MergeCheckPointGLSN { get; set; }
        public string? MergeStaticId { get; set; }
        public string? MigrateCollectionDirective { get; set; }
        public string? MigrateOfferToAutopilot { get; set; }
        public string? MigrateOfferToManualThroughput { get; set; }
        public string? OfferReplaceRURedistribution { get; set; }
        public string? PageSize { get; set; }
        public string? PartitionCount { get; set; }
        public string? PartitionKey { get; set; }
        public string? PartitionKeyRangeId { get; set; }
        public string? PartitionResourceFilter { get; set; }
        public string? PopulateAnalyticalMigrationProgress { get; set; }
        public string? PopulateByokEncryptionProgress { get; set; }
        public string? PopulateCollectionThroughputInfo { get; set; }
        public string? PopulateIndexMetrics { get; set; }
        public string? PopulateLogStoreInfo { get; set; }
        public string? PopulateOldestActiveSchema { get; set; }
        public string? PopulatePartitionStatistics { get; set; }
        public string? PopulateQueryMetrics { get; set; }
        public string? PopulateQuotaInfo { get; set; }
        public string? PopulateResourceCount { get; set; }
        public string? PopulateUnflushedMergeEntryCount { get; set; }
        public string? PopulateUniqueIndexReIndexProgress { get; set; }
        public string? PostTriggerExclude { get; set; }
        public string? PostTriggerInclude { get; set; }
        public string? Prefer { get; set; }
        public string? PreserveFullContent { get; set; }
        public string? PreTriggerExclude { get; set; }
        public string? PreTriggerInclude { get; set; }
        public string? PrimaryMasterKey { get; set; }
        public string? PrimaryReadonlyKey { get; set; }
        public string? ProfileRequest { get; set; }
        public string? RbacAction { get; set; }
        public string? RbacResource { get; set; }
        public string? RbacUserId { get; set; }
        public string? ReadFeedKeyType { get; set; }
        public string? RemainingTimeInMsOnClientRequest { get; set; }
        public string? RemoteStorageType { get; set; }
        public string? RequestedCollectionType { get; set; }
        public string? ResourceId { get; set; }
        public string? ResourceSchemaName { get; set; }
        public string? ResourceTokenExpiry { get; set; }
        public string? ResourceTypes { get; set; }
        public string? ResponseContinuationTokenLimitInKB { get; set; }
        public string? RestoreMetadataFilter { get; set; }
        public string? RestoreParams { get; set; }
        public string? RetriableWriteRequestId { get; set; }
        public string? RetriableWriteRequestStartTimestamp { get; set; }
        public string? SchemaHash { get; set; }
        public string? SchemaId { get; set; }
        public string? SchemaOwnerRid { get; set; }
        public string? SDKSupportedCapabilities { get; set; }
        public string? SecondaryMasterKey { get; set; }
        public string? SecondaryReadonlyKey { get; set; }
        public string? SessionToken { get; set; }
        public string? ShareThroughput { get; set; }
        public string? ShouldBatchContinueOnError { get; set; }
        public string? ShouldReturnCurrentServerDateTime { get; set; }
        public string? SkipRefreshDatabaseAccountConfigs { get; set; }
        public string? SourceCollectionIfMatch { get; set; }
        public string? StartEpk { get; set; }
        public string? StartId { get; set; }
        public string? SupportSpatialLegacyCoordinates { get; set; }
        public string? SystemDocumentType { get; set; }
        public string? SystemRestoreOperation { get; set; }
        public string? TargetGlobalCommittedLsn { get; set; }
        public string? TargetLsn { get; set; }
        public string? TimeToLiveInSeconds { get; set; }
        public string? TransactionCommit { get; set; }
        public string? TransactionFirstRequest { get; set; }
        public string? TransactionId { get; set; }
        public string? TransportRequestID { get; set; }
        public string? TruncateMergeLogRequest { get; set; }
        public string? UniqueIndexNameEncodingMode { get; set; }
        public string? UniqueIndexReIndexingState { get; set; }
        public string? UpdateMaxThroughputEverProvisioned { get; set; }
        public string? UpdateOfferStateToPending { get; set; }
        public string? UseArchivalPartition { get; set; }
        public string? UsePolygonsSmallerThanAHemisphere { get; set; }
        public string? UseSystemBudget { get; set; }
        public string? UseUserBackgroundBudget { get; set; }
        public string? Version { get; set; }
        public string? XDate { get; set; }

        public void Set(HeaderNames name, string value)
        {
            switch (name)
            {
                case HeaderNames.AddResourcePropertiesToResponse: this.AddResourcePropertiesToResponse = value; break;
                case HeaderNames.AllowTentativeWrites: this.AllowTentativeWrites = value; break;
                case HeaderNames.Authorization: this.Authorization = value; break;
                case HeaderNames.A_IM: this.A_IM = value; break;
                case HeaderNames.BinaryId: this.BinaryId = value; break;
                case HeaderNames.BinaryPassthroughRequest: this.BinaryPassthroughRequest = value; break;
                case HeaderNames.BindReplicaDirective: this.BindReplicaDirective = value; break;
                case HeaderNames.BuilderClientIdentifier: this.BuilderClientIdentifier = value; break;
                case HeaderNames.CanCharge: this.CanCharge = value; break;
                case HeaderNames.CanOfferReplaceComplete: this.CanOfferReplaceComplete = value; break;
                case HeaderNames.CanThrottle: this.CanThrottle = value; break;
                case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: this.ChangeFeedStartFullFidelityIfNoneMatch = value; break;
                case HeaderNames.ChangeFeedWireFormatVersion: this.ChangeFeedWireFormatVersion = value; break;
                case HeaderNames.ClientRetryAttemptCount: this.ClientRetryAttemptCount = value; break;
                case HeaderNames.CollectionChildResourceContentLimitInKB: this.CollectionChildResourceContentLimitInKB = value; break;
                case HeaderNames.CollectionChildResourceNameLimitInBytes: this.CollectionChildResourceNameLimitInBytes = value; break;
                case HeaderNames.CollectionPartitionIndex: this.CollectionPartitionIndex = value; break;
                case HeaderNames.CollectionRemoteStorageSecurityIdentifier: this.CollectionRemoteStorageSecurityIdentifier = value; break;
                case HeaderNames.CollectionRid: this.CollectionRid = value; break;
                case HeaderNames.CollectionServiceIndex: this.CollectionServiceIndex = value; break;
                case HeaderNames.CollectionTruncate: this.CollectionTruncate = value; break;
                case HeaderNames.ConsistencyLevel: this.ConsistencyLevel = value; break;
                case HeaderNames.ContentSerializationFormat: this.ContentSerializationFormat = value; break;
                case HeaderNames.Continuation: this.Continuation = value; break;
                case HeaderNames.CorrelatedActivityId: this.CorrelatedActivityId = value; break;
                case HeaderNames.DisableRUPerMinuteUsage: this.DisableRUPerMinuteUsage = value; break;
                case HeaderNames.EffectivePartitionKey: this.EffectivePartitionKey = value; break;
                case HeaderNames.EmitVerboseTracesInQuery: this.EmitVerboseTracesInQuery = value; break;
                case HeaderNames.EnableDynamicRidRangeAllocation: this.EnableDynamicRidRangeAllocation = value; break;
                case HeaderNames.EnableLogging: this.EnableLogging = value; break;
                case HeaderNames.EnableLowPrecisionOrderBy: this.EnableLowPrecisionOrderBy = value; break;
                case HeaderNames.EnableScanInQuery: this.EnableScanInQuery = value; break;
                case HeaderNames.EndEpk: this.EndEpk = value; break;
                case HeaderNames.EndId: this.EndId = value; break;
                case HeaderNames.EntityId: this.EntityId = value; break;
                case HeaderNames.EnumerationDirection: this.EnumerationDirection = value; break;
                case HeaderNames.ExcludeSystemProperties: this.ExcludeSystemProperties = value; break;
                case HeaderNames.FanoutOperationState: this.FanoutOperationState = value; break;
                case HeaderNames.FilterBySchemaResourceId: this.FilterBySchemaResourceId = value; break;
                case HeaderNames.ForceQueryScan: this.ForceQueryScan = value; break;
                case HeaderNames.ForceSideBySideIndexMigration: this.ForceSideBySideIndexMigration = value; break;
                case HeaderNames.GatewaySignature: this.GatewaySignature = value; break;
                case HeaderNames.GetAllPartitionKeyStatistics: this.GetAllPartitionKeyStatistics = value; break;
                case HeaderNames.HttpDate: this.HttpDate = value; break;
                case HeaderNames.IfMatch: this.IfMatch = value; break;
                case HeaderNames.IfModifiedSince: this.IfModifiedSince = value; break;
                case HeaderNames.IfNoneMatch: this.IfNoneMatch = value; break;
                case HeaderNames.IgnoreSystemLoweringMaxThroughput: this.IgnoreSystemLoweringMaxThroughput = value; break;
                case HeaderNames.IncludePhysicalPartitionThroughputInfo: this.IncludePhysicalPartitionThroughputInfo = value; break;
                case HeaderNames.IncludeTentativeWrites: this.IncludeTentativeWrites = value; break;
                case HeaderNames.IndexingDirective: this.IndexingDirective = value; break;
                case HeaderNames.IntendedCollectionRid: this.IntendedCollectionRid = value; break;
                case HeaderNames.IsAutoScaleRequest: this.IsAutoScaleRequest = value; break;
                case HeaderNames.IsBatchAtomic: this.IsBatchAtomic = value; break;
                case HeaderNames.IsBatchOrdered: this.IsBatchOrdered = value; break;
                case HeaderNames.IsClientEncrypted: this.IsClientEncrypted = value; break;
                case HeaderNames.IsFanoutRequest: this.IsFanoutRequest = value; break;
                case HeaderNames.IsInternalServerlessRequest: this.IsInternalServerlessRequest = value; break;
                case HeaderNames.IsMaterializedViewBuild: this.IsMaterializedViewBuild = value; break;
                case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: this.IsMaterializedViewSourceSchemaReplaceBatchRequest = value; break;
                case HeaderNames.IsOfferStorageRefreshRequest: this.IsOfferStorageRefreshRequest = value; break;
                case HeaderNames.IsReadOnlyScript: this.IsReadOnlyScript = value; break;
                case HeaderNames.IsRetriedWriteRequest: this.IsRetriedWriteRequest = value; break;
                case HeaderNames.IsRUPerGBEnforcementRequest: this.IsRUPerGBEnforcementRequest = value; break;
                case HeaderNames.IsServerlessStorageRefreshRequest: this.IsServerlessStorageRefreshRequest = value; break;
                case HeaderNames.IsThroughputCapRequest: this.IsThroughputCapRequest = value; break;
                case HeaderNames.IsUserRequest:this.IsUserRequest = value; break;
                case HeaderNames.MaxPollingIntervalMilliseconds: this.MaxPollingIntervalMilliseconds = value; break;
                case HeaderNames.MergeCheckPointGLSN: this.MergeCheckPointGLSN = value; break;
                case HeaderNames.MergeStaticId: this.MergeStaticId = value; break;
                case HeaderNames.MigrateCollectionDirective: this.MigrateCollectionDirective = value; break;
                case HeaderNames.MigrateOfferToAutopilot: this.MigrateOfferToAutopilot = value; break;
                case HeaderNames.MigrateOfferToManualThroughput: this.MigrateOfferToManualThroughput = value; break;
                case HeaderNames.OfferReplaceRURedistribution: this.OfferReplaceRURedistribution = value; break;
                case HeaderNames.PageSize: this.PageSize = value; break;
                case HeaderNames.PartitionCount: this.PartitionCount = value; break;
                case HeaderNames.PartitionKey: this.PartitionKey = value; break;
                case HeaderNames.PartitionKeyRangeId: this.PartitionKeyRangeId = value; break;
                case HeaderNames.PartitionResourceFilter: this.PartitionResourceFilter = value; break;
                case HeaderNames.PopulateAnalyticalMigrationProgress: this.PopulateAnalyticalMigrationProgress = value; break;
                case HeaderNames.PopulateByokEncryptionProgress: this.PopulateByokEncryptionProgress = value; break;
                case HeaderNames.PopulateCollectionThroughputInfo: this.PopulateCollectionThroughputInfo = value; break;
                case HeaderNames.PopulateIndexMetrics: this.PopulateIndexMetrics = value; break;
                case HeaderNames.PopulateLogStoreInfo: this.PopulateLogStoreInfo = value; break;
                case HeaderNames.PopulateOldestActiveSchema: this.PopulateOldestActiveSchema = value; break;
                case HeaderNames.PopulatePartitionStatistics: this.PopulatePartitionStatistics = value; break;
                case HeaderNames.PopulateQueryMetrics: this.PopulateQueryMetrics = value; break;
                case HeaderNames.PopulateQuotaInfo: this.PopulateQuotaInfo = value; break;
                case HeaderNames.PopulateResourceCount: this.PopulateResourceCount = value; break;
                case HeaderNames.PopulateUnflushedMergeEntryCount: this.PopulateUnflushedMergeEntryCount = value; break;
                case HeaderNames.PopulateUniqueIndexReIndexProgress: this.PopulateUniqueIndexReIndexProgress = value; break;
                case HeaderNames.PostTriggerExclude: this.PostTriggerExclude = value; break;
                case HeaderNames.PostTriggerInclude: this.PostTriggerInclude = value; break;
                case HeaderNames.Prefer: this.Prefer = value; break;
                case HeaderNames.PreserveFullContent: this.PreserveFullContent = value; break;
                case HeaderNames.PreTriggerExclude: this.PreTriggerExclude = value; break;
                case HeaderNames.PreTriggerInclude: this.PreTriggerInclude = value; break;
                case HeaderNames.PrimaryMasterKey: this.PrimaryMasterKey = value; break;
                case HeaderNames.PrimaryReadonlyKey: this.PrimaryReadonlyKey = value; break;
                case HeaderNames.ProfileRequest: this.ProfileRequest = value; break;
                case HeaderNames.RbacAction: this.RbacAction = value; break;
                case HeaderNames.RbacResource: this.RbacResource = value; break;
                case HeaderNames.RbacUserId: this.RbacUserId = value; break;
                case HeaderNames.ReadFeedKeyType: this.ReadFeedKeyType = value; break;
                case HeaderNames.RemainingTimeInMsOnClientRequest: this.RemainingTimeInMsOnClientRequest = value; break;
                case HeaderNames.RemoteStorageType: this.RemoteStorageType = value; break;
                case HeaderNames.RequestedCollectionType: this.RequestedCollectionType = value; break;
                case HeaderNames.ResourceId: this.ResourceId = value; break;
                case HeaderNames.ResourceSchemaName: this.ResourceSchemaName = value; break;
                case HeaderNames.ResourceTokenExpiry: this.ResourceTokenExpiry = value; break;
                case HeaderNames.ResourceTypes: this.ResourceTypes = value; break;
                case HeaderNames.ResponseContinuationTokenLimitInKB: this.ResponseContinuationTokenLimitInKB = value; break;
                case HeaderNames.RestoreMetadataFilter: this.RestoreMetadataFilter = value; break;
                case HeaderNames.RestoreParams: this.RestoreParams = value; break;
                case HeaderNames.RetriableWriteRequestId: this.RetriableWriteRequestId = value; break;
                case HeaderNames.RetriableWriteRequestStartTimestamp: this.RetriableWriteRequestStartTimestamp = value; break;
                case HeaderNames.SchemaHash: this.SchemaHash = value; break;
                case HeaderNames.SchemaId: this.SchemaId = value; break;
                case HeaderNames.SchemaOwnerRid: this.SchemaOwnerRid = value; break;
                case HeaderNames.SDKSupportedCapabilities: this.SDKSupportedCapabilities = value; break;
                case HeaderNames.SecondaryMasterKey: this.SecondaryMasterKey = value; break;
                case HeaderNames.SecondaryReadonlyKey: this.SecondaryReadonlyKey = value; break;
                case HeaderNames.SessionToken: this.SessionToken = value; break;
                case HeaderNames.ShareThroughput: this.ShareThroughput = value; break;
                case HeaderNames.ShouldBatchContinueOnError: this.ShouldBatchContinueOnError = value; break;
                case HeaderNames.ShouldReturnCurrentServerDateTime: this.ShouldReturnCurrentServerDateTime = value; break;
                case HeaderNames.SkipRefreshDatabaseAccountConfigs: this.SkipRefreshDatabaseAccountConfigs = value; break;
                case HeaderNames.SourceCollectionIfMatch: this.SourceCollectionIfMatch = value; break;
                case HeaderNames.StartEpk: this.StartEpk = value; break;
                case HeaderNames.StartId: this.StartId = value; break;
                case HeaderNames.SupportSpatialLegacyCoordinates: this.SupportSpatialLegacyCoordinates = value; break;
                case HeaderNames.SystemDocumentType: this.SystemDocumentType = value; break;
                case HeaderNames.SystemRestoreOperation: this.SystemRestoreOperation = value; break;
                case HeaderNames.TargetGlobalCommittedLsn: this.TargetGlobalCommittedLsn = value; break;
                case HeaderNames.TargetLsn: this.TargetLsn = value; break;
                case HeaderNames.TimeToLiveInSeconds: this.TimeToLiveInSeconds = value; break;
                case HeaderNames.TransactionCommit: this.TransactionCommit = value; break;
                case HeaderNames.TransactionFirstRequest: this.TransactionFirstRequest = value; break;
                case HeaderNames.TransactionId: this.TransactionId = value; break;
                case HeaderNames.TransportRequestID: this.TransportRequestID = value; break;
                case HeaderNames.TruncateMergeLogRequest: this.TruncateMergeLogRequest = value; break;
                case HeaderNames.UniqueIndexNameEncodingMode: this.UniqueIndexNameEncodingMode = value; break;
                case HeaderNames.UniqueIndexReIndexingState: this.UniqueIndexReIndexingState = value; break;
                case HeaderNames.UpdateMaxThroughputEverProvisioned: this.UpdateMaxThroughputEverProvisioned = value; break;
                case HeaderNames.UpdateOfferStateToPending: this.UpdateOfferStateToPending = value; break;
                case HeaderNames.UseArchivalPartition: this.UseArchivalPartition = value; break;
                case HeaderNames.UsePolygonsSmallerThanAHemisphere: this.UsePolygonsSmallerThanAHemisphere = value; break;
                case HeaderNames.UseSystemBudget: this.UseSystemBudget = value; break;
                case HeaderNames.UseUserBackgroundBudget: this.UseUserBackgroundBudget = value; break;
                case HeaderNames.Version: this.Version = value; break;
                case HeaderNames.XDate: this.XDate = value; break;
                default: throw new ArgumentException(nameof(name), $"Was {name}");
            }
        }

        public bool TryGetValue(HeaderNames name, out string? value)
        {
            switch (name)
            {
                case HeaderNames.AddResourcePropertiesToResponse: value = this.AddResourcePropertiesToResponse; break;
                case HeaderNames.AllowTentativeWrites: value = this.AllowTentativeWrites; break;
                case HeaderNames.Authorization: value = this.Authorization; break;
                case HeaderNames.A_IM: value = this.A_IM; break;
                case HeaderNames.BinaryId: value = this.BinaryId; break;
                case HeaderNames.BinaryPassthroughRequest: value = this.BinaryPassthroughRequest; break;
                case HeaderNames.BindReplicaDirective: value = this.BindReplicaDirective; break;
                case HeaderNames.BuilderClientIdentifier: value = this.BuilderClientIdentifier; break;
                case HeaderNames.CanCharge: value = this.CanCharge; break;
                case HeaderNames.CanOfferReplaceComplete: value = this.CanOfferReplaceComplete; break;
                case HeaderNames.CanThrottle: value = this.CanThrottle; break;
                case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: value = this.ChangeFeedStartFullFidelityIfNoneMatch; break;
                case HeaderNames.ChangeFeedWireFormatVersion: value = this.ChangeFeedWireFormatVersion; break;
                case HeaderNames.ClientRetryAttemptCount: value = this.ClientRetryAttemptCount; break;
                case HeaderNames.CollectionChildResourceContentLimitInKB: value = this.CollectionChildResourceContentLimitInKB; break;
                case HeaderNames.CollectionChildResourceNameLimitInBytes: value = this.CollectionChildResourceNameLimitInBytes; break;
                case HeaderNames.CollectionPartitionIndex: value = this.CollectionPartitionIndex; break;
                case HeaderNames.CollectionRemoteStorageSecurityIdentifier: value = this.CollectionRemoteStorageSecurityIdentifier; break;
                case HeaderNames.CollectionRid: value = this.CollectionRid; break;
                case HeaderNames.CollectionServiceIndex: value = this.CollectionServiceIndex; break;
                case HeaderNames.CollectionTruncate: value = this.CollectionTruncate; break;
                case HeaderNames.ConsistencyLevel: value = this.ConsistencyLevel; break;
                case HeaderNames.ContentSerializationFormat: value = this.ContentSerializationFormat; break;
                case HeaderNames.Continuation: value = this.Continuation; break;
                case HeaderNames.CorrelatedActivityId: value = this.CorrelatedActivityId; break;
                case HeaderNames.DisableRUPerMinuteUsage: value = this.DisableRUPerMinuteUsage; break;
                case HeaderNames.EffectivePartitionKey: value = this.EffectivePartitionKey; break;
                case HeaderNames.EmitVerboseTracesInQuery: value = this.EmitVerboseTracesInQuery; break;
                case HeaderNames.EnableDynamicRidRangeAllocation: value = this.EnableDynamicRidRangeAllocation; break;
                case HeaderNames.EnableLogging: value = this.EnableLogging; break;
                case HeaderNames.EnableLowPrecisionOrderBy: value = this.EnableLowPrecisionOrderBy; break;
                case HeaderNames.EnableScanInQuery: value = this.EnableScanInQuery; break;
                case HeaderNames.EndEpk: value = this.EndEpk; break;
                case HeaderNames.EndId: value = this.EndId; break;
                case HeaderNames.EntityId: value = this.EntityId; break;
                case HeaderNames.EnumerationDirection: value = this.EnumerationDirection; break;
                case HeaderNames.ExcludeSystemProperties: value = this.ExcludeSystemProperties; break;
                case HeaderNames.FanoutOperationState: value = this.FanoutOperationState; break;
                case HeaderNames.FilterBySchemaResourceId: value = this.FilterBySchemaResourceId; break;
                case HeaderNames.ForceQueryScan: value = this.ForceQueryScan; break;
                case HeaderNames.ForceSideBySideIndexMigration: value = this.ForceSideBySideIndexMigration; break;
                case HeaderNames.GatewaySignature: value = this.GatewaySignature; break;
                case HeaderNames.GetAllPartitionKeyStatistics: value = this.GetAllPartitionKeyStatistics; break;
                case HeaderNames.HttpDate: value = this.HttpDate; break;
                case HeaderNames.IfMatch: value = this.IfMatch; break;
                case HeaderNames.IfModifiedSince: value = this.IfModifiedSince; break;
                case HeaderNames.IfNoneMatch: value = this.IfNoneMatch; break;
                case HeaderNames.IgnoreSystemLoweringMaxThroughput: value = this.IgnoreSystemLoweringMaxThroughput; break;
                case HeaderNames.IncludePhysicalPartitionThroughputInfo: value = this.IncludePhysicalPartitionThroughputInfo; break;
                case HeaderNames.IncludeTentativeWrites: value = this.IncludeTentativeWrites; break;
                case HeaderNames.IndexingDirective: value = this.IndexingDirective; break;
                case HeaderNames.IntendedCollectionRid: value = this.IntendedCollectionRid; break;
                case HeaderNames.IsAutoScaleRequest: value = this.IsAutoScaleRequest; break;
                case HeaderNames.IsBatchAtomic: value = this.IsBatchAtomic; break;
                case HeaderNames.IsBatchOrdered: value = this.IsBatchOrdered; break;
                case HeaderNames.IsClientEncrypted: value = this.IsClientEncrypted; break;
                case HeaderNames.IsFanoutRequest: value = this.IsFanoutRequest; break;
                case HeaderNames.IsInternalServerlessRequest: value = this.IsInternalServerlessRequest; break;
                case HeaderNames.IsMaterializedViewBuild: value = this.IsMaterializedViewBuild; break;
                case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: value = this.IsMaterializedViewSourceSchemaReplaceBatchRequest; break;
                case HeaderNames.IsOfferStorageRefreshRequest: value = this.IsOfferStorageRefreshRequest; break;
                case HeaderNames.IsReadOnlyScript: value = this.IsReadOnlyScript; break;
                case HeaderNames.IsRetriedWriteRequest: value = this.IsRetriedWriteRequest; break;
                case HeaderNames.IsRUPerGBEnforcementRequest: value = this.IsRUPerGBEnforcementRequest; break;
                case HeaderNames.IsServerlessStorageRefreshRequest: value = this.IsServerlessStorageRefreshRequest; break;
                case HeaderNames.IsThroughputCapRequest: value = this.IsThroughputCapRequest; break;
                case HeaderNames.IsUserRequest: value = this.IsUserRequest; break;
                case HeaderNames.MaxPollingIntervalMilliseconds: value = this.MaxPollingIntervalMilliseconds; break;
                case HeaderNames.MergeCheckPointGLSN: value = this.MergeCheckPointGLSN; break;
                case HeaderNames.MergeStaticId: value = this.MergeStaticId; break;
                case HeaderNames.MigrateCollectionDirective: value = this.MigrateCollectionDirective; break;
                case HeaderNames.MigrateOfferToAutopilot: value = this.MigrateOfferToAutopilot; break;
                case HeaderNames.MigrateOfferToManualThroughput: value = this.MigrateOfferToManualThroughput; break;
                case HeaderNames.OfferReplaceRURedistribution: value = this.OfferReplaceRURedistribution; break;
                case HeaderNames.PageSize: value = this.PageSize; break;
                case HeaderNames.PartitionCount: value = this.PartitionCount; break;
                case HeaderNames.PartitionKey: value = this.PartitionKey; break;
                case HeaderNames.PartitionKeyRangeId: value = this.PartitionKeyRangeId; break;
                case HeaderNames.PartitionResourceFilter: value = this.PartitionResourceFilter; break;
                case HeaderNames.PopulateAnalyticalMigrationProgress: value = this.PopulateAnalyticalMigrationProgress; break;
                case HeaderNames.PopulateByokEncryptionProgress: value = this.PopulateByokEncryptionProgress; break;
                case HeaderNames.PopulateCollectionThroughputInfo: value = this.PopulateCollectionThroughputInfo; break;
                case HeaderNames.PopulateIndexMetrics: value = this.PopulateIndexMetrics; break;
                case HeaderNames.PopulateLogStoreInfo: value = this.PopulateLogStoreInfo; break;
                case HeaderNames.PopulateOldestActiveSchema: value = this.PopulateOldestActiveSchema; break;
                case HeaderNames.PopulatePartitionStatistics: value = this.PopulatePartitionStatistics; break;
                case HeaderNames.PopulateQueryMetrics: value = this.PopulateQueryMetrics; break;
                case HeaderNames.PopulateQuotaInfo: value = this.PopulateQuotaInfo; break;
                case HeaderNames.PopulateResourceCount: value = this.PopulateResourceCount; break;
                case HeaderNames.PopulateUnflushedMergeEntryCount: value = this.PopulateUnflushedMergeEntryCount; break;
                case HeaderNames.PopulateUniqueIndexReIndexProgress: value = this.PopulateUniqueIndexReIndexProgress; break;
                case HeaderNames.PostTriggerExclude: value = this.PostTriggerExclude; break;
                case HeaderNames.PostTriggerInclude: value = this.PostTriggerInclude; break;
                case HeaderNames.Prefer: value = this.Prefer; break;
                case HeaderNames.PreserveFullContent: value = this.PreserveFullContent; break;
                case HeaderNames.PreTriggerExclude: value = this.PreTriggerExclude; break;
                case HeaderNames.PreTriggerInclude: value = this.PreTriggerInclude; break;
                case HeaderNames.PrimaryMasterKey: value = this.PrimaryMasterKey; break;
                case HeaderNames.PrimaryReadonlyKey: value = this.PrimaryReadonlyKey; break;
                case HeaderNames.ProfileRequest: value = this.ProfileRequest; break;
                case HeaderNames.RbacAction: value = this.RbacAction; break;
                case HeaderNames.RbacResource: value = this.RbacResource; break;
                case HeaderNames.RbacUserId: value = this.RbacUserId; break;
                case HeaderNames.ReadFeedKeyType: value = this.ReadFeedKeyType; break;
                case HeaderNames.RemainingTimeInMsOnClientRequest: value = this.RemainingTimeInMsOnClientRequest; break;
                case HeaderNames.RemoteStorageType: value = this.RemoteStorageType; break;
                case HeaderNames.RequestedCollectionType: value = this.RequestedCollectionType; break;
                case HeaderNames.ResourceId: value = this.ResourceId; break;
                case HeaderNames.ResourceSchemaName: value = this.ResourceSchemaName; break;
                case HeaderNames.ResourceTokenExpiry: value = this.ResourceTokenExpiry; break;
                case HeaderNames.ResourceTypes: value = this.ResourceTypes; break;
                case HeaderNames.ResponseContinuationTokenLimitInKB: value = this.ResponseContinuationTokenLimitInKB; break;
                case HeaderNames.RestoreMetadataFilter: value = this.RestoreMetadataFilter; break;
                case HeaderNames.RestoreParams: value = this.RestoreParams; break;
                case HeaderNames.RetriableWriteRequestId: value = this.RetriableWriteRequestId; break;
                case HeaderNames.RetriableWriteRequestStartTimestamp: value = this.RetriableWriteRequestStartTimestamp; break;
                case HeaderNames.SchemaHash: value = this.SchemaHash; break;
                case HeaderNames.SchemaId: value = this.SchemaId; break;
                case HeaderNames.SchemaOwnerRid: value = this.SchemaOwnerRid; break;
                case HeaderNames.SDKSupportedCapabilities: value = this.SDKSupportedCapabilities; break;
                case HeaderNames.SecondaryMasterKey: value = this.SecondaryMasterKey; break;
                case HeaderNames.SecondaryReadonlyKey: value = this.SecondaryReadonlyKey; break;
                case HeaderNames.SessionToken: value = this.SessionToken; break;
                case HeaderNames.ShareThroughput: value = this.ShareThroughput; break;
                case HeaderNames.ShouldBatchContinueOnError: value = this.ShouldBatchContinueOnError; break;
                case HeaderNames.ShouldReturnCurrentServerDateTime: value = this.ShouldReturnCurrentServerDateTime; break;
                case HeaderNames.SkipRefreshDatabaseAccountConfigs: value = this.SkipRefreshDatabaseAccountConfigs; break;
                case HeaderNames.SourceCollectionIfMatch: value = this.SourceCollectionIfMatch; break;
                case HeaderNames.StartEpk: value = this.StartEpk; break;
                case HeaderNames.StartId: value = this.StartId; break;
                case HeaderNames.SupportSpatialLegacyCoordinates: value = this.SupportSpatialLegacyCoordinates; break;
                case HeaderNames.SystemDocumentType: value = this.SystemDocumentType; break;
                case HeaderNames.SystemRestoreOperation: value = this.SystemRestoreOperation; break;
                case HeaderNames.TargetGlobalCommittedLsn: value = this.TargetGlobalCommittedLsn; break;
                case HeaderNames.TargetLsn: value = this.TargetLsn; break;
                case HeaderNames.TimeToLiveInSeconds: value = this.TimeToLiveInSeconds; break;
                case HeaderNames.TransactionCommit: value = this.TransactionCommit; break;
                case HeaderNames.TransactionFirstRequest: value = this.TransactionFirstRequest; break;
                case HeaderNames.TransactionId: value = this.TransactionId; break;
                case HeaderNames.TransportRequestID: value = this.TransportRequestID; break;
                case HeaderNames.TruncateMergeLogRequest: value = this.TruncateMergeLogRequest; break;
                case HeaderNames.UniqueIndexNameEncodingMode: value = this.UniqueIndexNameEncodingMode; break;
                case HeaderNames.UniqueIndexReIndexingState: value = this.UniqueIndexReIndexingState; break;
                case HeaderNames.UpdateMaxThroughputEverProvisioned: value = this.UpdateMaxThroughputEverProvisioned; break;
                case HeaderNames.UpdateOfferStateToPending: value = this.UpdateOfferStateToPending; break;
                case HeaderNames.UseArchivalPartition: value = this.UseArchivalPartition; break;
                case HeaderNames.UsePolygonsSmallerThanAHemisphere: value = this.UsePolygonsSmallerThanAHemisphere; break;
                case HeaderNames.UseSystemBudget: value = this.UseSystemBudget; break;
                case HeaderNames.UseUserBackgroundBudget: value = this.UseUserBackgroundBudget; break;
                case HeaderNames.Version: value = this.Version; break;
                case HeaderNames.XDate: value = this.XDate; break;
                default: value = null; break;
            }

            return value != null;
        }
    }
}
