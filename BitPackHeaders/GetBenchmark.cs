using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPackHeaders
{
    [MemoryDiagnoser]
    public class GetBenchmark
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
            this.packed = new PackedHeaders();
            for (var i = 0; i < storedHeaders.Length; i++)
            {
                (HeaderNames Header, string Value) val = storedHeaders[i];
                dictionary.Set(val.Header, val.Value);
                fields.Set(val.Header, val.Value);
                packed.Set(val.Header, val.Value);
            }

            List<HeaderNames> missHeaders = new List<HeaderNames>();
            for(int i = 0; i < neededMissHeaders; i++)
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
            for (int x = 0; x < Iterations; x++)
            {
                for(int i = 0; i < headersToLookup.Length; i++)
                {
                    this.dictionary.TryGetValue(this.headersToLookup[i], out _);
                }
            }
        }

        [Benchmark]
        public void Fields()
        {
            for (int x = 0; x < Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    this.fields.TryGetValue(this.headersToLookup[i], out _);
                }
            }
        }

        [Benchmark]
        public void Packed()
        {
            for (int x = 0; x < Iterations; x++)
            {
                for (int i = 0; i < headersToLookup.Length; i++)
                {
                    this.packed.TryGetValue(this.headersToLookup[i], out _);
                }
            }
        }
    }
}
