using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{   public Vector3 mousePos;
    public Camera mainCamera;
	public Vector3 mousePosWorld;
	public Vector2 mousePosWorld2D;
	public GameObject player;
	public GameObject book;
	public Vector2 targetPos;
	public float speed;
	public bool isMoving;
	
	
	public int stones = 0;
	public bool apple = false;
	public int appleNumber;
	public bool ruby = false;
	public int rubyNumber;
	RaycastHit2D hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		
		
		
		
		
		
		
      //Ist Maustaste gedrückt?
		if(Input.GetMouseButtonDown(0))
		{
			//Maustaste wurde erkannt
			print("Maustaste wurde gedrückt");
			//Mausposition auslesen
			mousePos = Input.mousePosition;
			//Mausposition auf Konsole ausgeben
			print ("Screen Space:" + mousePos);
			//Koordinaten von Screenspace nach World Space umwandeln
			mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
			//World Space Koordinaten ausgeben
			print("World Space:" + mousePosWorld);
			//Umwandlung von Vector3 in Vector2
			mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
			//Raycast2D hit abspeichern
			hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);
			//Überprüfe ob hit einen Collider beinhaltet
			
			if(hit.collider !=null)
			{
				print("Objekt mit Collider wurde getroffen!");
				//Ausgabe des getroffenen game objects
				print("Name:" + hit.collider.gameObject.tag);
				//Abfrage ob Ground
				
				if(hit.collider.gameObject.tag == "Ground")
				{
				//Position Spieler verändern
				//player.transform.position = hit.point;
				targetPos = hit.point;
				//isMoving wahr, damit sich Spieler bewegt
				isMoving = true;
				//Überprüfe ob Sprite Flip notwendig ist
				CheckSpriteFlip();
				}
				else if(hit.collider.gameObject.tag == "Book")
				{
					
					print("Buch angeklickt");
					
				}
				else if(hit.collider.gameObject.tag == "Apple")
				{
					//Apfel erkannt
					//Apfel wird deaktiviert
					hit.collider.gameObject.SetActive(false);
					//Apfel speichern
					apple = true;
					stones = stones + 1;
					appleNumber = stones;
				}
				else if(hit.collider.gameObject.tag == "Ruby")
				{
					//Ruby erkannt
					//Ruby wird deaktiviert
					hit.collider.gameObject.SetActive(false);
					//Ruby speichern
					ruby = true;
					stones = stones + 1;
					rubyNumber = stones;
				}
			}
			else
			{
				print("Kein Collider erkannt!");
			}
			
		}	
			
			if(Input.GetMouseButtonDown(1))
		{
			//Maustaste wurde erkannt
			print("Maustaste 2 wurde gedrückt");
			//Mausposition auslesen
			mousePos = Input.mousePosition;
			//Mausposition auf Konsole ausgeben
			print ("Screen Space:" + mousePos);
			//Koordinaten von Screenspace nach World Space umwandeln
			mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
			//World Space Koordinaten ausgeben
			print("World Space:" + mousePosWorld);
			//Umwandlung von Vector3 in Vector2
			mousePosWorld2D = new Vector2(mousePosWorld.x, mousePosWorld.y);
			//Raycast2D hit abspeichern
			hit = Physics2D.Raycast(mousePosWorld2D, Vector2.zero);
			//Überprüfe ob hit einen Collider beinhaltet
			if(hit.collider !=null)
			{
				print("Objekt mit Collider wurde getroffen!");
				//Ausgabe des getroffenen game objects
				print("Name:" + hit.collider.gameObject.tag);
				//Abfrage ob Ground
			
				
				if(hit.collider.gameObject.tag == "Book")
				{
					
					print("Guck ma ein" + hit.collider.gameObject.tag);
					
				}
				else if(hit.collider.gameObject.tag == "Apple")
				{
					print("Guck ma ein" + hit.collider.gameObject.tag);
				}
				else if(hit.collider.gameObject.tag == "Ruby")
				{
					print("Guck ma ein" + hit.collider.gameObject.tag);
				}
			}
			else
			{
				print("Kein Collider erkannt!");
			}
		}
        
    }
    private void FixedUpdate()
	{   //Überprüfe ob Spieler sich bewegt
	    if(isMoving)
		{
		 //Spieler an Zielort befördern
		 player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed);
		 //Ist der Spieler am Zielort?
		 if(player.transform.position.x == targetPos.x && player.transform.position.y == targetPos.y)
		 {
			//Spieler am Zielort
            isMoving = false;			
		 }
			 
		 
		}
		
	}
    void CheckSpriteFlip()
	{
		if(player.transform.position.x > targetPos.x)
		{
			//Nach links blicken
			player.GetComponent<SpriteRenderer>().flipX = true;
		}
		else
		{
			//Nach rechts blicken
			player.GetComponent<SpriteRenderer>().flipX = false;
		}
	}

}
