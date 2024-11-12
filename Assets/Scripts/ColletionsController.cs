using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColletionsController : MonoBehaviour
{
    public delegate void ItemsRecollectDelagate(int itemValue);
    public ItemsRecollectDelagate ColletorCounter;
    public int collectionItems;
    // Start is called before the first frame update
    // Update is called once per frame
  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CollectionItem")
        {
            collectionItems++;
            Destroy(collision.gameObject);
            ColletorCounter?.Invoke(collectionItems);
        }
    }
}
