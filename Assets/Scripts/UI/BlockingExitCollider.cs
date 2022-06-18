using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingExitCollider : MonoBehaviour
{

    public GameObject warningBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            warningBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            warningBox.SetActive(false);
        }
    }

}
