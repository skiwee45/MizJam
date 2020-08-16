using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration
    public float totalSeconds = 0;

    // timer execution
    float elapsedSeconds = 0;
    bool running = false;

    // support for Finished property
    bool started = false;

    #endregion

    #region Properties

    /// Sets the duration of the timer
    /// The duration can only be set if the timer isn't currently running
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    /// Gets whether or not the timer has finished running
    /// This property returns false if the timer has never been started
    public bool Finished
    {
        get { return started && !running; } 
    }

    /// Gets whether or not the timer is currently running
    public bool Running
    {
        get { return running; }
    }

    /// Gets how many seconds are left on the timer
    public float SecondsLeft
    {
        get 
        {
            if (running)
            {
                return totalSeconds - elapsedSeconds; 
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion

    #region Methods
    void Update()
    {   
        // update timer and check for finished
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    /// Runs the timer
    /// Because a timer of 0 duration doesn't really make sense,
    /// the timer only runs if the total seconds is larger than 0
    /// This also makes sure the consumer of the class has actually 
    /// set the duration to something higher than 0
    public void Run()
    {   
        // only run with valid duration
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0;
        }
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void Stop()
    {
        started = false;
        running = false;
    }

    /// <summary>
    /// Adds the given number of seconds to the timer
    /// </summary>
    /// <param name="seconds">time to add</param>
    public void AddTime(float seconds)
    {
        totalSeconds += seconds;
    }

    #endregion
}
