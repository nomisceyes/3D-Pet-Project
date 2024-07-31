using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject _weaponItem;
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider _healthBar;
    [SerializeField] public int _health = 100;

    private DropBones _dropBones;

    private void Awake()
    {
        _dropBones = GetComponent<DropBones>();
    }

    private void Update()
    {
        _healthBar.value = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _animator.SetTrigger("Death");
            _weaponItem.GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = false;
            _healthBar.gameObject.SetActive(false);
            _dropBones.Create(transform.localPosition + (Vector3.up * 0.5f));
        }
        else
            _animator.SetTrigger("ReactionHit");
    }
}
