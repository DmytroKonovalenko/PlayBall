using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject explosionPrefab2;
    public CoinCollect coinCollect;
    //private Material matHit;
    //private Material matNormal;
    //private MeshRenderer meshRend;


    private int coins;




    private void Start()
    {
        //meshRend = GetComponent<MeshRenderer>();
        //matHit = Resources.Load("Hit", typeof(Material)) as Material;
        //matNormal = meshRend.material;
        coinsText.text = coins.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {
            coins++;
            coinsText.text = coins.ToString();
            coinCollect.StartCoin(other.transform.position);
            Destroy(other.gameObject);
            var explosion=Instantiate(explosionPrefab);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(explosion, 1f);
        
        }
        
    }
    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Obstracle")
        {
            //meshRend.material = matHit;
            var explosion2 = Instantiate(explosionPrefab2);
            explosion2.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(explosion2, 1f);
        }
        //else
        //{
        //    Invoke("ResetMaterial", .01f);
        //}
    }
     //void ResetMaterial()
    //{
      //  meshRend.material = matNormal;
    //}    

    private void Update()
    {
        
    }

}
