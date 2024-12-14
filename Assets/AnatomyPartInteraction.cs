using UnityEngine;

public class AnatomyPartInteraction : MonoBehaviour
{
    private Outline outlineComponent;

    void Start()
    {
        // Get the Outline component attached to the GameObject
        outlineComponent = GetComponent<Outline>();
        if (outlineComponent == null)
        {
            Debug.LogError("No Outline component found on " + gameObject.name);
        }
        else
        {
            // Disable the outline initially
            outlineComponent.enabled = false;
        }
    }

    void OnMouseDown()
    {
        EnableOutline();
    }

    void OnMouseUp()
    {
        DisableOutline();
    }

    void EnableOutline()
    {
        if (outlineComponent != null)
        {
            outlineComponent.enabled = true;
        }
    }

    void DisableOutline()
    {
        if (outlineComponent != null)
        {
            outlineComponent.enabled = false;
        }
    }
}
