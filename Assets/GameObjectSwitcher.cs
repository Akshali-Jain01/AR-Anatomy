using UnityEngine;

public class GameObjectSwitcher : MonoBehaviour
{
    public GameObject[] objects; // Array to hold game objects
    private int currentIndex = 0; // Tracks the current active object

    void Start()
    {
        // Ensure only the first object is active initially
        ActivateObjectAtIndex(0);
    }

    // Method to activate the next object in the array
    public void ActivateNextObject()
    {
        if (objects.Length == 0)
        {
            Debug.LogWarning("No objects in the array to switch.");
            return;
        }

        // Deactivate the current object
        if (objects[currentIndex] != null)
        {
            objects[currentIndex].SetActive(false);
        }

        // Increment the index and wrap around if out of range
        currentIndex = (currentIndex + 1) % objects.Length;

        // Activate the new current object
        ActivateObjectAtIndex(currentIndex);
    }

    // Helper method to activate an object at a specific index
    private void ActivateObjectAtIndex(int index)
    {
        if (objects[index] != null)
        {
            objects[index].SetActive(true);
            Debug.Log($"Activated object: {objects[index].name}");
        }
        else
        {
            Debug.LogWarning($"Object at index {index} is null.");
        }
    }
}
