using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilWizardScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    FireballScript fireball;
    EvilWizardHealth health;
    public Transform wizardFireballSpawner;
    public bool attack;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fireball = fireballPrefab.GetComponent<FireballScript>();
        health = GetComponent<EvilWizardHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack == true)
        {
            anim.Play("EvilWizardAttack");
        }
    }

    public void Fireball()
    {
        Instantiate(fireballPrefab, wizardFireballSpawner.transform.position, Quaternion.identity);
    }

    public void WizardDeath()
    {
        attack = false;
        anim.Play("EvilWizardDeath");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            health.health -= 80;
            Destroy(collision.gameObject);
        }
    }
}
