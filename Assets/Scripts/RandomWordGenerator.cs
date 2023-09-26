using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomWordGenerator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public List<string> wordList;

    private void Start()
    {
        // Initialize your list of words.
        wordList = new List<string>
        {
            "Red Buildings",
            "Yellow Houses",
            "Red Houses",
            "Blue Houses",
            "Coke Machines",
            "Shops",
            "Yellow Buildings",
            "Green Houses",
            "Stadiums",
            "Drug Stores",
            "Factories",
            // Add more words as needed.
        };


        // Generate and display a random word.
        GenerateRandomWords(5);
    }

    public void GenerateRandomWords(int count)
    {
        if (count <= 0)
        {
            Debug.LogWarning("Invalid count. Please specify a positive number.");
            return;
        }

        List<string> randomWords = new List<string>();

        for (int i = 0; i < count; i++)
        {
            string randomWord = GetRandomWord();
            randomWords.Add(randomWord);
        }

        // Join the random words with newline characters and update the TextMeshPro text.
        textMeshPro.text = string.Join("\n", randomWords);
    }

    private string GetRandomWord()
    {
        if (wordList.Count > 0)
        {
            int randomIndex = Random.Range(0, wordList.Count);
            string randomWord = wordList[randomIndex];
            wordList.RemoveAt(randomIndex); // Remove the word to avoid duplicates.
            return randomWord;
        }
        else
        {
            Debug.LogWarning("Word list is empty. Add more words to the list.");
            return "";
        }
    }
}