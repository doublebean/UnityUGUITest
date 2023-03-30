using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArticleItem : MonoBehaviour
{

    private Image articleSprite;
    private TextMeshProUGUI number;
    private Article article;



    private void Awake()
    {
        articleSprite = transform.GetComponent<Image>();

        number = transform.Find("Item_Count").GetComponent<TextMeshProUGUI>();
    }

    public void SetArticle(Article article)
    {  
        this.article = article;
        articleSprite.sprite = Resources.Load<Sprite>(article.spritePath); 
        number.text = article.count.ToString();
    }
}
