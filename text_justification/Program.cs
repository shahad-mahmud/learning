using System;
using System.Collections;
using System.Collections.Generic;

namespace text_justification
{
    class Program{
        static List<string> SplitText(string text){
            var words = new List<string>();

            int len = text.Length;
            string temp_word = "";

            foreach (var cha in text){
                if (cha != ' '){
                    temp_word += cha;
                }else{
                    words.Add(temp_word);
                    temp_word = "";
                }
            }

            if (temp_word != ""){
                words.Add(temp_word);
            }

            return words;
        }

        static void Justify(string text, int line_width){
            var words = SplitText(text);

            int start_index = 0, n_words = 0, line_len = 0;
        }
        static void Main(string[] args)
        {
            string text = "This is a text. I will try to justify this text using c sharp.";
            int line_width = 15;

            var words = SplitText(text);

            foreach (var word  in words){
                Console.WriteLine(word);
            }
            Console.WriteLine(words);
        }
    }
}
