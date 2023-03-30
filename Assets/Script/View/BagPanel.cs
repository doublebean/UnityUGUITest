using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPanel : ViewPanel
{
    private List<Article> articles = new List<Article>();//初始化

    private List<GameObject> articleItems = new List<GameObject>();//用一个列表来存实例化了的物品

    public MenuPanel menuPanel;
    public BagThings[] bagThings;
    public GameObject articleItemPrefab;//公共的一个预制体

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
    //初始化物品数据
    public void InitArticleData()
    {
        articles.Add(new Article("锤子", "Sprites/hammer", ArticleType.Weapon, 3));
        articles.Add(new Article("剑", "Sprites/sword", ArticleType.Weapon, 2));
        articles.Add(new Article("书", "Sprites/book", ArticleType.fangju, 1));
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

    //加载数据
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
        HideAllItem();//加载之前先清空之前的情况
        for (int i = 0; i< articles.Count;i++)
        {
            if (articles[i].articleType == articleType)
            {
                GetBagThings().SetArticleItem(LoadArticleItem(articles[i]));
            }
        }
        
    }
    //加载一个物品
    public ArticleItem LoadArticleItem(Article article)
    {
        
        GameObject obj = GetArticleItem();//实例化预制体
        ArticleItem articleItem = obj.GetComponent< ArticleItem>();//获取对应的组件
        articleItem.SetArticle(article);//将对应数据设置上去

        return articleItem;
    }
    //获取一个物品
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
    //清理 隐藏 物品
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
    #region  点击事件

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
