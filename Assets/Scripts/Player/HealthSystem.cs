using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHp = 3;
    [SerializeField] private int hp = 3;

    [SerializeField] private UnityEvent OnDamaged;
    [SerializeField] private UnityEvent OnZero;
    [SerializeField] private UnityEvent XDeathState; //Gibs
    public AudioSource hurtSound;
    public AudioSource dieSound;
    private Animator _animator;
    private AnimatorClipInfo[] _animatorinfo;
    private string current_animation;
   
    
    
    public void Damage(int hpAmount)
    {
        hp -= hpAmount;
        hurtSound.Play();
        Debug.Log("hp amount changed by " + hpAmount + " and is now " + hp);
        
        OnDamaged?.Invoke();

        if (hp <= -maxHp) //gibs?
        {
            XDeathState?.Invoke();
        }
        else if (hp <= 0)
        {
            OnZero?.Invoke();
            dieSound.Play();
            PlayerDied();

           
        }
    }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
