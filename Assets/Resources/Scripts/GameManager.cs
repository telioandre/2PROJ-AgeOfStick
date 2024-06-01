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
        _animator.SetFloat("attackTime", attackTime);
    }

    private void Update()
    {
        health.fillAmount = (float)life / maxLife;
    }

    //Permet de lancer le mouvement de chaque unité en fonction de leur ID
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
            Debug.DrawRay(rb2d.position + new Vector2(1, 0) * 50, new Vector2(1, 0) * attackRangeOfLevel, Color.red);

            if (hits.Length > 0)
            {
                RaycastHit2D firstHit = default;

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.CompareTag(gameObject.tag) && firstHit == default && hits[i].collider.gameObject.GetComponent<GameManager>().id != id)
                    {
                        firstHit = hits[i];
                        Debug.Log("First hit detected");

                        if (!isAttacking)
                        {
                            Debug.Log("Starting AttackPlayer coroutine");
                            StartCoroutine(AttackPlayer(firstHit.collider.gameObject.GetComponent<GameManager>(), rb2d, _player, firstHit.collider.gameObject.GetComponent<GameManager>().GetPlayer()));
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
            Debug.DrawRay(rb2d.position + new Vector2(-1, 0) * 50, new Vector2(-1, 0) * attackRangeOfLevel, Color.red);

            if (hits.Length > 0)
            {
                RaycastHit2D firstHit = default;

                for (int i = 0; i < hits.Length; i++)
                {
                    Debug.Log("hit.length = " + hits.Length);
                    if (hits[i].collider.gameObject.CompareTag(gameObject.tag) && firstHit == default && hits[i].collider.gameObject.GetComponent<GameManager>().id != id)
                    {
                        Debug.Log("First hit detected");
                        firstHit = hits[i];
                        Debug.Log(firstHit.collider.gameObject);

                        if (!isAttacking)
                        {
                            Debug.Log("Starting AttackPlayer coroutine");
                            StartCoroutine(AttackPlayer(firstHit.collider.gameObject.GetComponent<GameManager>(), rb2d, _player, firstHit.collider.gameObject.GetComponent<GameManager>().GetPlayer()));
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

    public int GetId()
    {
        return id;
    }

    public string GetUniqueId()
    {
        return uniqueId;
    }

    public Player GetPlayer()
    {
        return _player;
    }

    //Initialise les paramètres de l'objet prefab
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
                life = Mathf.RoundToInt(life * 1.5f);
                speed = Mathf.RoundToInt(speed * 1.05f);
                attack = Mathf.RoundToInt(attack * 1.5f);
                buildTime = Mathf.RoundToInt(buildTime * 1.25f);
                attackTime *= (float)0.9;
            }
        }
        for (int i = 0; i < troopLevel; i++)
        {
            attack = Mathf.RoundToInt(attack * 1.2f);
        }
        maxLife = life;
        Invoke(nameof(Endbuild), buildTime);
    }
    private void Endbuild()
    {
        RaycastHit2D[] hitsWidth;
        hitsWidth = Physics2D.RaycastAll(new Vector2(250, 500), Vector2.right, 5000);
        if (id == 1)
        {
            RaycastHit2D[] hitsHeight;

            hitsHeight = Physics2D.RaycastAll(new Vector2(-250, 300), new Vector2(0, 1), 2000000);
            Debug.DrawRay(new Vector2(-250, 380), new Vector2(0, 1) * 2000000, Color.red);


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
            Debug.DrawRay(new Vector2(5200, 380), new Vector2(0, 1) * 2000000, Color.red);
            
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

    public bool SuperEffective(int ally, int enemy)
    {
        if (ally == enemy + 1 || (ally == 4 && enemy == 1))
        {
            return true;
        }
        return false;
    }

    public void DropRewards(int troop, Player ally, Player enemy)
    {
        Debug.Log("troop = " + troop);
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
                // a modif
                ally.AddMoney(1000);
                ally.AddXp(5000);
                enemy.AddMoney(350);
                enemy.AddXp(2000);
                break;
        }

    }

    public IEnumerator AttackPlayer(GameManager enemyGameManager, Rigidbody2D myRb, Player ally, Player enemy)
    {
        if (enemyGameManager!= null && enemy != null)
        {
            if (isAttacking)
            {
                Debug.Log("Already attacking");
                _animator.SetTrigger("attack");
                yield break;
            }

            isAttacking = true;
            _animator = GetComponent<Animator>();
            bool canAttack = true;
            while (canAttack)
            {
                Debug.Log("Waiting for attack time");
                if (_animator != null)
                {
                    _animator.SetTrigger("attack");
                }
                yield return new WaitForSeconds(attackTime);
                

                Debug.Log("Waiting before dealing damage");
                yield return new WaitForSeconds(0.5f);

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


    public IEnumerator TroopUnderSpecial(GameManager troop, SpecialCollision special, Player otherPlayer)
        {
            char troopChar = troop.name[6];
            int troopNumber = int.Parse(troopChar.ToString());
            int damage;
            if (otherPlayer.GetAge() == troop._player.GetAge())
            {
                if (troopNumber >= 4)
                {
                    damage = troop.maxLife / 2;
                }
                else
                {
                    damage = troop.maxLife;
                }
            }
            else if (otherPlayer.GetAge() < troop._player.GetAge())
            {
                if (troopNumber >= 4)
                {
                    damage = troop.maxLife / 4;
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