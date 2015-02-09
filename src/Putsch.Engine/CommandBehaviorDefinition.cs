using System.Collections.Generic;
using Putsch.Engine.CommandBehavior;

namespace Putsch.Engine
{
	public class CommandBehaviorDefinition
	{
		public Dictionary<CommandType, ICommandBehavior> BuildCommandMap()
		{
			return new Dictionary<CommandType, ICommandBehavior>
				{
					{
						CommandType.Income, 
						new Behavior()
							.AdjustCredits(
								of: context => context.Player, 
								by: 1)
					}, {
						CommandType.Tax,
						new Behavior()
							.UnlessBlockedBy(Character.Duke)
							.AdjustCredits(
								of: context => context.Player,
								by: 2)
					}, {
						CommandType.ForeignAid,
						new Behavior()
							.UnlessProvenNotToBe(Character.Duke)
							.AdjustCredits(
								of: context => context.Player,
								by: 3)
					}, {
						CommandType.Steal,
						new Behavior()
							.UnlessProvenNotToBe(Character.Captain)
							.UnlessBlockedBy(Character.Captain, Character.Ambassador)
							.TransferAvailableCreditsToPlayer(
								player: context => context.Target, 
								target: context => context.Player,
								amount: 2)
					}, {
						CommandType.Exchange,
						new Behavior()
							.UnlessProvenNotToBe(Character.Ambassador)
							.ExchangeTwoCardsWithTheCourtDeck()
					}, {
						CommandType.Assassinate,
						new Behavior()
							.AdjustCredits(
								of: context => context.Player,
								by: -3)
							.UnlessProvenNotToBe(Character.Assassin)
							.UnlessBlockedBy(Character.Contessa)
							.ReduceInfluence(of: context => context.Target)
					}, {
						CommandType.Coup,
						new Behavior()
							.AdjustCredits(
								of: context => context.Player,
								by: -7)
							.ReduceInfluence(of: context => context.Target)
					}
				};
		}
	}
}