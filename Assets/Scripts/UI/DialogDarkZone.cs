using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDarkZone : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DisableDialogBox());
    }

    IEnumerator DisableDialogBox()
    {
        yield return new WaitForSeconds(4.5f);
        gameObject.SetActive(false);
    }
}
