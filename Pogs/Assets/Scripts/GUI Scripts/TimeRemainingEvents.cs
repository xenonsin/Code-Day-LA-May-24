using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeRemainingEvents : MonoBehaviour 
{
    public delegate void RunOut();
    public static event RunOut OfTime;

	private dfLabel _label;

    private bool ready;
    public float initialTime = 300f;
    private float time;

    void OnEnable()
    {
        NetworkManager.GameIsReady += Initialize;
    }

    void OnDisable()
    {
        NetworkManager.GameIsReady -= Initialize;
    }

    void Initialize()
    {
        ready = true;
    }

	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
        time = initialTime;
		// Obtain a reference to the dfLabel instance attached to this object
		this._label = GetComponent<dfLabel>();
	}


    public void Update()
    {
        if(ready)
        {
            time -= Time.deltaTime;
            this._label.Text = "Time Remaining: " + (int)time;
        }

        if (time <= 0)
            OfTime();
            
    }


}
