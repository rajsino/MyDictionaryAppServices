using System;

namespace MyDictionaryServices.Models
{
    public class TestResultModel
    {
        public DateTime? AttemtedDate { get; set; }
        public string PrimaryLanguage { get; set; }
        public string SecondaryLanguage { get; set; }

        public int AvailableQuestionsInDictionary { get; set; }
        public int QuestionsTaken { get; set; }
        public int QuestionsAttempted { get; set; }
        public int CorrectAnwers { get; set; }
        public int UserId { get; set; }
    }
}
