using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot!"));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming", "Jane Smith", 900);
        video2.AddComment(new Comment("Dave", "Fantastic overview!"));
        video2.AddComment(new Comment("Eve", "I finally understand OOP."));
        video2.AddComment(new Comment("Frank", "Could you do more examples?"));
        videos.Add(video2);

        Video video3 = new Video("Advanced C# Techniques", "Emily Brown", 1200);
        video3.AddComment(new Comment("Grace", "Super insightful!"));
        video3.AddComment(new Comment("Hank", "Really useful tricks!"));
        video3.AddComment(new Comment("Ivy", "Loved the depth of content."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine();
        }
    }
}
