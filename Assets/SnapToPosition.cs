using UnityEngine;
using System.Collections; // Needed for Coroutines

public class SnapToPosition : MonoBehaviour
{
    private Vector3 originalPosition; // Store the original position
    public GameObject objectToActivate; // Object to activate when moved
    public float movementThreshold = 0.1f; // Threshold to detect movement
    private bool isCoroutineRunning = false; // To prevent multiple coroutine calls
   // private bool hasActivatedOnce = false;
    void OnEnable()
    {
        // Save the object's initial position
        originalPosition = transform.position;

        // Ensure the other game object starts as deactivated
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No object assigned to 'objectToActivate'.");
        }
    }

    private void Update()
    {
        CheckIfMoved();
    }

    /*   void OnTriggerEnter(Collider other)
       {
           // Align the current object perfectly to the collided object's position (X, Y, Z)
           transform.position = other.transform.position;

           // Optionally align rotation if needed (optional)
           transform.rotation = other.transform.rotation;

           // Deactivate the collided object
           other.gameObject.SetActive(false);

           Debug.Log($"Snapped {gameObject.name} to {other.gameObject.name}'s position and deactivated it.");
       }
   */
    void CheckIfMoved()
    {
        // Check if the current game object has moved from its original position
        if (Vector3.Distance(transform.position, originalPosition) > movementThreshold )
        {
            // Start coroutine to activate the other object after 2 seconds if not already running
            if (objectToActivate != null && !objectToActivate.activeSelf && !isCoroutineRunning)
            {
                StartCoroutine(ActivateObjectAfterDelay());
            }
        }
    }

    private IEnumerator ActivateObjectAfterDelay()
    {
        isCoroutineRunning = true; // Set the flag to prevent multiple coroutine instances
        yield return new WaitForSeconds(1.5f); // Wait for 2 seconds

        if (objectToActivate != null && !objectToActivate.activeSelf)
        {
            objectToActivate.SetActive(true);
            //hasActivatedOnce = true; // Ensure the object is activated only once
            Debug.Log($"{objectToActivate.name} activated after 2 seconds because {gameObject.name} moved.");
        }

        isCoroutineRunning = false; // Reset the flag
    }
}
