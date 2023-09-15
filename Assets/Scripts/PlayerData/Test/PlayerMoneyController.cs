using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoneyController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            GameManager.Instance.PlayerMoney.EarnMoney(Enum_MoneyType.Gold, Money.ReturnMoney(3, 100));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.PlayerMoney.SpendMoney(Enum_MoneyType.Gold, Money.ReturnMoney(3, 100));
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            GameManager.Instance.PlayerMoney.EarnMoney(Enum_MoneyType.Crystal, Money.ReturnMoney(3, 100));
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.Instance.PlayerMoney.SpendMoney(Enum_MoneyType.Crystal, Money.ReturnMoney(3, 100));
        }
    }
}
