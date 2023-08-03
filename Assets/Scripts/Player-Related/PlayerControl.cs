using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    private Quaternion player_rotation;
    private CharacterController cc;
    [SerializeField] GameObject Child;
    private Animator animator;
    private Vector3 raw_move;
    AnimatorClipInfo[] current_animation;
   [SerializeField] private float speed = 5f;
    void Start()
    {
        animator = Child.GetComponent<Animator>();   
        cc = GetComponent<CharacterController>();   

    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        bool raw_magnitude = false;
        raw_magnitude = CheckMagnitude(raw_move.magnitude);
        if (raw_magnitude)
        {

            Vector3 movement = VectorMove();
            cc.Move(movement);

            player_rotation = Quaternion.LookRotation(movement);
            Child.transform.rotation = player_rotation;        
            
        }
        animator.SetBool("Walk", raw_magnitude);
       
    }

    private bool CheckMagnitude(float magnitude)
    {
        if (magnitude > 0) { return true; }
        else { return false; }
    }

    private Vector3 VectorMove()
    {
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        Vector3 movement = forward * raw_move.z * speed + right * raw_move.x * speed;
        return movement ;
    }
    public void OnMove(InputAction.CallbackContext value)
    {
        raw_move.x = value.ReadValue<Vector2>().x;
        raw_move.z = value.ReadValue<Vector2>().y;
    }
    public void OnAttack(InputAction.CallbackContext value)
    {
        animator.SetBool("Attack", true);
        current_animation = animator.GetCurrentAnimatorClipInfo(0);
        StartCoroutine(AnimationQueue(1,"Attack"));
       
    }
    private IEnumerator AnimationQueue(float duration, string boolName)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool(boolName, false);
    }
}
