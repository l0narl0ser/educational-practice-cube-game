using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject cubePrefab;
    public List<GameObject> cubeList;
    public float scalingFactor = 0.99995f;
    public int numCubes = 0;

    [SerializeField]
    private float _minimalScale = 0.9f;

    private void Start()
    {
        cubeList = new List<GameObject>();
    }

    private void Update()
    {
        
    }
}
