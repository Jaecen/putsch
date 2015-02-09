using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Putsch.Engine.CommandBehavior
{
	public static class Extensions
	{
		public static ICommandBehavior AdjustCredits(this ICommandBehavior that, Func<CommandBehaviorContext, Player> of, int by)
		{
			return new AdjustCredits(
				previousCommandBehavior: that,
				playerSelector: of,
				amount: by);
		}

		public static ICommandBehavior TransferAvailableCreditsToPlayer(this ICommandBehavior that, Func<CommandBehaviorContext, Player> player, Func<CommandBehaviorContext, Player> target, int amount)
		{
			return new TransferAvailableCreditsToPlayer(
				previousCommandBehavior: that,
				playerSelector: player,
				targetSelector: target,
				amount: amount);
		}

		public static ICommandBehavior UnlessBlockedBy(this ICommandBehavior that, params Character[] blockingCharacters)
		{
			throw new NotImplementedException();
		}

		public static ICommandBehavior UnlessProvenNotToBe(this ICommandBehavior that, params Character[] requiredCharacters)
		{
			throw new NotImplementedException();
		}

		public static ICommandBehavior ExchangeTwoCardsWithTheCourtDeck(this ICommandBehavior that)
		{
			throw new NotImplementedException();
		}

		public static ICommandBehavior ReduceInfluence(this ICommandBehavior that, Func<CommandBehaviorContext, Player> of)
		{
			return new ReduceInfluence(
				previousCommandBehavior: that,
				targetSelector: context => context.Target);
		}
	}
}
