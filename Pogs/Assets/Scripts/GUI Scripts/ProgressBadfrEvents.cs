using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBadfrEvents : MonoBehaviour 
{

	private dfProgressBar _progressBar;

    public DefenderPlayer defender;

    public dfLabel _hpLabel;

    void OnEnable()
    {
        DefenderPlayer.GotHit += UpdateValue;
        DefenderPlayer.DefenderReady += Initialize;
    }

    void OnDisable()
    {
        DefenderPlayer.GotHit -= UpdateValue;
        DefenderPlayer.DefenderReady -= Initialize;
    }

    void Initialize()
    {
        
    }

	// Called by Unity just before any of the Update methods is called the first time.
	void Start()
	{
        this._progressBar = GetComponent<dfProgressBar>();

        this._progressBar.MaxValue = defender.health;
        this._progressBar.Value = defender.health;
        UpdateLabel();

		// Obtain a reference to the dfProgressBar instance attached to this object
		
	}

    public void UpdateValue()
    {
        this._progressBar.Value = defender.health;
        UpdateLabel();
    }

    void UpdateLabel()
    {
        var value = (int)_progressBar.Value;
        _hpLabel.Text = value.ToString() + "/" + _progressBar.MaxValue.ToString();
    }

}
