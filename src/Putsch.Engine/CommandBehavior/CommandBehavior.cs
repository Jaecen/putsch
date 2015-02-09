namespace Putsch.Engine.CommandBehavior
{
	public class Behavior : ICommandBehavior
	{
		public Behavior()
		{ }

		public CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext context)
		{
			return context;
		}
	}
}
