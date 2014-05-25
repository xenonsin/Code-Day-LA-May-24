using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Seeker))]
public class WolfFollow : AIPath
{
    
    public float wolfSpeed = 5f;

    public bool canFollow;
    /** Minimum velocity for moving */
    public float sleepVelocity = 0.4F;
    /** Effect which will be instantiated when end of path is reached.
     * \see OnTargetReached */
    public GameObject endOfPathEffect;

   // private Transform _player;
   // private Transform _grandma;

    public void Awake()
    {
        base.Awake();
    }

    public new void Start()
    {
        
        //Call Start in base script (AIPath)
        base.Start();
    }

    /** Point for the last spawn of #endOfPathEffect */
    protected Vector3 lastTarget;

    /**
     * Called when the end of path has been reached.
     * An effect (#endOfPathEffect) is spawned when this function is called
     * However, since paths are recalculated quite often, we only spawn the effect
     * when the current position is some distance away from the previous spawn-point
    */
    public override void OnTargetReached()
    {
        if (Vector3.Distance(tr.position, lastTarget) > 1)
        {
            lastTarget = tr.position;
        }
    }

    public override Vector3 GetFeetPosition()
    {
        return tr.position;
    }

    protected new void Update()
    {
        //Calculate desired velocity
        Vector3 dir = CalculateVelocity(GetFeetPosition());    

        //Get velocity in world-space
        if (canMove)
        {
            //Rotate towards targetDirection (filled in by CalculateVelocity)
            RotateTowards(targetDirection);

           // dir.y = 0;

            rigidbody.MovePosition(rigidbody.position + dir.normalized * wolfSpeed * Time.deltaTime);
        }
    }
    
}