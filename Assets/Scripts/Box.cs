using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{

    public AnimationCurve curve;
    public GameObject SpawnPrefeb;
    public GameObject nextPrefeb;

    IEnumerator sample()
    {
        Vector2 pos = transform.position;

        for (float t = 0; t < curve.keys[curve.length - 1].time; t += Time.deltaTime)
        {
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t));
            yield return null;
        }
        if (SpawnPrefeb)
        {
            Instantiate(SpawnPrefeb, transform.position + Vector3.up, Quaternion.identity);

        }
        if (nextPrefeb)
        {
            Instantiate(nextPrefeb, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D coll)

    {
        if (coll.contacts[0].point.y < transform.position.y)
        {
            StartCoroutine("sample");
        }

    }

}


