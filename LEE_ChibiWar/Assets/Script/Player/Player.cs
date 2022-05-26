/// Code Maded From 2022-05-23////
/// MADE BY Lee Sang Jun /////////
//////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Player Scipts
public class Player : MonoBehaviour
{
    #region UnityComponent
    Camera camera;
    Animator _animator;
    #endregion

    #region Player Input

    public GameObject playCharacter;
    public Transform playerTransform;
    public Vector3 playerPos;
    public Vector3 playerRot;
    public Vector3 mousePos;
    public float rotAngle;


    //Move Var
    public Vector3 destination;
    public bool isMove;

    //Hit State
    bool isHit;
    public bool Hited
    {
        get { return isHit; }
        set
        {
            if (isHit==value)
            {
                _animator.Play("Hit");
            }
        }
    }
    
    // State
    [SerializeField] protected int hp { get; set; }
    [SerializeField] protected float speed { get; set; }
    [SerializeField] protected float slideGage { get; set; }
    [SerializeField] protected float slideSpeed { get; set; }
    [SerializeField] protected int reGenHp { get; set; }

    //

    #endregion

    #region Unity Life Cycle
    // Started
    private void Awake()
    {
        playerTransform = playCharacter.GetComponent<Transform>();
        PlayerInit();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetKey();   
    }
    #endregion


    #region Player Setting
    /// <summary>
    /// Player Start Init
    /// </summary>
    private void PlayerInit()
    {
        hp = 100;
        speed = 2;
        slideGage = 0;
        slideSpeed = 0;
        reGenHp = 0;
        camera = Camera.main;
    }
    /// <summary>
    /// Player Rotate Changed
    /// </summary>
    private void GetKey()
    {
      
        if(Input.GetMouseButton(0))
        {
           OnMouseClick_LookAt(Define.MouseEvent.RightPress);
            OnMouseClick_ToMove(Define.MouseEvent.RightPress);
        }
        if(Input.GetMouseButton(1))
        {
        }

        if(isMove)
        {
            Move();
        }
        else
        {
            Idle();
        }

    }

    void OnMouseClick_LookAt(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.RightPress)
            return;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }

    void OnMouseClick_ToMove(Define.MouseEvent evt)
    {
        if (evt != Define.MouseEvent.RightPress)
            return;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            CharacterMove(cameraRay.GetPoint(rayLength));
        }
    }
    void CharacterMove(Vector3 dest)
    {
        destination = dest;
        isMove = true;
    }
    private void Move()
    {
        if (isMove)
        {
            if (Vector3.Distance(destination, transform.position) <= 0.1f)
            {
                isMove = false;
                return;
            }
            var dir = destination - transform.position;
            transform.position += dir.normalized * Time.deltaTime * 5f;
        }
    }

    private void Idle()
    {
        if(!isMove)
        {
            _animator.Play("IDLE_A");
            return;
        }
    }
 
    #endregion
}
