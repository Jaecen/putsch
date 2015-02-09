using System.Linq;

namespace Putsch.Engine
{
	public interface IPlayerMutator
	{
		Player AdjustCredits(Player player, int amount);
		Player LoseInfluence(Player player, Character lostCharacter);
	}

	public class PlayerMutator : Putsch.Engine.IPlayerMutator
	{
		public Player AdjustCredits(Player player, int amount)
		{
			return new Player(
				source: player,
				credits: player.Credits + amount);
		}

		public Player LoseInfluence(Player player, Character lostCharacter)
		{
			return new Player(
				source: player,
				influence: player
					.Influence
					.GroupBy(i => i == lostCharacter)
					.SelectMany(x => x.Key == true
						? x.Skip(1).AsEnumerable()
						: x.AsEnumerable())
					.ToArray(),
				lostInfluence: player
					.LostInfluence
					.Concat(new[] { lostCharacter })
					.ToArray());
		}
	}
}
