using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public enum Turns
    {
        ATTACK,
        DEFEND
    }

    private Turns _currentTurn;

	// Use this for initialization
    IEnumerator Start()
    {
        while (true)
        {
            switch (_currentTurn)
            {
                case Turns.ATTACK:
                    Attack();
                    break;
                case Turns.DEFEND:
                    Defend();
                    break;

            }
            yield return 0;
        }
    }

    void Attack()
    {

    }

    void Defend()
    {

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
