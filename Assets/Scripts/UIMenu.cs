using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{

    public void Ex1() {SceneManager.LoadScene("Exercice 1");}
    public void Ex2() {
        RunCar.crash = false;
        SceneManager.LoadScene("Exercice 2");
        }
    public void Ex3() {SceneManager.LoadScene("Exercice 3");}
    public void Ex4() {SceneManager.LoadScene("Exercice 4");}
    public void Menu() {SceneManager.LoadScene("Main");}

}
