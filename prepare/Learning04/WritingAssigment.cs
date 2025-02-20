public class WritingAssignment : Assignment
{
    public string Title { get; set; }

    public WritingAssignment(string topic, string studentName, string title)
        : base(topic, studentName)
    {
        Title = title;
    }

    public string GetWritingInformation()
    {
        return $"Title: {Title}";
    }
}