using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{

    public float mousesensivity=100f;
    public Transform playerbody;
    float xrotation=0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState =CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Mousex= Input.GetAxis("MouseX")*mousesensivity*Time.deltaTime;
        float Mousey= Input.GetAxis("MouseY")*mousesensivity*Time.deltaTime;
        xrotation-=Mousey;
        xrotation=Mathf.Clamp(xrotation,-90f,90f);
        transform.localRotation=Quaternion.Euler(xrotation,0f,0f);
        playerbody.Rotate(Vector3.up*Mousex);







    }
}
