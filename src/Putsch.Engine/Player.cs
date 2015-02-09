using System.Collections.Generic;
using System.Linq;

namespace Putsch.Engine
{
	public class Player
	{
		public readonly int Credits;
		public readonly IEnumerable<Character> Influence;
		public readonly IEnumerable<Character> LostInfluence;

		public Player(int credits, IEnumerable<Character> influence, IEnumerable<Character> lostInfluence)
		{
			Credits = credits;
			Influence = influence ?? Enumerable.Empty<Character>();
			LostInfluence = lostInfluence ?? Enumerable.Empty<Character>();
		}

		public Player(Player source, int? credits = null, IEnumerable<Character> influence = null, IEnumerable<Character> lostInfluence = null)
			: this(
				credits: credits ?? source.Credits,
				influence: influence ?? source.Influence,
				lostInfluence: lostInfluence ?? source.LostInfluence)
		{ }
	}
}
