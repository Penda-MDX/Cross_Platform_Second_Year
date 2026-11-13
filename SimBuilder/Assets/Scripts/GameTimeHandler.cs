using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameTimeHandler : MonoBehaviour
{
    public static GameTimeHandler Instance { get; private set; }
    [SerializeField] private float slowTime;
    [SerializeField] private float medTime;
    [SerializeField] private float fastTime;
    [SerializeField] private string speedMode;
    public event EventHandler OnTick;
    
    private float tick;
    private float tickTarget;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one GameTimeHandler! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
        tick = 0;
        speedMode = "slow";
    }


    // Update is called once per frame
    void Update()
    {
        TimeMoves();
    }

    private void TimeMoves()
    {
        if (speedMode == "paused")
        {
            return;
        }

        tick += Time.deltaTime;
        if (tick >= tickTarget)
        {
            OnTick?.Invoke(this, EventArgs.Empty);
        }

    }

    public void ChangeTimeMode(string newMode)
    {
        speedMode = newMode;
        switch (speedMode)
        {
            case "paused":
                // pause housekeeping?
                break;
            case "slow":
                tickTarget = slowTime;
                break;
            case "medium":
                tickTarget = medTime;
                break;
            case "fast":
                tickTarget = fastTime;
                break;
            default:
                break;
        }


    }

    public float GetCurrentTimeChunk()
    {
        return tickTarget;
    }
}
