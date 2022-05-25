using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BitPackHeaders
{
    /// <remarks>
    /// It's worthwhile for this to be a cache-line multiple, so consider the full size.
    /// 
    /// 16-bytes for header and method table
    /// 8-bytes for overflow reference
    /// 24-bytes for bitmask (covering up to 192 unique headers)
    /// 
    /// This is 48 bytes
    /// 
    /// Cache lines are typically 64 bytes
    /// 
    /// 2 packed values isn't enough to be interesting,
    /// so let's instead go to 128 bytes for this class.
    /// 
    /// This gives us 80 bytes to work with, or 10 packed values.
    /// </remarks>
    internal class PackedHeaders
    {
        private const int PackedCapacity = 10;
        private const int MaximumHeaderCount = 151;

        private Data data;

        private string?[] overflow;

        internal PackedHeaders()
        {
            this.overflow = Array.Empty<string?>();
        }

        public string? ResourceId => this.GetOrDefault(HeaderNames.ResourceId, (int)HeaderNames.ResourceId, 0, ref this.data.headerBitfield0);
        public string? Authorization => this.GetOrDefault(HeaderNames.Authorization, (int)HeaderNames.Authorization, 0, ref this.data.headerBitfield0);
        public string? HttpDate => this.GetOrDefault(HeaderNames.HttpDate, (int)HeaderNames.HttpDate, 0, ref this.data.headerBitfield0);
        public string? XDate => this.GetOrDefault(HeaderNames.XDate, (int)HeaderNames.XDate, 0, ref this.data.headerBitfield0);
        public string? PageSize => this.GetOrDefault(HeaderNames.PageSize, (int)HeaderNames.PageSize, 0, ref this.data.headerBitfield0);
        public string? SessionToken => this.GetOrDefault(HeaderNames.SessionToken, (int)HeaderNames.SessionToken, 0, ref this.data.headerBitfield0);
        public string? Continuation => this.GetOrDefault(HeaderNames.Continuation, (int)HeaderNames.Continuation, 0, ref this.data.headerBitfield0);
        public string? IndexingDirective => this.GetOrDefault(HeaderNames.IndexingDirective, (int)HeaderNames.IndexingDirective, 0, ref this.data.headerBitfield0);
        public string? IfNoneMatch => this.GetOrDefault(HeaderNames.IfNoneMatch, (int)HeaderNames.IfNoneMatch, 0, ref this.data.headerBitfield0);
        public string? PreTriggerInclude => this.GetOrDefault(HeaderNames.PreTriggerInclude, (int)HeaderNames.PreTriggerInclude, 0, ref this.data.headerBitfield0);
        public string? PostTriggerInclude => this.GetOrDefault(HeaderNames.PostTriggerInclude, (int)HeaderNames.PostTriggerInclude, 0, ref this.data.headerBitfield0);
        public string? IsFanoutRequest => this.GetOrDefault(HeaderNames.IsFanoutRequest, (int)HeaderNames.IsFanoutRequest, 0, ref this.data.headerBitfield0);
        public string? CollectionPartitionIndex => this.GetOrDefault(HeaderNames.CollectionPartitionIndex, (int)HeaderNames.CollectionPartitionIndex, 0, ref this.data.headerBitfield0);
        public string? CollectionServiceIndex => this.GetOrDefault(HeaderNames.CollectionServiceIndex, (int)HeaderNames.CollectionServiceIndex, 0, ref this.data.headerBitfield0);
        public string? PreTriggerExclude => this.GetOrDefault(HeaderNames.PreTriggerExclude, (int)HeaderNames.PreTriggerExclude, 0, ref this.data.headerBitfield0);
        public string? PostTriggerExclude => this.GetOrDefault(HeaderNames.PostTriggerExclude, (int)HeaderNames.PostTriggerExclude, 0, ref this.data.headerBitfield0);
        public string? ConsistencyLevel => this.GetOrDefault(HeaderNames.ConsistencyLevel, (int)HeaderNames.ConsistencyLevel, 0, ref this.data.headerBitfield0);
        public string? EntityId => this.GetOrDefault(HeaderNames.EntityId, (int)HeaderNames.EntityId, 0, ref this.data.headerBitfield0);
        public string? ResourceSchemaName => this.GetOrDefault(HeaderNames.ResourceSchemaName, (int)HeaderNames.ResourceSchemaName, 0, ref this.data.headerBitfield0);
        public string? ResourceTokenExpiry => this.GetOrDefault(HeaderNames.ResourceTokenExpiry, (int)HeaderNames.ResourceTokenExpiry, 0, ref this.data.headerBitfield0);
        public string? EnableScanInQuery => this.GetOrDefault(HeaderNames.EnableScanInQuery, (int)HeaderNames.EnableScanInQuery, 0, ref this.data.headerBitfield0);
        public string? EmitVerboseTracesInQuery => this.GetOrDefault(HeaderNames.EmitVerboseTracesInQuery, (int)HeaderNames.EmitVerboseTracesInQuery, 0, ref this.data.headerBitfield0);
        public string? BindReplicaDirective => this.GetOrDefault(HeaderNames.BindReplicaDirective, (int)HeaderNames.BindReplicaDirective, 0, ref this.data.headerBitfield0);
        public string? PrimaryMasterKey => this.GetOrDefault(HeaderNames.PrimaryMasterKey, (int)HeaderNames.PrimaryMasterKey, 0, ref this.data.headerBitfield0);
        public string? SecondaryMasterKey => this.GetOrDefault(HeaderNames.SecondaryMasterKey, (int)HeaderNames.SecondaryMasterKey, 0, ref this.data.headerBitfield0);
        public string? PrimaryReadonlyKey => this.GetOrDefault(HeaderNames.PrimaryReadonlyKey, (int)HeaderNames.PrimaryReadonlyKey, 0, ref this.data.headerBitfield0);
        public string? SecondaryReadonlyKey => this.GetOrDefault(HeaderNames.SecondaryReadonlyKey, (int)HeaderNames.SecondaryReadonlyKey, 0, ref this.data.headerBitfield0);
        public string? ProfileRequest => this.GetOrDefault(HeaderNames.ProfileRequest, (int)HeaderNames.ProfileRequest, 0, ref this.data.headerBitfield0);
        public string? EnableLowPrecisionOrderBy => this.GetOrDefault(HeaderNames.EnableLowPrecisionOrderBy, (int)HeaderNames.EnableLowPrecisionOrderBy, 0, ref this.data.headerBitfield0);
        public string? Version => this.GetOrDefault(HeaderNames.Version, (int)HeaderNames.Version, 0, ref this.data.headerBitfield0);
        public string? CanCharge => this.GetOrDefault(HeaderNames.CanCharge, (int)HeaderNames.CanCharge, 0, ref this.data.headerBitfield0);
        public string? CanThrottle => this.GetOrDefault(HeaderNames.CanThrottle, (int)HeaderNames.CanThrottle, 0, ref this.data.headerBitfield0);
        public string? PartitionKey => this.GetOrDefault(HeaderNames.PartitionKey, (int)HeaderNames.PartitionKey, 0, ref this.data.headerBitfield0);
        public string? PartitionKeyRangeId => this.GetOrDefault(HeaderNames.PartitionKeyRangeId, (int)HeaderNames.PartitionKeyRangeId, 0, ref this.data.headerBitfield0);
        public string? MigrateCollectionDirective => this.GetOrDefault(HeaderNames.MigrateCollectionDirective, (int)HeaderNames.MigrateCollectionDirective, 0, ref this.data.headerBitfield0);
        public string? SupportSpatialLegacyCoordinates => this.GetOrDefault(HeaderNames.SupportSpatialLegacyCoordinates, (int)HeaderNames.SupportSpatialLegacyCoordinates, 0, ref this.data.headerBitfield0);
        public string? PartitionCount => this.GetOrDefault(HeaderNames.PartitionCount, (int)HeaderNames.PartitionCount, 0, ref this.data.headerBitfield0);
        public string? CollectionRid => this.GetOrDefault(HeaderNames.CollectionRid, (int)HeaderNames.CollectionRid, 0, ref this.data.headerBitfield0);
        public string? FilterBySchemaResourceId => this.GetOrDefault(HeaderNames.FilterBySchemaResourceId, (int)HeaderNames.FilterBySchemaResourceId, 0, ref this.data.headerBitfield0);
        public string? UsePolygonsSmallerThanAHemisphere => this.GetOrDefault(HeaderNames.UsePolygonsSmallerThanAHemisphere, (int)HeaderNames.UsePolygonsSmallerThanAHemisphere, 0, ref this.data.headerBitfield0);
        public string? GatewaySignature => this.GetOrDefault(HeaderNames.GatewaySignature, (int)HeaderNames.GatewaySignature, 0, ref this.data.headerBitfield0);
        public string? EnableLogging => this.GetOrDefault(HeaderNames.EnableLogging, (int)HeaderNames.EnableLogging, 0, ref this.data.headerBitfield0);
        public string? A_IM => this.GetOrDefault(HeaderNames.A_IM, (int)HeaderNames.A_IM, 0, ref this.data.headerBitfield0);
        public string? IfModifiedSince => this.GetOrDefault(HeaderNames.IfModifiedSince, (int)HeaderNames.IfModifiedSince, 0, ref this.data.headerBitfield0);
        public string? PopulateQuotaInfo => this.GetOrDefault(HeaderNames.PopulateQuotaInfo, (int)HeaderNames.PopulateQuotaInfo, 0, ref this.data.headerBitfield0);
        public string? DisableRUPerMinuteUsage => this.GetOrDefault(HeaderNames.DisableRUPerMinuteUsage, (int)HeaderNames.DisableRUPerMinuteUsage, 0, ref this.data.headerBitfield0);
        public string? PopulateQueryMetrics => this.GetOrDefault(HeaderNames.PopulateQueryMetrics, (int)HeaderNames.PopulateQueryMetrics, 0, ref this.data.headerBitfield0);
        public string? ResponseContinuationTokenLimitInKB => this.GetOrDefault(HeaderNames.ResponseContinuationTokenLimitInKB, (int)HeaderNames.ResponseContinuationTokenLimitInKB, 0, ref this.data.headerBitfield0);
        public string? PopulatePartitionStatistics => this.GetOrDefault(HeaderNames.PopulatePartitionStatistics, (int)HeaderNames.PopulatePartitionStatistics, 0, ref this.data.headerBitfield0);
        public string? RemoteStorageType => this.GetOrDefault(HeaderNames.RemoteStorageType, (int)HeaderNames.RemoteStorageType, 0, ref this.data.headerBitfield0);
        public string? RemainingTimeInMsOnClientRequest => this.GetOrDefault(HeaderNames.RemainingTimeInMsOnClientRequest, (int)HeaderNames.RemainingTimeInMsOnClientRequest, 0, ref this.data.headerBitfield0);
        public string? ClientRetryAttemptCount => this.GetOrDefault(HeaderNames.ClientRetryAttemptCount, (int)HeaderNames.ClientRetryAttemptCount, 0, ref this.data.headerBitfield0);
        public string? TargetLsn => this.GetOrDefault(HeaderNames.TargetLsn, (int)HeaderNames.TargetLsn, 0, ref this.data.headerBitfield0);
        public string? TargetGlobalCommittedLsn => this.GetOrDefault(HeaderNames.TargetGlobalCommittedLsn, (int)HeaderNames.TargetGlobalCommittedLsn, 0, ref this.data.headerBitfield0);
        public string? TransportRequestID => this.GetOrDefault(HeaderNames.TransportRequestID, (int)HeaderNames.TransportRequestID, 0, ref this.data.headerBitfield0);
        public string? CollectionRemoteStorageSecurityIdentifier => this.GetOrDefault(HeaderNames.CollectionRemoteStorageSecurityIdentifier, (int)HeaderNames.CollectionRemoteStorageSecurityIdentifier, 0, ref this.data.headerBitfield0);
        public string? PopulateCollectionThroughputInfo => this.GetOrDefault(HeaderNames.PopulateCollectionThroughputInfo, (int)HeaderNames.PopulateCollectionThroughputInfo, 0, ref this.data.headerBitfield0);
        public string? RestoreMetadataFilter => this.GetOrDefault(HeaderNames.RestoreMetadataFilter, (int)HeaderNames.RestoreMetadataFilter, 0, ref this.data.headerBitfield0);
        public string? RestoreParams => this.GetOrDefault(HeaderNames.RestoreParams, (int)HeaderNames.RestoreParams, 0, ref this.data.headerBitfield0);
        public string? ShareThroughput => this.GetOrDefault(HeaderNames.ShareThroughput, (int)HeaderNames.ShareThroughput, 0, ref this.data.headerBitfield0);
        public string? PartitionResourceFilter => this.GetOrDefault(HeaderNames.PartitionResourceFilter, (int)HeaderNames.PartitionResourceFilter, 0, ref this.data.headerBitfield0);
        public string? IsReadOnlyScript => this.GetOrDefault(HeaderNames.IsReadOnlyScript, (int)HeaderNames.IsReadOnlyScript, 0, ref this.data.headerBitfield0);
        public string? IsAutoScaleRequest => this.GetOrDefault(HeaderNames.IsAutoScaleRequest, (int)HeaderNames.IsAutoScaleRequest, 0, ref this.data.headerBitfield0);
        public string? ForceQueryScan => this.GetOrDefault(HeaderNames.ForceQueryScan, (int)HeaderNames.ForceQueryScan, 0, ref this.data.headerBitfield0);

        // rolle dot headerBitField1
        public string? CanOfferReplaceComplete => this.GetOrDefault(HeaderNames.CanOfferReplaceComplete, (int)HeaderNames.CanOfferReplaceComplete - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ExcludeSystemProperties => this.GetOrDefault(HeaderNames.ExcludeSystemProperties, (int)HeaderNames.ExcludeSystemProperties - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? BinaryId => this.GetOrDefault(HeaderNames.BinaryId, (int)HeaderNames.BinaryId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? TimeToLiveInSeconds => this.GetOrDefault(HeaderNames.TimeToLiveInSeconds, (int)HeaderNames.TimeToLiveInSeconds - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? EffectivePartitionKey => this.GetOrDefault(HeaderNames.EffectivePartitionKey, (int)HeaderNames.EffectivePartitionKey - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? BinaryPassthroughRequest => this.GetOrDefault(HeaderNames.BinaryPassthroughRequest, (int)HeaderNames.BinaryPassthroughRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? EnableDynamicRidRangeAllocation => this.GetOrDefault(HeaderNames.EnableDynamicRidRangeAllocation, (int)HeaderNames.EnableDynamicRidRangeAllocation - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? EnumerationDirection => this.GetOrDefault(HeaderNames.EnumerationDirection, (int)HeaderNames.EnumerationDirection - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? StartId => this.GetOrDefault(HeaderNames.StartId, (int)HeaderNames.StartId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? EndId => this.GetOrDefault(HeaderNames.EndId, (int)HeaderNames.EndId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? FanoutOperationState => this.GetOrDefault(HeaderNames.FanoutOperationState, (int)HeaderNames.FanoutOperationState - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? StartEpk => this.GetOrDefault(HeaderNames.StartEpk, (int)HeaderNames.StartEpk - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? EndEpk => this.GetOrDefault(HeaderNames.EndEpk, (int)HeaderNames.EndEpk - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ReadFeedKeyType => this.GetOrDefault(HeaderNames.ReadFeedKeyType, (int)HeaderNames.ReadFeedKeyType - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ContentSerializationFormat => this.GetOrDefault(HeaderNames.ContentSerializationFormat, (int)HeaderNames.ContentSerializationFormat - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? AllowTentativeWrites => this.GetOrDefault(HeaderNames.AllowTentativeWrites, (int)HeaderNames.AllowTentativeWrites - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsUserRequest => this.GetOrDefault(HeaderNames.IsUserRequest, (int)HeaderNames.IsUserRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? PreserveFullContent => this.GetOrDefault(HeaderNames.PreserveFullContent, (int)HeaderNames.PreserveFullContent - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IncludeTentativeWrites => this.GetOrDefault(HeaderNames.IncludeTentativeWrites, (int)HeaderNames.IncludeTentativeWrites - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? PopulateResourceCount => this.GetOrDefault(HeaderNames.PopulateResourceCount, (int)HeaderNames.PopulateResourceCount - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? MergeStaticId => this.GetOrDefault(HeaderNames.MergeStaticId, (int)HeaderNames.MergeStaticId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsBatchAtomic => this.GetOrDefault(HeaderNames.IsBatchAtomic, (int)HeaderNames.IsBatchAtomic - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ShouldBatchContinueOnError => this.GetOrDefault(HeaderNames.ShouldBatchContinueOnError, (int)HeaderNames.ShouldBatchContinueOnError - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsBatchOrdered => this.GetOrDefault(HeaderNames.IsBatchOrdered, (int)HeaderNames.IsBatchOrdered - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SchemaOwnerRid => this.GetOrDefault(HeaderNames.SchemaOwnerRid, (int)HeaderNames.SchemaOwnerRid - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SchemaHash => this.GetOrDefault(HeaderNames.SchemaHash, (int)HeaderNames.SchemaHash - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsRUPerGBEnforcementRequest => this.GetOrDefault(HeaderNames.IsRUPerGBEnforcementRequest, (int)HeaderNames.IsRUPerGBEnforcementRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? MaxPollingIntervalMilliseconds => this.GetOrDefault(HeaderNames.MaxPollingIntervalMilliseconds, (int)HeaderNames.MaxPollingIntervalMilliseconds - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? PopulateLogStoreInfo => this.GetOrDefault(HeaderNames.PopulateLogStoreInfo, (int)HeaderNames.PopulateLogStoreInfo - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? GetAllPartitionKeyStatistics => this.GetOrDefault(HeaderNames.GetAllPartitionKeyStatistics, (int)HeaderNames.GetAllPartitionKeyStatistics - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ForceSideBySideIndexMigration => this.GetOrDefault(HeaderNames.ForceSideBySideIndexMigration, (int)HeaderNames.ForceSideBySideIndexMigration - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? CollectionChildResourceNameLimitInBytes => this.GetOrDefault(HeaderNames.CollectionChildResourceNameLimitInBytes, (int)HeaderNames.CollectionChildResourceNameLimitInBytes - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? CollectionChildResourceContentLimitInKB => this.GetOrDefault(HeaderNames.CollectionChildResourceContentLimitInKB, (int)HeaderNames.CollectionChildResourceContentLimitInKB - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? MergeCheckPointGLSN => this.GetOrDefault(HeaderNames.MergeCheckPointGLSN, (int)HeaderNames.MergeCheckPointGLSN - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? Prefer => this.GetOrDefault(HeaderNames.Prefer, (int)HeaderNames.Prefer - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? UniqueIndexNameEncodingMode => this.GetOrDefault(HeaderNames.UniqueIndexNameEncodingMode, (int)HeaderNames.UniqueIndexNameEncodingMode - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? PopulateUnflushedMergeEntryCount => this.GetOrDefault(HeaderNames.PopulateUnflushedMergeEntryCount, (int)HeaderNames.PopulateUnflushedMergeEntryCount - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? MigrateOfferToManualThroughput => this.GetOrDefault(HeaderNames.MigrateOfferToManualThroughput, (int)HeaderNames.MigrateOfferToManualThroughput - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? MigrateOfferToAutopilot => this.GetOrDefault(HeaderNames.MigrateOfferToAutopilot, (int)HeaderNames.MigrateOfferToAutopilot - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsClientEncrypted => this.GetOrDefault(HeaderNames.IsClientEncrypted, (int)HeaderNames.IsClientEncrypted - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SystemDocumentType => this.GetOrDefault(HeaderNames.SystemDocumentType, (int)HeaderNames.SystemDocumentType - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsOfferStorageRefreshRequest => this.GetOrDefault(HeaderNames.IsOfferStorageRefreshRequest, (int)HeaderNames.IsOfferStorageRefreshRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ResourceTypes => this.GetOrDefault(HeaderNames.ResourceTypes, (int)HeaderNames.ResourceTypes - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? TransactionId => this.GetOrDefault(HeaderNames.TransactionId, (int)HeaderNames.TransactionId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? TransactionFirstRequest => this.GetOrDefault(HeaderNames.TransactionFirstRequest, (int)HeaderNames.TransactionFirstRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? TransactionCommit => this.GetOrDefault(HeaderNames.TransactionCommit, (int)HeaderNames.TransactionCommit - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? UpdateMaxThroughputEverProvisioned => this.GetOrDefault(HeaderNames.UpdateMaxThroughputEverProvisioned, (int)HeaderNames.UpdateMaxThroughputEverProvisioned - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? UniqueIndexReIndexingState => this.GetOrDefault(HeaderNames.UniqueIndexReIndexingState, (int)HeaderNames.UniqueIndexReIndexingState - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? UseSystemBudget => this.GetOrDefault(HeaderNames.UseSystemBudget, (int)HeaderNames.UseSystemBudget - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IgnoreSystemLoweringMaxThroughput => this.GetOrDefault(HeaderNames.IgnoreSystemLoweringMaxThroughput, (int)HeaderNames.IgnoreSystemLoweringMaxThroughput - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? TruncateMergeLogRequest => this.GetOrDefault(HeaderNames.TruncateMergeLogRequest, (int)HeaderNames.TruncateMergeLogRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? RetriableWriteRequestId => this.GetOrDefault(HeaderNames.RetriableWriteRequestId, (int)HeaderNames.RetriableWriteRequestId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IsRetriedWriteRequest => this.GetOrDefault(HeaderNames.IsRetriedWriteRequest, (int)HeaderNames.IsRetriedWriteRequest - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? RetriableWriteRequestStartTimestamp => this.GetOrDefault(HeaderNames.RetriableWriteRequestStartTimestamp, (int)HeaderNames.RetriableWriteRequestStartTimestamp - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? AddResourcePropertiesToResponse => this.GetOrDefault(HeaderNames.AddResourcePropertiesToResponse, (int)HeaderNames.AddResourcePropertiesToResponse - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? ChangeFeedStartFullFidelityIfNoneMatch => this.GetOrDefault(HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch, (int)HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SystemRestoreOperation => this.GetOrDefault(HeaderNames.SystemRestoreOperation, (int)HeaderNames.SystemRestoreOperation - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SkipRefreshDatabaseAccountConfigs => this.GetOrDefault(HeaderNames.SkipRefreshDatabaseAccountConfigs, (int)HeaderNames.SkipRefreshDatabaseAccountConfigs - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? IntendedCollectionRid => this.GetOrDefault(HeaderNames.IntendedCollectionRid, (int)HeaderNames.IntendedCollectionRid - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? UseArchivalPartition => this.GetOrDefault(HeaderNames.UseArchivalPartition, (int)HeaderNames.UseArchivalPartition - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? PopulateUniqueIndexReIndexProgress => this.GetOrDefault(HeaderNames.PopulateUniqueIndexReIndexProgress, (int)HeaderNames.PopulateUniqueIndexReIndexProgress - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SchemaId => this.GetOrDefault(HeaderNames.SchemaId, (int)HeaderNames.SchemaId - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? CollectionTruncate => this.GetOrDefault(HeaderNames.CollectionTruncate, (int)HeaderNames.CollectionTruncate - 64, this.data.PopCount0, ref this.data.headerBitfield1);
        public string? SDKSupportedCapabilities => this.GetOrDefault(HeaderNames.SDKSupportedCapabilities, (int)HeaderNames.SDKSupportedCapabilities - 64, this.data.PopCount0, ref this.data.headerBitfield1);

        // rolled over to headerBitfield2
        public string? IsMaterializedViewBuild => this.GetOrDefault(HeaderNames.IsMaterializedViewBuild, (int)HeaderNames.IsMaterializedViewBuild - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? BuilderClientIdentifier => this.GetOrDefault(HeaderNames.BuilderClientIdentifier, (int)HeaderNames.BuilderClientIdentifier - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? SourceCollectionIfMatch => this.GetOrDefault(HeaderNames.SourceCollectionIfMatch, (int)HeaderNames.SourceCollectionIfMatch - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? RequestedCollectionType => this.GetOrDefault(HeaderNames.RequestedCollectionType, (int)HeaderNames.RequestedCollectionType - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? PopulateIndexMetrics => this.GetOrDefault(HeaderNames.PopulateIndexMetrics, (int)HeaderNames.PopulateIndexMetrics - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? PopulateAnalyticalMigrationProgress => this.GetOrDefault(HeaderNames.PopulateAnalyticalMigrationProgress, (int)HeaderNames.PopulateAnalyticalMigrationProgress - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? ShouldReturnCurrentServerDateTime => this.GetOrDefault(HeaderNames.ShouldReturnCurrentServerDateTime, (int)HeaderNames.ShouldReturnCurrentServerDateTime - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? RbacUserId => this.GetOrDefault(HeaderNames.RbacUserId, (int)HeaderNames.RbacUserId - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? RbacAction => this.GetOrDefault(HeaderNames.RbacAction, (int)HeaderNames.RbacAction - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? RbacResource => this.GetOrDefault(HeaderNames.RbacResource, (int)HeaderNames.RbacResource - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? CorrelatedActivityId => this.GetOrDefault(HeaderNames.CorrelatedActivityId, (int)HeaderNames.CorrelatedActivityId - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IsThroughputCapRequest => this.GetOrDefault(HeaderNames.IsThroughputCapRequest, (int)HeaderNames.IsThroughputCapRequest - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? ChangeFeedWireFormatVersion => this.GetOrDefault(HeaderNames.ChangeFeedWireFormatVersion, (int)HeaderNames.ChangeFeedWireFormatVersion - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? PopulateByokEncryptionProgress => this.GetOrDefault(HeaderNames.PopulateByokEncryptionProgress, (int)HeaderNames.PopulateByokEncryptionProgress - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? UseUserBackgroundBudget => this.GetOrDefault(HeaderNames.UseUserBackgroundBudget, (int)HeaderNames.UseUserBackgroundBudget - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IncludePhysicalPartitionThroughputInfo => this.GetOrDefault(HeaderNames.IncludePhysicalPartitionThroughputInfo, (int)HeaderNames.IncludePhysicalPartitionThroughputInfo - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IsServerlessStorageRefreshRequest => this.GetOrDefault(HeaderNames.IsServerlessStorageRefreshRequest, (int)HeaderNames.IsServerlessStorageRefreshRequest - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? UpdateOfferStateToPending => this.GetOrDefault(HeaderNames.UpdateOfferStateToPending, (int)HeaderNames.UpdateOfferStateToPending - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? PopulateOldestActiveSchema => this.GetOrDefault(HeaderNames.PopulateOldestActiveSchema, (int)HeaderNames.PopulateOldestActiveSchema - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IsInternalServerlessRequest => this.GetOrDefault(HeaderNames.IsInternalServerlessRequest, (int)HeaderNames.IsInternalServerlessRequest - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? OfferReplaceRURedistribution => this.GetOrDefault(HeaderNames.OfferReplaceRURedistribution, (int)HeaderNames.OfferReplaceRURedistribution - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IsMaterializedViewSourceSchemaReplaceBatchRequest => this.GetOrDefault(HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest, (int)HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest - 128, this.data.PopCount01, ref this.data.headerBitfield2);
        public string? IfMatch => this.GetOrDefault(HeaderNames.IfMatch, (int)HeaderNames.IfMatch - 128, this.data.PopCount01, ref this.data.headerBitfield2);

        public bool TryGetValue(HeaderNames header, out string? value)
        {
            ref ulong bitfieldForHeader = ref this.GetBitfieldForHeader(header, out int headerOffsetForMask, out int setBitsBeforeBitfield);
            int headerIxInBitfield = ((int)header - headerOffsetForMask);

            return this.TryGetValueImpl(header, headerIxInBitfield, setBitsBeforeBitfield, ref bitfieldForHeader, out value);
        }

        public void Set(HeaderNames header, string value)
        {
            ref ulong bitfieldForHeader = ref this.GetBitfieldForHeader(header, out int headerOffsetForMask, out int setBitsBeforeBitfield);

            int headerIxInBitfield = ((int)header - headerOffsetForMask);
            ulong headerAsBit = 1UL << headerIxInBitfield;

            // todo: a bts (bit test and set) intrinsic would be nice here, as we could get rid of headerAsBit entirely
            bool headerAlreadySet = (bitfieldForHeader & headerAsBit) != 0;
            if (headerAlreadySet)
            {
                throw new InvalidOperationException();
            }

            int currentlySetInAllMasks = this.data.PopCount012;

            int setInMaskBeforeHeader = PackedHeaders.CountHeadersSetBefore(headerIxInBitfield, bitfieldForHeader);

            int fieldIndexToUse = setBitsBeforeBitfield + setInMaskBeforeHeader;

            if (currentlySetInAllMasks < PackedHeaders.PackedCapacity)
            {
                // there's space

                if (fieldIndexToUse != currentlySetInAllMasks)
                {
                    // everything AFTER setBefore needs to be moved down, to make room for the new value
                    this.ShiftValuesDown(fieldIndexToUse);
                }

                // record the header's data
                ref string? storeInto = ref this.GetPackedValueRef(fieldIndexToUse);
                storeInto = value;
            }
            else
            {
                // adding this value requires putting stuff in overflow

                // the base case is we go straight to overflow...
                HeaderNames toPushHeader = header;
                string? toPushValue = value;

                if (fieldIndexToUse < PackedHeaders.PackedCapacity)
                {
                    // ... but sometimes
                    // this header goes into the packed fields, and we push one out
                    // the field to push out is either in `maskForHeader` or in a higher
                    // packed field

                    toPushHeader = this.GetLastPackedHeader();
                    toPushValue = this.ShiftValuesDown(fieldIndexToUse);

                    // record header's data
                    ref string? storeInto = ref this.GetPackedValueRef(fieldIndexToUse);
                    storeInto = value;
                }

                // push the header (or the evicted header) data into overflow
                this.PushToOverflow(toPushHeader, toPushValue);
            }

            // finally, update the mask
            bitfieldForHeader |= headerAsBit;
        }

        public KeysEnumerator GetEnumerator()
        => new KeysEnumerator(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string? GetOrDefault(HeaderNames header, int headerIxInBitfield, int setBitsBeforeBitfield, ref ulong bitfieldForHeader)
        => this.TryGetValueImpl(header, headerIxInBitfield, setBitsBeforeBitfield, ref bitfieldForHeader, out string? value) ? value : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private bool TryGetValueImpl(
            HeaderNames header,
            int headerIxInBitfield,
            int setBitsBeforeBitfield,
            ref ulong bitfieldForHeader,
            out string? value)
        {
            // it would be really nice if we could GUARANTEE this becomes a bt instruction,
            // but practically this appears to get compiled that way
            bool notSet = (bitfieldForHeader & (1UL << headerIxInBitfield)) == 0;

            if (notSet)
            {
                value = null;
                return false;
            }

            int setInMaskBeforeHeader = PackedHeaders.CountHeadersSetBefore(headerIxInBitfield, bitfieldForHeader);

            int fieldIndexToUse = setBitsBeforeBitfield + setInMaskBeforeHeader;

            if (fieldIndexToUse < PackedHeaders.PackedCapacity)
            {
                // this header is in a packed field
                value = this.GetPackedValueRef(fieldIndexToUse);
                return true;
            }
            else
            {
                // value is in overflow
                int overflowIndex = PackedHeaders.GetIndexInOveflow(header);
                value = this.overflow[overflowIndex];
                return true;
            }
        }

        private void PushToOverflow(HeaderNames header, string? value)
        {
            int indexInOverflow = PackedHeaders.GetIndexInOveflow(header);

            int neededSize = indexInOverflow + 1;

            int oldLength = this.overflow.Length;

            if (oldLength < neededSize)
            {
                int newSize = 1 << (32 - PackedHeaders.LeadingZeroCount(neededSize));
                if (newSize > (PackedHeaders.MaximumHeaderCount - PackedHeaders.PackedCapacity))
                {
                    newSize = (PackedHeaders.MaximumHeaderCount - PackedHeaders.PackedCapacity);
                }

                string?[] newOverflow = new string?[newSize];

                if (oldLength > 0)
                {
                    // copy just the set bits
                    HeaderNames firstOverflowHeader = this.GetFirstOverflowHeader();
                    HeaderNames lastOverflowheader = this.GetLastOverflowHeader();
                    int firstOverflowIndex = PackedHeaders.GetIndexInOveflow(firstOverflowHeader);
                    int lastOverflowIndex = PackedHeaders.GetIndexInOveflow(lastOverflowheader);
                    ReadOnlySpan<string?> toCopy = this.overflow.AsSpan()[firstOverflowIndex..lastOverflowIndex];
                    Span<string?> copyInto = newOverflow.AsSpan()[firstOverflowIndex..lastOverflowIndex];
                    toCopy.CopyTo(copyInto);
                }

                this.overflow = newOverflow;
            }

            this.overflow[indexInOverflow] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref string? GetPackedValueRef(int ix)
        {
            return ref Unsafe.Add(ref this.data.packedValue0, ix);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetBitfieldByIndex(int ix)
        {
            ref ulong ptr = ref Unsafe.Add(ref this.data.headerBitfield0, ix);

            return ptr;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string? ShiftValuesDown(int fromIx)
        {
            string? valueShiftedOut = this.data.packedValue9;

            ref string? copyFrom = ref this.GetPackedValueRef(fromIx);
            ref string? copyTo = ref Unsafe.Add(ref copyFrom, 1);
            int copyLength = (PackedHeaders.PackedCapacity - 1) - fromIx;

            Span<string?> copyFromSpan = MemoryMarshal.CreateSpan(ref copyFrom, copyLength);
            Span<string?> copyToSpan = MemoryMarshal.CreateSpan(ref copyTo, copyLength);

            copyFromSpan.CopyTo(copyToSpan);

            return valueShiftedOut;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HeaderNames GetLastPackedHeader()
        {
            // assumes there is at least one packed header

            int remainingCapacity = PackedHeaders.PackedCapacity;

            int packedInHeaders0 = PackedHeaders.PopCount(this.data.headerBitfield0);
            if (packedInHeaders0 >= remainingCapacity)
            {
                return (HeaderNames)PackedHeaders.NthSetHeader(this.data.headerBitfield0, remainingCapacity - 1);
            }
            else
            {
                remainingCapacity -= packedInHeaders0;
                int packedInHeaders1 = PackedHeaders.PopCount(this.data.headerBitfield1);
                if (packedInHeaders1 >= remainingCapacity)
                {
                    return (HeaderNames)(PackedHeaders.NthSetHeader(this.data.headerBitfield1, remainingCapacity - 1) + 64);
                }

                remainingCapacity -= packedInHeaders1;

                return (HeaderNames)(PackedHeaders.NthSetHeader(this.data.headerBitfield2, remainingCapacity - 1) + 64 * 2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HeaderNames GetFirstOverflowHeader()
        {
            // assumes that there is at least one header in overflow

            int remainingCapacity = PackedHeaders.PackedCapacity + 1;

            int packedInHeaders0 = PackedHeaders.PopCount(this.data.headerBitfield0);
            if (packedInHeaders0 >= remainingCapacity)
            {
                return (HeaderNames)PackedHeaders.NthSetHeader(this.data.headerBitfield0, remainingCapacity - 1);
            }
            else
            {
                remainingCapacity -= packedInHeaders0;
                int packedInHeaders1 = PackedHeaders.PopCount(this.data.headerBitfield1);
                if (packedInHeaders1 >= remainingCapacity)
                {
                    return (HeaderNames)(PackedHeaders.NthSetHeader(this.data.headerBitfield1, remainingCapacity - 1) + 64);
                }

                remainingCapacity -= packedInHeaders1;

                return (HeaderNames)(PackedHeaders.NthSetHeader(this.data.headerBitfield2, remainingCapacity - 1) + 64 * 2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HeaderNames GetLastOverflowHeader()
        {
            // assumes that there is at least one header in overflow

            int lzcnt2 = PackedHeaders.LeadingZeroCount(this.data.headerBitfield2);
            if (lzcnt2 != 64)
            {
                return (HeaderNames)(64 - lzcnt2 + 64 * 2);
            }

            int lzcnt1 = PackedHeaders.LeadingZeroCount(this.data.headerBitfield1);
            if (lzcnt1 != 64)
            {
                return (HeaderNames)(64 - lzcnt1 + 64);
            }

            int lzcnt0 = PackedHeaders.LeadingZeroCount(this.data.headerBitfield0);
            return (HeaderNames)(64 - lzcnt0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ref ulong GetBitfieldForHeader(HeaderNames names, out int headerOffset, out int setBitsBeforeBitfield)
        {
            int asInt = (int)names;

            int bitfieldIndex = asInt / 64;
            headerOffset = 64 * bitfieldIndex;

            ref ulong bitfield = ref this.data.headerBitfield0;

            setBitsBeforeBitfield = 0;
            for (int i = 0; i < bitfieldIndex; i++)
            {
                setBitsBeforeBitfield += PackedHeaders.PopCount(bitfield);
                bitfield = ref Unsafe.Add(ref bitfield, 1);
            }

            return ref bitfield;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetIndexInOveflow(HeaderNames header)
        {
            // by the pigeonhole principle, the SMALLEST value that can go into overflow is PackedCapacity
            // so we can shrink this a bit
            int indexInOverflow = (int)header - PackedHeaders.PackedCapacity;

            return indexInOverflow;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int CountHeadersSetBefore(int headerIx, ulong setHeaders)
        {
            ulong bitsBeforeHeader = PackedHeaders.ZeroHighBits(setHeaders, headerIx);
            int setBeforeHeader = PackedHeaders.PopCount(bitsBeforeHeader);

            return setBeforeHeader;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static ulong ZeroHighBits(ulong value, int afterIx)
        {
            if (System.Runtime.Intrinsics.X86.Bmi2.X64.IsSupported)
            {
                return System.Runtime.Intrinsics.X86.Bmi2.X64.ZeroHighBits(value, (ulong)afterIx);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static int NthSetHeader(ulong value, int n)
        {
            // see: https://stackoverflow.com/a/27453505 , slightly tweaked
            if (System.Runtime.Intrinsics.X86.Bmi2.X64.IsSupported && System.Runtime.Intrinsics.X86.Bmi1.X64.IsSupported)
            {
                ulong nthBitAsMask = System.Runtime.Intrinsics.X86.Bmi2.X64.ParallelBitDeposit(1UL << n, value);
                int indexOfBit = (int)System.Runtime.Intrinsics.X86.Bmi1.X64.TrailingZeroCount(nthBitAsMask);

                return indexOfBit;
            }

            throw new NotImplementedException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static int PopCount(ulong value)
        {
            if (System.Runtime.Intrinsics.X86.Popcnt.X64.IsSupported)
            {
                return (int)System.Runtime.Intrinsics.X86.Popcnt.X64.PopCount(value);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static int LeadingZeroCount(int value)
        {
            if (System.Runtime.Intrinsics.X86.Lzcnt.IsSupported)
            {
                return (int)System.Runtime.Intrinsics.X86.Lzcnt.LeadingZeroCount((uint)value);
            }

            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static int LeadingZeroCount(ulong value)
        {
            if (System.Runtime.Intrinsics.X86.Lzcnt.X64.IsSupported)
            {
                return (int)System.Runtime.Intrinsics.X86.Lzcnt.X64.LeadingZeroCount(value);
            }

            throw new NotImplementedException();
        }

        [StructLayout(LayoutKind.Explicit, Size = 8 * 3 + 8 * 10)]
        private struct Data
        {
            [FieldOffset(0 * 8)]
            internal ulong headerBitfield0;
            [FieldOffset(1 * 8)]
            internal ulong headerBitfield1;
            [FieldOffset(2 * 8)]
            internal ulong headerBitfield2;

            [FieldOffset(3 * 8)]
            internal string? packedValue0;
            [FieldOffset(4 * 8)]
            internal string? packedValue1;
            [FieldOffset(5 * 8)]
            internal string? packedValue2;
            [FieldOffset(6 * 8)]
            internal string? packedValue3;
            [FieldOffset(7 * 8)]
            internal string? packedValue4;
            [FieldOffset(8 * 8)]
            internal string? packedValue5;
            [FieldOffset(9 * 8)]
            internal string? packedValue6;
            [FieldOffset(10 * 8)]
            internal string? packedValue7;
            [FieldOffset(11 * 8)]
            internal string? packedValue8;
            [FieldOffset(12 * 8)]
            internal string? packedValue9;

            internal int PopCount0
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return PackedHeaders.PopCount(this.headerBitfield0);
                }
            }

            internal int PopCount01
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return PackedHeaders.PopCount(this.headerBitfield0) + PackedHeaders.PopCount(this.headerBitfield1);
                }
            }

            internal int PopCount012
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    return PackedHeaders.PopCount(this.headerBitfield0) + PackedHeaders.PopCount(this.headerBitfield1) + PackedHeaders.PopCount(this.headerBitfield2);
                }
            }
        }

        internal struct KeysEnumerator : IEnumerator<HeaderNames>
        {
            private byte bitfieldOffset;
            private byte headerNumInBitfield;
            private readonly PackedHeaders headers;

            internal KeysEnumerator(PackedHeaders headers)
            {
                this.Current = 0;
                this.headers = headers;
                this.bitfieldOffset = 0;
                this.headerNumInBitfield = 0;
            }

            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => this.Current;

            public bool MoveNext()
            {
                while (this.bitfieldOffset < 3)
                {
                    ulong bitfield = this.headers.GetBitfieldByIndex(this.bitfieldOffset);
                    int bitIx = PackedHeaders.NthSetHeader(bitfield, this.headerNumInBitfield);

                    if (bitIx != 64)
                    {
                        int headerIndex = (this.bitfieldOffset * 64) + bitIx;
                        Current = (HeaderNames)headerIndex;

                        this.headerNumInBitfield++;

                        if (this.headerNumInBitfield == 64)
                        {
                            this.headerNumInBitfield = 0;
                            this.bitfieldOffset++;
                        }

                        return true;
                    }

                    this.headerNumInBitfield = 0;
                    this.bitfieldOffset++;
                }

                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public void Dispose() { }
        }
    }
}
