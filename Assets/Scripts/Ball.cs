using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject SplashPrefab;
    private GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other){
        rb.velocity = Vector3.up * jumpForce;
        GameObject splash = Instantiate(SplashPrefab,transform.position + new Vector3(0f,-0.2f,0f),transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        
        if(metarialName == "UnsafeColor (Instance)"){
            gm.RestartGame();
        }
        else if(metarialName == "LastRing (Instance)"){
            Debug.Log("Next Level");
        }
    }
}
