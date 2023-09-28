using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomWordGenerator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public List<string> wordList;
    public List<string> randomWords;

    // Reference to the DeliveryManager script.
    //public DeliveryTextController deliveryTextController; // Reference to the DeliveryTextController.

    private void Start()
    { 
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
        };

        // Generate and display random words.
        GenerateRandomWords(5);
    }

    public void GenerateRandomWords(int count)
    {
        if (count <= 0)
        {
            Debug.LogWarning("Invalid count. Please specify a positive number.");
            return;
        }

        randomWords = new List<string>();
        string screenText = "";

        for (int i = 0; i < count; i++)
        {
            string randomWord = GetRandomWord();
            randomWords.Add(randomWord);
            screenText += randomWord + "\n";
        }

        // Display the generated building names using TextMeshPro.
        textMeshPro.text = screenText;

        /* Pass the generated tag (building name) to the DeliveryTextController.
        if (deliveryTextController != null)
        {
            deliveryTextController.SetGeneratedTag(randomWords[0]); // Assuming you want the first word/tag.
        } */
    }

    public string GetRandomWord()
    {
        if (wordList.Count > 0)
        {
            int randomIndex = Random.Range(0, wordList.Count);
            string randomWord = wordList[randomIndex];
            wordList.RemoveAt(randomIndex);
            return randomWord;
        }
        else
        {
            Debug.LogWarning("Word list is empty. Add more words to the list.");
            return "";
        }
    }
}