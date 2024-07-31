using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBones : MonoBehaviour
{
    Animation _animation;

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    void Update()
    {
        _animation.transform.position = transform.position;
    }
}
