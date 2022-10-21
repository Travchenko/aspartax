using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // public fields
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    // Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmne;

    // Push
    protected Vector3 pushDirection;

    private RaycastHit2D hitx;
    private RaycastHit2D hity;
    protected BoxCollider2D boxCollider;
    protected Rigidbody2D rigidbody;
    protected Vector3 moveDelta;

    // All fighters can ReceiveDamage / die
   /* protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmne > immuneTime)
        {
            lastImmne = Time.time;
            hitpoint -= dmg.damageAmount;

            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
            hitx = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(pushDirection.x, 0), Mathf.Abs(pushDirection.x * Time.deltaTime), LayerMask.GetMask("Blocking"));
            hity = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, pushDirection.y), Mathf.Abs(pushDirection.y * Time.deltaTime), LayerMask.GetMask("Blocking"));
            if (hity.collider != null || hitx.collider != null)
                if (hity.collider != null)
                    pushDirection = new Vector3(pushDirection.x, 0, 0);
                else
                {
                    if (hitx.collider != null)
                        pushDirection = new Vector3(0, pushDirection.y, 0);
                    else
                    {
                        pushDirection = new Vector3(0, 0, 0);
                    }
                }

           
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }*/
    protected virtual void Death()
    {

    }
}
