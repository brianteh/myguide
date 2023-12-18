using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    List<chemical> reactant = new List<chemical>();

    //Cation
    public static chemical H_1 = new chemical("H", 1, "Hydrogen ion", "Colourless", "aq");
    static chemical Zn_2 = new chemical("Zn", 2, "Zinc ion", "Colourless", "aq");
    static chemical Al_3 = new chemical("Al", 3, "Aluminium ion", "Colourless", "aq");
    static chemical Pb_2 = new chemical("Pb", 2, "Lead(ii) ion", "Colourless", "aq");
    static chemical Mg_2 = new chemical("Mg", 2, "Magnesium ion", "Colourless", "aq");
    static chemical Ca_2 = new chemical("Ca", 2, "Calcium ion", "Colourless", "aq");
    static chemical Ag_1 = new chemical("Ag", 1, "Silver ion", "Colourless", "aq");
    static chemical Na_1 = new chemical("Na", 1, "Sodium ion", "Colourless", "aq");
    static chemical NH4_1 = new chemical("NH4", 1, "Zinc ion", "Colourless", "aq");
    static chemical AgNH32_1 = new chemical("Ag(NH3)2", 1, "Zinc ion", "Colourless", "aq");
    static chemical Cu_2 = new chemical("Cu", 2, "Copper(ii) ion", "Light Blue", "aq");
    static chemical CuOH2NH34 = new chemical("Cu(OH)2(NH3)4", 0, "Copper(ii) complex", "Dark Blue", "aq");
    static chemical Fe_2 = new chemical("Fe", 2, "Iron(ii) ion", "Green", "aq");
    static chemical Fe_3 = new chemical("Fe", 3, "Iron(iii) ion", "Yellow", "aq");

    public List<chemical> alkali = new List<chemical> { Zn_2, Pb_2, Na_1 };

    //Anion
    public static chemical OH_1 = new chemical("OH", -1, "Hydroxide", "Colourless", "aq");
    static chemical CO3_2 = new chemical("CO3", -2, "Carbonate", "Colourless", "aq");
    static chemical Cl_1 = new chemical("Cl", -1, "Chloride", "Colourless", "aq");
    static chemical Br_1 = new chemical("Br", -1, "Bromide", "Colourless", "aq");
    static chemical I_1 = new chemical("I", -1, "Iodide", "Colourless", "aq");
    static chemical NO3_1 = new chemical("NO3", -1, "Nitrate", "Colourless", "aq");
    static chemical NO2_1 = new chemical("NO2", -1, "Nitrite", "Colourless", "aq");
    static chemical SO4_2 = new chemical("SO4", -2, "Sulphate", "Colourless", "aq");
    static chemical SO3_2 = new chemical("SO3", -2, "Sulphite", "Colourless", "aq");
    static chemical AlOH4_1 = new chemical("Al(OH)4", -1, "Aluminium hydroxide", "Colourless", "aq");
    static chemical AlO2_1 = new chemical("AlO2", -1, "Aluminate", "Colourless", "aq");
    static chemical MnO4_1 = new chemical("MnO4", -1, "Manganate(vii) ion", "Purple", "aq");

    public List<chemical> acid = new List<chemical> { CO3_2, Cl_1, Br_1, I_1, NO3_1, NO2_1, SO4_2, SO3_2 };

    //Solid
    chemical ZnOH2 = new chemical("Zn(OH)2", 0, "Zinc hydroxide", "White", "s");
    //Pb(OH)2
    chemical MgOH2 = new chemical("Mg(OH)2", 0, "Magnesium hydroxide", "White", "s");
    chemical CaOH2 = new chemical("Ca(OH)2", 0, "Calcium hydoxide", "White", "s");
    chemical AlOH3 = new chemical("Al(OH)3", 0, "Aluminium hydoxide", "White", "s");
    /* , AgCl, BaSO4, BaSO3, CaCO3
        Blue: Cu(OH)2
        Green: Fe(OH)2
        Red - brown: Fe(OH)3
    */
    chemical AgCl = new chemical("AgCl", 0, "Silver Chloride", "White", "s");
    chemical AgBr = new chemical("AgBr", 0, "Silver Bromide", "Cream", "s");
    chemical AgI = new chemical("AgI", 0, "Silver Iodide", "Yellow", "s");

    chemical NH3 = new chemical("Zn2+", 0, "Zinc ion", "Colourless", "aq");
    static chemical H2O = new chemical("H2O", 0, "Water", "Colourless", "l");

    // Start is called before the first frame update
    void Start()
    {
        addAllReactable();

        addChemical(Cl_1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            addChemical(Ag_1);
        }
        if (Input.GetKeyDown("a"))
        {
            addChemical(AgCl);
        }

    }

    public void addChemical(chemical c)
    {
        bool react = false;
        string output = "";
        for (int i = 0; i < reactant.Count; i++)
        {
            if (c.reactable.ContainsKey(reactant[i]))
            {
                List<chemical> product = (List<chemical>) c.reactable[reactant[i]];
                reactant.Remove(reactant[i]);
                foreach(chemical p in product)
                {
                    if (!reactant.Contains(p))
                    {
                        reactant.Add(p);
                        output = output + " " + p.name;
                    }
                }
                react = true;
            }
            else output = output + " " + reactant[i].name;
        }
        if (!react)
        {
            if (!reactant.Contains(c))
            {
                reactant.Add(c);
                output = output + " " + c.name;
            }
        }

        Debug.Log(output);
    }

    void addReactable(chemical c1, chemical c2, List<chemical> product)
    {
        c1.reactable.Add(c2, product);
        c2.reactable.Add(c1, product);
    }

    void addAllReactable()
    {
        addReactable(H_1, OH_1, new List<chemical> { H2O });
        addReactable(Mg_2, OH_1, new List<chemical> { MgOH2 });
        addReactable(Ca_2, OH_1, new List<chemical> { CaOH2 });
        addReactable(Al_3, OH_1, new List<chemical> { AlOH3 });
        addReactable(Ag_1, Cl_1, new List<chemical> { AgCl });
        addReactable(Ag_1, Br_1, new List<chemical> { AgBr });
        addReactable(Ag_1, I_1, new List<chemical> { AgI });
    }

    List<chemical> getAcid()
    {
        return acid;
    }
}

public class chemical
{
    public string code;
    public int charge;
    public string name;
    public string color;
    public string state;
    public Hashtable reactable = new Hashtable();

    public chemical(string code, int charge, string name, string color, string state)
    {
        this.code = code;
        this.charge = charge;
        this.name = name;
        this.color = color;
        this.state = state;
    }
}
