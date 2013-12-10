#region Usings

using System;

#endregion

namespace AwfulVideoStore {
    public class Movie {
        public Movie(int movieCd) {
            if (movieCd == MovieCodes.CHILDRENS)
                MovieCodeName = "Children";
            else if (movieCd == MovieCodes.NEW_RELEASE)
                MovieCodeName = "New Release";
            else if (movieCd == MovieCodes.REGULAR)
                MovieCodeName = "Regular";
            else MovieCodeName = null;
        }

        public string Title { get; set; }
        public string Price { get; set; }
        public int Rating { get; set; }
        public string MovieCodeName { get; private set; }

        public override string ToString() {
            return Title + " for " + Price;
        }
    }
}