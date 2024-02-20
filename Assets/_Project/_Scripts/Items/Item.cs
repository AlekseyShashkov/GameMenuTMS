using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MyButton
{
    [SerializeField] private static int _activeID = int.MinValue;
    
    [SerializeField] private TextMeshProUGUI _nameTMP = null, 
                                             _informationTMP = null, 
                                             _costTMP = null;

    [SerializeField] private Sprite _icon = null;
    [SerializeField] private string _name = string.Empty;
    [SerializeField] private string _information = string.Empty;
    [SerializeField] private int _cost = 0;
    [SerializeField] private int _id = int.MinValue;

    public TextMeshProUGUI NameTMP { get => _nameTMP; set => _nameTMP = value; }
    public TextMeshProUGUI InformationTMP { get => _informationTMP; set => _informationTMP = value; }
    public TextMeshProUGUI CostTMP { get => _costTMP; set => _costTMP = value; }
    
    public Sprite Icon { get => _icon; set => _icon = value; }
    public string Name { set => _name = value; }
    public string Information { set => _information = value; }
    public int Cost { get => _cost; set => _cost = value; }
    public int ID { set => _id = value; }

    public int ActiveID { get => _activeID; set => _activeID = value; }

    public void GetItemInformation()
    {
        _activeID = _id;

        _nameTMP.SetText($"{_name}");
        _informationTMP.SetText($"{_information}");
        _costTMP.SetText($"{_cost}<sprite=0>");
        
        GetComponent<Image>().color = Color.red;
    }
}