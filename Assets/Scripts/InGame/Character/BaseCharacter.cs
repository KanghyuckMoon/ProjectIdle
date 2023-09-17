using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
	public bool IsPlayer => isPlayer;
	public BaseCharacter Target => target;

	public bool IsAttack
	{
		get
		{
			return isAttack;
		}
	}
	public float TargetDistance
	{
		get
		{
			Vector2 currentPosition = transform.position;
			Vector2 targetPosition = target.transform.position;

			float distance = Vector2.Distance(currentPosition, targetPosition);
			return distance;
		}
	}

	public bool IsDead
	{
		get
		{
			if(characterStat is null)
			{
				return true;
			}

			if(characterStat.Hp <= 0)
			{
				spriteRenderer.color = Color.gray;
				return true;
			}
			spriteRenderer.color = Color.white;
			return false;
		}
	}
	public float HpAmount
	{
		get
		{
			return (float)characterStat.Hp / characterStat.MaxHp;
		}
	}

	public CharacterStat CharacterStat => characterStat;

	[Header("Player")]
	public bool isPlayer;
	[SerializeField] private int index;
	[Header("Enemy")]
	[SerializeField] private CharacterDataSO characterDataSO;
	[SerializeField] private RewardSO rewardSO;
	[SerializeField] private Animator animator;
	[SerializeField] private SpriteRenderer spriteRenderer;

	public List<BaseSkill> skilList = new List<BaseSkill>();

	private CharacterData characterData;

	private CharacterStat characterStat;

	private BaseCharacter target;

	private float attackTimer = 0f;

	private bool isJoyStickMove;

	private bool isAttack;

	public Action UiUpdateAction
	{
		get
		{
			return uiUpdateAction;
		}
		set
		{
			uiUpdateAction = value;
		}
	}
	private Action uiUpdateAction;

	public void Start()
	{
		if(isPlayer)
		{
			characterData = GameManager.Instance.PlayerCharacter.GetCharacterData(index);
		}
		else
		{
			characterData = CharacterDataSO.ChDataSOToChData(characterDataSO);
		}
		ResetStat();

		if(isPlayer)
		{
			CharacterManager.Instance.playerCharacters.Add(this);
		}
		else
		{
			CharacterManager.Instance.enemyCharacters.Add(this);
		}
		UiUpdateAction?.Invoke();
	}

	public void Update()
	{
		if(IsDead)
		{
			return;
		}
		Move();
		CheckUseSkill();
	}

	public void ResetStat()
	{
		characterStat = CharacterStat.CharacterDataToChStat(characterData);
		characterStat.Hp = characterStat.MaxHp;
		SetSkill();
		spriteRenderer.color = Color.white;
		gameObject.SetActive(true);
		UiUpdateAction?.Invoke();
	}

	public void Move()
	{
		if(isJoyStickMove)
		{
			return;
		}

		if(target == null || target.IsDead)
		{
			ReTarget();
			return;
		}

		Vector2 currentPosition = transform.position;
		Vector2 targetPosition = target.transform.position;

		float distance = Vector2.Distance(currentPosition, targetPosition);
		isAttack = distance <= characterStat.AtkRange;
		if (isAttack)
		{
			Debug.Log("АјАн");
			Attack();
		}
		else
		{
			//float step = characterStat.Dex * Time.deltaTime;
			//transform.position = Vector2.MoveTowards(currentPosition, targetPosition, step);
			Vector2 dir = (targetPosition - currentPosition).normalized;
			MoveDirection(dir);
		}

		animator.SetBool("isMove", !isAttack);
	}

	private void MoveDirection(Vector2 direction)
	{
		if(direction.x > 0)
		{
			spriteRenderer.flipX = false;
		}
		else
		{
			spriteRenderer.flipX = true;
		}

		float step = characterStat.Dex * Time.deltaTime;
		Vector2 movement = direction * step;
		transform.position += (Vector3)movement;
		//transform.Translate(direction * step);// = new Vector2(direction.x + transform.position.x, direction.y + transform.position.y) * step;// Vector2.MoveTowards(currentPosition, targetPosition, step);
	}

	public void Attack()
	{
		attackTimer -= characterStat.Agi * Time.deltaTime;
		if (attackTimer <= 0f)
		{
			attackTimer = 1f;
			animator.SetTrigger("isAttack");

			target.Hit(CalcDamage());
		}
	}

	public float CalcDamage()
	{
		bool Cri = UnityEngine.Random.Range(0, 100) < characterStat.Luk;
		if (Cri)
		{
			return characterStat.Atk * characterStat.Cri;
		}
		else
		{
			return characterStat.Atk;
		}
	}

	public void Hit(float damage)
	{
		characterStat.Hp -= damage;
		UiUpdateAction?.Invoke();

		if (IsDead)
		{
			if(!isPlayer)
			{
				GameManager.Instance.PlayerMoney.EarnMoney(rewardSO.moneyType, Money.ReturnMoney(rewardSO.moneyIndex, rewardSO.money));
				GameManager.Instance.PlayerProfile.AddExp(rewardSO.exp);
				CharacterManager.Instance.CheckStageClear();
			}
			else
			{
				CharacterManager.Instance.CheckStageFailed();
			}
		}
		HitEffect.SetHitEffect(transform.position);
	}

	public void Hilling(int hp)
	{
		characterStat.Hp += hp;
		if(characterStat.Hp < characterStat.MaxHp)
		{
			characterStat.Hp = characterStat.MaxHp;
		}
	}

	public void ReTarget()
	{
		if(isPlayer)
		{
			target = FindClosest(CharacterManager.Instance.enemyCharacters);
		}
		else
		{
			target = FindClosest(CharacterManager.Instance.playerCharacters);
		}
	}

	public BaseCharacter FindClosest(List<BaseCharacter> list)
	{
		float closestDistance = Mathf.Infinity;
		Vector2 currentPosition = transform.position;
		BaseCharacter closestEnemy = null;

		foreach (BaseCharacter enemy in list)
		{
			if(enemy.IsDead)
			{
				continue;
			}
			float distance = Vector2.Distance(currentPosition, enemy.transform.position);
			if (distance < closestDistance)
			{
				closestDistance = distance;
				closestEnemy = enemy;
			}
		}

		return closestEnemy;
	}

	public List<BaseCharacter> FindClosestInRange(List<BaseCharacter> list)
	{
		Vector2 currentPosition = transform.position;
		List<BaseCharacter> closestEnemy = new List<BaseCharacter>();

		foreach (BaseCharacter enemy in list)
		{
			if (enemy.IsDead)
			{
				continue;
			}
			float distance = Vector2.Distance(currentPosition, enemy.transform.position);
			if (distance < characterStat.AtkRange)
			{
				closestEnemy.Add(enemy);
			}
		}
		return closestEnemy;
	}

	public void JoyStickMove(Vector2 dir)
	{
		isJoyStickMove = true;
		MoveDirection(dir);
	}

	public void JoyStickMoveEnd()
	{
		isJoyStickMove = false;
	}

	public void CheckUseSkill()
	{
		for(int i = 0; i < skilList.Count; ++i)
		{
			UseSkill(i);
		}
	}

	public void UseSkill(int index)
	{
		if(skilList[index].IsUseSkill)
		{
			skilList[index].UseSkill(this);
		}
	}

	public void SetSkill()
	{
		skilList.Clear();
		for (int i = 0; i < characterData.skillDataList.Count; ++i)
		{
			int index = i;
			skilList.Add(BaseSkill.ReturnSkill(characterData.skillDataList[index]));
		}
	}

	public void InvokeAnim(string anim)
	{
		animator.Play(anim);
	}
}
