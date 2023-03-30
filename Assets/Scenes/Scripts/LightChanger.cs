using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LightChanger : MonoBehaviour
{
    public Light pointLight = null;
    public InputAction action;
    public Texture hatLevel;
    public Texture imageLevel;
    public Texture bookLevel;
    public Texture hideLevel;
    public Color hatWallColor;
    public Color imageWallColor;
    public Color bookWallColor;
    private Renderer renderer;
    public GameObject plane;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject bottomWall;
    public GameObject topWall;
    public int level;

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
        renderer.material.mainTexture = hatLevel;
    }

    void Update()
    {
        //Retrieve Light Object
        Light l = pointLight.GetComponent<Light>();
        Color lightColor;
        Texture showText;
        Color showColor;
        switch (level)
        {
            case 2:
                lightColor = imageWallColor;
                showText = imageLevel;
                showColor = imageWallColor;
                break;
            case 3:
                lightColor = bookWallColor;
                showText = bookLevel;
                showColor = bookWallColor;
                break;
            default:
                lightColor = hatWallColor;
                showText = hatLevel;
                showColor = hatWallColor;
                break;
        }

        if (action.IsPressed())
        {
            //if (!l.enabled)
            //{
                l.color = lightColor;
                l.enabled = true;
                renderer.material.mainTexture = showText;
                renderer.material.mainTexture = showText;
                wall1.GetComponent<Renderer>().material.color = showColor;
                wall2.GetComponent<Renderer>().material.color = showColor;
                wall3.GetComponent<Renderer>().material.color = showColor;
                wall4.GetComponent<Renderer>().material.color = showColor;
                topWall.GetComponent<Renderer>().material.color = showColor;
                bottomWall.GetComponent<Renderer>().material.color = showColor;

            /*}
            else
            {
                l.enabled = false;
                renderer.material.mainTexture = hideLevel;
            }*/
        }
    }
}