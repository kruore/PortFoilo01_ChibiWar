/// Code Maded From 2022-06-08////
/// MADE BY Lee Sang Jun /////////
//////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

// Player Scipts
public class CreateController : MonoBehaviour
{
    #region UnityComponent
    Camera camera;
    public Animator _animator;
    #endregion

    public enum PlayerState
    {
        IDLE, MOVE, ATTACK, HIT, DEAD
    }

    #region Player Input

    public GameObject playCharacter;
    public Transform playerTransform;
    public Vector3 playerPos;
    public Vector3 playerRot;
    public Vector3 mousePos;
    public float rotAngle;

    //Move Var
    public Vector3 destination;
    public Vector3 mousePosition;
    [SerializeField] protected PlayerState currentState;
    private PlayerState states
    {
        get { return currentState; }
        set
        {
            StateChanger(value);
        }
    }

    [SerializeField]protected bool isHit;
    [SerializeField]protected bool isMove;
    public bool Hited
    {
        get { return isHit; }
        set
        {
            if (isHit == value)
            {
                _animator.Play("Hit");
            }
        }
    }

    // State
    [SerializeField] public int hp { get; set; }
    [SerializeField] public float speed { get; set; }
    [SerializeField] public float slideGage { get; set; }
    [SerializeField] public float slideSpeed { get; set; }
    [SerializeField] public int reGenHp { get; set; }

    #endregion

    #region Player Setting
    /// <summary>
    /// Init Player controller offset
    /// </summary>
    /// 
    private void AnimationChanger(string name)
    {
        for(int i =0; i<_animator.parameterCount;i++)
        {
            _animator.SetBool(_animator.parameters[i].name,false);
        }
        _animator.SetBool(name,true);
    }
    protected PlayerState StateChanger(PlayerState state)
    {

        switch (state)
        {
            case PlayerState.IDLE:
                currentState = PlayerState.IDLE;
                AnimationChanger("isIDLE");
                break;
            case PlayerState.MOVE:
                currentState = PlayerState.MOVE;
                AnimationChanger("isMove");
                isMove = true;
                Move();
                break;
            case PlayerState.ATTACK:
                currentState = PlayerState.ATTACK;
                break;
            case PlayerState.HIT:
                currentState = PlayerState.HIT;
                break;
            case PlayerState.DEAD:
                currentState = PlayerState.DEAD;
                break;
            default:
                break;
        }
        return currentState;
    }
    protected virtual void init()
    {
        // User Transform and animator
        playerTransform = playCharacter.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        camera = Camera.main;

        //PlayerStateSetting
        hp = 100;
        speed = 2;
        slideGage = 0;
        slideSpeed = 0;
        reGenHp = 0;
    }

    protected void OnMouseClick_LookAt(Vector3 mousePos)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePos);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pointTolook), 30 * Time.deltaTime);
            transform.LookAt(pointTolook);
        //    transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }

    protected void OnMouseClick_ToMove(Vector3 mousePos)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(mousePos);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            CharacterMove(cameraRay.GetPoint(rayLength));
        }
    }
    protected void CharacterMove(Vector3 dest)
    {
        destination = dest;
        StateChanger(PlayerState.MOVE);
    }
    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                StateChanger(PlayerState.IDLE);
                return;
            }
            var dir = destination - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }

    #endregion

    #region Input System


    #endregion
}
