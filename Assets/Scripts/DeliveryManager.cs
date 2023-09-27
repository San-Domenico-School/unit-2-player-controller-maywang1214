using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private List<string> buildingNames = new List<string>(); // This list contains the generated building names.
    private int currentDeliveryIndex = 0;

    public void SetBuildingNames(List<string> names)
    {
        buildingNames = names;
    }

    public void DeliverTo(string buildingName)
    {
        if (currentDeliveryIndex < buildingNames.Count && buildingName == buildingNames[currentDeliveryIndex])
        {
            // Correct delivery
            Debug.Log("You have successfully delivered a package to " + buildingName);
            currentDeliveryIndex++;
        }
        else
        {
            // Incorrect delivery
            Debug.Log("Sorry! You delivered to the wrong destination.");
        }
    }
}
