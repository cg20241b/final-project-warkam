using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour 
{
    public UDPReceive udpReceive;
    public GameObject[] handPoints;  // Keep this for visualization/debugging
    public UnityEngine.UI.Text gestureText;
    
    [SerializeField]
    private GameObject riggedHandModel; // Reference to your rigged hand model prefab
    private Transform[] handJoints;     // Array to store joint transforms
    private Material handMaterial; // Add this variable to store the material

    void Start()
    {
        // Load textures
        Texture2D colorMap = Resources.Load<Texture2D>("rigged-hand/textures/HAND_C");
        Texture2D normalMap = Resources.Load<Texture2D>("rigged-hand/textures/HAND_N");
        Texture2D specMap = Resources.Load<Texture2D>("rigged-hand/textures/HAND_S");

        // Apply textures to material
        if (handMaterial != null)
        {
            handMaterial.SetTexture("_MainTex", colorMap);
            handMaterial.SetTexture("_BumpMap", normalMap);
            handMaterial.SetTexture("_SpecGlossMap", specMap);
        }

        // Initialize rigged hand if assigned
        if (riggedHandModel != null)
        {
            handJoints = riggedHandModel.GetComponentsInChildren<Transform>();
            
            // Apply material to mesh renderer
            MeshRenderer[] renderers = riggedHandModel.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer renderer in renderers)
            {
                renderer.material = handMaterial;
            }
        }
    }

    void Update()
    {
        string data = udpReceive.data;
        if (string.IsNullOrEmpty(data)) return;

        data = data.Trim('[', ']');
        string[] points = data.Split(',');

        if (points.Length < 63) return;

        // Update both visualization points and rigged hand joints
        for (int i = 0; i < 21 && i < handPoints.Length; i++)
        {
            float x = 7 - float.Parse(points[i * 3]) / 100f;
            float y = float.Parse(points[i * 3 + 1]) / 100f;
            float z = float.Parse(points[i * 3 + 2]) / 100f;

            // Update visualization points
            if (handPoints[i] != null)
            {
                handPoints[i].transform.localPosition = new Vector3(x, y, z);
            }

            // Update rigged hand joints
            if (handJoints != null && i < handJoints.Length)
            {
                handJoints[i].localPosition = new Vector3(x, y, z);
            }
        }

        // Update gesture text
        if (gestureText != null && points.Length > 63)
        {
            gestureText.text = $"Current Gesture: {points[63]}";
        }
    }
}