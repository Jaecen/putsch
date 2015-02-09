using System;

namespace Putsch.Engine.CommandBehavior
{
	public class ReduceInfluence : ICommandBehavior
	{
		readonly ICommandBehavior PreviousCommandBehavior;
		readonly Func<CommandBehaviorContext, Player> TargetSelector;

		public ReduceInfluence(ICommandBehavior previousCommandBehavior, Func<CommandBehaviorContext, Player> targetSelector)
		{
			PreviousCommandBehavior = previousCommandBehavior;
			TargetSelector = targetSelector;
		}

		public CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext commandBehaviorContext)
		{
			var updatedContext = PreviousCommandBehavior.Apply(serviceContext, commandBehaviorContext);
			if(updatedContext.State != CommandBehaviorState.Continue)
				return updatedContext;

			var target = TargetSelector(commandBehaviorContext);
			serviceContext.Coordinator.RequireCommand(target, "Lose a card");

			return new CommandBehaviorDefer(updatedContext);
		}
	}

	public class LoseInfluence : ICommandBehavior
	{
		readonly ICommandBehavior PreviousCommandBehavior;
		readonly Func<CommandBehaviorContext, Player> PlayerSelector;

		public LoseInfluence(ICommandBehavior previousCommandBehavior, Func<CommandBehaviorContext, Player> playerSelector)
		{
			PreviousCommandBehavior = previousCommandBehavior;
			PlayerSelector = playerSelector;
		}

		public CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext commandBehaviorContext)
		{
			var updatedContext = PreviousCommandBehavior.Apply(serviceContext, commandBehaviorContext);
			if(updatedContext.State != CommandBehaviorState.Continue)
				return updatedContext;
			
			var player = PlayerSelector(commandBehaviorContext);
			var updatedPlayer = serviceContext.PlayerMutator.LoseInfluence(player, commandBehaviorContext.Card.Value);

			return new CommandBehaviorContext(
				source: updatedContext,
				player: updatedPlayer);
		}
	}
}
