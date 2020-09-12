using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizGameBlazor.Models.Api
{
    public class Question
    {
        //public int Id { get; set; }
        //public string Text { get; set; }
        //public List<Answer> Answers { get; set; }
        //public int Difficulty { get; set; }
        public string question;

        ///<summary>
        ///The address of an image that is loaded through a URL. You can leave this empty if you don't want an image
        /// </summary>
        public string imageURL;

        /// <summary>
        /// The address of a sound that accompanies the question. You can leave this empty if you don't want a sound
        /// </summary>
        public string soundURL;


        public Answer[] answers;

        /// <summary>
        /// A followup text that will be displayed after this question is answered. While displayed, the game is paused.
        /// </summary>
        public String followup;

        /// <summary>
        /// A followup image that will be displayed after this question is answered. While displayed, the game is paused.
        /// The address of a followup image that will be displayed after this question is answered. While displayed, the game is paused.
        /// </summary>
        public string followupImageURL;

        /// <summary>
        /// The address of a followup sound that can be played after this question is answered. While displayed, the game is paused.
        /// </summary>
        public string followupSoundURL;
        /// <summary>
        /// How many point we get if we answer this question correctly. The bonus value is also used to sort the questions from the easy ( low bonus ) to the difficult ( high bonus )
        /// </summary>
        public float bonus;
        /// <summary>
        /// How many seconds to answer this question we have. This should logically be tied to the difficulty of the question, same as the bonus. But the questions are sorted only based on the bonus, and not the time
        /// </summary>
        public float time = 10;
    }
}
