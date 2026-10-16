public class Goal
{
    private string _name;
    private string _description;
    private int _points;
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public string GetName()
    {
        return _name;
    }
    public virtual int RecordEvent()
    {
        return 0;
    }
    public virtual bool IsComplete()
    {
        return false;
    }
    public virtual string GetDetailsString()
    {
        return $"{_name} ({_description})";
    }
    public virtual string GetStringRepresentation()
    {
        return $"{_name}|{_description}|{_points}";
    }
    public int GetPoints()
    {
        return _points;
    }
}