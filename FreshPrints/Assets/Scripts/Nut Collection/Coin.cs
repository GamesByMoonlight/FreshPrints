using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    Rigidbody myRB;
    public GameObject goldCoin;
    public GameObject sparkles;
    public float flipStrength, fallSpeed;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (goldCoin.activeSelf || sparkles.activeSelf)
        {
            myRB.AddForce(Vector3.down * fallSpeed);
        }
    }

	public void Flip()
    {
        transform.localEulerAngles = Vector3.zero;
        goldCoin.SetActive(true);
        
        myRB.velocity = (transform.localPosition.normalized + Vector3.up).normalized * flipStrength;
        myRB.angularVelocity = myRB.velocity * 10f;

        StartCoroutine(MakeSparkles());
    }

    public void Arrange(int i)
    {
        transform.localPosition = new Vector3(Random.Range(-0.035f, 0.035f), 0.025f * i, Random.Range(-0.035f, 0.035f));
    }

    IEnumerator MakeSparkles()
    {
        yield return new WaitForSeconds(0.25f);

        sparkles.SetActive(true);

        yield return new WaitForSeconds(0.1f);

        goldCoin.SetActive(false);
        
        yield return new WaitForSeconds(0.25f);
        sparkles.SetActive(false);

        myRB.velocity = Vector3.zero;
        myRB.angularVelocity = Vector3.zero;
    }
}
