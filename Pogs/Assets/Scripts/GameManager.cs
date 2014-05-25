using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    void OnEnable()
    {
        DefenderPlayer.Dead += AttackerWin;
        TimeRemainingEvents.OfTime += DefenderWin;
    }
    void OnDisable()
    {
        DefenderPlayer.Dead -= AttackerWin;
        TimeRemainingEvents.OfTime -= DefenderWin;
    }

    void AttackerWin()
    {
        Application.LoadLevel("Game Over");
    }

    void DefenderWin()
    {
        Application.LoadLevel("Game Over");
    }
}
