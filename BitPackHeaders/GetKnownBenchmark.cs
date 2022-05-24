using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;

namespace BitPackHeaders
{
    public class GetKnownBenchmark
    {
        private const int Iterations = 10_000;

        [Params(1, 4, 10, 64)]
        public int NumHeadersLookedUp { get; set; }

        //[Params(0, 2022_05_19, 123456789)]
        public int Seed { get; set; }

        [Params(
            0, 
            10, 
            //20, 
            30, 
            //40, 
            //50, 
            60, 
            //70, 
            //80, 
            //90, 
            100)]
        public int HitRate { get; set; }

        private DictionaryHeaders dictionary;
        private FieldHeaders fields;
        private ArrayHeaders array;
        private PackedHeaders packed;

        private HeaderNames[] headersToLookup;

        [GlobalSetup]
        public void Init()
        {
            this.Seed = 2022_05_19;

            int neededRealHeaders = (int)(HitRate / 100.0 * NumHeadersLookedUp);
            int neededMissHeaders = NumHeadersLookedUp - neededRealHeaders;

            (HeaderNames Header, string Value)[] storedHeaders = new (HeaderNames Header, string Value)[neededRealHeaders];
            Random r = new Random(Seed);

            List<HeaderNames> allHeaders = Enum.GetValues<HeaderNames>().ToList();

            for (int i = 0; i < storedHeaders.Length; i++)
            {
                int nextHeaderIx = r.Next(allHeaders.Count);
                storedHeaders[i] = (allHeaders[nextHeaderIx], i.ToString());

                allHeaders.RemoveAt(nextHeaderIx);
            }

            this.dictionary = new DictionaryHeaders();
            this.fields = new FieldHeaders();
            this.array = new ArrayHeaders();
            this.packed = new PackedHeaders();
            for (var i = 0; i < storedHeaders.Length; i++)
            {
                (HeaderNames Header, string Value) val = storedHeaders[i];
                dictionary.Set(val.Header, val.Value);
                fields.Set(val.Header, val.Value);
                array.Set(val.Header, val.Value);
                packed.Set(val.Header, val.Value);
            }

            List<HeaderNames> missHeaders = new List<HeaderNames>();
            for (int i = 0; i < neededMissHeaders; i++)
            {
                int nextHeaderIx = r.Next(allHeaders.Count);
                missHeaders.Add(allHeaders[nextHeaderIx]);

                allHeaders.RemoveAt(nextHeaderIx);
            }

            headersToLookup = storedHeaders.Select(s => s.Header).Concat(missHeaders).Select(t => (t, r.Next())).OrderBy(t => t.Item2).Select(t => t.t).ToArray();
        }

