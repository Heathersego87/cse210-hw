using System.IO;
using System.Security.Cryptography.X509Certificates;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _filepath;
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}||{entry._promptText}||{entry._entryText}");
            }
        }
        public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _entries.Clear();
        foreach (string line in lines);
        {
            string[] parts = line.Split("||");
        }
    }
    }
}
//Heather Sego