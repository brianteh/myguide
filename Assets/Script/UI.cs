using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public test test;
    public TMPro.TMP_Dropdown stateOption;
    public TMPro.TMP_Dropdown chemicalOption;
    public Button addButton;

    // Start is called before the first frame update
    void Start()
    {
        iniChemicalOption();
        stateOption.onValueChanged.AddListener(delegate {
            iniChemicalOption();
        });

        addButton.onClick.AddListener(delegate
        {
            if (stateOption.value == 0)
            {
                test.addChemical(test.H_1);
                test.addChemical(test.acid[chemicalOption.value]);
            }
            else if (stateOption.value == 1)
            {
                test.addChemical(test.OH_1);
                test.addChemical(test.alkali[chemicalOption.value]);
            }
        });

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void iniChemicalOption()
    {
        chemicalOption.ClearOptions();
        if (stateOption.value == 0)
        {
            List<string> acidName = new List<string>();
            foreach (chemical acid in test.acid)
            {
                acidName.Add(acid.code);
            }
            chemicalOption.AddOptions(acidName);
        }
        else if (stateOption.value == 1)
        {
            List<string> alkaliName = new List<string>();
            foreach (chemical alkali in test.alkali)
            {
                alkaliName.Add(alkali.code);
            }
            chemicalOption.AddOptions(alkaliName);
        }
    }
}
