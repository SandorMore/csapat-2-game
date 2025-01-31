using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{

    private SpriteRenderer sr;

    [Header("FlashFx")]
    [SerializeField] private Material hitMat;
    [SerializeField] private Material originalMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }
    private IEnumerator FlashFx()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(.16f);
        sr.material = originalMat;
    }
}
