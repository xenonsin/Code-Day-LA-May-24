using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage = 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        rigidbody.AddForce(-transform.forward * 400f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            var objectThatWasHit = col.transform.GetComponent<Unit>();
            objectThatWasHit.Hit(damage);
            this.Recycle();
        }
    }
}
