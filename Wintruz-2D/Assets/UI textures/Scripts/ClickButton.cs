using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip compressClip, uncompressClip;
    [SerializeField] private AudioSource source;
    public void OnPointerDown(PointerEventData eventData)
    {
        source.PlayOneShot(compressClip);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        source.PlayOneShot(uncompressClip);
    }

    public void IWasClicked()
    {
        Debug.Log("clicked");
    }

}
