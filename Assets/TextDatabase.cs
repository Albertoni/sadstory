using UnityEngine;
using System.Collections;
using System;
using System.IO;
using SimpleJSON;

public sealed class TextDatabase {
    private static readonly TextDatabase instance = new TextDatabase();
    private System.Collections.Generic.List<TextSnippet> snippets;
    private bool initialized = false;
    private readonly string databaseName = "strings.json";

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
        // load all texts and delays and stuff and snippets
        // open file (onde?)
        string file = File.ReadAllText(Application.dataPath + this.databaseName);

        // parse
        // http://wiki.unity3d.com/index.php/SimpleJSON
        var data = JSON.Parse(file);
        // new TextSnippet() até chorar
        var parsedData = data["data"].AsArray;
        foreach(var snippet in parsedData){

        }

        // snippets.Add(novoSnippet) // https://msdn.microsoft.com/en-us/library/6sh2ey19%28v=vs.110%29.aspx
    }

    public TextSnippet getSnippet(int id) {
        if (!initialized) {
            this.init();
            this.initialized = true;
        }

        return snippets[id];
    }
}

public class TextSnippet {
    public string text;
    public int[] delay;
    public TextSnippet(int id, string text, int[] delay) {
        try {
            if (text.Length != delay.Length) {
                throw new Exception(@"TEXT LENGHT AND DELAY ARRAY SIZE NOT THE SAME AT" + text);
            }
        }
        catch (Exception e) {
            throw e;
        }
        this.text = text;
        this.delay = delay;
    }
}