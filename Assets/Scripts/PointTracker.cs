using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointTracker : MonoBehaviour
{
    //player sphere's start position: (-7.285, 3.193594, 2.734375)
    public GameObject _mainCamera, _trophy;
    public TextMeshProUGUI _tmpStart, _tmpA, _tmpB, _tmpC, _tmpD, _tmpTrophy, _tmpRestart,
        _tmpInstructions;

    private bool _hasHitA, _hasHitB, _hasHitC, _hasHitD, _hasHitTrophy, _restart;
    private CamMovement _camScript;
    private float _rotationSpeed, _instructionsOffsetX, _instructionsOffsetY, _instructionsOffsetZ;
    private string _congratulations, _preStart, _postStart, _completed, _instructions;
    private Vector3 _defaultSize, _biggerSize,  _rotation;


    

    // Start is called before the first frame update
    void Start()
    {
        // set up a few tracking variables 
        _defaultSize = Vector3.one;
        _biggerSize = Vector3.one * 2.0f;
        _rotation = new Vector3(0.0f, -1.0f, 0.0f);
        _rotationSpeed = 0.3f;
        _camScript = _mainCamera.GetComponent<CamMovement>();
        _instructionsOffsetX = _tmpInstructions.transform.parent.position.y - transform.position.x;
        _instructionsOffsetY = _tmpInstructions.transform.parent.position.y - transform.position.y;
        _instructionsOffsetZ = _tmpInstructions.transform.parent.position.z - transform.position.z;

        _congratulations = "congratulations!!! \n hit space-bar to restart ~";
        _preStart = "click on the cube! ";
        _postStart = "good luck :)";
        _completed = ":)";
        _instructions = "objective: ball reaches all checkpoints in alphabetical order.\nhow: click on the platforms to move the ball \n";

        _tmpStart.rectTransform.localScale = _biggerSize;
        _tmpStart.color = Color.cyan;
        _tmpStart.text = _preStart;
        _tmpInstructions.text = _instructions;
        

    }

    // Update is called once per frame
    void Update()
    {
        ManagingTextRotations();
        DidBallHitTrophy();
        IsRestartNeeded();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collidedName = collision.gameObject.name;

        DidBallHitPlayer(collidedName);
        DidBallHitA(collidedName);
        DidBallHitB(collidedName);
        DidBallHitC(collidedName);
        DidBallHitD(collidedName);
    }

    void IsRestartNeeded() // looks to see whether the demo needs to be reloaded 
    {
        if (_restart == false) { 
            if ((gameObject.transform.position.y < -20.0f)) // if the ball has fallen 
            {
                _tmpStart.text = _tmpA.text = _tmpB.text = _tmpC.text = _tmpD.text = _tmpTrophy.text =
                    _tmpInstructions.text = "";
                _tmpRestart.text = "game over :( \n restarting in 2 seconds";
                Restart(transform.position);
            }
            if ((Input.GetKeyDown("space")) && (_tmpInstructions.text == _congratulations))
                // if the user hit the spacebar after completing the level 
            {
                _tmpTrophy.text = _tmpInstructions.text = "";
                _tmpRestart.text = "hang tight! \n restarting in 2 seconds";
                Restart(transform.position);
            }
        }
    }
    void Restart(Vector3 bannerPosition) //restarting the level 
    {
        _camScript.enabled = false;
        _restart = true;
        _tmpRestart.rectTransform.position = bannerPosition;
        Invoke("Reload", 2.0f);
    }

    void Reload() //calling the actual reload
    {
        SceneManager.LoadScene("Demo_2");
    }

    void Rotating(TextMeshProUGUI textBanner, float rotSpeed)
    {
        textBanner.transform.Rotate(_rotation * rotSpeed, Space.Self);
    }

    void ManagingTextRotations() //manages the TMP during the whole game (in the update() function)
    {
        if (!_restart) //for positioning the instructions TMP 
        {
            float x = 0;
            if (transform.position.x <= 15.0f) {
                x = _tmpInstructions.transform.parent.position.x;
                _instructionsOffsetX = x - transform.position.x;
            }
            else
            {
                x = transform.position.x + _instructionsOffsetX;
            }
            float y = transform.position.y + _instructionsOffsetY;
            float z = 0.0f;
            if (transform.position.z <= 15.0f)
            {
                z = _tmpInstructions.transform.parent.position.z;
                _instructionsOffsetZ = z - transform.position.z;
            }
            else 
            {
                z = transform.position.z + _instructionsOffsetZ;
            }

            _tmpInstructions.transform.parent.position = new Vector3(x, y, z);
        }

        _rotation = new Vector3(0.0f, (Mathf.Repeat(Time.time, 6) / 3.0f) - 1.0f, 0.0f);

        if (_tmpStart.text == _preStart) //
        {
            Rotating(_tmpStart, _rotationSpeed);
        }

        if (_hasHitTrophy)
        {
            Rotating(_tmpInstructions, _rotationSpeed);
        }

        if (_tmpRestart.text != "")
        {
            Rotating(_tmpRestart, _rotationSpeed);
        }

        if (_tmpA.rectTransform.localScale == _biggerSize)
        {
            Rotating(_tmpA, _rotationSpeed);
        }

        if (_tmpB.rectTransform.localScale == _biggerSize)
        {
            Rotating(_tmpB, _rotationSpeed);
        }

        if (_tmpC.rectTransform.localScale == _biggerSize)
        {
            Rotating(_tmpC, _rotationSpeed);
        }

        if (_tmpD.rectTransform.localScale == _biggerSize)
        {
            Rotating(_tmpD, _rotationSpeed);
        }
    }

    void DidBallHitPlayer(string collidedName)
    {
        if (collidedName.Contains("Player"))
        {
            IncrementLevel(_tmpStart, _tmpA, _postStart);
        }
    }

    void DidBallHitA(string collidedName)
    {
        if (collidedName.Contains("PointA"))
        {
            if (_hasHitA) { }
            else if (_hasHitB || _hasHitC || _hasHitD || _hasHitTrophy)
            {
                Restart(transform.position);
            }
            else
            {
                _hasHitA = true;
                IncrementLevel(_tmpA, _tmpB, _completed);
            }
        }
    }

    void DidBallHitB(string collidedName)
    {
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
                IncrementLevel(_tmpB, _tmpC, _completed);
            }
        }
    }

    void DidBallHitC(string collidedName)
    {
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
                IncrementLevel(_tmpC, _tmpD, _completed);
            }
        }
    }

    void DidBallHitD(string collidedName)
    {
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
                IncrementLevel(_tmpD, _tmpTrophy, _completed);
            }
        }
    }

    void DidBallHitTrophy()
    {
        if (_trophy.activeInHierarchy == false)
        {
            _hasHitTrophy = true;
            if (!(_hasHitA) || !(_hasHitB) || !(_hasHitC) || !(_hasHitD))
            {
                //Restart(transform.position);
            }
            if (!_restart) {
                _tmpInstructions.text = _congratulations;
                _tmpInstructions.color = Color.cyan;
                _tmpInstructions.rectTransform.localScale = _biggerSize;
                _tmpStart.text = _tmpA.text = _tmpB.text = _tmpC.text = _tmpD.text =
                    _tmpTrophy.text = "";
            }

            //_tmpTrophy.colorGradientPreset = ;
        }
    }

    void IncrementLevel(TextMeshProUGUI tmpFirst, TextMeshProUGUI tmpSecond, string textFirst)
    {
        tmpFirst.rectTransform.localScale = _defaultSize;
        tmpFirst.color = Color.black;
        tmpFirst.text = textFirst;
        tmpSecond.color = Color.cyan;
        tmpSecond.rectTransform.localScale = _biggerSize;
    }
}
