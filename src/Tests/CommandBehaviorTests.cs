using Moq;
using Putsch.Engine;
using Putsch.Engine.CommandBehavior;
using Xunit;

namespace Tests.CommandBehaviorTests
{
	public class AdjustCreditsBehaviorTest
	{
		[Fact]
		public void Adjusts_Credits_By_Specified_Amount()
		{
			var serviceContext = new ServiceContext(
				playerMutator: new PlayerMutator(),
				coordinator: new Mock<ICoordinator>().Object);

			var commandBehaviorMock = new Mock<ICommandBehavior>();
			commandBehaviorMock
				.Setup(x => x.Apply(It.IsAny<ServiceContext>(), It.IsAny<CommandBehaviorContext>()))
				.Returns<ServiceContext, CommandBehaviorContext>((x, y) => y);

			var behaviorContext = new CommandBehaviorContext(
				commandType: CommandType.Income,
				player: new Player(
					credits: 5,
					influence: null,
					lostInfluence: null),
				target: null,
				card: null,
				state: CommandBehaviorState.Continue,
				errorReason: null);

			var behavior = new AdjustCredits(
				previousCommandBehavior: commandBehaviorMock.Object,
				playerSelector: context => context.Player,
				amount: 3);

			var result = behavior.Apply(
				serviceContext: serviceContext,
				commandBehaviorContext: behaviorContext);

			Assert.Equal(8, result.Player.Credits);
		}

		[Fact]
		public void Errors_When_Income_Adjusted_Below_Zero()
		{
			var serviceContext = new ServiceContext(
				playerMutator: new PlayerMutator(),
				coordinator: new Mock<ICoordinator>().Object);

			var commandBehaviorMock = new Mock<ICommandBehavior>();
			commandBehaviorMock
				.Setup(x => x.Apply(It.IsAny<ServiceContext>(), It.IsAny<CommandBehaviorContext>()))
				.Returns<ServiceContext, CommandBehaviorContext>((x, y) => y);

			var behaviorContext = new CommandBehaviorContext(
				commandType: CommandType.Income,
				player: new Player(
					credits: 5,
					influence: null,
					lostInfluence: null),
				target: null,
				card: null,
				state: CommandBehaviorState.Continue,
				errorReason: null);

			var behavior = new AdjustCredits(
				previousCommandBehavior: commandBehaviorMock.Object,
				playerSelector: context => context.Player,
				amount: -7);

			var result = behavior.Apply(
				serviceContext: serviceContext,
				commandBehaviorContext: behaviorContext);

			Assert.Equal(CommandBehaviorState.Error, result.State);
		}
	}

	public class TransferAvailableCreditsToPlayerBehaviorTest
	{
		[Fact]
		public void Transfers_The_Full_Amount_When_Target_Balance_Is_Sufficient()
		{
			var serviceContext = new ServiceContext(
				playerMutator: new PlayerMutator(),
				coordinator: new Mock<ICoordinator>().Object);

			var commandBehaviorMock = new Mock<ICommandBehavior>();
			commandBehaviorMock
				.Setup(x => x.Apply(It.IsAny<ServiceContext>(), It.IsAny<CommandBehaviorContext>()))
				.Returns<ServiceContext, CommandBehaviorContext>((x, y) => y);

			var behaviorContext = new CommandBehaviorContext(
				commandType: CommandType.Income,
				player: new Player(
					credits: 5,
					influence: null,
					lostInfluence: null),
				target: new Player(
					credits: 5,
					influence: null,
					lostInfluence: null),
				card: null,
				state: CommandBehaviorState.Continue,
				errorReason: null);

			var behavior = new TransferAvailableCreditsToPlayer(
				previousCommandBehavior: commandBehaviorMock.Object,
				playerSelector: context => context.Player,
				targetSelector: context => context.Target,
				amount: 5);

			var result = behavior.Apply(
				serviceContext: serviceContext,
				commandBehaviorContext: behaviorContext);

			Assert.Equal(10, result.Player.Credits);
			Assert.Equal(0, result.Target.Credits);
		}

		[Fact]
		public void Transfers_Balance_When_Target_Balance_Is_Insufficient()
		{
			var serviceContext = new ServiceContext(
				playerMutator: new PlayerMutator(),
				coordinator: new Mock<ICoordinator>().Object);

			var commandBehaviorMock = new Mock<ICommandBehavior>();
			commandBehaviorMock
				.Setup(x => x.Apply(It.IsAny<ServiceContext>(), It.IsAny<CommandBehaviorContext>()))
				.Returns<ServiceContext, CommandBehaviorContext>((x, y) => y);

			var behaviorContext = new CommandBehaviorContext(
				commandType: CommandType.Income,
				player: new Player(
					credits: 5,
					influence: null,
					lostInfluence: null),
				target: new Player(
					credits: 2,
					influence: null,
					lostInfluence: null),
				card: null,
				state: CommandBehaviorState.Continue,
				errorReason: null);

			var behavior = new TransferAvailableCreditsToPlayer(
				previousCommandBehavior: commandBehaviorMock.Object,
				playerSelector: context => context.Player,
				targetSelector: context => context.Target,
				amount: 5);

			var result = behavior.Apply(
				serviceContext: serviceContext,
				commandBehaviorContext: behaviorContext);

			Assert.Equal(7, result.Player.Credits);
			Assert.Equal(0, result.Target.Credits);
		}
	}
}
