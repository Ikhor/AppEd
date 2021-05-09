using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabelFiller : MonoBehaviour
{
    public Text UItext;
    public string defaultText;
    public Simulator simulator;

    public Simulator.Color color;

    public Toggle[] choices;

    public string selected;

    // Start is called before the first frame update
    void Start()
    {
        simulator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Simulator>();
        UItext = GetComponent<Text>();
        defaultText = defaultText.Replace("{nome}", "{nome}" +"\n");
    }

    // Update is called once per frame
    void Update()
    {
        string textToShow = defaultText;
        switch (color) {
            case Simulator.Color.Cinza:
                foreach (Toggle t in choices)
                {
                    if (t.isOn)
                    {
                        if (t.name.Equals("Nao"))
                        {
                            textToShow = "Sem dosagem à aplicar";
                        }
                        else
                        {
                            textToShow = textToShow.Replace("{dosagem}", simulator.cinza.ToString("#.##"));
                        }
                    }                    
                }                
                break;
            case Simulator.Color.Azul:
                foreach (Toggle t in choices)
                {
                    if (t.isOn) {
                        textToShow = textToShow.Replace("{nome}", t.name);
                        if (t.name.Equals("Alfentanil"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "500");
                        }
                        else
                        {
                            textToShow = textToShow.Replace("{quantidade}", "50");
                        }
                        selected = t.name;
                    }
                }
                textToShow = textToShow.Replace("{dosagem}", simulator.azul.ToString("#.##"));
                break;
            case Simulator.Color.Amarelo:
                foreach (Toggle t in choices)
                {
                    if (t.isOn)
                    {
                        textToShow = textToShow.Replace("{nome}", t.name);
                        if (t.name.Equals("Etomidato"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "2");
                            textToShow = textToShow.Replace("{dosagem}", simulator.etomidato.ToString("#.##"));
                        }
                        else if (t.name.Equals("Cetamina"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "50");
                            textToShow = textToShow.Replace("{dosagem}", simulator.cetamina.ToString("#.##"));
                        }
                        else if (t.name.Equals("Midazolan"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "Ampola de 1");
                            textToShow = textToShow.Replace("{dosagem}", simulator.midazolan.ToString("#.##"));

                            textToShow += defaultText;
                            textToShow = textToShow.Replace("{nome}", "");
                            textToShow = textToShow.Replace("{quantidade}", "Ampola de 5");
                            textToShow = textToShow.Replace("{dosagem}", simulator.midazolanM5.ToString("#.##"));
                        }
                        selected = t.name;
                    }
                }
                break;
            case Simulator.Color.Vermelho:
                foreach (Toggle t in choices)
                {
                    if (t.isOn)
                    {
                        textToShow = defaultText.Replace("{nome}", t.name);
                        selected = t.name;

                        if (t.name.Equals("Succinilcolina"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "100mg + 10 ml AD");
                            textToShow = textToShow.Replace("{dosagem}", simulator.vermelho.ToString("#.##"));
                        }
                        else if (t.name.Equals("Rocurönio"))
                        {
                            textToShow = textToShow.Replace("{quantidade}", "50 mg/ml");
                            textToShow = textToShow.Replace("{dosagem}", simulator.vermelho.ToString("#.##"));
                        }
                    }
                }
                textToShow = textToShow.Replace("{dosagem}", simulator.vermelho.ToString());
                break;
        }
        UItext.text = textToShow;
    }
}
