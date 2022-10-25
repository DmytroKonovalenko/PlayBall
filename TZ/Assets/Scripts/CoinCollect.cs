using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject coinPrefab;
    public Camera cam;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
    public void StartCoin(Vector3 _intial)
    {

        Vector3 targetpos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, target.position.z ));
        GameObject _coin = Instantiate(coinPrefab, transform);
        

        StartCoroutine(MoveCoin(_coin.transform, _intial, targetpos));
        
    }
    IEnumerator MoveCoin(Transform obj, Vector3 startPos, Vector3 endPos)
    {
        float time = 0;

        while (time < 1)
        {
            time += speed * Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, endPos, time);
            yield return new WaitForEndOfFrame(); 

        }
        yield return null;
        Destroy(obj.gameObject);
    }
}
