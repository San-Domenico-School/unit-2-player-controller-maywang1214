using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryTextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float displayDuration = 1.0f; // Adjust the duration (in seconds) for how long the text will stay on screen.
    private bool isDisplaying = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delivery Areas")) 
        {
            if (!isDisplaying)
            {
                textMeshPro.text = "You have successfully delivered a package!";
                isDisplaying = true;
                Invoke("HideText", displayDuration);
            }
        }
    }

    private void HideText()
    {
        textMeshPro.text = "";
        isDisplaying = false;
    }
}
