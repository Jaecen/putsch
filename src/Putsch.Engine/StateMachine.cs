using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Putsch.Engine
{
	public class StateMachine
	{
		public StateMachine(ILookup<StateType, CommandType> definition)
		{

		}
	}

	public enum StateType
	{
		Action,
		ActionChallenge,
		Block,
		BlockChallenge,
		ReturnCard,
		LoseInfluence,
		End,
	}

	public enum CommandType
	{
		Income,
		Tax,
		ForeignAid,
		Steal,
		Exchange,
		Assassinate,
		Coup,
		Challenge,
		Block,
		Pass,
		Lose,
		Return,
	}
}
