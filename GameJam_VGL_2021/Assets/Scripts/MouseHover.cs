using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MouseHover : MonoBehaviour
{
    [SerializeField]
    public GraphicRaycaster gr;
    PointerEventData m_PointerEventData;
    [SerializeField] EventSystem m_EventSystem;
    [SerializeField] RectTransform canvasRect;
    TMPro.TextMeshProUGUI tmp;
    List<RaycastResult> results;
    // Start is called before the first frame update
    void Start()
    {
        // change default font styles
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        // Fetch the raycaster to gameobject (Canvas)
        gr = GetComponent<GraphicRaycaster>();
        //Set up the new Pointer Event
        m_PointerEventData = new PointerEventData(m_EventSystem);
        //Set the Pointer Event Position to that of the mouse position
        m_PointerEventData.position = Input.mousePosition;
    }
    void RefreshAllTMProUGUIObjects()
    {
        TextMeshProUGUI[] objs = Resources.FindObjectsOfTypeAll(typeof(TextMeshProUGUI)) as TextMeshProUGUI[];

        for (int o = 0; o < objs.Length; o++)
        {
            objs[o].SetAllDirty();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Create the PointerEventData with null for the EventSystem
            PointerEventData ped = new PointerEventData(null);
            //Set required parameters, in this case, mouse position
            ped.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            gr.Raycast(ped, results);

            if (results.Count > 0)
            {
                Debug.Log("hit " + results[0].gameObject.name);
                if (results[0].gameObject.name == "Start Game")
                {
                    SceneManager.LoadScene("Main");
                }

            }

        }
    }
}
