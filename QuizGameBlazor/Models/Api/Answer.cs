namespace QuizGameBlazor.Models.Api
{
    public class Answer
    {
        /// <summary>
        /// The answer to a question
        /// </summary>
        public string answer;

        /// <summary>
        /// The address of an image that is loaded through a URL. You can leave this empty if you don't want an image
        /// </summary>
        public string imageURL;

        /// <summary>
        /// The address of a sound that accompanies the answer. You can leave this empty if you don't want a sound
        /// </summary>
        public string soundURL;

        public bool isCorrect = false;
    }
}
