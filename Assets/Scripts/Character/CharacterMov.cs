using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMov : MonoBehaviour
{
    private Rigidbody rb; 

    [Header("Nom des inputs")]
    public string inputNameVertical;
    public string inputNameHorizontal;

    [Header("Stats très rapides")]
    public float speed;
    public float inputVertical;
    public float inputHorizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical); 
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * inputHorizontal * Time.deltaTime, rb.velocity.y, speed * inputVertical * Time.deltaTime); 
    }
}
