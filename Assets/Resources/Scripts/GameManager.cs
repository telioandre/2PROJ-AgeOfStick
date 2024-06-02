using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;
    public int id;
    public bool movementAllowed = true;
    public int life;
    public int attack;
    private Player _player;
    public int troopLevel;
    public float buildTime;
    public float attackTime;
    private Casern _casern;
    public int maxLife;
    public int troopId;
    public string uniqueId;
    public List<int> attackRange; 
    public bool isAttacking;


    private List<int> _troop1dropsXp;
    private List<int> _troop2dropsXp;
    private List<int> _troop3dropsXp;
    private List<int> _troop4dropsXp;

    private List<int> _troop1drops;
    private List<int> _troop2drops;
    private List<int> _troop3drops;
    private List<int> _troop4drops;

    private List<int> _troop1dropsRange;
    private List<int> _troop2dropsRange;
    private List<int> _troop3dropsRange;
    private List<int> _troop4dropsRange;
    private Animator _animator;
    public Image health; 
    private int _enemyNumber; 
    
    /*
     * This start method is used to set up every drop in terms of Xp and Money, and also the Range for each one.
     * The attack range of each troop is initialized here.
     * Other parameters such as the Rigibody and the Animator are set up.
     */
    private void Start()
    {
        _troop1dropsXp = new List<int> { 190, 200, 210, 220, 230, 240 };
        _troop2dropsXp = new List<int> { 200, 210, 220, 230, 240, 250 };
        _troop3dropsXp = new List<int> { 220, 230, 240, 250, 260, 270 };
        _troop4dropsXp = new List<int> { 250, 260, 270, 280, 290, 300 };

        _troop1drops = new List<int> { 2, 8, 17, 32, 75, 150 };
        _troop2drops = new List<int> { 1, 3, 13, 25, 60, 130 };
        _troop3drops = new List<int> { 4, 9, 19, 34, 85, 175 };
        _troop4drops = new List<int> { 6, 11, 20, 40, 100, 195 };

        _troop1dropsRange = new List<int>{ 2, 4, 4, 8, 20, 25 };
        _troop2dropsRange = new List<int> { 1, 4, 4, 10, 20, 30 };
        _troop3dropsRange = new List<int> { 2, 6, 6, 11, 25, 20 };
        _troop4dropsRange = new List<int> { 6, 6, 15, 20, 30, 45 };

        attackRange = new List<int> { 80, 180, 90, 90, 200};

        rb2d = GetComponent<Rigidbody2D>(); 
        _animator = GetComponent<Animator>();
        isAttacking = false;
        if (_animator != null)
        {
            _animator.SetFloat("attackTime", attackTime);
        }
    }

    /*
     * Update method to display dynamically the troop's life points.
     */
    private void Update()
    {
        health.fillAmount = (float)life / maxLife;
    }

    /*
     * This method will create RayCast for each troop depending on his id and his range.
     * When an opponent's troop or the opponent's castle will be detected in the Raycast, it will start a coroutine.
     */
    void FixedUpdate()
    {
        RaycastHit2D[] hits;
        RaycastHit2D hitCastle;

        int attackRangeOfLevel = attackRange[troopId - 1];
        for (int i = 0; i < troopLevel; i++)
        {
            attackRangeOfLevel = Mathf.RoundToInt(attackRangeOfLevel * 1.2f);
        }
        print(attackRangeOfLevel);
        if (id == 1)
        {
            hits = Physics2D.RaycastAll(rb2d.position + new Vector2(1, 0) * 50, new Vector2(1, 0), attackRangeOfLevel);

            if (hits.Length > 0)
            {
                RaycastHit2D firstHit = default;

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.CompareTag(gameObject.tag) && firstHit == default && hits[i].collider.gameObject.GetComponent<GameManager>().id != id)
                    {
                        firstHit = hits[i];

                        if (!isAttacking)
                        {
                            StartCoroutine(AttackPlayer(firstHit.collider.gameObject.GetComponent<GameManager>(), rb2d, _player, firstHit.collider.gameObject.GetComponent<GameManager>()._player));
                        }
                    }
                }
            }

            hitCastle = Physics2D.Raycast(rb2d.position + new Vector2(1, 0) * 50, new Vector2(1, 0), 200);

            if (hitCastle.collider != null && hitCastle.collider.CompareTag("player 2"))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
                _animator.SetTrigger("attack");
            }

            if (movementAllowed)
            {
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            }
        }
        else if (id == 2)
        {
            hits = Physics2D.RaycastAll(rb2d.position + new Vector2(-1, 0) * 50, new Vector2(-1, 0), attackRangeOfLevel);

            if (hits.Length > 0)
            {
                RaycastHit2D firstHit = default;

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.CompareTag(gameObject.tag) && firstHit == default && hits[i].collider.gameObject.GetComponent<GameManager>().id != id)
                    {
                        firstHit = hits[i];

                        if (!isAttacking)
                        {
                            StartCoroutine(AttackPlayer(firstHit.collider.gameObject.GetComponent<GameManager>(), rb2d, _player, firstHit.collider.gameObject.GetComponent<GameManager>()._player));
                        }
                    }
                }
            }

            hitCastle = Physics2D.Raycast(rb2d.position + new Vector2(-1, 0) * 50, new Vector2(-1, 0), 200);

            if (hitCastle.collider != null && hitCastle.collider.CompareTag("player 1"))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
                _animator.SetTrigger("attack");
            }

            if (movementAllowed)
            {
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            }
        }
    }

    /*
     * This method is called when the process of the casern is done, it will set every stats of the player depending on the playerId and the troopId send.
     * A unique Id will be given to recognize it on the list of troops of the player.
     * The troop stats will be improve depending of the troop level associated and the age of the player.
     * When everything is done, it will Invoke the EndBuild method to spawn the troop with the correct build time.
     */
    public void SetPlayer(int playerId, int newTroopId)
    {
        id = playerId;
        troopId = newTroopId;
        uniqueId = System.Guid.NewGuid().ToString();
        _casern = GameObject.Find("Casern").GetComponent<Casern>();
        if (id == 1)
        {
            _player = GameObject.Find("Castle 1").GetComponent<Player>();
        }
        else
        {
            _player = GameObject.Find("Castle 2").GetComponent<Player>();
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        char troopName = name[6];
        int troopNumber = int.Parse(troopName.ToString());
        switch (troopNumber)
        {
            case 1:
                troopLevel = _player.troop1Level;
                break;

            case 2:
                troopLevel = _player.troop2Level;
                break;

            case 3:
                troopLevel = _player.troop3Level;
                break;

            case 4:
                troopLevel = _player.troop4Level;
                break;
        }

        if (troopId != 5)
        {
            for (int i = 1; i < _player.GetAge(); i++)
            {
                life = Mathf.RoundToInt(life * 1.75f);
                speed = Mathf.RoundToInt(speed * 1.05f);
                attack = Mathf.RoundToInt(attack * 1.65f);
                buildTime = Mathf.RoundToInt(buildTime * 1.25f);
                attackTime *= (float)0.95;
            }
        }
        for (int i = 0; i < troopLevel; i++)
        {
            attack = Mathf.RoundToInt(attack * 1.3f);
        }
        maxLife = life;
        Invoke(nameof(Endbuild), buildTime);
    }
    
    /*
     * This method will end the troop creation process.
     * It will spawn the troop depending on the other troops with the same id localization to not mess it up.
     */
    private void Endbuild()
    {
        RaycastHit2D[] hitsWidth;
        hitsWidth = Physics2D.RaycastAll(new Vector2(250, 500), Vector2.right, 5000);
        if (id == 1)
        {
            RaycastHit2D[] hitsHeight;

            hitsHeight = Physics2D.RaycastAll(new Vector2(-250, 300), new Vector2(0, 1), 2000000);


            int countWidth = 0;
            if (hitsHeight.Length == 0)
            {
                foreach (var hit in hitsWidth)
                {
                    if (id == 1)
                    {
                        countWidth++;
                    }
                }
            }
            
            int totalHits = hitsHeight.Length + countWidth;

            transform.position = new Vector2(-250, 1000 + 2000 * totalHits);

            _casern.isForming1 = false;
        }
        else if (id == 2)
        {
            RaycastHit2D[] hitsHeight;

            hitsHeight = Physics2D.RaycastAll(new Vector2(5200, 300), new Vector2(0, 1), 2000000);
            
            int countWidth = 0;
            if (hitsHeight.Length == 0)
            {
                foreach (var hit in hitsWidth)
                {
                    if (id == 2)
                    {
                        countWidth++;
                    }
                }
            }

            int totalHits = hitsHeight.Length + countWidth;
            
            transform.position = new Vector2(5200, 1000 + 1000 * totalHits);

            _casern.isForming2 = false;
        }
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    /*
     * Method that return true if a troop is plan to be super effective on the other when an attack process is in progress.
     */
    public bool SuperEffective(int ally, int enemy)
    {
        if (ally == enemy + 1 || (ally == 4 && enemy == 1))
        {
            return true;
        }
        return false;
    }

    /*
     * This method will drop money and xp for both player depending on which troop is killed.
     */
    public void DropRewards(int troop, Player ally, Player enemy)
    {
        switch (troop)
        {
            case 1:

                ally.AddMoney(_troop1drops[_player.GetAge() - 1] + _troop1dropsRange[_player.GetAge() - 1]);
                ally.AddXp(_troop1dropsXp[_player.GetAge() - 1]);
                enemy.AddMoney((_troop1drops[_player.GetAge() - 1] + _troop1dropsRange[_player.GetAge() - 1]) / 2);
                enemy.AddXp(_troop1dropsXp[_player.GetAge() - 1] / 2);
                break;

            case 2:

                ally.AddMoney(_troop2drops[_player.GetAge() - 1] + _troop2dropsRange[_player.GetAge() - 1]);
                ally.AddXp(_troop2dropsXp[_player.GetAge() - 1]);
                enemy.AddMoney((_troop2drops[_player.GetAge() - 1] + _troop2dropsRange[_player.GetAge() - 1]) / 2);
                enemy.AddXp(_troop2dropsXp[_player.GetAge() - 1] / 2);
                break;

            case 3:

                ally.AddMoney(_troop3drops[_player.GetAge() - 1] + _troop3dropsRange[_player.GetAge() - 1]);
                ally.AddXp(_troop3dropsXp[_player.GetAge() - 1]);
                enemy.AddMoney((_troop3drops[_player.GetAge() - 1] + _troop3dropsRange[_player.GetAge() - 1]) / 2);
                enemy.AddXp(_troop3dropsXp[_player.GetAge() - 1] / 2);
                break;

            case 4:

                ally.AddMoney(_troop4drops[_player.GetAge() - 1] + _troop4dropsRange[_player.GetAge() - 1]);
                ally.AddXp(_troop4dropsXp[_player.GetAge() - 1]);
                enemy.AddMoney((_troop4drops[_player.GetAge() - 1] + _troop4dropsRange[_player.GetAge() - 1]) / 2);
                enemy.AddXp(_troop4dropsXp[_player.GetAge() - 1] / 2);
                break;
            
            case 5:
                ally.AddMoney(1000);
                ally.AddXp(2500);
                enemy.AddMoney(350);
                enemy.AddXp(1000);
                break;
        }

    }

    /*
     * Coroutine when a troop detect on his RayCast another troop wit a different id.
     * It will make a different animation (if there's one) and deal damage depending on his stat and the super effective state.
     * When the opposite troop has no life point, it will drop rewards and remove the troop from the troops list.
     */
    public IEnumerator AttackPlayer(GameManager enemyGameManager, Rigidbody2D myRb, Player ally, Player enemy)
    {
        if (enemyGameManager!= null && enemy != null)
        {
            if (isAttacking)
            {
                _animator.SetTrigger("attack");
                yield break;
            }

            isAttacking = true;
            _animator = GetComponent<Animator>();
            bool canAttack = true;
            while (canAttack)
            {
                if (_animator != null)
                {
                    _animator.SetTrigger("attack");
                }
                yield return new WaitForSeconds(attackTime);

                int damage = attack + Random.Range(0, 10);
                char allyChar = name[6];
                char enemyChar = enemyGameManager.name[6];
                int allyNumber = int.Parse(allyChar.ToString());
                int enemyNumber = int.Parse(enemyChar.ToString());
            
                if (SuperEffective(allyNumber, enemyNumber))
                {
                    damage = Mathf.RoundToInt(damage * 1.5f);
                }
                enemyGameManager.life -= damage;

                if (enemyGameManager.life <= 0)
                {
                    DropRewards(enemyNumber, ally, enemy);
                    enemyGameManager.life = 0;
                    _casern.DestroyTroop(enemyGameManager.id, enemyGameManager.uniqueId);
                    myRb.constraints = RigidbodyConstraints2D.None;
                    canAttack = false;
                    Destroy(enemyGameManager.gameObject);
                    StopAllCoroutines();
                }
            }
            isAttacking = false;
        }
    }

    /*
     * Coroutine that will deal damage to the troop touch by the special if the id is different.
     * The damage is set in function the maximum possible life points of the touched troop.
     */
    public IEnumerator TroopUnderSpecial(GameManager troop, SpecialCollision special, Player otherPlayer)
        {
            char troopChar = troop.name[6];
            int troopNumber = int.Parse(troopChar.ToString());
            int damage;
            if (otherPlayer.GetAge() == troop._player.GetAge())
            {
                if (troopNumber == 4)
                {
                    damage = troop.maxLife / 2;
                }
                else if (troopNumber == 5)
                {
                    damage = troop.maxLife / 4;
                }
                else
                {
                    damage = troop.maxLife;
                }
            }
            else if (otherPlayer.GetAge() < troop._player.GetAge())
            {
                if (troopNumber == 4)
                {
                    damage = troop.maxLife / 4;
                }
                else if (troopNumber == 5)
                {
                    damage = troop.maxLife / 8;
                }
                else
                {
                    damage = troop.maxLife / 2;
                }
            }
            else
            {
                damage = troop.maxLife;
            }
            troop.life -= damage;
            Destroy(special.gameObject);
            if (troop.life <= 0)
            {
                life = 0;
                _casern.DestroyTroop(troop.id, troop.uniqueId);
                DropRewards(troopNumber, otherPlayer, troop._player);
                Destroy(troop.gameObject);
            }
            yield return null;
        }
    }