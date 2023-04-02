using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class Layout : MonoBehaviour
{
    public Item ItemPrefab;
    public Container ContainerPrefab;
    public GameObject BoardPrefab;

    private static readonly int _countContainer = 2;
    private static readonly int _containerSize = 4;
    private static readonly int _itemSize = 2;
    private static readonly int _itemCount = 2;
    private Item[,] _items = new Item[_itemCount * _countContainer, _itemCount * _countContainer];
    private List<Item> _itemsList = new List<Item>();
    public Item SelectedItem;

    public Item[,] Items => _items;

    public void SetSelectedItem(Item item) {

        // Highlight current rows and columns.
        this.SelectRowAndColumn(item);

        // Highlight current sector.
        //Transform containerTransform = item.gameObject.transform.parent;
        //int childCount = containerTransform.childCount;
        //for (int i = 0; i < childCount; i++) {
        //    Transform childTransform = containerTransform.GetChild(i);
        //    SpriteRenderer childRenderer = childTransform.gameObject.GetComponent<SpriteRenderer>();
        //    childRenderer.color = Color.blue;
        //}

        //// Highlight current item.

        //SelectedItem = item;
        //SpriteRenderer itemRenderer = item.gameObject.GetComponent<SpriteRenderer>();
        //itemRenderer.color = Color.green;
    }

    public void SelectRowAndColumn(Item item)
    {
        _itemsList.ForEach(Item =>
        {
            SpriteRenderer itemRenderer = Item.gameObject.GetComponent<SpriteRenderer>();
            if (Item.xIndex == item.xIndex || Item.yIndex == item.yIndex)
            {
                itemRenderer.color = Color.blue;
            }
            else 
            {
                itemRenderer.color = Color.white;
            }
            
        });
    }


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _countContainer; i++) 
        { 
            for(int j = 0; j < _countContainer; j++)
            {
                int containerX = (int)i * _containerSize;
                int containerY = (int)j * _containerSize;
                Container container = Instantiate(ContainerPrefab, new Vector2(containerX, containerY), Quaternion.identity);
                SpriteRenderer containerRenderer = container.gameObject.GetComponent<SpriteRenderer>();
                containerRenderer.size = new Vector2(_containerSize, _containerSize);
                
                for (int n = 0; n < _itemCount; n++)
                {
                    for (int m = 0; m < _itemCount; m++)
                    {
                        Item item = Instantiate(ItemPrefab, new Vector2(containerX - (int)_itemSize / 2 + n * _itemSize, containerY - (int)_itemSize / 2 + m * _itemSize), Quaternion.identity, container.transform);
                        SpriteRenderer itemRenderer = item.gameObject.GetComponent<SpriteRenderer>();
                        itemRenderer.size = new Vector2(_itemSize, _itemSize);
                        item.xIndex = i + j + n;
                        item.yIndex = i + j + m;

                        // set a back reference to layout.
                        item.Init(this);

                        _items[i + n, j + m] = item;
                        _itemsList.Add(item);
                    }
                }
            }
        }

        Vector2 center = new Vector2(_containerSize / 2, _containerSize / 2);

        GameObject board = Instantiate(BoardPrefab, center, Quaternion.identity);
        SpriteRenderer boardRenderer = board.GetComponent<SpriteRenderer>();
        boardRenderer.size = new Vector2(_containerSize * 2, _containerSize * 2);

        Camera.main.transform.position = new Vector3(_containerSize / 2, _containerSize / 2, -1);




        /*        GameObject obj = Instantiate(prefab);

                // Set the parent of the instantiated object to be this object
                obj.transform.SetParent(gameObject);

                // Get the RectTransform of the instantiated object
                RectTransform rectTransform = obj.GetComponent<RectTransform>();

                // Get the width of the parent RectTransform
                float parentWidth = GetComponent<RectTransform>().rect.width;

                // Set the size of the instantiated object based on the parent width
                float size = parentWidth * sizePercentage;
                rectTransform.sizeDelta = new Vector2(size, size);*/


        /*        gameobject square = new gameobject("square");
                spriterenderer squarerenderer = square.addcomponent<spriterenderer>();

                // create a new texture for the sprite
                texture2d squaretexture = new texture2d(1, 1);
                squaretexture.setpixel(0, 0, color.blue);
                squaretexture.apply();

                // set the sprite renderer's sprite to the new texture
                sprite squaresprite = sprite.create(squaretexture, new rect(0, 0, 1, 1), vector2.zero);
                squarerenderer.sprite = squaresprite;

                // set the square's size
                square.transform.localscale = new vector3(2, 2, 1);


                // create container game objects.
                for (int i = 0; i < 4; i++)
                {

                }*/
    }

    [MenuItem("MyMenu/Do Something")]
    static void setCameraPosition()
    {
        Vector2 center = new Vector2(1, 1);
        Camera.main.transform.position = center;
        Debug.Log("Doing Something...");
    }

    // Update is called once per frame
    void Update()
    {
        //Check if there is a mouse click
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
