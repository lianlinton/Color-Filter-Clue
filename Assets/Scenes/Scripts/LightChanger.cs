using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LightChanger : MonoBehaviour
{
    public Light pointLight = null;
    public InputAction action;
    public Texture showLevel1;
    public Texture showLevel2;
    public Texture showLevel3;
    public Texture showLevel4;
    public Texture hide;
    private Renderer renderer;
    public GameObject plane;
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
        renderer.material.mainTexture = hide;
    }

    void Update()
    {
        //Retrieve Light Object
        Light l = pointLight.GetComponent<Light>();
        Color lightColor;
        Texture showText;
        switch (level)
        {
            case 1:
                lightColor = Color.blue;
                showText = showLevel2;
                break;
            case 2:
                lightColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);
                showText = showLevel3;
                break;
            case 3:
                lightColor = Color.magenta;
                showText = showLevel4;
                break;
            default:
                lightColor = Color.red;
                showText = showLevel1;
                break;
        }

        if (action.IsPressed())
        {

            if (!l.enabled)
            {
                l.color = lightColor;
                l.enabled = true;
                renderer.material.mainTexture = showText;

            }
            else
            {
                l.enabled = false;
                renderer.material.mainTexture = hide;
            }
        }
    }
}