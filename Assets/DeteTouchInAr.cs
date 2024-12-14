using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeteTouchInAr : MonoBehaviour
{
    private Camera arCamera; // Reference to the AR camera
    public TextMeshProUGUI objectNameText;
    void Start()
    {
        // Get the main camera (assume it's the AR camera)
        arCamera = Camera.main;

        if (arCamera == null)
        {
            Debug.LogError("AR Camera not found. Please assign a camera to this script.");
        }
    }

    void Update()
    {
        // Check if the screen is touched
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is 'Began'
            if (touch.phase == TouchPhase.Began)
            {
                // Perform a raycast from the touch position
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // Log the name of the object touched
                    objectNameText.text = "Touched object: {hit.transform.name}";
                    Debug.Log($"Touched object: {hit.transform.name}");
                }
                else
                {
                    Debug.Log("No object detected at touch position.");
                    objectNameText.text = "Touched object: Not any";
                }
            }
        }
    }
}

