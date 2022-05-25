using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPackHeaders
{
    [MemoryDiagnoser]
    public class KeysBenchmark
    {
        private const int Iterations = 10_000;

        [Params(
            1, 
            4, 
            10,
            20, 
            40, 
            80, 
            151
        )]
        public int NumHeaders { get; set; }

        //[Params(0, 2022_05_19, 123456789)]
        public int Seed { get; set; }

        private DictionaryHeaders dictionary;
        private FieldHeaders fields;
        private ArrayHeaders array;
        private PackedHeaders packed;

        [GlobalSetup]
        public void Init()
        {
            this.Seed = 2022_05_19;

            (HeaderNames Header, string Value)[] storedHeaders = new (HeaderNames Header, string Value)[this.NumHeaders];
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
        }

        [Benchmark]
        public void Dictionary()
        {
            Span<HeaderNames> storeTo = stackalloc HeaderNames[this.NumHeaders];

            for (int x = 0; x < Iterations; x++)
            {
                int ix = 0;
                foreach (HeaderNames header in this.dictionary)
                {
                    storeTo[ix] = header;
                    ix++;
                }
            }
        }

        [Benchmark]
        public void Fields_Switch()
        {
            Span<HeaderNames> storeTo = stackalloc HeaderNames[this.NumHeaders];

            for (int x = 0; x < Iterations; x++)
            {
                int ix = 0;
                foreach (HeaderNames header in this.fields)
                {
                    storeTo[ix] = header;
                    ix++;
                }
            }
        }

        [Benchmark]
        public void Fields_Enumerable()
        {
            Span<HeaderNames> storeTo = stackalloc HeaderNames[this.NumHeaders];

            for (int x = 0; x < Iterations; x++)
            {
                int ix = 0;
                foreach (HeaderNames header in this.fields.Enumerable())
                {
                    storeTo[ix] = header;
                    ix++;
                }
            }
        }

        [Benchmark]
        public void Array()
        {
            Span<HeaderNames> storeTo = stackalloc HeaderNames[this.NumHeaders];

            for (int x = 0; x < Iterations; x++)
            {
                int ix = 0;
                foreach (HeaderNames header in this.array)
                {
                    storeTo[ix] = header;
                    ix++;
                }
            }
        }

        [Benchmark]
        public void Packed()
        {
            Span<HeaderNames> storeTo = stackalloc HeaderNames[this.NumHeaders];

            for (int x = 0; x < Iterations; x++)
            {
                int ix = 0;
                foreach (HeaderNames header in this.packed)
                {
                    storeTo[ix] = header;
                    ix++;
                }
            }
        }
    }
}
