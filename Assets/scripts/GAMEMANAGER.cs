using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
    public bool isGameOver; 
    // Start is called before the first frame update

    public Text coinText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        isGameOver=true;
        StartCoroutine("LoadScene");
        //Llamar funcion de forma normal
        //LoadScene();
        //Invocamos la funcion despues de 1.5 segundos
        //Invoke("LoadScene",1.5f); 
    }
   /* void LoadScene()
    {
        SceneManager.LoadScene(0);
    }*/

    
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.5f);
        
         SceneManager.LoadScene(0);

    }
    public void AddCoin()
{
    coins++; 
    coinText.text = coins.ToString(); 
}
}
