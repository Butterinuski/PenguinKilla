using UnityEngine;
using UnityEngine.UI; // Include UI namespace to manipulate the Text component

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 60f;  // The time limit for the level in seconds (e.g., 60 seconds)
    public Text timerText;         // The Text component that will display the timer
    public bool isTimeUp = false;  // Flag to track if time has run out

    private float currentTime;     // The current time remaining

    void Start()
    {
        // Set the current time to the time limit at the start of the level
        currentTime = timeLimit;
    }

    void Update()
    {
        if (isTimeUp)
            return;  // Don't update the timer if time is up

        // Decrease the time by the amount of time that has passed since the last frame
        currentTime -= Time.deltaTime;

        // If time runs out, stop the timer and trigger an event
        if (currentTime <= 0f)
        {
            currentTime = 0f;  
            isTimeUp = true;
            OnTimeUp();
        }

        
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        // Format the time as minutes and seconds (e.g., "02:30")
        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = Mathf.Floor(currentTime % 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    // This function is called when the time runs out
    void OnTimeUp()
    {
        Debug.Log("Time's up!");
    }

    // Reset the timer 
    public void ResetTimer()
    {
        currentTime = timeLimit;
        isTimeUp = false;
    }

    
}


