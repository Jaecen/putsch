namespace Putsch.Engine.CommandBehavior
{
	public interface ICommandBehavior
	{
		CommandBehaviorContext Apply(ServiceContext serviceContext, CommandBehaviorContext commandBehaviorContext);
	}
}
