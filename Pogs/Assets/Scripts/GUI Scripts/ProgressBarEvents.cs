using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgressBarEvents : MonoBehaviour 
{
    /*
	private dfProgressBar _progressBar;
    private Player _player;
    private dfLabel _hpLabel;

    void OnEnable()
    {
        Player.HpChange += UpdateValue;
    }

    void OnDisable()
    {
        Player.HpChange -= UpdateValue;
    }

	// Called by Unity just before any of the Update methods is called the first time.
	public void Start()
	{
		// Obtain a reference to the dfProgressBar instance attached to this object
		this._progressBar = GetComponent<dfProgressBar>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _hpLabel = GetComponentInChildren<dfLabel>();

        this._progressBar.MaxValue = _player.MaxHealth;
        this._progressBar.Value = _player.Health;
        UpdateLabel();
        
	}

    void UpdateValue()
    {
        this._progressBar.Value = _player.Health;
        UpdateLabel();
    }

    void UpdateLabel()
    {
        var value = (int)_progressBar.Value;
        _hpLabel.Text = value.ToString() + "/" + _progressBar.MaxValue.ToString();
    }

    */
}
