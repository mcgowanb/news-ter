using System;

namespace NewsTer
{
    class Article
    {
        private String hashTag;
        public String Title { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        public String ThumbLink { get; set; }
        public String GUID { get; set; }
        public String Category { get; set; }
        public String HashTag
        {
            get
            {
                return hashTag;
            }
            set
            {
                hashTag = "#" + value.ToLower().Replace(" ", ""); ;
            }
        }
        public DateTime Date { get; set; }

        private const int TWEET_LENGTH = 136;

        public Article(String guid, String title, DateTime date, String desc, String category, String hashtag )
        {
            GUID = guid;
            Title = title;
            Date = date;
            Description = desc;
            Category = category;
            HashTag = hashtag;
        }



        public override string ToString()
        {
            int length = TWEET_LENGTH - (GUID.Length + HashTag.Length);
            if (Title.Length >= length)
            {
                Title = Title.Substring(0, (length - 3)) + "...";
            }
            return String.Format("{0}. {1} {2}", Title, GUID, hashTag);
        }

        public String GetArticleForTwitter()
        {
            int length = TWEET_LENGTH - (GUID.Length + HashTag.Length);
            if (Title.Length >= length)
            {
                Title = Title.Substring(0, (length - 3)) + "...";
            }
            return String.Format("{0}. {1} {2}", Title, GUID, hashTag);
        }

    }
}
