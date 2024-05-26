using System.Speech.Synthesis;

Console.WriteLine("Press any key to start...");
Console.ReadKey();

var dictionary = new List<string> 
{ 
    "challenge", "pyramid", "recommend", "accommodate", "definitely", "binoculars", 
    "separate", "occurrence", "embarrass", "receive",  
     "necessary", "calendar", "restaurant", 
    "maintenance", "privilege", "occasionally", "guarantee", "broccoli", "conscience", 
    "mischievous" 
};

var words = GetRandomWords(dictionary, 4);

var correctWords = new List<string>();
var incorrectWords = new List<string>();
var incorrectWordsAttempt = new List<string>();

PracticeWords(words);
Console.Clear();

while (incorrectWords.Count > 0)
{ 
    
    Console.WriteLine("You have some incorrect words. Let's practice them again... Press any key to start...");

    for (var i = 0; i < incorrectWords.Count; i++)
    {
        Console.WriteLine(incorrectWords[i] + ": You wrote " + incorrectWordsAttempt[i]);
    }

    Console.ReadKey();
    words = incorrectWords.Select(x=>x).ToList();
    incorrectWords.Clear();
    incorrectWordsAttempt.Clear();
    Console.Clear();
    
    PracticeWords(words);
    //Retry!
}

Console.WriteLine("You got everything correct! Great job! Press any key to exit...");
Console.ReadKey();


static List<string> GetRandomWords(List<string> words, int count)
{
    var random = new Random();
    return words.OrderBy(x => random.Next()).Take(count).ToList();
}

void PracticeWords(List<string> list)
{
    var synth = new SpeechSynthesizer();
    
    for (var i = 0; i < list.Count; i++)
    {
        var word = list[i];
        Console.WriteLine("Listen to the word and then type it out and press enter... Press enter to listen again...");
        synth.Speak(word);
        var typedWord = Console.ReadLine();

        if (typedWord == "")
            i--;
        else if (word == typedWord)
        {
            Console.WriteLine("Correct!");
            correctWords.Add(word);
        }
        else
        {
            Console.WriteLine("Incorrect! The correct word is: " + word);
            incorrectWords.Add(word);
            incorrectWordsAttempt.Add(typedWord);
        }
    }
}