        [Benchmark]
        public void Dictionary()
        {
            string?[] store = ArrayPool<string?>.Shared.Rent(this.headersToLookup.Length);

            for(int x = 0; x < GetKnownBenchmark.Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    HeaderNames name = this.headersToLookup[i];
                    switch (name)
                    {
                        case HeaderNames.AddResourcePropertiesToResponse: store[i] = dictionary.AddResourcePropertiesToResponse; break;
                        case HeaderNames.AllowTentativeWrites: store[i] = dictionary.AllowTentativeWrites; break;
                        case HeaderNames.Authorization: store[i] = dictionary.Authorization; break;
                        case HeaderNames.A_IM: store[i] = dictionary.A_IM; break;
                        case HeaderNames.BinaryId: store[i] = dictionary.BinaryId; break;
                        case HeaderNames.BinaryPassthroughRequest: store[i] = dictionary.BinaryPassthroughRequest; break;
                        case HeaderNames.BindReplicaDirective: store[i] = dictionary.BindReplicaDirective; break;
                        case HeaderNames.BuilderClientIdentifier: store[i] = dictionary.BuilderClientIdentifier; break;
                        case HeaderNames.CanCharge: store[i] = dictionary.CanCharge; break;
                        case HeaderNames.CanOfferReplaceComplete: store[i] = dictionary.CanOfferReplaceComplete; break;
                        case HeaderNames.CanThrottle: store[i] = dictionary.CanThrottle; break;
                        case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: store[i] = dictionary.ChangeFeedStartFullFidelityIfNoneMatch; break;
                        case HeaderNames.ChangeFeedWireFormatVersion: store[i] = dictionary.ChangeFeedWireFormatVersion; break;
                        case HeaderNames.ClientRetryAttemptCount: store[i] = dictionary.ClientRetryAttemptCount; break;
                        case HeaderNames.CollectionChildResourceContentLimitInKB: store[i] = dictionary.CollectionChildResourceContentLimitInKB; break;
                        case HeaderNames.CollectionChildResourceNameLimitInBytes: store[i] = dictionary.CollectionChildResourceNameLimitInBytes; break;
                        case HeaderNames.CollectionPartitionIndex: store[i] = dictionary.CollectionPartitionIndex; break;
                        case HeaderNames.CollectionRemoteStorageSecurityIdentifier: store[i] = dictionary.CollectionRemoteStorageSecurityIdentifier; break;
                        case HeaderNames.CollectionRid: store[i] = dictionary.CollectionRid; break;
                        case HeaderNames.CollectionServiceIndex: store[i] = dictionary.CollectionServiceIndex; break;
                        case HeaderNames.CollectionTruncate: store[i] = dictionary.CollectionTruncate; break;
                        case HeaderNames.ConsistencyLevel: store[i] = dictionary.ConsistencyLevel; break;
                        case HeaderNames.ContentSerializationFormat: store[i] = dictionary.ContentSerializationFormat; break;
                        case HeaderNames.Continuation: store[i] = dictionary.Continuation; break;
                        case HeaderNames.CorrelatedActivityId: store[i] = dictionary.CorrelatedActivityId; break;
                        case HeaderNames.DisableRUPerMinuteUsage: store[i] = dictionary.DisableRUPerMinuteUsage; break;
                        case HeaderNames.EffectivePartitionKey: store[i] = dictionary.EffectivePartitionKey; break;
                        case HeaderNames.EmitVerboseTracesInQuery: store[i] = dictionary.EmitVerboseTracesInQuery; break;
                        case HeaderNames.EnableDynamicRidRangeAllocation: store[i] = dictionary.EnableDynamicRidRangeAllocation; break;
                        case HeaderNames.EnableLogging: store[i] = dictionary.EnableLogging; break;
                        case HeaderNames.EnableLowPrecisionOrderBy: store[i] = dictionary.EnableLowPrecisionOrderBy; break;
                        case HeaderNames.EnableScanInQuery: store[i] = dictionary.EnableScanInQuery; break;
                        case HeaderNames.EndEpk: store[i] = dictionary.EndEpk; break;
                        case HeaderNames.EndId: store[i] = dictionary.EndId; break;
                        case HeaderNames.EntityId: store[i] = dictionary.EntityId; break;
                        case HeaderNames.EnumerationDirection: store[i] = dictionary.EnumerationDirection; break;
                        case HeaderNames.ExcludeSystemProperties: store[i] = dictionary.ExcludeSystemProperties; break;
                        case HeaderNames.FanoutOperationState: store[i] = dictionary.FanoutOperationState; break;
                        case HeaderNames.FilterBySchemaResourceId: store[i] = dictionary.FilterBySchemaResourceId; break;
                        case HeaderNames.ForceQueryScan: store[i] = dictionary.ForceQueryScan; break;
                        case HeaderNames.ForceSideBySideIndexMigration: store[i] = dictionary.ForceSideBySideIndexMigration; break;
                        case HeaderNames.GatewaySignature: store[i] = dictionary.GatewaySignature; break;
                        case HeaderNames.GetAllPartitionKeyStatistics: store[i] = dictionary.GetAllPartitionKeyStatistics; break;
                        case HeaderNames.HttpDate: store[i] = dictionary.HttpDate; break;
                        case HeaderNames.IfMatch: store[i] = dictionary.IfMatch; break;
                        case HeaderNames.IfModifiedSince: store[i] = dictionary.IfModifiedSince; break;
                        case HeaderNames.IfNoneMatch: store[i] = dictionary.IfNoneMatch; break;
                        case HeaderNames.IgnoreSystemLoweringMaxThroughput: store[i] = dictionary.IgnoreSystemLoweringMaxThroughput; break;
                        case HeaderNames.IncludePhysicalPartitionThroughputInfo: store[i] = dictionary.IncludePhysicalPartitionThroughputInfo; break;
                        case HeaderNames.IncludeTentativeWrites: store[i] = dictionary.IncludeTentativeWrites; break;
                        case HeaderNames.IndexingDirective: store[i] = dictionary.IndexingDirective; break;
                        case HeaderNames.IntendedCollectionRid: store[i] = dictionary.IntendedCollectionRid; break;
                        case HeaderNames.IsAutoScaleRequest: store[i] = dictionary.IsAutoScaleRequest; break;
                        case HeaderNames.IsBatchAtomic: store[i] = dictionary.IsBatchAtomic; break;
                        case HeaderNames.IsBatchOrdered: store[i] = dictionary.IsBatchOrdered; break;
                        case HeaderNames.IsClientEncrypted: store[i] = dictionary.IsClientEncrypted; break;
                        case HeaderNames.IsFanoutRequest: store[i] = dictionary.IsFanoutRequest; break;
                        case HeaderNames.IsInternalServerlessRequest: store[i] = dictionary.IsInternalServerlessRequest; break;
                        case HeaderNames.IsMaterializedViewBuild: store[i] = dictionary.IsMaterializedViewBuild; break;
                        case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: store[i] = dictionary.IsMaterializedViewSourceSchemaReplaceBatchRequest; break;
                        case HeaderNames.IsOfferStorageRefreshRequest: store[i] = dictionary.IsOfferStorageRefreshRequest; break;
                        case HeaderNames.IsReadOnlyScript: store[i] = dictionary.IsReadOnlyScript; break;
                        case HeaderNames.IsRetriedWriteRequest: store[i] = dictionary.IsRetriedWriteRequest; break;
                        case HeaderNames.IsRUPerGBEnforcementRequest: store[i] = dictionary.IsRUPerGBEnforcementRequest; break;
                        case HeaderNames.IsServerlessStorageRefreshRequest: store[i] = dictionary.IsServerlessStorageRefreshRequest; break;
                        case HeaderNames.IsThroughputCapRequest: store[i] = dictionary.IsThroughputCapRequest; break;
                        case HeaderNames.IsUserRequest: store[i] = dictionary.IsUserRequest; break;
                        case HeaderNames.MaxPollingIntervalMilliseconds: store[i] = dictionary.MaxPollingIntervalMilliseconds; break;
                        case HeaderNames.MergeCheckPointGLSN: store[i] = dictionary.MergeCheckPointGLSN; break;
                        case HeaderNames.MergeStaticId: store[i] = dictionary.MergeStaticId; break;
                        case HeaderNames.MigrateCollectionDirective: store[i] = dictionary.MigrateCollectionDirective; break;
                        case HeaderNames.MigrateOfferToAutopilot: store[i] = dictionary.MigrateOfferToAutopilot; break;
                        case HeaderNames.MigrateOfferToManualThroughput: store[i] = dictionary.MigrateOfferToManualThroughput; break;
                        case HeaderNames.OfferReplaceRURedistribution: store[i] = dictionary.OfferReplaceRURedistribution; break;
                        case HeaderNames.PageSize: store[i] = dictionary.PageSize; break;
                        case HeaderNames.PartitionCount: store[i] = dictionary.PartitionCount; break;
                        case HeaderNames.PartitionKey: store[i] = dictionary.PartitionKey; break;
                        case HeaderNames.PartitionKeyRangeId: store[i] = dictionary.PartitionKeyRangeId; break;
                        case HeaderNames.PartitionResourceFilter: store[i] = dictionary.PartitionResourceFilter; break;
                        case HeaderNames.PopulateAnalyticalMigrationProgress: store[i] = dictionary.PopulateAnalyticalMigrationProgress; break;
                        case HeaderNames.PopulateByokEncryptionProgress: store[i] = dictionary.PopulateByokEncryptionProgress; break;
                        case HeaderNames.PopulateCollectionThroughputInfo: store[i] = dictionary.PopulateCollectionThroughputInfo; break;
                        case HeaderNames.PopulateIndexMetrics: store[i] = dictionary.PopulateIndexMetrics; break;
                        case HeaderNames.PopulateLogStoreInfo: store[i] = dictionary.PopulateLogStoreInfo; break;
                        case HeaderNames.PopulateOldestActiveSchema: store[i] = dictionary.PopulateOldestActiveSchema; break;
                        case HeaderNames.PopulatePartitionStatistics: store[i] = dictionary.PopulatePartitionStatistics; break;
                        case HeaderNames.PopulateQueryMetrics: store[i] = dictionary.PopulateQueryMetrics; break;
                        case HeaderNames.PopulateQuotaInfo: store[i] = dictionary.PopulateQuotaInfo; break;
                        case HeaderNames.PopulateResourceCount: store[i] = dictionary.PopulateResourceCount; break;
                        case HeaderNames.PopulateUnflushedMergeEntryCount: store[i] = dictionary.PopulateUnflushedMergeEntryCount; break;
                        case HeaderNames.PopulateUniqueIndexReIndexProgress: store[i] = dictionary.PopulateUniqueIndexReIndexProgress; break;
                        case HeaderNames.PostTriggerExclude: store[i] = dictionary.PostTriggerExclude; break;
                        case HeaderNames.PostTriggerInclude: store[i] = dictionary.PostTriggerInclude; break;
                        case HeaderNames.Prefer: store[i] = dictionary.Prefer; break;
                        case HeaderNames.PreserveFullContent: store[i] = dictionary.PreserveFullContent; break;
                        case HeaderNames.PreTriggerExclude: store[i] = dictionary.PreTriggerExclude; break;
                        case HeaderNames.PreTriggerInclude: store[i] = dictionary.PreTriggerInclude; break;
                        case HeaderNames.PrimaryMasterKey: store[i] = dictionary.PrimaryMasterKey; break;
                        case HeaderNames.PrimaryReadonlyKey: store[i] = dictionary.PrimaryReadonlyKey; break;
                        case HeaderNames.ProfileRequest: store[i] = dictionary.ProfileRequest; break;
                        case HeaderNames.RbacAction: store[i] = dictionary.RbacAction; break;
                        case HeaderNames.RbacResource: store[i] = dictionary.RbacResource; break;
                        case HeaderNames.RbacUserId: store[i] = dictionary.RbacUserId; break;
                        case HeaderNames.ReadFeedKeyType: store[i] = dictionary.ReadFeedKeyType; break;
                        case HeaderNames.RemainingTimeInMsOnClientRequest: store[i] = dictionary.RemainingTimeInMsOnClientRequest; break;
                        case HeaderNames.RemoteStorageType: store[i] = dictionary.RemoteStorageType; break;
                        case HeaderNames.RequestedCollectionType: store[i] = dictionary.RequestedCollectionType; break;
                        case HeaderNames.ResourceId: store[i] = dictionary.ResourceId; break;
                        case HeaderNames.ResourceSchemaName: store[i] = dictionary.ResourceSchemaName; break;
                        case HeaderNames.ResourceTokenExpiry: store[i] = dictionary.ResourceTokenExpiry; break;
                        case HeaderNames.ResourceTypes: store[i] = dictionary.ResourceTypes; break;
                        case HeaderNames.ResponseContinuationTokenLimitInKB: store[i] = dictionary.ResponseContinuationTokenLimitInKB; break;
                        case HeaderNames.RestoreMetadataFilter: store[i] = dictionary.RestoreMetadataFilter; break;
                        case HeaderNames.RestoreParams: store[i] = dictionary.RestoreParams; break;
                        case HeaderNames.RetriableWriteRequestId: store[i] = dictionary.RetriableWriteRequestId; break;
                        case HeaderNames.RetriableWriteRequestStartTimestamp: store[i] = dictionary.RetriableWriteRequestStartTimestamp; break;
                        case HeaderNames.SchemaHash: store[i] = dictionary.SchemaHash; break;
                        case HeaderNames.SchemaId: store[i] = dictionary.SchemaId; break;
                        case HeaderNames.SchemaOwnerRid: store[i] = dictionary.SchemaOwnerRid; break;
                        case HeaderNames.SDKSupportedCapabilities: store[i] = dictionary.SDKSupportedCapabilities; break;
                        case HeaderNames.SecondaryMasterKey: store[i] = dictionary.SecondaryMasterKey; break;
                        case HeaderNames.SecondaryReadonlyKey: store[i] = dictionary.SecondaryReadonlyKey; break;
                        case HeaderNames.SessionToken: store[i] = dictionary.SessionToken; break;
                        case HeaderNames.ShareThroughput: store[i] = dictionary.ShareThroughput; break;
                        case HeaderNames.ShouldBatchContinueOnError: store[i] = dictionary.ShouldBatchContinueOnError; break;
                        case HeaderNames.ShouldReturnCurrentServerDateTime: store[i] = dictionary.ShouldReturnCurrentServerDateTime; break;
                        case HeaderNames.SkipRefreshDatabaseAccountConfigs: store[i] = dictionary.SkipRefreshDatabaseAccountConfigs; break;
                        case HeaderNames.SourceCollectionIfMatch: store[i] = dictionary.SourceCollectionIfMatch; break;
                        case HeaderNames.StartEpk: store[i] = dictionary.StartEpk; break;
                        case HeaderNames.StartId: store[i] = dictionary.StartId; break;
                        case HeaderNames.SupportSpatialLegacyCoordinates: store[i] = dictionary.SupportSpatialLegacyCoordinates; break;
                        case HeaderNames.SystemDocumentType: store[i] = dictionary.SystemDocumentType; break;
                        case HeaderNames.SystemRestoreOperation: store[i] = dictionary.SystemRestoreOperation; break;
                        case HeaderNames.TargetGlobalCommittedLsn: store[i] = dictionary.TargetGlobalCommittedLsn; break;
                        case HeaderNames.TargetLsn: store[i] = dictionary.TargetLsn; break;
                        case HeaderNames.TimeToLiveInSeconds: store[i] = dictionary.TimeToLiveInSeconds; break;
                        case HeaderNames.TransactionCommit: store[i] = dictionary.TransactionCommit; break;
                        case HeaderNames.TransactionFirstRequest: store[i] = dictionary.TransactionFirstRequest; break;
                        case HeaderNames.TransactionId: store[i] = dictionary.TransactionId; break;
                        case HeaderNames.TransportRequestID: store[i] = dictionary.TransportRequestID; break;
                        case HeaderNames.TruncateMergeLogRequest: store[i] = dictionary.TruncateMergeLogRequest; break;
                        case HeaderNames.UniqueIndexNameEncodingMode: store[i] = dictionary.UniqueIndexNameEncodingMode; break;
                        case HeaderNames.UniqueIndexReIndexingState: store[i] = dictionary.UniqueIndexReIndexingState; break;
                        case HeaderNames.UpdateMaxThroughputEverProvisioned: store[i] = dictionary.UpdateMaxThroughputEverProvisioned; break;
                        case HeaderNames.UpdateOfferStateToPending: store[i] = dictionary.UpdateOfferStateToPending; break;
                        case HeaderNames.UseArchivalPartition: store[i] = dictionary.UseArchivalPartition; break;
                        case HeaderNames.UsePolygonsSmallerThanAHemisphere: store[i] = dictionary.UsePolygonsSmallerThanAHemisphere; break;
                        case HeaderNames.UseSystemBudget: store[i] = dictionary.UseSystemBudget; break;
                        case HeaderNames.UseUserBackgroundBudget: store[i] = dictionary.UseUserBackgroundBudget; break;
                        case HeaderNames.Version: store[i] = dictionary.Version; break;
                        case HeaderNames.XDate: store[i] = dictionary.XDate; break;
                        default: throw new ArgumentException(nameof(name), $"Was {name}");
                    }
                }
            }

