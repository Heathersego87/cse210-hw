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
    public void AddEdntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
}
