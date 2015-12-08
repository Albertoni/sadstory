using UnityEngine;
using System.Collections;

public class HandleClick : MonoBehaviour {
    public void displayText(string text, int[] times) {
        char[] letters = text.ToCharArray();
        string toShow = "";
        for (int i = 0; i < letters.Length; i++) {
            toShow += letters[i];
            // bota na textbox
            // delay
        }
    }

    public GameObject textbox;
    public void switchTextbox() {
        textbox.SetActive(!textbox.activeSelf);
    }

    public void doTheHand(int buttonId) {
        // pega o texto e os delays de uma estrutura via o id
        // bota caixa de texto
        // imprime texto
        // 
    }
}
