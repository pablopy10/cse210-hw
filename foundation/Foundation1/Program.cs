using System;
using System.Collections.Generic;

class Comment
{
    // Properties to store commenter's name and the comment text
    public string CommenterName;
    public string Text;

    // Constructor to initialize the name and comment
    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    // Method to return the comment as a string
    public string GetCommentInfo()
    {
        return CommenterName + ": " + Text;
    }
}

class Video
{
    // Properties to store the title, author, and length of the video
    public string Title;
    public string Author;
    public int Length; // Length in seconds

    // List to store comments
    public List<Comment> Comments;

    // Constructor to initialize video details
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>(); // Initialize the list of comments
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display video details and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Length: " + Length + " seconds");
        Console.WriteLine("Number of comments: " + GetNumberOfComments());

        // Display all comments
        Console.WriteLine("Comments:");
        foreach (Comment comment in Comments)
        {
            Console.WriteLine(" - " + comment.GetCommentInfo());
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        // Create 3 video objects
        Video video1 = new Video("Learn C# for Beginners", "John Smith", 600);
        Video video2 = new Video("How to Bake a Cake", "Jane Doe", 1200);
        Video video3 = new Video("Simple Workout Routine", "Mike Lee", 900);

        // Add comments to video1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        
        // Add comments to video2
        video2.AddComment(new Comment("Charlie", "Delicious recipe!"));
        video2.AddComment(new Comment("David", "I love baking!"));
        
        // Add comments to video3
        video3.AddComment(new Comment("Eve", "Thanks for the workout tips."));
        video3.AddComment(new Comment("Frank", "This was really helpful!"));

        // Create a list to store videos
        List<Video> videoList = new List<Video>();

        // Add videos to the list
        videoList.Add(video1);
        videoList.Add(video2);
        videoList.Add(video3);

        // Loop through the video list and display their info
        foreach (Video video in videoList)
        {
            video.DisplayVideoInfo(); // Show the video's details and comments
        }
    }
}
