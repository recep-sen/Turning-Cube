using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float speed;
    public static Cube Instance;
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        transform.Rotate(Time.deltaTime * speed,0f , 0f);
    }
}