using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallNumbers
{
    public class GenerateCallNumberQuestions
    {

        public Random random = new Random();
        //----------------------------------------------------------------------------------------------------------------//
        /// <summary>
        ///     Generate the Questions for matching the column
        /// </summary>
        public Dictionary<string, string> GenerateQuestions()
        {
            Dictionary<string, string> questions = new Dictionary<string, string>();
            Dictionary<string, string> currentDescriptions = new Dictionary<string, string>();

            //Clone original dictionary data 
            foreach (string key in CallNumbersDescriptions.descriptions.Keys)
            {
                currentDescriptions.Add(key, CallNumbersDescriptions.descriptions[key]);
            }

            //Randomly take 7 descriptions
            for (int i = 0; i < 7; i++)
            {
                int index = random.Next(0, currentDescriptions.Count);
                questions.Add(currentDescriptions.Keys.ElementAt(index), currentDescriptions.Values.ElementAt(index));
                currentDescriptions.Remove(currentDescriptions.Keys.ElementAt(index));
            }

            return questions;
        }
    }
}
