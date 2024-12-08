using UnityEngine;
using System.Collections;

public class HandAnimationController : MonoBehaviour
{
    private Animator animator;
    private string currentGesture = "Paper";
    private bool isTransitioning = false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Only allow input if not currently transitioning
        if (!isTransitioning)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SetGesture("Rock");
            }
            else if (Input.GetKeyDown(KeyCode.P)) 
            {
                SetGesture("Paper");
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SetGesture("Scissor"); 
            }
        }
    }

    public void SetGesture(string gesture)
    {
        if (gesture != currentGesture)
        {
            StartCoroutine(PlayGestureAnimation(gesture));
        }
    }

    private IEnumerator PlayGestureAnimation(string gesture)
    {
        isTransitioning = true;
        
        // Reset previous triggers
        animator.ResetTrigger("Rock");
        animator.ResetTrigger("Paper");
        animator.ResetTrigger("Scissors");
        
        // Set new trigger
        animator.SetTrigger(gesture);
        currentGesture = gesture;
        
        // Wait for transition
        yield return new WaitForSeconds(0.25f);
        isTransitioning = false;
    }
}