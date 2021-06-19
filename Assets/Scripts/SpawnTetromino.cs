using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] Tetrominoes;

    public void NewTetromino()
    {
        //Prototype
        Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], new Vector3(Random.Range(2,7), 17, 0), Quaternion.identity);
    }
}
