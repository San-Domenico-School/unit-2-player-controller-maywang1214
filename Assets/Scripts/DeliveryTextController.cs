using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryTextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public RandomWordGenerator rwg;
    public float displayDuration = 1.0f;
    private bool isDisplaying = false;
    private int count = 0;
    //private string generatedTag; // Store the generated tag (building name).

    public void SetGeneratedTag(string tag)
    {
        //generatedTag = tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tag of collision: " + other.tag);
        Debug.Log("Tag Generated: " + rwg.randomWords[count]);
        if (other.CompareTag(rwg.randomWords[count])) // Compare with the generated tag.
        {
            if (!isDisplaying)
            {
                textMeshPro.text = "You have successfully delivered a package to " + rwg.randomWords[count];
                isDisplaying = true;
                Invoke("HideText", displayDuration);
                if (count < rwg.randomWords.Count)
                {
                    count++;
                }
            }
        }
        else
        {
            if (!isDisplaying)
            {
                textMeshPro.text = "Sorry! You delivered to the wrong destination.";
                isDisplaying = true;
                Invoke("HideText", displayDuration);
            }
        }
    }

    private void HideText()
    {

    
    }

    private void OnTriggerExit(Collider other)
    {
        textMeshPro.text = "";
        isDisplaying = false;
    }
}