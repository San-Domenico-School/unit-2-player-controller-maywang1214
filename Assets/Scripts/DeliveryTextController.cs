using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryTextController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float displayDuration = 1.0f; // Adjust the duration (in seconds) for how long the text will stay on screen.
    private bool isDisplaying = false;
    private DeliveryManager deliveryManager; // Reference to the DeliveryManager.

    private void Start()
    {
        // Find the DeliveryManager in the scene.
        deliveryManager = FindObjectOfType<DeliveryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delivery Areas")) 
        {
            if (!isDisplaying)
            {
                if (deliveryManager != null)
                {
                    deliveryManager.DeliverTo(textMeshPro.text);
                }
                isDisplaying = true;
                textMeshPro.text = "You have successfully delivered a package!";
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
