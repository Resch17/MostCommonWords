using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

string Story = File.ReadAllText("./story.txt");

char[] delimiterChars = { ' ', ',', '.', ';', '-' };
string[] words = Story.Split(delimiterChars);
List<string> WordList = new List<string>();

foreach (string word in words)
{
  // // remove comments and comment out subsequent line for case-sensitivity
  //   string thisWord = word.ToLower();
  //   WordList.Add(thisWord);
  WordList.Add(word);
}

Dictionary<string, int> WordDictionary = new Dictionary<string, int>();

WordList.ForEach(delegate (String word)
{
  if (!string.IsNullOrWhiteSpace(word))
  {

    if (!WordDictionary.ContainsKey(word))
    {
      WordDictionary.Add(word, 1);
    }
    else
    {
      WordDictionary[word]++;
    }
  }
});

var SortedList = WordDictionary.ToList();
SortedList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

for (int i = 0; i < 10; i++)
{
  Console.WriteLine($"{i + 1}) \"{SortedList[i].Key}\" occurs {SortedList[i].Value} times.");
}