using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Best Travel Camera in 2026", "Tech Scout", 542);
        video1.AddComment(new Comment("Mia", "This review was super helpful."));
        video1.AddComment(new Comment("Jordan", "I bought this camera last week and love it."));
        video1.AddComment(new Comment("Chris", "The battery life section was great."));
        video1.AddComment(new Comment("Ava", "Can you compare it with the Sony next?"));

        Video video2 = new Video("Morning Protein Smoothie Recipe", "Fit Kitchen", 318);
        video2.AddComment(new Comment("Liam", "I made this today and it tasted amazing."));
        video2.AddComment(new Comment("Emma", "Thanks for keeping the ingredients simple."));
        video2.AddComment(new Comment("Noah", "I added peanut butter and it was great."));
        video2.AddComment(new Comment("Sophia", "This is going on my weekly meal plan."));

        Video video3 = new Video("Desk Setup for College Students", "Study Space", 465);
        video3.AddComment(new Comment("Olivia", "This setup looks clean and affordable."));
        video3.AddComment(new Comment("Ethan", "The lighting tip made a huge difference for me."));
        video3.AddComment(new Comment("Grace", "Please make a dorm room version too."));
        video3.AddComment(new Comment("Lucas", "The cable management part was my favorite."));

        Video video4 = new Video("How to Start Running Consistently", "Move Daily", 601);
        video4.AddComment(new Comment("Harper", "This motivated me to get started again."));
        video4.AddComment(new Comment("Jack", "The beginner schedule was very realistic."));
        video4.AddComment(new Comment("Ella", "I liked the advice about resting."));
        video4.AddComment(new Comment("Henry", "This was encouraging and practical."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
