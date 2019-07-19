using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Update(){
        InputListener();
    }

    private void InputListener(){
        if (Input.GetButtonDown("Cancel"))
            Application.Quit();
        else if (Input.anyKey){
            SceneManager.LoadScene(1);
        }
    }
}
