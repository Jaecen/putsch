using System;

namespace Putsch.Engine.CommandBehavior
{
	public class AdjustCredits : ICommandBehavior
	{
		readonly ICommandBehavior PreviousCommandBehavior;
		readonly Func<CommandBehaviorContext, Player> PlayerSelector;
		readonly int Amount;

		public AdjustCredits(ICommandBehavior previousCommandBehavior, Func<CommandBehaviorContext, Player> playerSelector, int amount)
		{
			PreviousCommandBehavior = previousCommandBehavior;
			PlayerSelector = playerSelector;
			Amount = amount;
		}

		public CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext commandBehaviorContext)
		{
			var updatedContext = PreviousCommandBehavior.Apply(serviceContext, commandBehaviorContext);
			if(updatedContext.State != CommandBehaviorState.Continue)
				return updatedContext;

			var player = PlayerSelector(commandBehaviorContext);
			var updatedPlayer = serviceContext.PlayerMutator.AdjustCredits(player, Amount);

			if(updatedPlayer.Credits < 0)
				return new CommandBehaviorError(updatedContext, "Insufficient credits");
				
			return new CommandBehaviorContext(updatedContext, player: updatedPlayer);
		}
	}
}
