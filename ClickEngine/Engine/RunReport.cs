using ClickEngine.Engine.Positions;

public class RunReport
{
    private readonly IClick _report;
    private readonly FillType _fillType;
    public RunReport(IClick report,FillType fillType)
    {
        _report = report;
        _fillType = fillType;
    }
    public void Run(string fileName,int numIterations)
    {
        int iteration = 0;
        while (iteration < numIterations)
        {
            _report.PreProcess();
            _report.Fill(_fillType);
            _report.Run(fileName);
            _report.PostProcess();
            iteration++;
        }
    }
}