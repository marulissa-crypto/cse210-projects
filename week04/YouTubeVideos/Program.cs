using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Morning Desk Setup & Productivity Routine", "TechWithLiam", 645);
        video1.AddComment(new Comment("Hannah K.", "That mechanical keyboard sounds so clean."));
        video1.AddComment(new Comment("Devon R.", "Where is that monitor light bar from?"));
        video1.AddComment(new Comment("Priya S.", "Great pacing, super easy to follow."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("10-Minute Healthy Meal Prep for Busy Weeks", "KitchenCraft", 510);
        video2.AddComment(new Comment("Carlos M.", "Tried the grain bowls last night—so good!"));
        video2.AddComment(new Comment("Maya T.", "Love how simple the ingredient list is."));
        video2.AddComment(new Comment("Samir N.", "Do you store the dressing separately?"));
        video2.AddComment(new Comment("Claire B.", "This saves me so much time on weekdays."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Trail Running Gear Review: 500km Later", "StrideAndSummit", 890);
        video3.AddComment(new Comment("Owen P.", "Appreciate an honest long-term durability check."));
        video3.AddComment(new Comment("Nadia L.", "Did the grip hold up well on wet rock?"));
        video3.AddComment(new Comment("Toby W.", "Solid breakdown of sizing too."));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}