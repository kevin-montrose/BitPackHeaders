using BitPackHeaders;
using System.Diagnostics;

//using System;
//using System.Collections.Generic;
//using System.Linq;

//IEnumerable<HeaderNames> allHeaders = Enum.GetValues<HeaderNames>();
//IEnumerable<HeaderNames> allHeadersReversed = allHeaders.Reverse().ToArray();

//Random r = new Random(2022_05_19);
//IEnumerable<HeaderNames> allHeadersRandomized = allHeaders.Select(t => (t, r.Next())).OrderBy(t => t.Item2).Select(t => t.t).ToArray();

//IEnumerable<HeaderNames> subsetHeaders = allHeaders.Where(t => r.Next(2) == 1).ToArray();
//IEnumerable<HeaderNames> subsetHeadersReversed = subsetHeaders.Reverse().ToArray();
//IEnumerable<HeaderNames> subsetHeadersRandomized = subsetHeaders.Select(t => (t, r.Next())).OrderBy(t => t.Item2).Select(t => t.t).ToArray();

//CorrectnessCheck.Fields(allHeaders);
//CorrectnessCheck.Fields(allHeadersRandomized);
//CorrectnessCheck.Fields(allHeadersReversed);
//CorrectnessCheck.Fields(subsetHeaders);
//CorrectnessCheck.Fields(subsetHeadersReversed);
//CorrectnessCheck.Fields(subsetHeadersRandomized);

//CorrectnessCheck.Dictionary(allHeaders);
//CorrectnessCheck.Dictionary(allHeadersRandomized);
//CorrectnessCheck.Dictionary(allHeadersReversed);
//CorrectnessCheck.Dictionary(subsetHeaders);
//CorrectnessCheck.Dictionary(subsetHeadersReversed);
//CorrectnessCheck.Dictionary(subsetHeadersRandomized);

//CorrectnessCheck.Array(allHeaders);
//CorrectnessCheck.Array(allHeadersRandomized);
//CorrectnessCheck.Array(allHeadersReversed);
//CorrectnessCheck.Array(subsetHeaders);
//CorrectnessCheck.Array(subsetHeadersReversed);
//CorrectnessCheck.Array(subsetHeadersRandomized);

//CorrectnessCheck.Packed(allHeaders);
//CorrectnessCheck.Packed(allHeadersRandomized);
//CorrectnessCheck.Packed(allHeadersReversed);
//CorrectnessCheck.Packed(subsetHeaders);
//CorrectnessCheck.Packed(subsetHeadersReversed);
//CorrectnessCheck.Packed(subsetHeadersRandomized);

if (Debugger.IsAttached)
{
    var g = new GetBenchmark();
    g.Seed = 123;
    g.HitRate = 30;
    g.NumHeadersLookedUp = 45;
    g.Init();
    g.Dictionary();
    g.Fields();
    g.Packed();

    var s = new SetBenchmark();
    s.Seed = 123;
    s.SetPattern = "Random";
    s.NumHeaders = 24;
    s.Init();
    s.Dictionary();
    s.Fields();
    s.Packed();

    var gk = new GetKnownBenchmark();
    gk.Seed = 123;
    gk.HitRate = 50;
    gk.NumHeadersLookedUp = 24;
    gk.Init();
    gk.Dictionary();
    gk.Fields();
    gk.Packed();

    var k = new KeysBenchmark();
    k.Seed = 123;
    k.NumHeaders = 42;
    k.Init();
    k.Dictionary();
    k.Fields_Switch();
    k.Fields_Enumerable();
    k.Packed();
}
else
{
    //var s = new SetBenchmark();
    //s.Seed = 123;
    //s.SetPattern = "Random";
    //s.NumHeaders = 151;
    //s.Init();

    //for (int i = 1; i < 1000; i++)
    //{
    //    s.Packed();
    //}

    BenchmarkDotNet.Running.BenchmarkSwitcher.FromAssembly(typeof(HeaderNames).Assembly).Run();
}