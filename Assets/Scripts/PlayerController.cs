using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject BulletPrefab;
    private GameInputActions _inputActions;
    private Rigidbody2D _rigidbody;
    [SerializeField] private float jumpHeight;
    [SerializeField] private UI_Inventory uiInventory;
    
    private Animator _animator;
    private Vector2 _facingVector = Vector2.right;
    private Inventory inventory;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _inputActions = new GameInputActions();
        _inputActions.Player.Enable();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        //transform.position = new Vector2(3, -1);
        //Invoke(nameof(AcceptDefeat), 10);
    }

    public void AcceptDefeat()
    {
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_inputActions.Player.Fire.WasPerformedThisFrame())
        {
            var ball = Instantiate(BulletPrefab, 
                transform.position,
                Quaternion.identity);
            //Get the Rigidbody 2D component from the new ball 
            //and set its velocity to x:-10f, y:0, z:0
            ball.GetComponent<Shooting>()?.SetDirection(_facingVector);
           

        }

        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void FixedUpdate()
    {

        var dir = _inputActions.Player.Move.ReadValue<Vector2>();
        _rigidbody.velocity = dir * 6;

        if (dir.magnitude > 0.5)
        {
            _facingVector = dir;
            _animator.Play("Player Run");
        }

        else

        {
            
            _animator.Play("Player Idle");
        }
    }
}   