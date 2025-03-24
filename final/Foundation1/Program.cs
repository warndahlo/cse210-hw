using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}\nAuthor: {Author}\nLength: {LengthInSeconds} seconds\nNumber of Comments: {GetCommentCount()}\n");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine("-----------------------------");
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Understanding Abstraction", "TechGuru", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "This really helped me understand abstraction."));
        video1.AddComment(new Comment("Charlie", "Awesome video, thanks!"));
        videos.Add(video1);

        Video video2 = new Video("C# Interfaces Explained", "CodeMaster", 720);
        video2.AddComment(new Comment("David", "Very informative."));
        video2.AddComment(new Comment("Emma", "Loved the real-world examples."));
        video2.AddComment(new Comment("Frank", "Simple and clear!"));
        videos.Add(video2);

        Video video3 = new Video("Design Patterns in C#", "DevSensei", 900);
        video3.AddComment(new Comment("Grace", "Finally, I understand Singleton!"));
        video3.AddComment(new Comment("Hank", "Really useful for my project."));
        video3.AddComment(new Comment("Ivy", "Thanks for this detailed explanation."));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
