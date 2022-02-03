using UnityEngine;

public class PlatformPatrol : MonoBehaviour
{

    public float speed;
    public Transform posA;
    public Transform posB;
    private Transform target;




    void Start()
    {
        target = posA;
        

    }


    void Update()
    {

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target != posA ? posA : posB;
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }



}
