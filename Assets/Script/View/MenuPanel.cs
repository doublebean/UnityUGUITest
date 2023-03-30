using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : ViewPanel
{
    public BagPanel bagPanel;

    public void OnBtnBagPanelClick()
    {
        bagPanel.Show();
        this.Hide(); //��ǰ��������
    }

    public override void Hide()
    {
        //base.Hide();
        transform.GetComponent<Animator>().SetBool("isShow",false);
    }

    public override void Show()
    {
        transform.GetComponent<Animator>().SetBool("isShow", true);
    }
}
