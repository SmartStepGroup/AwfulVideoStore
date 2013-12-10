namespace AwfulVideoStore {
    public class Movie {
        public Movie(int movieCd) {
            if (movieCd == MovieCodes.CHILDRENS)
                MovieCodeName = "Children";
            if (movieCd == MovieCodes.NEW_RELEASE)
                MovieCodeName = "New Release";
            if (movieCd == MovieCodes.REGULAR)
                MovieCodeName = "Regular";
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