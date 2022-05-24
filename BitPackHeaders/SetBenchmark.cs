using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitPackHeaders
{
    [MemoryDiagnoser]
    public class SetBenchmark
    {
        private const int Iterations = 10_000;

        [Params(1, 4, 10, 32, 151)]
        public int NumHeaders { get; set; }

        [Params("Random", "InOrder")]
        public string SetPattern { get; set; }

        //[Params(0, 2022_05_19, 123456789)]
        public int Seed { get; set; }

        private (HeaderNames Header, string Value)[] Headers;

        [GlobalSetup]
        public void Init()
        {
            Seed = 2022_05_19;
            Headers = new (HeaderNames Header, string Value)[NumHeaders];
            Random r = new Random(Seed);

            List<HeaderNames> allHeaders = Enum.GetValues<HeaderNames>().ToList();

            for(int i = 0; i < Headers.Length; i++)
            {
                int nextHeaderIx =
                    SetPattern == "Random" ?
                        r.Next(allHeaders.Count) :
                        SetPattern == "InOrder" ?
                            0 :
                            throw new InvalidOperationException();
                Headers[i] = (allHeaders[nextHeaderIx], i.ToString());

                allHeaders.RemoveAt(nextHeaderIx);
            }
        }

        [Benchmark]
        public void Dictionary()
        {
            for (int x = 0; x < Iterations; x++)
            {
                var dict = new DictionaryHeaders();
                for (var i = 0; i < Headers.Length; i++)
                {
                    (HeaderNames Header, string Value) val = this.Headers[i];
                    dict.Set(val.Header, val.Value);
                }
            }
        }

        [Benchmark]
        public void Fields()
        {
            for (int x = 0; x < Iterations; x++)
            {
                var fields = new FieldHeaders();
                for (var i = 0; i < Headers.Length; i++)
                {
                    (HeaderNames Header, string Value) val = this.Headers[i];
                    fields.Set(val.Header, val.Value);
                }
            }
        }

        [Benchmark]
        public void Array()
        {
            for (int x = 0; x < Iterations; x++)
            {
                var dict = new ArrayHeaders();
                for (var i = 0; i < Headers.Length; i++)
                {
                    (HeaderNames Header, string Value) val = this.Headers[i];
                    dict.Set(val.Header, val.Value);
                }
            }
        }

        [Benchmark]
        public void Packed()
        {
            for (int x = 0; x < Iterations; x++)
            {
                var packed = new PackedHeaders();
                for (var i = 0; i < Headers.Length; i++)
                {
                    (HeaderNames Header, string Value) val = this.Headers[i];
                    packed.Set(val.Header, val.Value);
                }
            }
        }
    }
}