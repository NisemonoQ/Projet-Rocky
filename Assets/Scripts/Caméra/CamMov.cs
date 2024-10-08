using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CamMov : MonoBehaviour
{
    [Header("Notre magnifique Caméra")]
    private Camera cam; 

    [Header("Transform des personnages")]
    public List<Transform> targets;

    [Header("Des Vecteurs")]
    public Vector3 offset;
    private Vector3 velocity;

    [Header("Variables Nuémriques")]
    public float smoothFactor = .8f;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimit = 50f;

    void Start()
    {
        cam = GetComponent<Camera>(); 
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        MoveCam();

        Zoomin(); 

    }

    void Zoomin()
    {
        //Debug.Log(GetGreatestDistance());
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance()/zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime); 
    }
    
    void MoveCam()
    {
        Vector3 centerPos = GetCenter();
        Vector3 newPos = centerPos + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothFactor);
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.y;
    }

    Vector3 GetCenter()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center; 
    }
}
