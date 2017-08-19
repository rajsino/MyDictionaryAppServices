using MyDictionaryServices.Models.Profiles;
using System;

namespace MyDictionaryServices.Models.PrepareTest
{
    public class TestResults
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime? AttemtedDate { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }

        public int AvailableQuestionsInDictionary { get; set; }
        public int QuestionsTaken { get; set; }
        public int QuestionsAttempted { get; set; }
        public int CorrectAnwers { get; set; }

    }
}