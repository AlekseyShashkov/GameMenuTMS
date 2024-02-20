using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    private const int MaxName = 100;
    private const int MaxCost = 200;

    [SerializeField] private Sprite[] _sprites = null;
    [SerializeField] private Transform _viewContent = null;

    [SerializeField] private Item _item = null;
    [SerializeField] private int _itemCount = 32;
    [SerializeField] private int _money = 1000;
    [SerializeField] private TextMeshProUGUI _nameTMP = null, _infoTMP = null, 
                                             _costTMP = null, _moneyTMP = null;

    [SerializeField] private MyButton _buy = null;  

    private readonly List<Item> _items = new();  

    void Awake()
    {
        for (int i = 0; i < _itemCount; ++i)
        {
            Sprite sprite = _sprites[Random.Range(0, _sprites.Length - 1)];
            string name = $"Name{Random.Range(0, MaxName)}{i}";
            int cost = Random.Range(1, MaxCost);

            _item.ID = i;
            _item.Name = name;
            _item.Information = $"Special info #{i}";
            _item.Cost = cost;
            _item.Icon = sprite;         

            _item.NameTMP = _nameTMP.GetComponent<TextMeshProUGUI>();
            _item.InformationTMP = _infoTMP.GetComponent<TextMeshProUGUI>();
            _item.CostTMP = _costTMP.GetComponent<TextMeshProUGUI>();

            Item item = Instantiate(_item, _viewContent);

            var itemIcon = item.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = _item.Icon;

            item.AddListener(item.GetItemInformation);

            _items.Add(item);
        }

        _buy.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        for (int i = 0; i < _items.Count; ++i)
        {
            if (i == _items[i].ActiveID)
            {
                if(_items[i].Cost <= _money)
                {   
                    _money -=_items[i].Cost;
                    
                    _items[i].ActiveID = int.MinValue;
                    _items[i].gameObject.SetActive(false);

                    _items[i].NameTMP.SetText("");
                    _items[i].InformationTMP.SetText("");
                    _items[i].CostTMP.SetText("0<sprite=0>");

                    _moneyTMP.SetText($"{_money}<sprite=0>");
                }
            }
        }
    }
}