using UnityEngine;
using System.Collections;

public class TowerAttack : MonoBehaviour {

    private RangeWeapon _rangeAttack = new TowerBlast();

    private bool hasShot;
	// Use this for initialization
	void Start () {
        hasShot = false;
	}
	
	// Update is called once per frame
	void Update () {
        GetDistance();
	}

    void GetDistance()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * 10f , Color.green);
        if (Physics.Raycast(transform.position, transform.up, out hit, 10f, 1 << LayerMask.NameToLayer("Units")))
        {
            //do something if hit object ie
            if (!hasShot)
            {
                Debug.Log("hi!");
                hasShot = true;
                StartCoroutine(AttackDelay(3f));
            }
        }
    }

    IEnumerator AttackDelay(float delay)
    {
        Shoot();
        yield return new WaitForSeconds(delay);
        hasShot = false;

    }

    void Shoot()
    {
        PhotonNetwork.Instantiate("Bullet", transform.position, Quaternion.identity, 0);
    }
}
