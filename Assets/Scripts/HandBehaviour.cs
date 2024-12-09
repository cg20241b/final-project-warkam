using UnityEngine;

public class HandBehaviour : MonoBehaviour
{   
    private Animator mAnimator;
    private UDPReceive udpReceiver;
    private string currentGesture = "";

    void Start()
    {
        mAnimator = GetComponent<Animator>();
        // Find the UDPReceive component in the scene
        udpReceiver = FindObjectOfType<UDPReceive>();

        if (udpReceiver == null)
        {
            Debug.LogError("UDPReceive component not found in scene!");
        }
    }

    void Update()
    {
        if (mAnimator != null && udpReceiver != null)
        {
            // Get the current gesture from UDPReceive
            string gesture = udpReceiver.currentGesture.Trim();

            // Only update animation if gesture has changed
            if (gesture != currentGesture)
            {
                currentGesture = gesture;
                
                // Trigger appropriate animation based on gesture
                switch (gesture.ToLower())
                {
                    case "rock":
                        mAnimator.SetTrigger("TrigRock");
                        break;
                    case "paper":
                        mAnimator.SetTrigger("TrigPaper");
                        break;
                    case "scissors":
                        mAnimator.SetTrigger("TrigScissors");
                        break;
                }
            }
        }
    }
}