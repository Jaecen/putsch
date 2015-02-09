using System;

namespace Putsch.Engine.CommandBehavior
{
	public class TransferAvailableCreditsToPlayer : ICommandBehavior
	{
		readonly ICommandBehavior PreviousCommandBehavior;
		readonly Func<CommandBehaviorContext, Player> PlayerSelector;
		readonly Func<CommandBehaviorContext, Player> TargetSelector;
		readonly int Amount;

		public TransferAvailableCreditsToPlayer(ICommandBehavior previousCommandBehavior, Func<CommandBehaviorContext, Player> playerSelector, Func<CommandBehaviorContext, Player> targetSelector, int amount)
		{
			PreviousCommandBehavior = previousCommandBehavior;
			PlayerSelector = playerSelector;
			TargetSelector = targetSelector;
			Amount = amount;
		}

		public CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext commandBehaviorContext)
		{
			var updatedContext = PreviousCommandBehavior.Apply(serviceContext, commandBehaviorContext);
			if(updatedContext.State != CommandBehaviorState.Continue)
				return updatedContext;

			var player = PlayerSelector(commandBehaviorContext);
			var target = TargetSelector(commandBehaviorContext);
			var actualAmount = Math.Min(target.Credits, Amount);

			var updatedPlayer = serviceContext.PlayerMutator.AdjustCredits(player, actualAmount);
			var updatedTarget = serviceContext.PlayerMutator.AdjustCredits(target, -actualAmount);

			return new CommandBehaviorContext(
				source: updatedContext,
				player: updatedPlayer,
				target: updatedTarget);
		}
	}
}
