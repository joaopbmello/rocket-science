using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject squareButton;

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

        Task1();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetSceneByName("ZoomScene").isLoaded && Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 

            BoxCollider2D boxCollider = GameObject.Find("ZoomRectangle").GetComponent<BoxCollider2D>();
            if (!boxCollider.bounds.Contains(mousePosition)){
                SceneManager.UnloadSceneAsync("ZoomScene");
            }
        }
    }


    public GameObject triangle;
    public GameObject target;

    void Task1(){
        float[,] centers = {{-5f, 2f}, {5f, 2f}, {-5f, -2f}, {5f, -2f}};

        for (int i = 0; i < 4; i++){
            Vector2 v = new Vector2(centers[i,0], centers[i,1]) + Random.insideUnitCircle.normalized * 1.5f;
            Vector3 v3 = v;
            Instantiate(target, v3, Quaternion.identity);
        }
    }

}
