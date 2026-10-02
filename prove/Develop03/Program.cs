using System;
//Heather Sego
// To exceed the requirements, I added multiple scriptures and randomly select
// one for the user to memorize each time the program runs. I also made the
// program select only words that are still visible when hiding random words.

class Program
{
    static void Main(string[] args)
    {
        Reference reference1 = new Reference("1 Nephi", 3, 7);
        string text1 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Scripture scripture1 = new Scripture( reference1, text1 );
        Reference reference2 = new Reference("Joshua", 24, 15);
        string text2 = "And if it seem evil unto you to serve the Lord, choose you this day whom ye will serve; whether the gods which your fathers served that were on the other side of the flood, or the gods of the Amorites, in whose land ye dwell: but as for me and my house, we will serve the Lord.";
        Scripture scripture2 = new Scripture(reference2, text2);
        Reference reference3 = new Reference("Mormon", 9, 27, 28);
        string text3 = "O then despise not, and wonder not, but hearken unto the words of the Lord, and ask the Father in the name of Jesus for what things soever ye shall stand in need. Doubt not, but be believing, and begin as in times of old, and come unto the Lord with all your heart, and work out your own salvation with fear and trembling before him. Be wise in the days of your probation; strip yourselves of all uncleanness; ask not, that ye may consume it on your lusts, but ask with a firmness unshaken, that ye will yield to no temptation, but that ye will serve the true and living God.";
        Scripture scripture3 = new Scripture(reference3, text3);
        List<Scripture> scriptures = new List<Scripture>();
        
        scriptures.Add(scripture1);
        scriptures.Add(scripture2);
        scriptures.Add(scripture3);
        Random random = new Random();
        int randomIndex = random.Next(0, scriptures.Count);
        Scripture selectedScripture = scriptures[randomIndex];
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetReference());
            Console.WriteLine(selectedScripture.GetRenderedText());
            if (selectedScripture.IsCompletelyHidden())
            {
                break;
            }
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            selectedScripture.HideRandomWords(3);
        }
    }
}