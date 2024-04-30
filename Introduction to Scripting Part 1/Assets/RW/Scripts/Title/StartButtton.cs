using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButtton : MonoBehaviour, IPointerClickHandler
{
   public void OnPointerClick(PointerEventData eventData) // 1
   {
        SceneManager.LoadScene("Game"); // 2
    }
}
