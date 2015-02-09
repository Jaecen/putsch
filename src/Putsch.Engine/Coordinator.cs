using System;

namespace Putsch.Engine
{
	public interface ICoordinator
	{
		event EventHandler<CommandRequiredEventArgs> CommandRequired;
		void RequireCommand(Player player, string prompt);
		void SubmitCommand(string verb, string noun);
	}

	public class CommandRequiredEventArgs : EventArgs
	{
		public readonly Player Player;
		public readonly string Prompt;

		public CommandRequiredEventArgs(Player player, string prompt)
		{
			Player = player;
			Prompt = prompt;
		}
	}

	public class Coordinator : ICoordinator
	{
		public event EventHandler<CommandRequiredEventArgs> CommandRequired;

		public void RequireCommand(Player player, string prompt)
		{
			if(CommandRequired != null)
				CommandRequired(this, new CommandRequiredEventArgs(player, prompt));
		}

		public void SubmitCommand(string verb, string noun)
		{
			throw new NotImplementedException();
		}
	}
}
