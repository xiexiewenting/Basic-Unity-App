using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoesGeneration : MonoBehaviour
{
    //domino way's position: (7, -11, 9)
    //domino way's scale: (3, 1, 8)

    public GameObject _trophy, _dominoPrefab;

    private bool _alreadyGenerated;
    private int _dominoCount;

    private float xCoor, yCoor, zCoor;

    // Start is called before the first frame update
    void Start()
    {
        _dominoCount = 5;
        //_delay = 1.0f;
        xCoor = 7.5f;
        yCoor = -4.63f;
        zCoor = 11.36f;
    }

    // Update is called once per frame
    void Update()
    {
        if ((_trophy.activeInHierarchy == false) && (_alreadyGenerated == false)) 
        {
            _alreadyGenerated = true;
            StartCoroutine("GenerateDomino");
        }
    }

    private IEnumerator GenerateDomino()
    {
        for (int i = 0; i <_dominoCount; i++)
        {

            GameObject clone = Instantiate(_dominoPrefab, new Vector3(xCoor, yCoor, zCoor - (1.5f*i)), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }
     }


}
