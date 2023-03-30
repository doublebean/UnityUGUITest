using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : ViewPanel
{
    private List<Article> articles = new List<Article>();//��ʼ��

    private List<GameObject> articleItems = new List<GameObject>();//��һ���б�����ʵ�����˵���Ʒ

    public MenuPanel menuPanel;
    public BagThings[] bagThings;
    public GameObject articleItemPrefab;//������һ��Ԥ����

    private void Awake()
    {
        InitArticleData();
        bagThings = transform.GetComponentsInChildren<BagThings>();
    }

    private void Start()
    {
        LoadArticleData();
    }
    public override void Hide()
    {
        
        base.Hide();
        menuPanel.Show();
        
    }

    public override void Show()
    {
        Invoke("showExc", 1);
    }

    public void showExc()
    {
        base.Show();
    }
    //��ʼ����Ʒ����
    public void InitArticleData()
    {
        articles.Add(new Article("����", "Sprites/hammer", ArticleType.Weapon, 3));
        articles.Add(new Article("��", "Sprites/sword", ArticleType.Weapon, 2));
        articles.Add(new Article("��", "Sprites/book", ArticleType.fangju, 1));
    }

    public BagThings GetBagThings()
    {
        for(int i = 0; i < bagThings.Length; i++)
        {
            if (bagThings[i].ArticleItem == null )
            {
                return bagThings[i];    
            }
        }
        return null;
    }

    //��������
    public void LoadArticleData()
    {
        HideAllItem();
        for (int i =  0; i < articles.Count; i++)
        {
            GetBagThings().SetArticleItem(LoadArticleItem(articles[i]));

        }
    }

    public void LoadArticleData(ArticleType articleType)
    {
        HideAllItem();//����֮ǰ�����֮ǰ�����
        for (int i = 0; i< articles.Count;i++)
        {
            if (articles[i].articleType == articleType)
            {
                GetBagThings().SetArticleItem(LoadArticleItem(articles[i]));
            }
        }
        
    }
    //����һ����Ʒ
    public ArticleItem LoadArticleItem(Article article)
    {
        
        GameObject obj = GetArticleItem();//ʵ����Ԥ����
        ArticleItem articleItem = obj.GetComponent< ArticleItem>();//��ȡ��Ӧ�����
        articleItem.SetArticle(article);//����Ӧ����������ȥ

        return articleItem;
    }
    //��ȡһ����Ʒ
    public GameObject GetArticleItem()
    {
        for(int i = 0;i < articleItems.Count;i++)
        {
            if (articleItems[i].activeSelf == false)
            {
                articleItems[i].SetActive(false);
                return articleItems[i];
            }
        }
       return GameObject.Instantiate(articleItemPrefab);
    }
    //���� ���� ��Ʒ
    public void HideAllItem()
    {
        for(int i = 0;i < bagThings.Length ; i++) 
        {
            if (bagThings[i].ArticleItem != null)
            {
                bagThings[i].ClearBagthings();
            }
        }
    }
    #region  ����¼�

    public void OnAllTogClick(bool v) 
    {
        if(v == true)
        {
            LoadArticleData();
        }
    }
    public void OnWeaponTogClick(bool v) 
    {
        if (v == true)
        {
            LoadArticleData(ArticleType.Weapon);
        }
    }
    public void OnFangjuTogClick(bool v)
    {
        if (v == true)
        {
            LoadArticleData(ArticleType.fangju);
        }
    }

    #endregion
}
