using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float StartingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private int duration;
    private SpriteRenderer spriteRend;
    
    // Start is called before the first frame update
    void Awake()
    {
        CurrentHealth = StartingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void takeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);
        
        if (CurrentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                dead = true;
            }
            
            
        }


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            takeDamage(1);
        }
    }

    public IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(0, 6, true);
        yield return new WaitForSeconds(duration);
        Physics2D.IgnoreLayerCollision(0, 6, false);
    }
}
