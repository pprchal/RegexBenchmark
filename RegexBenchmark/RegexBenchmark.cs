using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;
using System.Text.RegularExpressions;


public class RegexBenchmark
{
    readonly Regex rx = new("(a+|b+)+b", RegexOptions.Compiled);

    //[ParamsSource(nameof(LinesForTest))]
    //public string Line = "";

    private string CreateLine(int n)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            sb.Append('a');
        }
        sb.Append('c');
        return sb.ToString();
    }

    public IEnumerable<string> LinesForTest
    {
        get
        {
            for (int n = 0; n < 10; n++)
            {
                yield return CreateLine(n);
            }
        }
    }

    // [Benchmark]
    // public bool CheckRe(string line = null) => rx.IsMatch(line ?? Line);
    DateTime t = DateTime.Now;

    [Benchmark]
    public bool FileInfoBench()
    {
        var fi = new FileInfo("c:\\work\\AIB.log").LastWriteTime;
        var secs = new TimeSpan(DateTime.Now.Ticks - t.Ticks).TotalSeconds;

        return fi == t;
    }

}
