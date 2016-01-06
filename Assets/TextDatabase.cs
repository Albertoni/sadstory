using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using SimpleJSON;

public sealed class TextDatabase {
    private static readonly TextDatabase instance = new TextDatabase();
    private List<TextSnippet> snippets = new List<TextSnippet>();
    private bool initialized = false;
    private readonly string databaseName = "\\strings.json";

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    // see http://csharpindepth.com/Articles/General/Singleton.aspx
    static TextDatabase() {
    }

    private TextDatabase() {
    }

    public static TextDatabase Instance {
        get {
            return instance;
        }
    }

    public void init() {
        //this.snippets 

        // load all texts and delays and stuff and snippets
        // open file (onde?)
        string file = File.ReadAllText(Application.dataPath + this.databaseName);

        // parse
        // http://wiki.unity3d.com/index.php/SimpleJSON
        var data = JSON.Parse(file);
        int length = data["length"].AsInt;
        
        for (int i = 0; i < length; i++) {
            int id = data["data"][i]["id"].AsInt;
            string text = data["data"][i]["text"].ToString();


            int arrayLenght = data["data"][i]["delay"].AsArray.Count;
            List<int> delay = new List<int>();
            for (int j = 0; j < arrayLenght; j++) {
                delay.Add(data["data"][i]["delay"][j].AsInt);
            }
            snippets.Add(new TextSnippet(id, text, delay)); // https://msdn.microsoft.com/en-us/library/6sh2ey19%28v=vs.110%29.aspx
        }
    }

    public TextSnippet getSnippet(int id) {
        if (!initialized) {
            this.init();
            this.initialized = true;
        }
        Debug.Log(snippets);
        return snippets[id];
    }
}

public class TextSnippet {
    public string text;
    public List<int> delay;
    public TextSnippet(int id, string text, List<int> delay) {
        if (text.Length != delay.Count) {
            Debug.LogError(@"TEXT LENGHT AND DELAY ARRAY SIZE NOT THE SAME AT " + text + ", text is "+text.Length+" and delay is "+delay.Count);
        }
        
        this.text = text;
        this.delay = delay;
    }
}