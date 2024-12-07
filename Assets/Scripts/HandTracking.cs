using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;       // Reference to the UDPReceive script
    public GameObject[] handPoints;     // Array of GameObjects that represent hand points
    public UnityEngine.UI.Text gestureText;  // Reference to a UI Text component for gesture display

    void Start()
    {
        // Initialize if needed
    }

    void Update()
    {
        // Access the received data (the string from UDPReceive)
        string data = udpReceive.data;

        if (string.IsNullOrEmpty(data))
            return;

        // Clean up the data (remove the first and last characters, which are '[' and ']')
        data = data.Trim('[', ']');

        // Split the data into an array by commas
        string[] points = data.Split(',');

        // Check if we have the right amount of data
        if (points.Length < 63) return;  // Ensure we have at least 63 landmarks (21 points with 3 coordinates)

        // Update hand points' positions based on the data (assuming data consists of x, y, z coordinates for each landmark)
        for (int i = 0; i < 21; i++) // 21 landmarks in total
        {
            // Parse the x, y, z coordinates for each landmark
            float x = 7 - float.Parse(points[i * 3]) / 100f;   // X position (adjust scaling as needed)
            float y = float.Parse(points[i * 3 + 1]) / 100f;   // Y position
            float z = float.Parse(points[i * 3 + 2]) / 100f;   // Z position

            // Update the position of each hand point
            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }

        // The last element in the array is the gesture
        string gesture = points[63];

        // Display the gesture in the UI Text component
        if (gestureText != null)
        {
            gestureText.text = $"Current Gesture: {gesture}";
        }
    }
}
