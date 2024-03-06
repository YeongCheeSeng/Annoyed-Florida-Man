using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float Speed;
    public float LifeTime = 1f;

    public LayerMask TargetLayerMask;
    public LayerMask IgnoreLayerMask;

    private DamageOnTouch _damageOnTouch;
    private Rigidbody2D _rigidbody;
    float _timer = 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if (_rigidbody == null)
            return;

        //_rigidbody.AddRelativeForce(new Vector2(x: 0f, y: Speed));
        _rigidbody.velocity = transform.up * Speed;

        _damageOnTouch = GetComponent<DamageOnTouch>();
    }

    private void Update()
    {

        if (_timer < LifeTime)
        {
            _timer += Time.deltaTime;
            return;
        }

        Die();
        _timer = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (((IgnoreLayerMask.value & (1 << col.gameObject.layer)) > 0))
            return;

        if (((TargetLayerMask.value & (1 << col.gameObject.layer)) > 0))
        {
            Die();
        }
    }

    protected void Die()
    {
        Destroy(this.gameObject);
    }
}
