using System;
using System.Collections;
using System.Collections.Generic;
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
    public AudioSource dieSound;
    public AudioSource shootSound;
    
    private AnimatorClipInfo[] _animatorinfo;
    private string current_animation;


    // Start is called before the first frame update
    
    void Awake() {
    inventory = new Inventory();
            uiInventory.SetInventory(inventory);
    
    }
    
    
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
        dieSound.Play();
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_inputActions.Player.Fire.WasPerformedThisFrame())
        {
            shootSound.Play();
            var ball = Instantiate(BulletPrefab, 
                transform.position,
                Quaternion.identity);
            //Get the Rigidbody 2D component from the new ball 
            //and set its velocity to x:-10f, y:0, z:0
            ball.GetComponent<Shooting>()?.SetDirection(_facingVector);
           

        }
        
        _animatorinfo = this._animator.GetCurrentAnimatorClipInfo(0);
        current_animation = _animatorinfo[0].clip.name;

        
    }

    private void FixedUpdate()
    {
        if (current_animation != "Player Intro")
        {
            var dir = _inputActions.Player.Move.ReadValue<Vector2>();
            _rigidbody.velocity = dir * 6;
        }
        
        _animator.SetFloat("Velocity",_rigidbody.velocity.magnitude);
    }
}   