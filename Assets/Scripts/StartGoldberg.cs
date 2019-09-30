using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGoldberg : MonoBehaviour
{
    //public GameObject _startPlatform;
    public TextMeshProUGUI _textMeshPro;
    public string _standByText, startedText;

    private Camera _mainCamera;
    private bool _rayDidHit;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _textMeshPro.text = _standByText;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonUp(0)) && (_rayDidHit == false)) 
        {
            //Debug.Log("Pressed left click.");
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            _rayDidHit = Physics.Raycast(ray, out hitInfo);
            if (_rayDidHit)
            {
                Interact(hitInfo);
            }
        }
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        if (hit.collider.name == gameObject.name)
        {
            gameObject.SetActive(false);
            _textMeshPro.text = startedText;
        }
        else //if it turns out the object that clicked on was NOT the platform
        {
            _rayDidHit = false;
        }
    }
}
