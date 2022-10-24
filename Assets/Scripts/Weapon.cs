using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    // damage struct
    //1  2  3  4  5  6   7   8   9   10
    public int[] damagePoin = { 1, 3, 4, 5, 8, 10, 14, 14, 20, 25, 1000 };
    public float[] pushForce = { 2.0f, 2.0f, 2.0f, 2.0f, 4.0f, 2.5f, 2.0f, 2.5f, 2.0f, 3.5f, 10.0f };
    // 1      2    3     4      5     6     7     8     9     10
    // Upgrate
    public int weaponLvl = 0;
    private SpriteRenderer spriteRenderer;

    // swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void onCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;
            // Create a new damage object

            Damage dmg = new Damage
            {
                damageAmount = damagePoin[weaponLvl],
                origin = transform.position,
                pushForce = pushForce[weaponLvl],
            };
            coll.SendMessage("ReceiveDamage", dmg);


        }

    }

    protected void Swing()
    {
        anim.SetTrigger("Swing");
    }

    public void UpgradeWeapon()
    {
        weaponLvl++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLvl];

        // Change stats
    }

    public void SetWeaponLevel(int level)
    {
        weaponLvl = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLvl];

    }
}