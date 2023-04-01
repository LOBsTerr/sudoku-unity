using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Layout : MonoBehaviour
{
    public GameObject nodePrefab;
    public GameObject containerPrefab;
    public GameObject boardPrefab;

    private static readonly int _countContainer = 2;
    private static readonly int _containerSize = 4;
    private static readonly int _itemSize = 2;
    private static readonly int _itemCount = 2;
    private GameObject[,] _items = new GameObject[_itemCount * _countContainer, _itemCount * _countContainer];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _countContainer; i++) 
        { 
            for(int j = 0; j < _countContainer; j++)
            {
                int containerX = i * _containerSize;
                int containerY = j * _containerSize;

                GameObject container = Instantiate(containerPrefab, new Vector2(containerX, containerY), Quaternion.identity);
                SpriteRenderer containerRenderer = container.GetComponent<SpriteRenderer>();
                containerRenderer.size = new Vector2(_containerSize, _containerSize);
                for (int n = 0; n < _itemCount; n++)
                {
                    for (int m = 0; m < _itemCount; m++)
                    {
                        GameObject node = Instantiate(nodePrefab, new Vector2(containerX - _itemSize / 2 + n * _itemSize, containerY - _itemSize / 2 + m * _itemSize), Quaternion.identity, container.transform);
                        SpriteRenderer nodeRenderer = node.GetComponent<SpriteRenderer>();
                        nodeRenderer.size = new Vector2(_itemSize, _itemSize);
                        //_items[i + n, j + m] = node;
                    }
                }
            }
        }

        Vector2 center = new Vector2(_containerSize / 2, _containerSize / 2);

        GameObject board = Instantiate(boardPrefab, center, Quaternion.identity);
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
        
    }
}
