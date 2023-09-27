using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomWordGenerator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private List<string> wordList;

    // Reference to the DeliveryManager script.
    public DeliveryManager deliveryManager;

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

        List<string> randomWords = new List<string>();

        for (int i = 0; i < count; i++)
        {
            string randomWord = GetRandomWord();
            randomWords.Add(randomWord);
        }

        // Display the generated building names using TextMeshPro.
        textMeshPro.text = string.Join("\n", randomWords);

        // Pass the generated random building names to the DeliveryManager.
        deliveryManager.SetBuildingNames(randomWords);
    }

    private string GetRandomWord()
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