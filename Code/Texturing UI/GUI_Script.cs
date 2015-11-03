
using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System;

public class GUI_Script : MonoBehaviour
{
    public Vector2 scrollViewVector = new Vector2(0.0f, 1.0f);
    public int button_selected = 7;
    private GameObject Object;
    public List<ProceduralMaterial> Materials = new List<ProceduralMaterial>();
    List<string> buttonNames = new List<string>();
    private string[] bn;
    public Button button;
    private List<Button> materialButtons;
    private bool doWindow0;
    public Vector3 b_prefab_pos;
    public Material mt;
    public ProceduralMaterial mt_proc;
    public List<ProceduralPropertyDescription> material_arguments;
    public List<float> arg = new List<float>();
    public float argument;
    public ProceduralMaterial mt_copy;
    float[] prop_values;
    private void Awake()
    {
        Debug.Log("Awaking");
        Object = GameObject.Find("Cube");
        foreach (ProceduralMaterial mt in Resources.LoadAll("Materials", typeof(ProceduralMaterial)))
        {
            Materials.Add(mt); //Костыль, связанный со спецификой Unity.
        }
        Object.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Bumped Diffuse"); //А это кусоек старого кода

        if (Materials == null)
        {
            Debug.Log("Materials is null");
        }
        if (Object == null)
        {
            throw new System.ArgumentNullException("Sp" + "here");
        }
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("Start of program;");
        doWindow0 = true;
        int i = 0;
        foreach (ProceduralMaterial m in Materials)
        {
            Debug.Log(m.name);
            buttonNames.Add(m.name);
        };

        // OnGUI();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, Screen.width / 6, Screen.height - 20));
        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        //scrollViewVector = GUI.BeginScrollView(new Rect(10, 10, Screen.width / 6, Screen.height - 20), scrollViewVector, new Rect(10, 10, Screen.width / 6, Screen.height*5));
        string[] bn = new string[buttonNames.Count()];
        for (int i = 0; i < buttonNames.Count(); i++)
        { bn[i] = buttonNames[i]; }
        button_selected = GUILayout.SelectionGrid(button_selected, bn, 1);
        GUILayout.EndScrollView();
        GUILayout.EndArea();
        //mt = Materials[button_selected];
        GUILayout.BeginArea(new Rect(Screen.width - (Screen.width / 6), 10, Screen.width / 6, Screen.height - 20));

        Object.GetComponent<Renderer>().sharedMaterial = Materials[button_selected];
        mt_proc = Object.GetComponent<Renderer>().sharedMaterial as ProceduralMaterial;
        //material_arguments.Clear();
        material_arguments = new List<ProceduralPropertyDescription>();
        material_arguments = mt_proc.GetProceduralPropertyDescriptions().Select(m => { return m; }).ToList();
        //prop_values = new float[material_arguments.Count()];
        //this.prop_values = new List<float>();
        //int ind = 0;
        GUILayout.BeginScrollView(Vector2.zero);
        foreach (ProceduralPropertyDescription desc in material_arguments)
        {
            Debug.Log(desc.GetType());
            if (desc.type == ProceduralPropertyType.Float)
            {
                //prop_values[ind] = GUILayout.HorizontalSlider(prop_values[ind], desc.minimum, desc.maximum);
                GUILayout.TextField(desc.name);
                mt_proc.SetProceduralFloat(desc.name, GUILayout.HorizontalSlider(mt_proc.GetProceduralFloat(desc.name), desc.minimum, desc.maximum));
                //ind++;
            }
            //else Debug.Log("There is no float");
        }
        GUILayout.EndScrollView();
        //foreach (var m in mt_proc.GetProceduralPropertyDescriptions()) { material_arguments.Add(m); Debug.Log(m.name); }
        //arg.Clear();
        //arg = new List<float>();
        //argument = GUILayout.HorizontalSlider(argument, 0, 1);
        //arg.Add(argument);
        //mt_proc.SetProceduralFloat("Age", argument);
        mt_proc.RebuildTextures();
        // Object.GetComponent<Renderer>().sharedMaterial = mt_proc;


        GUILayout.EndArea();
    }
}
