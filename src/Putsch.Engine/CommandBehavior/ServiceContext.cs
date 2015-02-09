namespace Putsch.Engine.CommandBehavior
{
	public class ServiceContext
	{
		public readonly IPlayerMutator PlayerMutator;
		public readonly ICoordinator Coordinator;

		public ServiceContext(IPlayerMutator playerMutator, ICoordinator coordinator)
		{
			PlayerMutator = playerMutator;
			Coordinator = coordinator;
		}
	}
}
