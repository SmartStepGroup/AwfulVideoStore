using System;
using System.Collections.Generic;

namespace AwfulVideoStore {
    public class SellingReportServce {
        public List<Movie> Load() {
            var movies = new List<Movie>();
            var random = new Random();
            var code = random.Next(0, 3);
            for (var i = 0; i < 5; i++) {
                movies.Add(new Movie(code) {
                    Price = "1.99$",
                    Rating = 16,
                    Title = string.Format("Очень страшное кино {0}", (i + 1))
                });
            }

            return movies;
        }
    }
}