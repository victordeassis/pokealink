using UnityEngine;
using UnityEngine.UI;

public class PokeButtonBehavior : MonoBehaviour
{

    [SerializeField]
    private Button pokeButton;

    [SerializeField]
    private Text pokeALinkText;

    [SerializeField]
    private Text thisIsNotALinkText;

    [SerializeField]
    private Sprite ocarinaLink;

    [SerializeField]
    private Sprite ganon;

    float probabilityOfChangeSprite;  


    private void Start()
    {
        InvokeRepeating("ChangeSprite", 0, 1.0f);
    }


    // Update is called once per frame
    void Update()
    {
        pokeButton.transform.Rotate(0, 0, -.5f);
    }


    void ChangeSprite()
    {
        
        probabilityOfChangeSprite = Random.Range(0, 1001);

        // Validates if the game already began
        if (!pokeALinkText.IsActive() && !thisIsNotALinkText.IsActive())
        {

            if (probabilityOfChangeSprite > 800)
            {
                pokeButton.image.sprite = ganon;
            }
            else
            {
                // TODO: Everytime that it is Link, bump it to make it juicy
                pokeButton.image.sprite = ocarinaLink;
            }
        }
    }
}
