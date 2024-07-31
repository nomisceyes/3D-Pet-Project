using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerHealthText;

    [SerializeField] private int _health;

    private Animator _animator;
    private bool _gameOver;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _health = 100;
        _gameOver = false;
    }

    private void Update()
    {
        _playerHealthText.text = _health.ToString();

        if (_gameOver)
            SceneManager.LoadScene("Level");
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _animator.SetTrigger("isHitting");

        if (_health <= 0)
            _gameOver = true;
    }
}
