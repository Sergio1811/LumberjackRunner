using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20f;
    public CharacterController controller;
    public Animator anim;

    private bool isChangingLane = false;
    private Vector3 locationAfterChangingLane;

    private Vector3 movementDistance = Vector3.right*1.5f;

    public float changeSpeed = 5.0f;

    public float JumpSpeed = 8.0f;
    public float Speed = 6.0f;

    public Transform CharacterGO;

    UIManager UI;

    Axe m_Axe;

    
    IInputDetector inputDetector = null;

    enum Location
    {
        Left, Center, Right
    }

    Location currentLocation = Location.Center;

    private void Start()
    {
        moveDirection = transform.forward;
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= Speed;

        UI =GameManager.Instance.UI;
        UI.ResetScore();
        UI.SetStatus(Blackboard.StatusTapToStart);

        GameManager.Instance.GameState = GameState.Start;


        anim = CharacterGO.GetComponent<Animator>();
        inputDetector = GetComponent<IInputDetector>();
        controller = GetComponent<CharacterController>();
        m_Axe = GameObject.FindGameObjectWithTag("Axe").GetComponent<Axe>();
    }

    private void Update()
    {
        switch (GameManager.Instance.GameState)
        {
            case GameState.Start:
                if (Input.GetMouseButtonUp(0))
                {
                    anim.SetBool(Blackboard.AnimationStarted, true);
                    var instance = GameManager.Instance;
                    instance.GameState = GameState.Playing;

                    UI.SetStatus(string.Empty);
                }
                break;
            case GameState.Playing:
                UI.IncreaseScore(0.001f);
           
                CheckHeight();

                DetectJumpOrSwuipeLeftRight();

                moveDirection.y -= gravity * Time.deltaTime;

                if (isChangingLane)
                {
                    if (Mathf.Abs((transform.position.x - locationAfterChangingLane.x)) <0.1f)
                    {
                        isChangingLane = false;
                        moveDirection.x = 0;
                    }
                }

                if(Input.GetMouseButtonUp(0))
                {
                    anim.SetTrigger(Blackboard.AnimationAttack);
                    m_Axe.inAttack = true;
                    m_Axe.animTimer = 1.2f;
                    print("Attack");
                }

              

                controller.Move(moveDirection * Time.deltaTime);

                break;

            case GameState.Dead:
                anim.SetBool(Blackboard.AnimationStarted, false);

                if (Input.GetMouseButtonUp(0))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            default:
                break;
        }
    }
    private void CheckHeight()
    {
        if (transform.position.y < -10)
        {
            GameManager.Instance.Die();
        }
    }

    private void DetectJumpOrSwuipeLeftRight()
    {
        var inputDirection = inputDetector.DetectInputDirection();

        if (controller.isGrounded && inputDirection.HasValue && inputDirection== InputDirection.Top && !isChangingLane)
        {
            moveDirection.y = JumpSpeed;
            anim.SetTrigger(Blackboard.AnimationJump);
        }

        if (controller.isGrounded && inputDirection.HasValue && !isChangingLane)
        {
            isChangingLane = true;

            if (inputDirection == InputDirection.Left && currentLocation != Location.Left)
            {
                locationAfterChangingLane = transform.position - movementDistance;
                moveDirection.x = -changeSpeed;
                print(locationAfterChangingLane);  
                if (currentLocation == Location.Center)
                    currentLocation = Location.Left;
                else currentLocation = Location.Center;
            }
            else if (inputDirection == InputDirection.Right && currentLocation != Location.Right)
            {
                locationAfterChangingLane = transform.position + movementDistance;
                moveDirection.x = changeSpeed;
                if (currentLocation == Location.Center)
                    currentLocation = Location.Right;
                else currentLocation = Location.Center;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(Blackboard.WidePathBorderTag))
        {
            isChangingLane = false;
            moveDirection.x = 0;
        }
    }
}
