using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BitPackHeaders
{
    internal class ArrayHeaders
    {
        private const int IndexesSize = 151;

        private readonly byte[] headerIndexes;
        private readonly List<string?> headerValues;

        internal ArrayHeaders()
        {
            this.headerIndexes = new byte[IndexesSize];
            this.headerValues = new List<string?>();
            this.headerValues.Add(null);    // store a null so default values short circuit
        }

        public string? ResourceId => this.GetOrDefault(HeaderNames.ResourceId);
        public string? Authorization => this.GetOrDefault(HeaderNames.Authorization);
        public string? HttpDate => this.GetOrDefault(HeaderNames.HttpDate);
        public string? XDate => this.GetOrDefault(HeaderNames.XDate);
        public string? PageSize => this.GetOrDefault(HeaderNames.PageSize);
        public string? SessionToken => this.GetOrDefault(HeaderNames.SessionToken);
        public string? Continuation => this.GetOrDefault(HeaderNames.Continuation);
        public string? IndexingDirective => this.GetOrDefault(HeaderNames.IndexingDirective);
        public string? IfNoneMatch => this.GetOrDefault(HeaderNames.IfNoneMatch);
        public string? PreTriggerInclude => this.GetOrDefault(HeaderNames.PreTriggerInclude);
        public string? PostTriggerInclude => this.GetOrDefault(HeaderNames.PostTriggerInclude);
        public string? IsFanoutRequest => this.GetOrDefault(HeaderNames.IsFanoutRequest);
        public string? CollectionPartitionIndex => this.GetOrDefault(HeaderNames.CollectionPartitionIndex);
        public string? CollectionServiceIndex => this.GetOrDefault(HeaderNames.CollectionServiceIndex);
        public string? PreTriggerExclude => this.GetOrDefault(HeaderNames.PreTriggerExclude);
        public string? PostTriggerExclude => this.GetOrDefault(HeaderNames.PostTriggerExclude);
        public string? ConsistencyLevel => this.GetOrDefault(HeaderNames.ConsistencyLevel);
        public string? EntityId => this.GetOrDefault(HeaderNames.EntityId);
        public string? ResourceSchemaName => this.GetOrDefault(HeaderNames.ResourceSchemaName);
        public string? ResourceTokenExpiry => this.GetOrDefault(HeaderNames.ResourceTokenExpiry);
        public string? EnableScanInQuery => this.GetOrDefault(HeaderNames.EnableScanInQuery);
        public string? EmitVerboseTracesInQuery => this.GetOrDefault(HeaderNames.EmitVerboseTracesInQuery);
        public string? BindReplicaDirective => this.GetOrDefault(HeaderNames.BindReplicaDirective);
        public string? PrimaryMasterKey => this.GetOrDefault(HeaderNames.PrimaryMasterKey);
        public string? SecondaryMasterKey => this.GetOrDefault(HeaderNames.SecondaryMasterKey);
        public string? PrimaryReadonlyKey => this.GetOrDefault(HeaderNames.PrimaryReadonlyKey);
        public string? SecondaryReadonlyKey => this.GetOrDefault(HeaderNames.SecondaryReadonlyKey);
        public string? ProfileRequest => this.GetOrDefault(HeaderNames.ProfileRequest);
        public string? EnableLowPrecisionOrderBy => this.GetOrDefault(HeaderNames.EnableLowPrecisionOrderBy);
        public string? Version => this.GetOrDefault(HeaderNames.Version);
        public string? CanCharge => this.GetOrDefault(HeaderNames.CanCharge);
        public string? CanThrottle => this.GetOrDefault(HeaderNames.CanThrottle);
        public string? PartitionKey => this.GetOrDefault(HeaderNames.PartitionKey);
        public string? PartitionKeyRangeId => this.GetOrDefault(HeaderNames.PartitionKeyRangeId);
        public string? MigrateCollectionDirective => this.GetOrDefault(HeaderNames.MigrateCollectionDirective);
        public string? SupportSpatialLegacyCoordinates => this.GetOrDefault(HeaderNames.SupportSpatialLegacyCoordinates);
        public string? PartitionCount => this.GetOrDefault(HeaderNames.PartitionCount);
        public string? CollectionRid => this.GetOrDefault(HeaderNames.CollectionRid);
        public string? FilterBySchemaResourceId => this.GetOrDefault(HeaderNames.FilterBySchemaResourceId);
        public string? UsePolygonsSmallerThanAHemisphere => this.GetOrDefault(HeaderNames.UsePolygonsSmallerThanAHemisphere);
        public string? GatewaySignature => this.GetOrDefault(HeaderNames.GatewaySignature);
        public string? EnableLogging => this.GetOrDefault(HeaderNames.EnableLogging);
        public string? A_IM => this.GetOrDefault(HeaderNames.A_IM);
        public string? IfModifiedSince => this.GetOrDefault(HeaderNames.IfModifiedSince);
        public string? PopulateQuotaInfo => this.GetOrDefault(HeaderNames.PopulateQuotaInfo);
        public string? DisableRUPerMinuteUsage => this.GetOrDefault(HeaderNames.DisableRUPerMinuteUsage);
        public string? PopulateQueryMetrics => this.GetOrDefault(HeaderNames.PopulateQueryMetrics);
        public string? ResponseContinuationTokenLimitInKB => this.GetOrDefault(HeaderNames.ResponseContinuationTokenLimitInKB);
        public string? PopulatePartitionStatistics => this.GetOrDefault(HeaderNames.PopulatePartitionStatistics);
        public string? RemoteStorageType => this.GetOrDefault(HeaderNames.RemoteStorageType);
        public string? RemainingTimeInMsOnClientRequest => this.GetOrDefault(HeaderNames.RemainingTimeInMsOnClientRequest);
        public string? ClientRetryAttemptCount => this.GetOrDefault(HeaderNames.ClientRetryAttemptCount);
        public string? TargetLsn => this.GetOrDefault(HeaderNames.TargetLsn);
        public string? TargetGlobalCommittedLsn => this.GetOrDefault(HeaderNames.TargetGlobalCommittedLsn);
        public string? TransportRequestID => this.GetOrDefault(HeaderNames.TransportRequestID);
        public string? CollectionRemoteStorageSecurityIdentifier => this.GetOrDefault(HeaderNames.CollectionRemoteStorageSecurityIdentifier);
        public string? PopulateCollectionThroughputInfo => this.GetOrDefault(HeaderNames.PopulateCollectionThroughputInfo);
        public string? RestoreMetadataFilter => this.GetOrDefault(HeaderNames.RestoreMetadataFilter);
        public string? RestoreParams => this.GetOrDefault(HeaderNames.RestoreParams);
        public string? ShareThroughput => this.GetOrDefault(HeaderNames.ShareThroughput);
        public string? PartitionResourceFilter => this.GetOrDefault(HeaderNames.PartitionResourceFilter);
        public string? IsReadOnlyScript => this.GetOrDefault(HeaderNames.IsReadOnlyScript);
        public string? IsAutoScaleRequest => this.GetOrDefault(HeaderNames.IsAutoScaleRequest);
        public string? ForceQueryScan => this.GetOrDefault(HeaderNames.ForceQueryScan);
        public string? CanOfferReplaceComplete => this.GetOrDefault(HeaderNames.CanOfferReplaceComplete);
        public string? ExcludeSystemProperties => this.GetOrDefault(HeaderNames.ExcludeSystemProperties);
        public string? BinaryId => this.GetOrDefault(HeaderNames.BinaryId);
        public string? TimeToLiveInSeconds => this.GetOrDefault(HeaderNames.TimeToLiveInSeconds);
        public string? EffectivePartitionKey => this.GetOrDefault(HeaderNames.EffectivePartitionKey);
        public string? BinaryPassthroughRequest => this.GetOrDefault(HeaderNames.BinaryPassthroughRequest);
        public string? EnableDynamicRidRangeAllocation => this.GetOrDefault(HeaderNames.EnableDynamicRidRangeAllocation);
        public string? EnumerationDirection => this.GetOrDefault(HeaderNames.EnumerationDirection);
        public string? StartId => this.GetOrDefault(HeaderNames.StartId);
        public string? EndId => this.GetOrDefault(HeaderNames.EndId);
        public string? FanoutOperationState => this.GetOrDefault(HeaderNames.FanoutOperationState);
        public string? StartEpk => this.GetOrDefault(HeaderNames.StartEpk);
        public string? EndEpk => this.GetOrDefault(HeaderNames.EndEpk);
        public string? ReadFeedKeyType => this.GetOrDefault(HeaderNames.ReadFeedKeyType);
        public string? ContentSerializationFormat => this.GetOrDefault(HeaderNames.ContentSerializationFormat);
        public string? AllowTentativeWrites => this.GetOrDefault(HeaderNames.AllowTentativeWrites);
        public string? IsUserRequest => this.GetOrDefault(HeaderNames.IsUserRequest);
        public string? PreserveFullContent => this.GetOrDefault(HeaderNames.PreserveFullContent);
        public string? IncludeTentativeWrites => this.GetOrDefault(HeaderNames.IncludeTentativeWrites);
        public string? PopulateResourceCount => this.GetOrDefault(HeaderNames.PopulateResourceCount);
        public string? MergeStaticId => this.GetOrDefault(HeaderNames.MergeStaticId);
        public string? IsBatchAtomic => this.GetOrDefault(HeaderNames.IsBatchAtomic);
        public string? ShouldBatchContinueOnError => this.GetOrDefault(HeaderNames.ShouldBatchContinueOnError);
        public string? IsBatchOrdered => this.GetOrDefault(HeaderNames.IsBatchOrdered);
        public string? SchemaOwnerRid => this.GetOrDefault(HeaderNames.SchemaOwnerRid);
        public string? SchemaHash => this.GetOrDefault(HeaderNames.SchemaHash);
        public string? IsRUPerGBEnforcementRequest => this.GetOrDefault(HeaderNames.IsRUPerGBEnforcementRequest);
        public string? MaxPollingIntervalMilliseconds => this.GetOrDefault(HeaderNames.MaxPollingIntervalMilliseconds);
        public string? PopulateLogStoreInfo => this.GetOrDefault(HeaderNames.PopulateLogStoreInfo);
        public string? GetAllPartitionKeyStatistics => this.GetOrDefault(HeaderNames.GetAllPartitionKeyStatistics);
        public string? ForceSideBySideIndexMigration => this.GetOrDefault(HeaderNames.ForceSideBySideIndexMigration);
        public string? CollectionChildResourceNameLimitInBytes => this.GetOrDefault(HeaderNames.CollectionChildResourceNameLimitInBytes);
        public string? CollectionChildResourceContentLimitInKB => this.GetOrDefault(HeaderNames.CollectionChildResourceContentLimitInKB);
        public string? MergeCheckPointGLSN => this.GetOrDefault(HeaderNames.MergeCheckPointGLSN);
        public string? Prefer => this.GetOrDefault(HeaderNames.Prefer);
        public string? UniqueIndexNameEncodingMode => this.GetOrDefault(HeaderNames.UniqueIndexNameEncodingMode);
        public string? PopulateUnflushedMergeEntryCount => this.GetOrDefault(HeaderNames.PopulateUnflushedMergeEntryCount);
        public string? MigrateOfferToManualThroughput => this.GetOrDefault(HeaderNames.MigrateOfferToManualThroughput);
        public string? MigrateOfferToAutopilot => this.GetOrDefault(HeaderNames.MigrateOfferToAutopilot);
        public string? IsClientEncrypted => this.GetOrDefault(HeaderNames.IsClientEncrypted);
        public string? SystemDocumentType => this.GetOrDefault(HeaderNames.SystemDocumentType);
        public string? IsOfferStorageRefreshRequest => this.GetOrDefault(HeaderNames.IsOfferStorageRefreshRequest);
        public string? ResourceTypes => this.GetOrDefault(HeaderNames.ResourceTypes);
        public string? TransactionId => this.GetOrDefault(HeaderNames.TransactionId);
        public string? TransactionFirstRequest => this.GetOrDefault(HeaderNames.TransactionFirstRequest);
        public string? TransactionCommit => this.GetOrDefault(HeaderNames.TransactionCommit);
        public string? UpdateMaxThroughputEverProvisioned => this.GetOrDefault(HeaderNames.UpdateMaxThroughputEverProvisioned);
        public string? UniqueIndexReIndexingState => this.GetOrDefault(HeaderNames.UniqueIndexReIndexingState);
        public string? UseSystemBudget => this.GetOrDefault(HeaderNames.UseSystemBudget);
        public string? IgnoreSystemLoweringMaxThroughput => this.GetOrDefault(HeaderNames.IgnoreSystemLoweringMaxThroughput);
        public string? TruncateMergeLogRequest => this.GetOrDefault(HeaderNames.TruncateMergeLogRequest);
        public string? RetriableWriteRequestId => this.GetOrDefault(HeaderNames.RetriableWriteRequestId);
        public string? IsRetriedWriteRequest => this.GetOrDefault(HeaderNames.IsRetriedWriteRequest);
        public string? RetriableWriteRequestStartTimestamp => this.GetOrDefault(HeaderNames.RetriableWriteRequestStartTimestamp);
        public string? AddResourcePropertiesToResponse => this.GetOrDefault(HeaderNames.AddResourcePropertiesToResponse);
        public string? ChangeFeedStartFullFidelityIfNoneMatch => this.GetOrDefault(HeaderNames.ChangeFeedStartFullFidelityIfNoneMatch);
        public string? SystemRestoreOperation => this.GetOrDefault(HeaderNames.SystemRestoreOperation);
        public string? SkipRefreshDatabaseAccountConfigs => this.GetOrDefault(HeaderNames.SkipRefreshDatabaseAccountConfigs);
        public string? IntendedCollectionRid => this.GetOrDefault(HeaderNames.IntendedCollectionRid);
        public string? UseArchivalPartition => this.GetOrDefault(HeaderNames.UseArchivalPartition);
        public string? PopulateUniqueIndexReIndexProgress => this.GetOrDefault(HeaderNames.PopulateUniqueIndexReIndexProgress);
        public string? SchemaId => this.GetOrDefault(HeaderNames.SchemaId);
        public string? CollectionTruncate => this.GetOrDefault(HeaderNames.CollectionTruncate);
        public string? SDKSupportedCapabilities => this.GetOrDefault(HeaderNames.SDKSupportedCapabilities);
        public string? IsMaterializedViewBuild => this.GetOrDefault(HeaderNames.IsMaterializedViewBuild);
        public string? BuilderClientIdentifier => this.GetOrDefault(HeaderNames.BuilderClientIdentifier);
        public string? SourceCollectionIfMatch => this.GetOrDefault(HeaderNames.SourceCollectionIfMatch);
        public string? RequestedCollectionType => this.GetOrDefault(HeaderNames.RequestedCollectionType);
        public string? PopulateIndexMetrics => this.GetOrDefault(HeaderNames.PopulateIndexMetrics);
        public string? PopulateAnalyticalMigrationProgress => this.GetOrDefault(HeaderNames.PopulateAnalyticalMigrationProgress);
        public string? ShouldReturnCurrentServerDateTime => this.GetOrDefault(HeaderNames.ShouldReturnCurrentServerDateTime);
        public string? RbacUserId => this.GetOrDefault(HeaderNames.RbacUserId);
        public string? RbacAction => this.GetOrDefault(HeaderNames.RbacAction);
        public string? RbacResource => this.GetOrDefault(HeaderNames.RbacResource);
        public string? CorrelatedActivityId => this.GetOrDefault(HeaderNames.CorrelatedActivityId);
        public string? IsThroughputCapRequest => this.GetOrDefault(HeaderNames.IsThroughputCapRequest);
        public string? ChangeFeedWireFormatVersion => this.GetOrDefault(HeaderNames.ChangeFeedWireFormatVersion);
        public string? PopulateByokEncryptionProgress => this.GetOrDefault(HeaderNames.PopulateByokEncryptionProgress);
        public string? UseUserBackgroundBudget => this.GetOrDefault(HeaderNames.UseUserBackgroundBudget);
        public string? IncludePhysicalPartitionThroughputInfo => this.GetOrDefault(HeaderNames.IncludePhysicalPartitionThroughputInfo);
        public string? IsServerlessStorageRefreshRequest => this.GetOrDefault(HeaderNames.IsServerlessStorageRefreshRequest);
        public string? UpdateOfferStateToPending => this.GetOrDefault(HeaderNames.UpdateOfferStateToPending);
        public string? PopulateOldestActiveSchema => this.GetOrDefault(HeaderNames.PopulateOldestActiveSchema);
        public string? IsInternalServerlessRequest => this.GetOrDefault(HeaderNames.IsInternalServerlessRequest);
        public string? OfferReplaceRURedistribution => this.GetOrDefault(HeaderNames.OfferReplaceRURedistribution);
        public string? IsMaterializedViewSourceSchemaReplaceBatchRequest => this.GetOrDefault(HeaderNames.IsMaterializedViewSourceSchemaReplaceBatchRequest);
        public string? IfMatch => this.GetOrDefault(HeaderNames.IfMatch);

        public void Set(HeaderNames name, string value)
        {
            int nameAsInt = (int)name;

            // can't set what's already set
            if (this.headerIndexes[nameAsInt] != 0)
            {
                throw new InvalidOperationException();
            }

            byte nextIndex = (byte)headerValues.Count;

            this.headerIndexes[nameAsInt] = nextIndex;
            this.headerValues.Add(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public bool TryGetValue(HeaderNames name, out string? value)
        {
            int nameAsInt = (int)name;

            value = this.headerValues[this.headerIndexes[nameAsInt]];

            return value != null;
        }

        public Enumerator GetEnumerator()
        => new Enumerator(this);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string? GetOrDefault(HeaderNames name)
        => this.TryGetValue(name, out string? value) ? value : null;

        internal struct Enumerator : IEnumerator<HeaderNames>
        {
            private readonly ArrayHeaders headers;
            private int startIndex;

            public HeaderNames Current { get; private set; }

            object IEnumerator.Current
            => this.Current;

            internal Enumerator(ArrayHeaders headers)
            {
                this.startIndex = 0;
                this.headers = headers;
                this.Current = 0;
            }

            public bool MoveNext()
            {
                if (this.startIndex >= ArrayHeaders.IndexesSize)
                {
                    return false;
                }

                int fullLength = ArrayHeaders.IndexesSize - this.startIndex;
                int remainder = fullLength;

                int longs = remainder / 8;
               
               
                // note: requires LittleEndian, BigEndian inverts some of this

                Span<byte> toSearch = this.headers.headerIndexes.AsSpan().Slice(this.startIndex);

                // go 8 bytes at a time
                Span<ulong> toSearchLongs = MemoryMarshal.Cast<byte, ulong>(toSearch.Slice(0, longs * 8));
                for (int i = 0; i < toSearchLongs.Length; i++)
                {
                    int count = BitOperations.TrailingZeroCount(toSearchLongs[i]);
                    if (count != 64)
                    {
                        int firstNonZeroByte = count / 8;
                        int byteOffset = i * 8 + firstNonZeroByte;

                        int currentHeaderOffset = (this.startIndex + byteOffset);

                        this.Current = (HeaderNames)currentHeaderOffset;
                        this.startIndex = currentHeaderOffset + 1;

                        return true;
                    }
                }

                remainder -= longs * 8;
                int ints = remainder / 4;

                // go 4 bytes at at time
                Span<uint> toSearchInts = MemoryMarshal.Cast<byte, uint>(toSearch.Slice(longs * 8, ints * 4));
                for (int i = 0; i < toSearchInts.Length; i++)
                {
                    int count = BitOperations.TrailingZeroCount(toSearchInts[i]);
                    if (count != 32)
                    {
                        int firstNonZeroByte = count / 8;
                        int byteOffset = longs * 8 + i * 4 + firstNonZeroByte;

                        int currentHeaderOffset = (this.startIndex + byteOffset);

                        this.Current = (HeaderNames)currentHeaderOffset;
                        this.startIndex = currentHeaderOffset + 1;

                        return true;
                    }
                }

                remainder -= ints * 4;

                // not bothering with shorts, go 1 byte at a time
                Span<byte> toSearchBytes = toSearch.Slice(toSearch.Length - remainder);
                for (int i = 0; i < toSearchBytes.Length; i++)
                {
                    if (toSearchBytes[i] != 0)
                    {
                        int currentHeaderOffset = this.startIndex + longs * 8 + ints * 4 + i;

                        this.Current = (HeaderNames)currentHeaderOffset;
                        this.startIndex = currentHeaderOffset + 1;

                        return true;
                    }
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
