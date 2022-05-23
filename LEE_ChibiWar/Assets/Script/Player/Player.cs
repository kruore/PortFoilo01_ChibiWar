/// Code Maded From 2022-05-23////
/// MADE BY Lee Sang Jun /////////
//////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Scipts
public class Player : MonoBehaviour
{

    #region Player Input

    public GameObject playCharacter;
    public Transform playerTransform;
    public Vector3 playerPos;
    public Vector3 playerRot;
    public Vector3 mousePos;
    public float rotAngle;
    
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
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetKey();
        GetRotate();
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
    }
    /// <summary>
    /// Player Rotate Changed
    /// </summary>
    private void GetRotate()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if (GroupPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

           transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));
        }
    }
    /// <summary>
    /// Player Transform Changed
    /// </summary>
    private void GetKey()
    {
        //조작 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 transformDirction = transform.TransformDirection(inputDirection);
        Vector3 flatMovement = speed * Time.deltaTime * transformDirction;

        transform.position = transform.position += flatMovement;

        // 조작 2
        if (Input.GetKey(KeyCode.W))
        {
            playerTransform.position += Vector3.forward * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerTransform.position += Vector3.left * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            playerTransform.position += Vector3.back * Time.deltaTime * speed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            playerTransform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
    #endregion
}
