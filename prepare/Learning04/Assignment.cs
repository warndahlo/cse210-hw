public class Assignment
{
    public string Topic { get; set; }
    public string StudentName { get; set; }

    public Assignment(string topic, string studentName)
    {
        Topic = topic;
        StudentName = studentName;
    }

    public string GetSummary()
    {
        return $"Student: {StudentName}, Topic: {Topic}";
    }
}