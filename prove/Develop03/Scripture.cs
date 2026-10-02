using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

public class Scripture
{
   private Reference _reference;
   private List<Word> _words;

   public Scripture(Reference reference, string text)
    {   
        _reference = reference;
        _words = new List<Word>();
        string[] wordList = text.Split(" ");
        foreach (string word in wordList)
        {
            Word word1 = new Word(word);
            _words.Add(word1);
        }
    }
    public void HideRandomWords(int number)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }
        Random random = new Random();
        for (int i = 0; i < number; i++)
        {
            if (visibleWords.Count == 0)
            {
                break;
            }
            int index = random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public string GetRenderedText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text += word.GetRenderedText() +" ";
        }
        return text;
    }
    public bool IsCompletelyHidden()
    {
    foreach (Word word in _words)
    {
        if (!word.IsHidden())
        {
            return false;
        }
    }
        return true;
    }
    public string GetReference()
    {
        return _reference.GetReferenceString();
    }
}