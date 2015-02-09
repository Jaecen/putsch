namespace Putsch.Engine.CommandBehavior
{
	public enum CommandBehaviorState
	{
		Continue,
		Defer,
		Error,
	}

	public class CommandBehaviorContext
	{
		public readonly CommandType CommandType;
		public readonly Player Player;
		public readonly Player Target;
		public readonly Character? Card;
		public readonly CommandBehaviorState State;
		public readonly string ErrorReason;

		public CommandBehaviorContext(CommandType commandType, Player player, Player target, Character? card, CommandBehaviorState state, string errorReason)
		{
			CommandType = commandType;
			Player = player;
			Target = target;
			Card = card;
			State = state;
			ErrorReason = errorReason;
		}

		public CommandBehaviorContext(CommandBehaviorContext source, CommandType? commandType = null, Player player = null, Player target = null, Character? card = null, CommandBehaviorState? state = null, string errorReason = null)
			: this(
				commandType: commandType ?? source.CommandType,
				player: player ?? source.Player,
				target: target ?? source.Target,
				card: card ?? source.Card,
				state: state ?? source.State,
				errorReason: errorReason ?? source.ErrorReason)
		{ }
	}

	public class CommandBehaviorDefer : CommandBehaviorContext
	{
		public CommandBehaviorDefer(CommandBehaviorContext source)
			: base(
				source: source, 
				state: CommandBehaviorState.Defer)
		{ }
	}

	public class CommandBehaviorError : CommandBehaviorContext
	{
		public CommandBehaviorError(CommandBehaviorContext source, string reason)
			: base(
				source: source, 
				state: CommandBehaviorState.Error,
				errorReason: reason)
		{ }
	}
}
