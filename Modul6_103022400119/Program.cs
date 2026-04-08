public class SayaMusicUser
{
    private int id;
    public string username;
    private List<SayaMusicTrack> uploadedTracks;

    public SayaMusicUser (string username)
    {
        this.username = username;
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
    }
    
    public void PrintAllTrack()
    {
        Console.WriteLine($"User:{username}");
        for (int i = 0; i < uploadedTracks.Count; i++)
        {
            Console.WriteLine($"Track" + uploadedTracks.Count + uploadedTracks[i].title);
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
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        this.playCount = count;
    }

    public void PrintTrackDetails()
    {
        Console.WriteLine($"Id: {id}");
        Console.WriteLine($"Judul: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

public class Program
{
    static void main (string[] args)
    {
        SayaMusicTrack track = new SayaMusicTrack("lagu sedih");
        int playTest = Convert.ToInt32 (Console.ReadLine());
        track.IncreasePlayCount(playTest);
        track.PrintTrackDetails();
    }
}