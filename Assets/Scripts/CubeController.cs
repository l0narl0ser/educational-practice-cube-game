using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeController : MonoBehaviour
{
    public GameObject cubePrefab;
    public List<GameObject> cubeList;
    public float scalingFactor = 0.95f;
    public int numCubes = 0;

    [SerializeField]
    private float _minimalScale = 0.1f;

    private void Start()
    {
        cubeList = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObjectSpawn();
        }
        UpdateCubesStates();
    }
    private void UpdateCubesStates()
    {
        UpdateCubesSize();
        TryRemoveCubes();
    }

    private void TryRemoveCubes()
    {
        GameObject[] copiedGameObjectList = cubeList.ToArray();
        foreach (GameObject goTemp in copiedGameObjectList)
        {
            if (goTemp.transform.localScale.x < _minimalScale)
            {
                cubeList.Remove(goTemp);
                Destroy(goTemp);
            }

        }
    }

    private void UpdateCubesSize()
    {

        foreach (GameObject goTemp in cubeList)
        {
            SizeReducing(goTemp);
        }
    }

    private void GameObjectSpawn()
    {
        numCubes++;
        cubeList.Add(GameObjectCreate());


    }
     
    

    private void SizeReducing(GameObject cube)
    {
        float scale = cube.transform.localScale.x;
        scale *= scalingFactor;
        cube.transform.localScale = Vector3.one * scale; // 0,95 * (1 , 1 , 1) =  (0,95 , 0,95 , 0,95)
        
    }

    private GameObject GameObjectCreate()
    {
        
        GameObject cube = Instantiate<GameObject>(cubePrefab);
        cube.name = "Cube" + numCubes;
        Color color = new Color(Random.value, Random.value, Random.value);
        cube.GetComponent<Renderer>().material.color = color;
        cube.transform.position = Random.insideUnitSphere + new Vector3(0, Random.RandomRange(1, 3), 0);
        return cube;
    }
}
