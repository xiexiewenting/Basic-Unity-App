using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointTracker : MonoBehaviour
{
    private bool _hasHitA, _hasHitB, _hasHitC, _hasHitD, _hasHitTrophy, _restart;
    public TextMeshProUGUI _tmpStart, _tmpA, _tmpB, _tmpC, _tmpD, _tmpTrophy, _tmpRestart;
    private Vector3 _defaultSize, _biggerSize, _rotation;
    private float _rotationSpeed;
    public GameObject _mainCamera, _trophy;
    private CamMovement _camScript;

    //player sphere's start position: (-7.285, 3.193594, 2.734375)

    // Start is called before the first frame update
    void Start()
    {
        _tmpStart.text = "Click here!";
        _defaultSize = new Vector3(1.0f, 1.0f, 1.0f);
        _biggerSize = new Vector3(2.0f, 2.0f, 2.0f);
        _rotation = new Vector3(0.0f, -1.0f, 0.0f);
        _tmpStart.rectTransform.localScale = _biggerSize;
        _camScript = _mainCamera.GetComponent<CamMovement>();
        _rotationSpeed = 0.3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotating();
        if ((gameObject.transform.position.y < -20.0f) && (_restart == false))
        {
            Restart(_tmpRestart.transform.position);
        }

        if (_trophy.activeInHierarchy == false)
        {
            _hasHitTrophy = true;
            if (!(_hasHitA) || !(_hasHitB) || !(_hasHitC) || !(_hasHitD))
            {
                Restart(transform.position);
            }
            _tmpTrophy.text = "Congratulations!!!";
            _tmpTrophy.color = Color.white;
            _tmpTrophy.rectTransform.localScale = _biggerSize * 2.0f;
            _tmpStart.text = _tmpA.text = _tmpB.text = _tmpC.text = _tmpD.text= "";
            //_tmpTrophy.colorGradientPreset = ;
        }
        if (_hasHitTrophy)
        {
            _tmpTrophy.transform.Rotate(_rotation * _rotationSpeed, Space.Self);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        string collidedName = collision.gameObject.name;
        if (collidedName.Contains("Player"))
        {
            _tmpStart.rectTransform.localScale = _defaultSize;
            _tmpStart.color = Color.black;
            _tmpA.color = Color.blue;
            _tmpA.rectTransform.localScale = _biggerSize;
            _tmpStart.text = "Good luck :)";
            
        }

        if (collidedName.Contains("PointA")) {

            if (_hasHitA) { }
            else if (_hasHitB || _hasHitC || _hasHitD || _hasHitTrophy)
            {
                _tmpRestart.rectTransform.position = transform.position;
                Restart(transform.position);
            }
            else
            {
                _hasHitA = true;
                _tmpA.rectTransform.localScale = _defaultSize;
                _tmpA.color = Color.black;
                _tmpB.color = Color.blue;
                _tmpB.rectTransform.localScale = _biggerSize;
                _tmpA.text = ":)";
            }
        }
        if (collidedName.Contains("PointB"))
        {
            if (_hasHitB) { }
            else if (!(_hasHitA) || _hasHitC || _hasHitD || _hasHitTrophy)
            {
                Restart(transform.position);
            }
            else
            {
                _hasHitB = true;
                _tmpB.rectTransform.localScale = _defaultSize;
                _tmpB.color = Color.black;
                _tmpC.color = Color.blue;
                _tmpC.rectTransform.localScale = _biggerSize;
                _tmpB.text = ":)";
            }
            
        }
        if (collidedName.Contains("PointC"))
        {
            if (_hasHitC) { }
            else if (!(_hasHitA) || !(_hasHitB) || _hasHitD || _hasHitTrophy)
            {
                Restart(transform.position);
            }
            else
            {
                _hasHitC = true;
                _tmpC.rectTransform.localScale = _defaultSize;
                _tmpC.color = Color.black;
                _tmpD.color = Color.blue;
                _tmpD.rectTransform.localScale = _biggerSize;
                _tmpC.text = ":)";
            }
            
        }
        if (collidedName.Contains("PointD"))
        {
            if (_hasHitD) { }
            else if (!(_hasHitA) || !(_hasHitB) || !(_hasHitC) || _hasHitTrophy)
            {
                Restart(transform.position);
            }
            else
            {
                _hasHitD = true;
                _tmpD.rectTransform.localScale = _defaultSize;
                _tmpD.color = Color.black;
                _tmpTrophy.color = Color.blue;
                _tmpTrophy.rectTransform.localScale = _biggerSize;
                _tmpD.text = ":)";
            }
            
        }

    }

    void Restart(Vector3 bannerPosition)
    {
        _camScript.enabled = false;
        _restart = true;
        _tmpStart.text = _tmpA.text = _tmpB.text = _tmpC.text = _tmpD.text = _tmpTrophy.text
            = "";
        _tmpRestart.rectTransform.position = bannerPosition;
        _tmpRestart.text = "Game Over :(";
        Invoke("Reload", 2.0f);
    }

    void Reload()
    {
        SceneManager.LoadScene("Demo_2");
    }

    void Rotating()
    {
        _tmpStart.transform.Rotate(_rotation * _rotationSpeed, Space.Self);
    }
}
