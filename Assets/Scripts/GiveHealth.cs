using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    [SerializeField] float HealthAgree;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthPlayer>())
        {
            collision.GetComponent<HealthPlayer>().TakeHealth(HealthAgree);
            Destroy(gameObject);
        }
    }
}
