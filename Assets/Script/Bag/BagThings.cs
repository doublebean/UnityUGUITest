using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagThings : MonoBehaviour
{
    private ArticleItem articleItem;

    public ArticleItem ArticleItem
    {
        get { return articleItem; }
    }
    public void SetArticleItem(ArticleItem articleItem)
    {
        this.articleItem = articleItem;
        //

        this.articleItem.transform.SetParent(transform);
        //
        this.articleItem.transform.localPosition = Vector3.zero;
        //
        this.articleItem.transform.localScale = Vector3.one;
        //
        this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2 (5, 5);
        this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2 (-5, -5);
    }
    
    public void ClearBagthings()
    {
        articleItem.gameObject.SetActive(false);
        articleItem.transform.SetParent(null);
        articleItem = null;
    }
}
