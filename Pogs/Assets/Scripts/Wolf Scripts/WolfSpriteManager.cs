using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterControllerIso))]
public class WolfSpriteManager : MonoBehaviour
{

    private string[] directions = new string[]
    {
        "N",  //N
        "N", //NE, it calls the NW animation but the sprite is flipped
        "S", //E
        "S", //SE
        "S", //S
        "S", //SW
        "S", //W
        "N", //NW
    };

    private string[] states = new string[]
    {
        "Walk",
        "Walk",
        "Attack",
        "Hit",
    };

    private tk2dSpriteAnimator _animator;
    private tk2dSprite _sprite;
    private Vector3 _spriteDefaultScale;
    private WolfController _wolfController;

    private int _currentDirection;
    private int _currentState;
    // private string _currentAnimation;

    public bool IsWalking { get; set; }
    public bool IsAttacking { get; set; }

    // Use this for initialization
    void Start()
    {
        _animator = this.GetComponentInChildren<tk2dSpriteAnimator>();
        _sprite = this.GetComponentInChildren<tk2dSprite>();
        _wolfController = this.GetComponent<WolfController>();
        _spriteDefaultScale = _sprite.scale;


    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentDirection();
        FlipSpriteWhenFacingEast();


        if (IsAttacking)
            _currentState = 2;
        else if (IsWalking)
            _currentState = 1;
        else
            _currentState = 0;



        if (IsAttacking && _wolfController.CanMove)
        {
            _wolfController.CanMove = false;
            _animator.Play(states[_currentState] + " - " + directions[_currentDirection]);
            StartCoroutine(WaitForAnimationToComplete());

        }
        else if (_wolfController.CanMove)
            _animator.Play(states[_currentState] + " - " + directions[_currentDirection]);





        // _currentAnimation = directions[_currentDirection] + " - " + states[_currentState];





    }

    void GetCurrentDirection()
    {
        var camPos = new Vector2(Camera.main.transform.forward.x, Camera.main.transform.forward.z);
        var parent = new Vector2(transform.forward.x, transform.forward.z);
        float enemyAngle = Vector2.Angle(camPos, parent);
        Vector3 cross = Vector3.Cross(camPos, parent);

        if (cross.z > 0)
            enemyAngle = 360 - enemyAngle;

        float arrayIndexFloat = Mathf.Round(enemyAngle / 360f * 8.0f) % 8.0f;

        _currentDirection = Mathf.FloorToInt(arrayIndexFloat);


    }

    void FlipSpriteWhenFacingEast()
    {
        if (_currentDirection == 1 || _currentDirection == 2 || _currentDirection == 3)
            _sprite.scale = new Vector3(_spriteDefaultScale.x * -1, _spriteDefaultScale.y, _spriteDefaultScale.z);
        else
            _sprite.scale = _spriteDefaultScale;
    }


    IEnumerator Wait(System.Action operation, float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        operation();
    }

    IEnumerator WaitForAnimationToComplete()
    {
        while (_animator.Playing)
        {
            yield return null; // wait for next frame. will check until animator has stopped playing.
        }
        //do stuff after animation is done.
        IsAttacking = false;
        _wolfController.CanMove = true;

    }

    public IEnumerator FreezeFrame(float hitPower)
    {
        _animator.Pause();
        yield return new WaitForSeconds(hitPower);
        _animator.Resume();
    }

    public IEnumerator FlashRed(float seconds)
    {
        _sprite.color = Color.red;
        yield return new WaitForSeconds(seconds);
        _sprite.color = Color.black;

        //need to get wolf black again.
    }
}
