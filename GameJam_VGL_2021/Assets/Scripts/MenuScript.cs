using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour
{
    public Text option1;
    public Text option2;
    public TextMesh option3;

    private int numberOfOptions = 3;

    private int selectedOption;
    // Start is called before the first frame update
    void Start()
    {
        selectedOption = 1;
        option1.color = Color.white;
        option2.color = Color.black;
        option3.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) )
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numberOfOptions) 
            {
                selectedOption = 1;
            }

            option1.color = Color.black;
            option2.color = Color.black;
            option3.color = Color.black;

            switch (selectedOption)
            {
                case 1:
                    option1.color = Color.white;
                    break;
                case 2:
                    option2.color = Color.white;
                    break;
                case 3:
                    option3.color = Color.white;
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) ){
            selectedOption -= 1;
            if(selectedOption < 1){
                selectedOption = 3;
            }
            option1.color = Color.black;
            option2.color = Color.black;
            option3.color = Color.black;

            switch (selectedOption)
            {
                case 1:
                    option1.color = Color.white;
                    break;
                case 2:
                    option2.color = Color.white;
                    break;
                case 3:
                    option3.color = Color.white;
                    break;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            ChooseAnOption();
        }
    }
    private void ChooseAnOption(){
        switch (selectedOption){
            case 1:
            // Start Game
            // Asteroids 
            SceneManager.LoadScene("Asteroids");
            break;
            case 2:
            // Options
            break;
            case 3:
            // Quit
            Application.Quit();
            break;
        }
    }
}
