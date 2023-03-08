using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LightChanger : MonoBehaviour
{
    public Light pointLight = null;
    public InputAction action;
    public Texture show;
    public Texture hide;
    private Renderer renderer;
    public GameObject plane;

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        renderer = plane.GetComponent<Renderer>();
        renderer.material.mainTexture = hide;
    }

    void Update()
    {
        //Retrieve Light Object
        Light l = pointLight.GetComponent<Light>();

        if (action.IsPressed())
        {

            if (!l.enabled)
            { 
                //Change color of room to Red
                l.color = Color.red;
                l.enabled = true;
                renderer.material.mainTexture = show;
        
            }
            else
            {
                l.enabled = false;
                renderer.material.mainTexture = hide;
            }
        }
    }
}
