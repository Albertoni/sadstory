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
    private GameObject textbox;
    //private GameObject textDatabase;
    public void displayTextbox(GameObject box) {
        box.SetActive(true);
        doTheHand(0, box);
    }

    public void doTheHand(int buttonId, GameObject box) {
        // só organizando
        this.textbox = box;

        // pega o texto e os delays de uma estrutura via o id
        TextSnippet snippet = TextDatabase.Instance.getSnippet(buttonId);


        // bota caixa de texto
        //this.displayTextbox(this.textbox);

        // imprime texto
        UnityEngine.UI.Text text = (UnityEngine.UI.Text) this.textbox.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        text.text = snippet.text;
    }

    public void Update() {
        const int MOUSE_LEFT = 0;
        if (Input.GetMouseButton(MOUSE_LEFT)) {
            //this.textbox.SetActive(false);
        }
    }
}