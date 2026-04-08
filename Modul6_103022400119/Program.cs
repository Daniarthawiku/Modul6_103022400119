using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

public class SayaMusicUser
{
    private int id;
    public string username;
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser (string username)
    {
        this.username = username;
        Contract.Requires(username.Length <= 100);
        Contract.Requires(username != null);
    }

    public int GetTotalPlayCount
    {
        get
        {
            return uploadedTracks.Count;
        }
    }
    
    public void AddTrack(SayaMusicTrack track)
    {
        this.uploadedTracks.Add(track);
        Contract.Requires(track != null);
    }
    
    public void PrintAllTrack()
    {
        Console.WriteLine($"User:{username}");
        for (int i = 0; i < uploadedTracks.Count; i++)
        {
            Console.WriteLine($"\nTrack" + uploadedTracks.Count + uploadedTracks[i].title);
        }
    }
}

public class SayaMusicTrack
{
    private int id = 5;
    public string title;
    private int playCount;

    public SayaMusicTrack(string title)
    {
        this.title = title;
        Contract.Requires(title != null);
        Contract.Requires(title.Length <= 200);

        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 25000000);
        this.playCount = count;
        Contract.Requires(count < int.MaxValue);

        try
        {
            int currentCount = playCount;
            checked
            {
                currentCount = currentCount + count;
            }
        }
        catch
        {
            Console.WriteLine("error");
           
        }
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine($"\nId: {id}");
        Console.WriteLine($"Judul: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

public class Program
{
    public static void Main (string[] args)
    {
        SayaMusicTrack track = new SayaMusicTrack("lagu sedih");
        SayaMusicUser user = new SayaMusicUser("HarryKane");

        
        do
        {
            try
            {
                Console.WriteLine("\nMasukan Playtest: ");
                int playTest = Convert.ToInt32(Console.ReadLine());
                {
                    for (int j = 0; j < 3; j++)
                    {
                        track.IncreasePlayCount(playTest);
                    }
                }
               
                track.PrintTrackDetails();
                
            }
            catch (Exception e)
            {
                track.PrintTrackDetails();
                Console.WriteLine(e.ToString());
                break;
            }
        } while (true);
        user.PrintAllTrack();
    }
}