using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScoringKlondike
{
    public class ScoringRule : ReadOnlyDictionary<(Type,Type),int>
    {
        public ScoringRule(IDictionary<(Type, Type), int> dictionary) : base(dictionary)
        {

        }


        public static ScoringRule GenerateDefaultRule()
        {
            var dictionary = new Dictionary<(Type, Type), int>();


            dictionary.[] = 5;

            return new ScoringRule(dictionary);

        }
    }
}