            ArrayPool<string?>.Shared.Return(store);
        }

        [Benchmark]
        public void Fields()
        {
            string?[] store = ArrayPool<string?>.Shared.Rent(this.headersToLookup.Length);

            for (int x = 0; x < GetKnownBenchmark.Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    HeaderNames name = this.headersToLookup[i];
                    switch (name)
                    {
                        case HeaderNames.AddResourcePropertiesToResponse: store[i] = fields.AddResourcePropertiesToResponse; break;
                        case HeaderNames.AllowTentativeWrites: store[i] = fields.AllowTentativeWrites; break;
                        case HeaderNames.Authorization: store[i] = fields.Authorization; break;
                        case HeaderNames.A_IM: store[i] = fields.A_IM; break;
                        case HeaderNames.BinaryId: store[i] = fields.BinaryId; break;
                        case HeaderNames.BinaryPassthroughRequest: store[i] = fields.BinaryPassthroughRequest; break;
                        case HeaderNames.BindReplicaDirective: store[i] = fields.BindReplicaDirective; break;
                        case HeaderNames.BuilderClientIdentifier: store[i] = fields.BuilderClientIdentifier; break;
                        case HeaderNames.CanCharge: store[i] = fields.CanCharge; break;
                        case HeaderNames.CanOfferReplaceComplete: store[i] = fields.CanOfferReplaceComplete; break;
                        case HeaderNames.CanThrottle: store[i] = fields.CanThrottle; break;
                        case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: store[i] = fields.ChangeFeedStartFullFidelityIfNoneMatch; break;
                        case HeaderNames.ChangeFeedWireFormatVersion: store[i] = fields.ChangeFeedWireFormatVersion; break;
                        case HeaderNames.ClientRetryAttemptCount: store[i] = fields.ClientRetryAttemptCount; break;
                        case HeaderNames.CollectionChildResourceContentLimitInKB: store[i] = fields.CollectionChildResourceContentLimitInKB; break;
                        case HeaderNames.CollectionChildResourceNameLimitInBytes: store[i] = fields.CollectionChildResourceNameLimitInBytes; break;
                        case HeaderNames.CollectionPartitionIndex: store[i] = fields.CollectionPartitionIndex; break;
                        case HeaderNames.CollectionRemoteStorageSecurityIdentifier: store[i] = fields.CollectionRemoteStorageSecurityIdentifier; break;
                        case HeaderNames.CollectionRid: store[i] = fields.CollectionRid; break;
                        case HeaderNames.CollectionServiceIndex: store[i] = fields.CollectionServiceIndex; break;
                        case HeaderNames.CollectionTruncate: store[i] = fields.CollectionTruncate; break;
                        case HeaderNames.ConsistencyLevel: store[i] = fields.ConsistencyLevel; break;
                        case HeaderNames.ContentSerializationFormat: store[i] = fields.ContentSerializationFormat; break;
                        case HeaderNames.Continuation: store[i] = fields.Continuation; break;
                        case HeaderNames.CorrelatedActivityId: store[i] = fields.CorrelatedActivityId; break;
                        case HeaderNames.DisableRUPerMinuteUsage: store[i] = fields.DisableRUPerMinuteUsage; break;
                        case HeaderNames.EffectivePartitionKey: store[i] = fields.EffectivePartitionKey; break;
                        case HeaderNames.EmitVerboseTracesInQuery: store[i] = fields.EmitVerboseTracesInQuery; break;
                        case HeaderNames.EnableDynamicRidRangeAllocation: store[i] = fields.EnableDynamicRidRangeAllocation; break;
                        case HeaderNames.EnableLogging: store[i] = fields.EnableLogging; break;
                        case HeaderNames.EnableLowPrecisionOrderBy: store[i] = fields.EnableLowPrecisionOrderBy; break;
                        case HeaderNames.EnableScanInQuery: store[i] = fields.EnableScanInQuery; break;
                        case HeaderNames.EndEpk: store[i] = fields.EndEpk; break;
                        case HeaderNames.EndId: store[i] = fields.EndId; break;
                        case HeaderNames.EntityId: store[i] = fields.EntityId; break;
                        case HeaderNames.EnumerationDirection: store[i] = fields.EnumerationDirection; break;
                        case HeaderNames.ExcludeSystemProperties: store[i] = fields.ExcludeSystemProperties; break;
                        case HeaderNames.FanoutOperationState: store[i] = fields.FanoutOperationState; break;
                        case HeaderNames.FilterBySchemaResourceId: store[i] = fields.FilterBySchemaResourceId; break;
                        case HeaderNames.ForceQueryScan: store[i] = fields.ForceQueryScan; break;
                        case HeaderNames.ForceSideBySideIndexMigration: store[i] = fields.ForceSideBySideIndexMigration; break;
                        case HeaderNames.GatewaySignature: store[i] = fields.GatewaySignature; break;
                        case HeaderNames.GetAllPartitionKeyStatistics: store[i] = fields.GetAllPartitionKeyStatistics; break;
                        case HeaderNames.HttpDate: store[i] = fields.HttpDate; break;
                        case HeaderNames.IfMatch: store[i] = fields.IfMatch; break;
                        case HeaderNames.IfModifiedSince: store[i] = fields.IfModifiedSince; break;
                        case HeaderNames.IfNoneMatch: store[i] = fields.IfNoneMatch; break;
                        case HeaderNames.IgnoreSystemLoweringMaxThroughput: store[i] = fields.IgnoreSystemLoweringMaxThroughput; break;
                        case HeaderNames.IncludePhysicalPartitionThroughputInfo: store[i] = fields.IncludePhysicalPartitionThroughputInfo; break;
                        case HeaderNames.IncludeTentativeWrites: store[i] = fields.IncludeTentativeWrites; break;
                        case HeaderNames.IndexingDirective: store[i] = fields.IndexingDirective; break;
                        case HeaderNames.IntendedCollectionRid: store[i] = fields.IntendedCollectionRid; break;
                        case HeaderNames.IsAutoScaleRequest: store[i] = fields.IsAutoScaleRequest; break;
                        case HeaderNames.IsBatchAtomic: store[i] = fields.IsBatchAtomic; break;
                        case HeaderNames.IsBatchOrdered: store[i] = fields.IsBatchOrdered; break;
                        case HeaderNames.IsClientEncrypted: store[i] = fields.IsClientEncrypted; break;
                        case HeaderNames.IsFanoutRequest: store[i] = fields.IsFanoutRequest; break;
                        case HeaderNames.IsInternalServerlessRequest: store[i] = fields.IsInternalServerlessRequest; break;
                        case HeaderNames.IsMaterializedViewBuild: store[i] = fields.IsMaterializedViewBuild; break;
                        case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: store[i] = fields.IsMaterializedViewSourceSchemaReplaceBatchRequest; break;
                        case HeaderNames.IsOfferStorageRefreshRequest: store[i] = fields.IsOfferStorageRefreshRequest; break;
                        case HeaderNames.IsReadOnlyScript: store[i] = fields.IsReadOnlyScript; break;
                        case HeaderNames.IsRetriedWriteRequest: store[i] = fields.IsRetriedWriteRequest; break;
                        case HeaderNames.IsRUPerGBEnforcementRequest: store[i] = fields.IsRUPerGBEnforcementRequest; break;
                        case HeaderNames.IsServerlessStorageRefreshRequest: store[i] = fields.IsServerlessStorageRefreshRequest; break;
                        case HeaderNames.IsThroughputCapRequest: store[i] = fields.IsThroughputCapRequest; break;
                        case HeaderNames.IsUserRequest: store[i] = fields.IsUserRequest; break;
                        case HeaderNames.MaxPollingIntervalMilliseconds: store[i] = fields.MaxPollingIntervalMilliseconds; break;
                        case HeaderNames.MergeCheckPointGLSN: store[i] = fields.MergeCheckPointGLSN; break;
                        case HeaderNames.MergeStaticId: store[i] = fields.MergeStaticId; break;
                        case HeaderNames.MigrateCollectionDirective: store[i] = fields.MigrateCollectionDirective; break;
                        case HeaderNames.MigrateOfferToAutopilot: store[i] = fields.MigrateOfferToAutopilot; break;
                        case HeaderNames.MigrateOfferToManualThroughput: store[i] = fields.MigrateOfferToManualThroughput; break;
                        case HeaderNames.OfferReplaceRURedistribution: store[i] = fields.OfferReplaceRURedistribution; break;
                        case HeaderNames.PageSize: store[i] = fields.PageSize; break;
                        case HeaderNames.PartitionCount: store[i] = fields.PartitionCount; break;
                        case HeaderNames.PartitionKey: store[i] = fields.PartitionKey; break;
                        case HeaderNames.PartitionKeyRangeId: store[i] = fields.PartitionKeyRangeId; break;
                        case HeaderNames.PartitionResourceFilter: store[i] = fields.PartitionResourceFilter; break;
                        case HeaderNames.PopulateAnalyticalMigrationProgress: store[i] = fields.PopulateAnalyticalMigrationProgress; break;
                        case HeaderNames.PopulateByokEncryptionProgress: store[i] = fields.PopulateByokEncryptionProgress; break;
                        case HeaderNames.PopulateCollectionThroughputInfo: store[i] = fields.PopulateCollectionThroughputInfo; break;
                        case HeaderNames.PopulateIndexMetrics: store[i] = fields.PopulateIndexMetrics; break;
                        case HeaderNames.PopulateLogStoreInfo: store[i] = fields.PopulateLogStoreInfo; break;
                        case HeaderNames.PopulateOldestActiveSchema: store[i] = fields.PopulateOldestActiveSchema; break;
                        case HeaderNames.PopulatePartitionStatistics: store[i] = fields.PopulatePartitionStatistics; break;
                        case HeaderNames.PopulateQueryMetrics: store[i] = fields.PopulateQueryMetrics; break;
                        case HeaderNames.PopulateQuotaInfo: store[i] = fields.PopulateQuotaInfo; break;
                        case HeaderNames.PopulateResourceCount: store[i] = fields.PopulateResourceCount; break;
                        case HeaderNames.PopulateUnflushedMergeEntryCount: store[i] = fields.PopulateUnflushedMergeEntryCount; break;
                        case HeaderNames.PopulateUniqueIndexReIndexProgress: store[i] = fields.PopulateUniqueIndexReIndexProgress; break;
                        case HeaderNames.PostTriggerExclude: store[i] = fields.PostTriggerExclude; break;
                        case HeaderNames.PostTriggerInclude: store[i] = fields.PostTriggerInclude; break;
                        case HeaderNames.Prefer: store[i] = fields.Prefer; break;
                        case HeaderNames.PreserveFullContent: store[i] = fields.PreserveFullContent; break;
                        case HeaderNames.PreTriggerExclude: store[i] = fields.PreTriggerExclude; break;
                        case HeaderNames.PreTriggerInclude: store[i] = fields.PreTriggerInclude; break;
                        case HeaderNames.PrimaryMasterKey: store[i] = fields.PrimaryMasterKey; break;
                        case HeaderNames.PrimaryReadonlyKey: store[i] = fields.PrimaryReadonlyKey; break;
                        case HeaderNames.ProfileRequest: store[i] = fields.ProfileRequest; break;
                        case HeaderNames.RbacAction: store[i] = fields.RbacAction; break;
                        case HeaderNames.RbacResource: store[i] = fields.RbacResource; break;
                        case HeaderNames.RbacUserId: store[i] = fields.RbacUserId; break;
                        case HeaderNames.ReadFeedKeyType: store[i] = fields.ReadFeedKeyType; break;
                        case HeaderNames.RemainingTimeInMsOnClientRequest: store[i] = fields.RemainingTimeInMsOnClientRequest; break;
                        case HeaderNames.RemoteStorageType: store[i] = fields.RemoteStorageType; break;
                        case HeaderNames.RequestedCollectionType: store[i] = fields.RequestedCollectionType; break;
                        case HeaderNames.ResourceId: store[i] = fields.ResourceId; break;
                        case HeaderNames.ResourceSchemaName: store[i] = fields.ResourceSchemaName; break;
                        case HeaderNames.ResourceTokenExpiry: store[i] = fields.ResourceTokenExpiry; break;
                        case HeaderNames.ResourceTypes: store[i] = fields.ResourceTypes; break;
                        case HeaderNames.ResponseContinuationTokenLimitInKB: store[i] = fields.ResponseContinuationTokenLimitInKB; break;
                        case HeaderNames.RestoreMetadataFilter: store[i] = fields.RestoreMetadataFilter; break;
                        case HeaderNames.RestoreParams: store[i] = fields.RestoreParams; break;
                        case HeaderNames.RetriableWriteRequestId: store[i] = fields.RetriableWriteRequestId; break;
                        case HeaderNames.RetriableWriteRequestStartTimestamp: store[i] = fields.RetriableWriteRequestStartTimestamp; break;
                        case HeaderNames.SchemaHash: store[i] = fields.SchemaHash; break;
                        case HeaderNames.SchemaId: store[i] = fields.SchemaId; break;
                        case HeaderNames.SchemaOwnerRid: store[i] = fields.SchemaOwnerRid; break;
                        case HeaderNames.SDKSupportedCapabilities: store[i] = fields.SDKSupportedCapabilities; break;
                        case HeaderNames.SecondaryMasterKey: store[i] = fields.SecondaryMasterKey; break;
                        case HeaderNames.SecondaryReadonlyKey: store[i] = fields.SecondaryReadonlyKey; break;
                        case HeaderNames.SessionToken: store[i] = fields.SessionToken; break;
                        case HeaderNames.ShareThroughput: store[i] = fields.ShareThroughput; break;
                        case HeaderNames.ShouldBatchContinueOnError: store[i] = fields.ShouldBatchContinueOnError; break;
                        case HeaderNames.ShouldReturnCurrentServerDateTime: store[i] = fields.ShouldReturnCurrentServerDateTime; break;
                        case HeaderNames.SkipRefreshDatabaseAccountConfigs: store[i] = fields.SkipRefreshDatabaseAccountConfigs; break;
                        case HeaderNames.SourceCollectionIfMatch: store[i] = fields.SourceCollectionIfMatch; break;
                        case HeaderNames.StartEpk: store[i] = fields.StartEpk; break;
                        case HeaderNames.StartId: store[i] = fields.StartId; break;
                        case HeaderNames.SupportSpatialLegacyCoordinates: store[i] = fields.SupportSpatialLegacyCoordinates; break;
                        case HeaderNames.SystemDocumentType: store[i] = fields.SystemDocumentType; break;
                        case HeaderNames.SystemRestoreOperation: store[i] = fields.SystemRestoreOperation; break;
                        case HeaderNames.TargetGlobalCommittedLsn: store[i] = fields.TargetGlobalCommittedLsn; break;
                        case HeaderNames.TargetLsn: store[i] = fields.TargetLsn; break;
                        case HeaderNames.TimeToLiveInSeconds: store[i] = fields.TimeToLiveInSeconds; break;
                        case HeaderNames.TransactionCommit: store[i] = fields.TransactionCommit; break;
                        case HeaderNames.TransactionFirstRequest: store[i] = fields.TransactionFirstRequest; break;
                        case HeaderNames.TransactionId: store[i] = fields.TransactionId; break;
                        case HeaderNames.TransportRequestID: store[i] = fields.TransportRequestID; break;
                        case HeaderNames.TruncateMergeLogRequest: store[i] = fields.TruncateMergeLogRequest; break;
                        case HeaderNames.UniqueIndexNameEncodingMode: store[i] = fields.UniqueIndexNameEncodingMode; break;
                        case HeaderNames.UniqueIndexReIndexingState: store[i] = fields.UniqueIndexReIndexingState; break;
                        case HeaderNames.UpdateMaxThroughputEverProvisioned: store[i] = fields.UpdateMaxThroughputEverProvisioned; break;
                        case HeaderNames.UpdateOfferStateToPending: store[i] = fields.UpdateOfferStateToPending; break;
                        case HeaderNames.UseArchivalPartition: store[i] = fields.UseArchivalPartition; break;
                        case HeaderNames.UsePolygonsSmallerThanAHemisphere: store[i] = fields.UsePolygonsSmallerThanAHemisphere; break;
                        case HeaderNames.UseSystemBudget: store[i] = fields.UseSystemBudget; break;
                        case HeaderNames.UseUserBackgroundBudget: store[i] = fields.UseUserBackgroundBudget; break;
                        case HeaderNames.Version: store[i] = fields.Version; break;
                        case HeaderNames.XDate: store[i] = fields.XDate; break;
                        default: store[i] = null; break;
                    }
                }
            }

