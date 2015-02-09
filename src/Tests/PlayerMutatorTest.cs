using System.Linq;
using Putsch.Engine;
using Xunit;

namespace Tests
{
	public class PlayerMutatorTest
	{
		[Fact]
		public void Increases_Credits_With_Positive_Amount()
		{
			var player = new Player(
				credits: 5,
				influence: null,
				lostInfluence: null);

			var playerMutator = new PlayerMutator();
			var result = playerMutator.AdjustCredits(
				player: player,
				amount: 3);

			Assert.Equal(8, result.Credits);
		}

		[Fact]
		public void Decreases_Credits_With_Negative_Amount()
		{
			var player = new Player(
				credits: 5,
				influence: null,
				lostInfluence: null);

			var playerMutator = new PlayerMutator();
			var result = playerMutator.AdjustCredits(
				player: player,
				amount: -3);

			Assert.Equal(2, result.Credits);
		}

		[Theory]
		[InlineData(
			new Character[] { Character.Captain, Character.Contessa },
			new Character[] { },
			Character.Contessa,
			new Character[] { Character.Captain },
			new Character[] { Character.Contessa }
			)]
		[InlineData(
			new Character[] { Character.Contessa, Character.Captain },
			new Character[] { },
			Character.Contessa,
			new Character[] { Character.Captain },
			new Character[] { Character.Contessa }
			)]
		[InlineData(
			new Character[] { Character.Duke },
			new Character[] { Character.Ambassador },
			Character.Duke,
			new Character[] { },
			new Character[] { Character.Ambassador, Character.Duke }
			)]
		[InlineData(
			new Character[] { Character.Assassin, Character.Assassin },
			new Character[] { },
			Character.Assassin,
			new Character[] { Character.Assassin },
			new Character[] { Character.Assassin }
			)]
		public void Moves_Card_From_Influence_To_LostInfluence(Character[] influence, Character[] lostInfluence, Character lostCharacter, Character[] expectedInfluence, Character[] expectedLostInfluence)
		{
			var player = new Player(
				credits: 0,
				influence: influence,
				lostInfluence: lostInfluence);

			var playerMutator = new PlayerMutator();
			var result = playerMutator.LoseInfluence(
				player: player,
				lostCharacter: lostCharacter);

			Assert.Equal(expectedInfluence, result.Influence);
			Assert.Equal(expectedLostInfluence, result.LostInfluence);
		}
	}
}
