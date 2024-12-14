/*using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    private Camera arCamera;
    private bool isDragging = false;
    private Vector3 originalPosition;
    public float dragSpeedMultiplier = 0.5f; // Factor to slow down dragging
    public string ShadowTag; // Tag to identify colliders to snap to
    private Collider lastShadowCollider = null; // To store the last collided object with the ShadowTag

    void OnEnable()
    {
        arCamera = Camera.main;
        originalPosition = transform.position; // Save original position when the object is enabled
    }

    void Update()
    {
        if (Input.touchCount == 1) // Single-finger drag
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 targetPosition = hit.point;
                    // Slow down the drag movement
                    Vector3 movementDelta = (targetPosition - transform.position) * dragSpeedMultiplier;
                    targetPosition = transform.position + movementDelta;

                    // Lock Z position
                    targetPosition.z = originalPosition.z;
                    transform.position = targetPosition;
                }

                // Snap to ShadowTag collider if one is nearby
                if (lastShadowCollider != null)
                {
                    transform.position = lastShadowCollider.transform.position;
                    Debug.Log($"Snapping to {lastShadowCollider.gameObject.name} while dragging.");
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;

                // Final snap to the last ShadowTag collider's position if one was collided with
                if (lastShadowCollider != null)
                {
                    transform.position = lastShadowCollider.transform.position;
                    Debug.Log($"Snapped to {lastShadowCollider.gameObject.name}.");

                    // Deactivate the shadow object
                    lastShadowCollider.gameObject.SetActive(false);
                    Debug.Log($"{lastShadowCollider.gameObject.name} has been deactivated.");

                    lastShadowCollider = null; // Reset after snapping
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with something with the ShadowTag
        if (other.CompareTag(ShadowTag))
        {
            lastShadowCollider = other; // Store the collider to snap to
            Debug.Log($"Collided with {other.gameObject.name} having ShadowTag.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Clear the last shadow collider if the object exits its trigger zone
        if (other.CompareTag(ShadowTag) && lastShadowCollider == other)
        {
            lastShadowCollider = null;
            Debug.Log($"Exited collision with {other.gameObject.name}.");
        }
    }
}
*/
using UnityEngine;

public class DragAndMove : MonoBehaviour
{
    private Camera arCamera;
    private bool isDragging = false;
    private Vector3 originalPosition;
    public float dragSpeedMultiplier = 0.5f; // Factor to slow down dragging
    public string ShadowTag; // Tag to identify colliders to snap to
    private Collider lastShadowCollider = null; // To store the last collided object with the ShadowTag

    void OnEnable()
    {
        arCamera = Camera.main;
        originalPosition = transform.position; // Save original position when the object is enabled
    }

    void Update()
    {
        if (Input.touchCount == 1) // Single-finger drag
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
                {
                    isDragging = true;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Vector3 targetPosition = hit.point;

                    // Slow down the drag movement
                    Vector3 movementDelta = (targetPosition - transform.position) * dragSpeedMultiplier;
                    targetPosition = transform.position + movementDelta;

                    // Lock Z position to original Z position
                    targetPosition.z = originalPosition.z;
                    transform.position = targetPosition;
                }

                // Snap to ShadowTag collider if one is nearby
                if (lastShadowCollider != null)
                {
                    transform.position = new Vector3(lastShadowCollider.transform.position.x, lastShadowCollider.transform.position.y, originalPosition.z);
                    Debug.Log($"Snapping to {lastShadowCollider.gameObject.name} while dragging.");
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;

                // Final snap to the last ShadowTag collider's position if one was collided with
                if (lastShadowCollider != null)
                {
                    transform.position = new Vector3(lastShadowCollider.transform.position.x, lastShadowCollider.transform.position.y, originalPosition.z);
                    Debug.Log($"Snapped to {lastShadowCollider.gameObject.name}.");

                    // Deactivate the shadow object
                    lastShadowCollider.gameObject.SetActive(false);
                    Debug.Log($"{lastShadowCollider.gameObject.name} has been deactivated.");

                    lastShadowCollider = null; // Reset after snapping
                }
                else
                {
                    // Ensure Z position remains unchanged
                    Vector3 resetPosition = transform.position;
                    resetPosition.z = originalPosition.z;
                    transform.position = resetPosition;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collides with something with the ShadowTag
        if (other.CompareTag(ShadowTag))
        {
            lastShadowCollider = other; // Store the collider to snap to
            Debug.Log($"Collided with {other.gameObject.name} having ShadowTag.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Clear the last shadow collider if the object exits its trigger zone
        if (other.CompareTag(ShadowTag) && lastShadowCollider == other)
        {
            lastShadowCollider = null;
            Debug.Log($"Exited collision with {other.gameObject.name}.");
        }
    }
}
