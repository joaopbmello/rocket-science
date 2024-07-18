using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject zoomPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // game objects
        if (SceneManager.GetSceneByName("ZoomScene").isLoaded && Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 

            BoxCollider2D boxCollider = GameObject.Find("ZoomRectangle").GetComponent<BoxCollider2D>();
            if (!boxCollider.bounds.Contains(mousePosition)){
                SceneManager.UnloadSceneAsync("ZoomScene");
            }
        }

        // ui
        if (Input.GetMouseButtonDown(0)) {
            RectTransform panelRect = zoomPanel.GetComponent<RectTransform>();
            Vector2 mousePos = Input.mousePosition;

            if (!RectTransformUtility.RectangleContainsScreenPoint(panelRect, mousePos)){
                zoomPanel.SetActive(false);
            }
        }
    }

    // UI
    public void onButtonPress(){
        if (!zoomPanel.activeSelf){
            zoomPanel.SetActive(true);
        }
    }

}
