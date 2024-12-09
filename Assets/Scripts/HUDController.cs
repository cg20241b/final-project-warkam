using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerGestureText;
    [SerializeField] private UDPReceive udpReceive;

    void Update()
    {
        if (udpReceive != null && playerGestureText != null && udpReceive.currentGesture != "")
        {
            playerGestureText.text = $"{udpReceive.currentGesture.Substring(1, udpReceive.currentGesture.Length - 2)}";
        }
    }
}