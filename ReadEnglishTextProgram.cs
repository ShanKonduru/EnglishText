using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;

namespace EnglishText {
    class ReadEnglishText {
        private static List<string> totalWords = new List<string> ();

        private static string[] GetWords (string text) {
            List<string> lstreturn = new List<string> ();
            List<string> lst = text.Split (new [] { ' ' }).ToList ();
            foreach (string str in lst) {
                if (str.Trim () == "") {
                    // ignore the empty word
                } else {
                    lstreturn.Add (str.Trim (new Char[] { ' ', '*', '.', '+', '/', '!', '@', '#', '$', '%', '^', '&', '(', ')', '?', '/', '{', '}', ']' }));
                    Console.WriteLine (str.Trim ());
                }
            }

            return lstreturn.ToArray ();
        }

        public static void PrintIndexAndValues (List<string> myList) {
            int i = 0;
            string[] myArr = myList.ToArray ();
            foreach (string data in myArr)
                Console.WriteLine ("\t[{0}]:\t{1}", i++, data.ToString ());
            Console.WriteLine ();
        }

        public static void PrintIndexAndValues (string[] myArr) {
            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine ("\t[{0}]:\t{1}", i, myArr[i]);
            Console.WriteLine ();
        }

        static void Main (string[] args) {
            string textFile = @".\TextData.txt";

            // Read entire text file content in one string  
            string text = File.ReadAllText (textFile);
            // Console.WriteLine (text);

            // Read a text file line by line.  
            string[] lines = File.ReadAllLines (textFile);

            foreach (string line in lines) {
                Console.WriteLine (line);
                totalWords.AddRange (GetWords (line));
            }

            totalWords = totalWords.OrderBy (q => q).Distinct ().ToList ();

            PrintIndexAndValues (totalWords);
        }
    }
}