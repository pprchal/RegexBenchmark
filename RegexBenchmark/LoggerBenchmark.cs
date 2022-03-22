using BenchmarkDotNet.Attributes;
using NLog;



public class LoggerBenchmark
{
    private readonly static ILogger LOG = LogManager.GetCurrentClassLogger();

    [Benchmark]
    public void Interpolated()
    {
        for (int i = 0; i < 1000; i++)
        {
            LOG.Info($"Ahoj, {(i*i)/2*i}");
        }
    }

    [Benchmark]
    public void Optimized()
    {
        for (int i = 0; i < 1000; i++)
        {
            LOG.Info("Ahoj {i}", (i * i) / 2 * i);
        }
    }
}
