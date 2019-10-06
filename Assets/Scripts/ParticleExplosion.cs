using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
//this script generates the particles in the explosion
{
    public GameObject _originalObject, _particlePrefab;
    public int _particleCount;
    public float _particleMinSize, _particleMaxSize;

    private bool _alreadyExploded;

    // Start is called before the first frame update
    void Start()
    {
        _alreadyExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((_originalObject.activeInHierarchy == false) && (_alreadyExploded == false))
        {
            _alreadyExploded = true;
            Exploding();
        }
    }

    void Exploding()
    {
        for (int i = 0; i < _particleCount; i++)
        {
            GameObject clone = Instantiate(_particlePrefab,
                _originalObject.transform.position, _originalObject.transform.rotation);
            clone.transform.localScale = clone.transform.localScale * Random.Range(_particleMinSize, _particleMaxSize);
        }

    }
}
