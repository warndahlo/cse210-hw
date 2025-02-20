public class MathAssignment : Assignment
{
    public string Section { get; set; }
    public string Problems { get; set; }

    public MathAssignment(string topic, string studentName, string section, string problems)
        : base(topic, studentName)
    {
        Section = section;
        Problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section: {Section}, Problems: {Problems}";
    }
}