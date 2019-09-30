using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoesGeneration : MonoBehaviour
{
    //domino way's position: (7, -11, 9)
    //domino way's scale: (3, 1, 8)

    //player cube's position: (8, -7.3, 4)
    //player cube's scale: (1, 1, 1)

    public GameObject _trophy, _dominoPrefab;

    private bool _alreadyGenerated;
    private int _dominoCount;

    private float _xCoor, _yCoor, _zCoor, _dominoGap;

    // Start is called before the first frame update
    void Start()
    {
        _dominoCount = 5;
        //_delay = 1.0f;
        _xCoor = 7.5f;
        _yCoor = -4.63f;
        _zCoor = 11.36f;
        _dominoGap = 1.45f;
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

            GameObject clone = Instantiate(_dominoPrefab, new Vector3(_xCoor, _yCoor, _zCoor - (_dominoGap*i)), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }
     }


}