            ArrayPool<string?>.Shared.Return(store);
        }

        [Benchmark]
        public void Array()
        {
            string?[] store = ArrayPool<string?>.Shared.Rent(this.headersToLookup.Length);

            for (int x = 0; x < GetKnownBenchmark.Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    HeaderNames name = this.headersToLookup[i];
                    switch (name)
                    {
                        case HeaderNames.AddResourcePropertiesToResponse: store[i] = array.AddResourcePropertiesToResponse; break;
                        case HeaderNames.AllowTentativeWrites: store[i] = array.AllowTentativeWrites; break;
                        case HeaderNames.Authorization: store[i] = array.Authorization; break;
                        case HeaderNames.A_IM: store[i] = array.A_IM; break;
                        case HeaderNames.BinaryId: store[i] = array.BinaryId; break;
                        case HeaderNames.BinaryPassthroughRequest: store[i] = array.BinaryPassthroughRequest; break;
                        case HeaderNames.BindReplicaDirective: store[i] = array.BindReplicaDirective; break;
                        case HeaderNames.BuilderClientIdentifier: store[i] = array.BuilderClientIdentifier; break;
                        case HeaderNames.CanCharge: store[i] = array.CanCharge; break;
                        case HeaderNames.CanOfferReplaceComplete: store[i] = array.CanOfferReplaceComplete; break;
                        case HeaderNames.CanThrottle: store[i] = array.CanThrottle; break;
                        case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: store[i] = array.ChangeFeedStartFullFidelityIfNoneMatch; break;
                        case HeaderNames.ChangeFeedWireFormatVersion: store[i] = array.ChangeFeedWireFormatVersion; break;
                        case HeaderNames.ClientRetryAttemptCount: store[i] = array.ClientRetryAttemptCount; break;
                        case HeaderNames.CollectionChildResourceContentLimitInKB: store[i] = array.CollectionChildResourceContentLimitInKB; break;
                        case HeaderNames.CollectionChildResourceNameLimitInBytes: store[i] = array.CollectionChildResourceNameLimitInBytes; break;
                        case HeaderNames.CollectionPartitionIndex: store[i] = array.CollectionPartitionIndex; break;
                        case HeaderNames.CollectionRemoteStorageSecurityIdentifier: store[i] = array.CollectionRemoteStorageSecurityIdentifier; break;
                        case HeaderNames.CollectionRid: store[i] = array.CollectionRid; break;
                        case HeaderNames.CollectionServiceIndex: store[i] = array.CollectionServiceIndex; break;
                        case HeaderNames.CollectionTruncate: store[i] = array.CollectionTruncate; break;
                        case HeaderNames.ConsistencyLevel: store[i] = array.ConsistencyLevel; break;
                        case HeaderNames.ContentSerializationFormat: store[i] = array.ContentSerializationFormat; break;
                        case HeaderNames.Continuation: store[i] = array.Continuation; break;
                        case HeaderNames.CorrelatedActivityId: store[i] = array.CorrelatedActivityId; break;
                        case HeaderNames.DisableRUPerMinuteUsage: store[i] = array.DisableRUPerMinuteUsage; break;
                        case HeaderNames.EffectivePartitionKey: store[i] = array.EffectivePartitionKey; break;
                        case HeaderNames.EmitVerboseTracesInQuery: store[i] = array.EmitVerboseTracesInQuery; break;
                        case HeaderNames.EnableDynamicRidRangeAllocation: store[i] = array.EnableDynamicRidRangeAllocation; break;
                        case HeaderNames.EnableLogging: store[i] = array.EnableLogging; break;
                        case HeaderNames.EnableLowPrecisionOrderBy: store[i] = array.EnableLowPrecisionOrderBy; break;
                        case HeaderNames.EnableScanInQuery: store[i] = array.EnableScanInQuery; break;
                        case HeaderNames.EndEpk: store[i] = array.EndEpk; break;
                        case HeaderNames.EndId: store[i] = array.EndId; break;
                        case HeaderNames.EntityId: store[i] = array.EntityId; break;
                        case HeaderNames.EnumerationDirection: store[i] = array.EnumerationDirection; break;
                        case HeaderNames.ExcludeSystemProperties: store[i] = array.ExcludeSystemProperties; break;
                        case HeaderNames.FanoutOperationState: store[i] = array.FanoutOperationState; break;
                        case HeaderNames.FilterBySchemaResourceId: store[i] = array.FilterBySchemaResourceId; break;
                        case HeaderNames.ForceQueryScan: store[i] = array.ForceQueryScan; break;
                        case HeaderNames.ForceSideBySideIndexMigration: store[i] = array.ForceSideBySideIndexMigration; break;
                        case HeaderNames.GatewaySignature: store[i] = array.GatewaySignature; break;
                        case HeaderNames.GetAllPartitionKeyStatistics: store[i] = array.GetAllPartitionKeyStatistics; break;
                        case HeaderNames.HttpDate: store[i] = array.HttpDate; break;
                        case HeaderNames.IfMatch: store[i] = array.IfMatch; break;
                        case HeaderNames.IfModifiedSince: store[i] = array.IfModifiedSince; break;
                        case HeaderNames.IfNoneMatch: store[i] = array.IfNoneMatch; break;
                        case HeaderNames.IgnoreSystemLoweringMaxThroughput: store[i] = array.IgnoreSystemLoweringMaxThroughput; break;
                        case HeaderNames.IncludePhysicalPartitionThroughputInfo: store[i] = array.IncludePhysicalPartitionThroughputInfo; break;
                        case HeaderNames.IncludeTentativeWrites: store[i] = array.IncludeTentativeWrites; break;
                        case HeaderNames.IndexingDirective: store[i] = array.IndexingDirective; break;
                        case HeaderNames.IntendedCollectionRid: store[i] = array.IntendedCollectionRid; break;
                        case HeaderNames.IsAutoScaleRequest: store[i] = array.IsAutoScaleRequest; break;
                        case HeaderNames.IsBatchAtomic: store[i] = array.IsBatchAtomic; break;
                        case HeaderNames.IsBatchOrdered: store[i] = array.IsBatchOrdered; break;
                        case HeaderNames.IsClientEncrypted: store[i] = array.IsClientEncrypted; break;
                        case HeaderNames.IsFanoutRequest: store[i] = array.IsFanoutRequest; break;
                        case HeaderNames.IsInternalServerlessRequest: store[i] = array.IsInternalServerlessRequest; break;
                        case HeaderNames.IsMaterializedViewBuild: store[i] = array.IsMaterializedViewBuild; break;
                        case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: store[i] = array.IsMaterializedViewSourceSchemaReplaceBatchRequest; break;
                        case HeaderNames.IsOfferStorageRefreshRequest: store[i] = array.IsOfferStorageRefreshRequest; break;
                        case HeaderNames.IsReadOnlyScript: store[i] = array.IsReadOnlyScript; break;
                        case HeaderNames.IsRetriedWriteRequest: store[i] = array.IsRetriedWriteRequest; break;
                        case HeaderNames.IsRUPerGBEnforcementRequest: store[i] = array.IsRUPerGBEnforcementRequest; break;
                        case HeaderNames.IsServerlessStorageRefreshRequest: store[i] = array.IsServerlessStorageRefreshRequest; break;
                        case HeaderNames.IsThroughputCapRequest: store[i] = array.IsThroughputCapRequest; break;
                        case HeaderNames.IsUserRequest: store[i] = array.IsUserRequest; break;
                        case HeaderNames.MaxPollingIntervalMilliseconds: store[i] = array.MaxPollingIntervalMilliseconds; break;
                        case HeaderNames.MergeCheckPointGLSN: store[i] = array.MergeCheckPointGLSN; break;
                        case HeaderNames.MergeStaticId: store[i] = array.MergeStaticId; break;
                        case HeaderNames.MigrateCollectionDirective: store[i] = array.MigrateCollectionDirective; break;
                        case HeaderNames.MigrateOfferToAutopilot: store[i] = array.MigrateOfferToAutopilot; break;
                        case HeaderNames.MigrateOfferToManualThroughput: store[i] = array.MigrateOfferToManualThroughput; break;
                        case HeaderNames.OfferReplaceRURedistribution: store[i] = array.OfferReplaceRURedistribution; break;
                        case HeaderNames.PageSize: store[i] = array.PageSize; break;
                        case HeaderNames.PartitionCount: store[i] = array.PartitionCount; break;
                        case HeaderNames.PartitionKey: store[i] = array.PartitionKey; break;
                        case HeaderNames.PartitionKeyRangeId: store[i] = array.PartitionKeyRangeId; break;
                        case HeaderNames.PartitionResourceFilter: store[i] = array.PartitionResourceFilter; break;
                        case HeaderNames.PopulateAnalyticalMigrationProgress: store[i] = array.PopulateAnalyticalMigrationProgress; break;
                        case HeaderNames.PopulateByokEncryptionProgress: store[i] = array.PopulateByokEncryptionProgress; break;
                        case HeaderNames.PopulateCollectionThroughputInfo: store[i] = array.PopulateCollectionThroughputInfo; break;
                        case HeaderNames.PopulateIndexMetrics: store[i] = array.PopulateIndexMetrics; break;
                        case HeaderNames.PopulateLogStoreInfo: store[i] = array.PopulateLogStoreInfo; break;
                        case HeaderNames.PopulateOldestActiveSchema: store[i] = array.PopulateOldestActiveSchema; break;
                        case HeaderNames.PopulatePartitionStatistics: store[i] = array.PopulatePartitionStatistics; break;
                        case HeaderNames.PopulateQueryMetrics: store[i] = array.PopulateQueryMetrics; break;
                        case HeaderNames.PopulateQuotaInfo: store[i] = array.PopulateQuotaInfo; break;
                        case HeaderNames.PopulateResourceCount: store[i] = array.PopulateResourceCount; break;
                        case HeaderNames.PopulateUnflushedMergeEntryCount: store[i] = array.PopulateUnflushedMergeEntryCount; break;
                        case HeaderNames.PopulateUniqueIndexReIndexProgress: store[i] = array.PopulateUniqueIndexReIndexProgress; break;
                        case HeaderNames.PostTriggerExclude: store[i] = array.PostTriggerExclude; break;
                        case HeaderNames.PostTriggerInclude: store[i] = array.PostTriggerInclude; break;
                        case HeaderNames.Prefer: store[i] = array.Prefer; break;
                        case HeaderNames.PreserveFullContent: store[i] = array.PreserveFullContent; break;
                        case HeaderNames.PreTriggerExclude: store[i] = array.PreTriggerExclude; break;
                        case HeaderNames.PreTriggerInclude: store[i] = array.PreTriggerInclude; break;
                        case HeaderNames.PrimaryMasterKey: store[i] = array.PrimaryMasterKey; break;
                        case HeaderNames.PrimaryReadonlyKey: store[i] = array.PrimaryReadonlyKey; break;
                        case HeaderNames.ProfileRequest: store[i] = array.ProfileRequest; break;
                        case HeaderNames.RbacAction: store[i] = array.RbacAction; break;
                        case HeaderNames.RbacResource: store[i] = array.RbacResource; break;
                        case HeaderNames.RbacUserId: store[i] = array.RbacUserId; break;
                        case HeaderNames.ReadFeedKeyType: store[i] = array.ReadFeedKeyType; break;
                        case HeaderNames.RemainingTimeInMsOnClientRequest: store[i] = array.RemainingTimeInMsOnClientRequest; break;
                        case HeaderNames.RemoteStorageType: store[i] = array.RemoteStorageType; break;
                        case HeaderNames.RequestedCollectionType: store[i] = array.RequestedCollectionType; break;
                        case HeaderNames.ResourceId: store[i] = array.ResourceId; break;
                        case HeaderNames.ResourceSchemaName: store[i] = array.ResourceSchemaName; break;
                        case HeaderNames.ResourceTokenExpiry: store[i] = array.ResourceTokenExpiry; break;
                        case HeaderNames.ResourceTypes: store[i] = array.ResourceTypes; break;
                        case HeaderNames.ResponseContinuationTokenLimitInKB: store[i] = array.ResponseContinuationTokenLimitInKB; break;
                        case HeaderNames.RestoreMetadataFilter: store[i] = array.RestoreMetadataFilter; break;
                        case HeaderNames.RestoreParams: store[i] = array.RestoreParams; break;
                        case HeaderNames.RetriableWriteRequestId: store[i] = array.RetriableWriteRequestId; break;
                        case HeaderNames.RetriableWriteRequestStartTimestamp: store[i] = array.RetriableWriteRequestStartTimestamp; break;
                        case HeaderNames.SchemaHash: store[i] = array.SchemaHash; break;
                        case HeaderNames.SchemaId: store[i] = array.SchemaId; break;
                        case HeaderNames.SchemaOwnerRid: store[i] = array.SchemaOwnerRid; break;
                        case HeaderNames.SDKSupportedCapabilities: store[i] = array.SDKSupportedCapabilities; break;
                        case HeaderNames.SecondaryMasterKey: store[i] = array.SecondaryMasterKey; break;
                        case HeaderNames.SecondaryReadonlyKey: store[i] = array.SecondaryReadonlyKey; break;
                        case HeaderNames.SessionToken: store[i] = array.SessionToken; break;
                        case HeaderNames.ShareThroughput: store[i] = array.ShareThroughput; break;
                        case HeaderNames.ShouldBatchContinueOnError: store[i] = array.ShouldBatchContinueOnError; break;
                        case HeaderNames.ShouldReturnCurrentServerDateTime: store[i] = array.ShouldReturnCurrentServerDateTime; break;
                        case HeaderNames.SkipRefreshDatabaseAccountConfigs: store[i] = array.SkipRefreshDatabaseAccountConfigs; break;
                        case HeaderNames.SourceCollectionIfMatch: store[i] = array.SourceCollectionIfMatch; break;
                        case HeaderNames.StartEpk: store[i] = array.StartEpk; break;
                        case HeaderNames.StartId: store[i] = array.StartId; break;
                        case HeaderNames.SupportSpatialLegacyCoordinates: store[i] = array.SupportSpatialLegacyCoordinates; break;
                        case HeaderNames.SystemDocumentType: store[i] = array.SystemDocumentType; break;
                        case HeaderNames.SystemRestoreOperation: store[i] = array.SystemRestoreOperation; break;
                        case HeaderNames.TargetGlobalCommittedLsn: store[i] = array.TargetGlobalCommittedLsn; break;
                        case HeaderNames.TargetLsn: store[i] = array.TargetLsn; break;
                        case HeaderNames.TimeToLiveInSeconds: store[i] = array.TimeToLiveInSeconds; break;
                        case HeaderNames.TransactionCommit: store[i] = array.TransactionCommit; break;
                        case HeaderNames.TransactionFirstRequest: store[i] = array.TransactionFirstRequest; break;
                        case HeaderNames.TransactionId: store[i] = array.TransactionId; break;
                        case HeaderNames.TransportRequestID: store[i] = array.TransportRequestID; break;
                        case HeaderNames.TruncateMergeLogRequest: store[i] = array.TruncateMergeLogRequest; break;
                        case HeaderNames.UniqueIndexNameEncodingMode: store[i] = array.UniqueIndexNameEncodingMode; break;
                        case HeaderNames.UniqueIndexReIndexingState: store[i] = array.UniqueIndexReIndexingState; break;
                        case HeaderNames.UpdateMaxThroughputEverProvisioned: store[i] = array.UpdateMaxThroughputEverProvisioned; break;
                        case HeaderNames.UpdateOfferStateToPending: store[i] = array.UpdateOfferStateToPending; break;
                        case HeaderNames.UseArchivalPartition: store[i] = array.UseArchivalPartition; break;
                        case HeaderNames.UsePolygonsSmallerThanAHemisphere: store[i] = array.UsePolygonsSmallerThanAHemisphere; break;
                        case HeaderNames.UseSystemBudget: store[i] = array.UseSystemBudget; break;
                        case HeaderNames.UseUserBackgroundBudget: store[i] = array.UseUserBackgroundBudget; break;
                        case HeaderNames.Version: store[i] = array.Version; break;
                        case HeaderNames.XDate: store[i] = array.XDate; break;
                        default: throw new ArgumentException(nameof(name), $"Was {name}");
                    }
                }
            }

            ArrayPool<string?>.Shared.Return(store);
        }

        [Benchmark]
        public void Packed()
        {
            string?[] store = ArrayPool<string?>.Shared.Rent(this.headersToLookup.Length);

            for (int x = 0; x < GetKnownBenchmark.Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    HeaderNames name = this.headersToLookup[i];
                    switch (name)
                    {
                        case HeaderNames.AddResourcePropertiesToResponse: store[i] = packed.AddResourcePropertiesToResponse; break;
                        case HeaderNames.AllowTentativeWrites: store[i] = packed.AllowTentativeWrites; break;
                        case HeaderNames.Authorization: store[i] = packed.Authorization; break;
                        case HeaderNames.A_IM: store[i] = packed.A_IM; break;
                        case HeaderNames.BinaryId: store[i] = packed.BinaryId; break;
                        case HeaderNames.BinaryPassthroughRequest: store[i] = packed.BinaryPassthroughRequest; break;
                        case HeaderNames.BindReplicaDirective: store[i] = packed.BindReplicaDirective; break;
                        case HeaderNames.BuilderClientIdentifier: store[i] = packed.BuilderClientIdentifier; break;
                        case HeaderNames.CanCharge: store[i] = packed.CanCharge; break;
                        case HeaderNames.CanOfferReplaceComplete: store[i] = packed.CanOfferReplaceComplete; break;
                        case HeaderNames.CanThrottle: store[i] = packed.CanThrottle; break;
                        case HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch: store[i] = packed.ChangeFeedStartFullFidelityIfNoneMatch; break;
                        case HeaderNames.ChangeFeedWireFormatVersion: store[i] = packed.ChangeFeedWireFormatVersion; break;
                        case HeaderNames.ClientRetryAttemptCount: store[i] = packed.ClientRetryAttemptCount; break;
                        case HeaderNames.CollectionChildResourceContentLimitInKB: store[i] = packed.CollectionChildResourceContentLimitInKB; break;
                        case HeaderNames.CollectionChildResourceNameLimitInBytes: store[i] = packed.CollectionChildResourceNameLimitInBytes; break;
                        case HeaderNames.CollectionPartitionIndex: store[i] = packed.CollectionPartitionIndex; break;
                        case HeaderNames.CollectionRemoteStorageSecurityIdentifier: store[i] = packed.CollectionRemoteStorageSecurityIdentifier; break;
                        case HeaderNames.CollectionRid: store[i] = packed.CollectionRid; break;
                        case HeaderNames.CollectionServiceIndex: store[i] = packed.CollectionServiceIndex; break;
                        case HeaderNames.CollectionTruncate: store[i] = packed.CollectionTruncate; break;
                        case HeaderNames.ConsistencyLevel: store[i] = packed.ConsistencyLevel; break;
                        case HeaderNames.ContentSerializationFormat: store[i] = packed.ContentSerializationFormat; break;
                        case HeaderNames.Continuation: store[i] = packed.Continuation; break;
                        case HeaderNames.CorrelatedActivityId: store[i] = packed.CorrelatedActivityId; break;
                        case HeaderNames.DisableRUPerMinuteUsage: store[i] = packed.DisableRUPerMinuteUsage; break;
                        case HeaderNames.EffectivePartitionKey: store[i] = packed.EffectivePartitionKey; break;
                        case HeaderNames.EmitVerboseTracesInQuery: store[i] = packed.EmitVerboseTracesInQuery; break;
                        case HeaderNames.EnableDynamicRidRangeAllocation: store[i] = packed.EnableDynamicRidRangeAllocation; break;
                        case HeaderNames.EnableLogging: store[i] = packed.EnableLogging; break;
                        case HeaderNames.EnableLowPrecisionOrderBy: store[i] = packed.EnableLowPrecisionOrderBy; break;
                        case HeaderNames.EnableScanInQuery: store[i] = packed.EnableScanInQuery; break;
                        case HeaderNames.EndEpk: store[i] = packed.EndEpk; break;
                        case HeaderNames.EndId: store[i] = packed.EndId; break;
                        case HeaderNames.EntityId: store[i] = packed.EntityId; break;
                        case HeaderNames.EnumerationDirection: store[i] = packed.EnumerationDirection; break;
                        case HeaderNames.ExcludeSystemProperties: store[i] = packed.ExcludeSystemProperties; break;
                        case HeaderNames.FanoutOperationState: store[i] = packed.FanoutOperationState; break;
                        case HeaderNames.FilterBySchemaResourceId: store[i] = packed.FilterBySchemaResourceId; break;
                        case HeaderNames.ForceQueryScan: store[i] = packed.ForceQueryScan; break;
                        case HeaderNames.ForceSideBySideIndexMigration: store[i] = packed.ForceSideBySideIndexMigration; break;
                        case HeaderNames.GatewaySignature: store[i] = packed.GatewaySignature; break;
                        case HeaderNames.GetAllPartitionKeyStatistics: store[i] = packed.GetAllPartitionKeyStatistics; break;
                        case HeaderNames.HttpDate: store[i] = packed.HttpDate; break;
                        case HeaderNames.IfMatch: store[i] = packed.IfMatch; break;
                        case HeaderNames.IfModifiedSince: store[i] = packed.IfModifiedSince; break;
                        case HeaderNames.IfNoneMatch: store[i] = packed.IfNoneMatch; break;
                        case HeaderNames.IgnoreSystemLoweringMaxThroughput: store[i] = packed.IgnoreSystemLoweringMaxThroughput; break;
                        case HeaderNames.IncludePhysicalPartitionThroughputInfo: store[i] = packed.IncludePhysicalPartitionThroughputInfo; break;
                        case HeaderNames.IncludeTentativeWrites: store[i] = packed.IncludeTentativeWrites; break;
                        case HeaderNames.IndexingDirective: store[i] = packed.IndexingDirective; break;
                        case HeaderNames.IntendedCollectionRid: store[i] = packed.IntendedCollectionRid; break;
                        case HeaderNames.IsAutoScaleRequest: store[i] = packed.IsAutoScaleRequest; break;
                        case HeaderNames.IsBatchAtomic: store[i] = packed.IsBatchAtomic; break;
                        case HeaderNames.IsBatchOrdered: store[i] = packed.IsBatchOrdered; break;
                        case HeaderNames.IsClientEncrypted: store[i] = packed.IsClientEncrypted; break;
                        case HeaderNames.IsFanoutRequest: store[i] = packed.IsFanoutRequest; break;
                        case HeaderNames.IsInternalServerlessRequest: store[i] = packed.IsInternalServerlessRequest; break;
                        case HeaderNames.IsMaterializedViewBuild: store[i] = packed.IsMaterializedViewBuild; break;
                        case HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest: store[i] = packed.IsMaterializedViewSourceSchemaReplaceBatchRequest; break;
                        case HeaderNames.IsOfferStorageRefreshRequest: store[i] = packed.IsOfferStorageRefreshRequest; break;
                        case HeaderNames.IsReadOnlyScript: store[i] = packed.IsReadOnlyScript; break;
                        case HeaderNames.IsRetriedWriteRequest: store[i] = packed.IsRetriedWriteRequest; break;
                        case HeaderNames.IsRUPerGBEnforcementRequest: store[i] = packed.IsRUPerGBEnforcementRequest; break;
                        case HeaderNames.IsServerlessStorageRefreshRequest: store[i] = packed.IsServerlessStorageRefreshRequest; break;
                        case HeaderNames.IsThroughputCapRequest: store[i] = packed.IsThroughputCapRequest; break;
                        case HeaderNames.IsUserRequest: store[i] = packed.IsUserRequest; break;
                        case HeaderNames.MaxPollingIntervalMilliseconds: store[i] = packed.MaxPollingIntervalMilliseconds; break;
                        case HeaderNames.MergeCheckPointGLSN: store[i] = packed.MergeCheckPointGLSN; break;
                        case HeaderNames.MergeStaticId: store[i] = packed.MergeStaticId; break;
                        case HeaderNames.MigrateCollectionDirective: store[i] = packed.MigrateCollectionDirective; break;
                        case HeaderNames.MigrateOfferToAutopilot: store[i] = packed.MigrateOfferToAutopilot; break;
                        case HeaderNames.MigrateOfferToManualThroughput: store[i] = packed.MigrateOfferToManualThroughput; break;
                        case HeaderNames.OfferReplaceRURedistribution: store[i] = packed.OfferReplaceRURedistribution; break;
                        case HeaderNames.PageSize: store[i] = packed.PageSize; break;
                        case HeaderNames.PartitionCount: store[i] = packed.PartitionCount; break;
                        case HeaderNames.PartitionKey: store[i] = packed.PartitionKey; break;
                        case HeaderNames.PartitionKeyRangeId: store[i] = packed.PartitionKeyRangeId; break;
                        case HeaderNames.PartitionResourceFilter: store[i] = packed.PartitionResourceFilter; break;
                        case HeaderNames.PopulateAnalyticalMigrationProgress: store[i] = packed.PopulateAnalyticalMigrationProgress; break;
                        case HeaderNames.PopulateByokEncryptionProgress: store[i] = packed.PopulateByokEncryptionProgress; break;
                        case HeaderNames.PopulateCollectionThroughputInfo: store[i] = packed.PopulateCollectionThroughputInfo; break;
                        case HeaderNames.PopulateIndexMetrics: store[i] = packed.PopulateIndexMetrics; break;
                        case HeaderNames.PopulateLogStoreInfo: store[i] = packed.PopulateLogStoreInfo; break;
                        case HeaderNames.PopulateOldestActiveSchema: store[i] = packed.PopulateOldestActiveSchema; break;
                        case HeaderNames.PopulatePartitionStatistics: store[i] = packed.PopulatePartitionStatistics; break;
                        case HeaderNames.PopulateQueryMetrics: store[i] = packed.PopulateQueryMetrics; break;
                        case HeaderNames.PopulateQuotaInfo: store[i] = packed.PopulateQuotaInfo; break;
                        case HeaderNames.PopulateResourceCount: store[i] = packed.PopulateResourceCount; break;
                        case HeaderNames.PopulateUnflushedMergeEntryCount: store[i] = packed.PopulateUnflushedMergeEntryCount; break;
                        case HeaderNames.PopulateUniqueIndexReIndexProgress: store[i] = packed.PopulateUniqueIndexReIndexProgress; break;
                        case HeaderNames.PostTriggerExclude: store[i] = packed.PostTriggerExclude; break;
                        case HeaderNames.PostTriggerInclude: store[i] = packed.PostTriggerInclude; break;
                        case HeaderNames.Prefer: store[i] = packed.Prefer; break;
                        case HeaderNames.PreserveFullContent: store[i] = packed.PreserveFullContent; break;
                        case HeaderNames.PreTriggerExclude: store[i] = packed.PreTriggerExclude; break;
                        case HeaderNames.PreTriggerInclude: store[i] = packed.PreTriggerInclude; break;
                        case HeaderNames.PrimaryMasterKey: store[i] = packed.PrimaryMasterKey; break;
                        case HeaderNames.PrimaryReadonlyKey: store[i] = packed.PrimaryReadonlyKey; break;
                        case HeaderNames.ProfileRequest: store[i] = packed.ProfileRequest; break;
                        case HeaderNames.RbacAction: store[i] = packed.RbacAction; break;
                        case HeaderNames.RbacResource: store[i] = packed.RbacResource; break;
                        case HeaderNames.RbacUserId: store[i] = packed.RbacUserId; break;
                        case HeaderNames.ReadFeedKeyType: store[i] = packed.ReadFeedKeyType; break;
                        case HeaderNames.RemainingTimeInMsOnClientRequest: store[i] = packed.RemainingTimeInMsOnClientRequest; break;
                        case HeaderNames.RemoteStorageType: store[i] = packed.RemoteStorageType; break;
                        case HeaderNames.RequestedCollectionType: store[i] = packed.RequestedCollectionType; break;
                        case HeaderNames.ResourceId: store[i] = packed.ResourceId; break;
                        case HeaderNames.ResourceSchemaName: store[i] = packed.ResourceSchemaName; break;
                        case HeaderNames.ResourceTokenExpiry: store[i] = packed.ResourceTokenExpiry; break;
                        case HeaderNames.ResourceTypes: store[i] = packed.ResourceTypes; break;
                        case HeaderNames.ResponseContinuationTokenLimitInKB: store[i] = packed.ResponseContinuationTokenLimitInKB; break;
                        case HeaderNames.RestoreMetadataFilter: store[i] = packed.RestoreMetadataFilter; break;
                        case HeaderNames.RestoreParams: store[i] = packed.RestoreParams; break;
                        case HeaderNames.RetriableWriteRequestId: store[i] = packed.RetriableWriteRequestId; break;
                        case HeaderNames.RetriableWriteRequestStartTimestamp: store[i] = packed.RetriableWriteRequestStartTimestamp; break;
                        case HeaderNames.SchemaHash: store[i] = packed.SchemaHash; break;
                        case HeaderNames.SchemaId: store[i] = packed.SchemaId; break;
                        case HeaderNames.SchemaOwnerRid: store[i] = packed.SchemaOwnerRid; break;
                        case HeaderNames.SDKSupportedCapabilities: store[i] = packed.SDKSupportedCapabilities; break;
                        case HeaderNames.SecondaryMasterKey: store[i] = packed.SecondaryMasterKey; break;
                        case HeaderNames.SecondaryReadonlyKey: store[i] = packed.SecondaryReadonlyKey; break;
                        case HeaderNames.SessionToken: store[i] = packed.SessionToken; break;
                        case HeaderNames.ShareThroughput: store[i] = packed.ShareThroughput; break;
                        case HeaderNames.ShouldBatchContinueOnError: store[i] = packed.ShouldBatchContinueOnError; break;
                        case HeaderNames.ShouldReturnCurrentServerDateTime: store[i] = packed.ShouldReturnCurrentServerDateTime; break;
                        case HeaderNames.SkipRefreshDatabaseAccountConfigs: store[i] = packed.SkipRefreshDatabaseAccountConfigs; break;
                        case HeaderNames.SourceCollectionIfMatch: store[i] = packed.SourceCollectionIfMatch; break;
                        case HeaderNames.StartEpk: store[i] = packed.StartEpk; break;
                        case HeaderNames.StartId: store[i] = packed.StartId; break;
                        case HeaderNames.SupportSpatialLegacyCoordinates: store[i] = packed.SupportSpatialLegacyCoordinates; break;
                        case HeaderNames.SystemDocumentType: store[i] = packed.SystemDocumentType; break;
                        case HeaderNames.SystemRestoreOperation: store[i] = packed.SystemRestoreOperation; break;
                        case HeaderNames.TargetGlobalCommittedLsn: store[i] = packed.TargetGlobalCommittedLsn; break;
                        case HeaderNames.TargetLsn: store[i] = packed.TargetLsn; break;
                        case HeaderNames.TimeToLiveInSeconds: store[i] = packed.TimeToLiveInSeconds; break;
                        case HeaderNames.TransactionCommit: store[i] = packed.TransactionCommit; break;
                        case HeaderNames.TransactionFirstRequest: store[i] = packed.TransactionFirstRequest; break;
                        case HeaderNames.TransactionId: store[i] = packed.TransactionId; break;
                        case HeaderNames.TransportRequestID: store[i] = packed.TransportRequestID; break;
                        case HeaderNames.TruncateMergeLogRequest: store[i] = packed.TruncateMergeLogRequest; break;
                        case HeaderNames.UniqueIndexNameEncodingMode: store[i] = packed.UniqueIndexNameEncodingMode; break;
                        case HeaderNames.UniqueIndexReIndexingState: store[i] = packed.UniqueIndexReIndexingState; break;
                        case HeaderNames.UpdateMaxThroughputEverProvisioned: store[i] = packed.UpdateMaxThroughputEverProvisioned; break;
                        case HeaderNames.UpdateOfferStateToPending: store[i] = packed.UpdateOfferStateToPending; break;
                        case HeaderNames.UseArchivalPartition: store[i] = packed.UseArchivalPartition; break;
                        case HeaderNames.UsePolygonsSmallerThanAHemisphere: store[i] = packed.UsePolygonsSmallerThanAHemisphere; break;
                        case HeaderNames.UseSystemBudget: store[i] = packed.UseSystemBudget; break;
                        case HeaderNames.UseUserBackgroundBudget: store[i] = packed.UseUserBackgroundBudget; break;
                        case HeaderNames.Version: store[i] = packed.Version; break;
                        case HeaderNames.XDate: store[i] = packed.XDate; break;
                        default: store[i] = null; break;
                    }
                }
            }

            ArrayPool<string?>.Shared.Return(store);
        }
    }
}
