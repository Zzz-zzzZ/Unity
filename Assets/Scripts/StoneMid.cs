using UnityEngine;
using System.Collections;

public class StoneMid : MonoBehaviour
{

    public AnimationCurve curve;
    public GameObject SpawnPrefeb;
    public GameObject nextPrefeb;

    public GameObject NextPrefeb
    {
        get
        {
            return nextPrefeb;
        }

        set
        {
            nextPrefeb = value;
        }
    }

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
            Vector3 npos = transform.position + new Vector3(-1.4f, 1.4f, 0);

            Instantiate(SpawnPrefeb, npos, Quaternion.identity);

        }
        if (nextPrefeb)
        {
            Vector3 npos = transform.position + new Vector3(0, 0, 0);
            Instantiate(nextPrefeb, npos, Quaternion.identity);
            //Instantiate(nextPrefeb, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D coll)

    {
        if (coll.contacts[0].point.y < transform.position.y + 2.2)
        {

            StartCoroutine("sample");
        }

    }

}
