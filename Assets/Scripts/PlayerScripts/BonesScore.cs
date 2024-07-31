using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BonesScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bonesScore;

    private int _score;

    private void Start()
    {
        _score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bone"))
        {
            _score++;
            _bonesScore.text = _score.ToString();
            Destroy(other.gameObject);
        }
    }
}
