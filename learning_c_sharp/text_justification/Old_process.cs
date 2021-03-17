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

        static string JoinLine(List<string> words, int start_pos, int end_pos, int  n_space){
            int n_words = end_pos - start_pos + 1;
            string justified_line = "";

            foreach (var word in words){
                Console.WriteLine("Loop 2");
                justified_line += word;
                n_words--;

                double n_space_to_add = (double)n_space / n_words;
                int space_to_add = (int)Math.Ceiling(n_space_to_add);
                for(int i = 0; i < space_to_add; i++){
                    justified_line += " ";
                }

                n_space -= space_to_add;
            }

            return justified_line;
        }

        static void Justify(string text, int line_width){
            Console.WriteLine("call funtion");
            var words = SplitText(text);
            int len = words.Count;

            int start_index = 0, n_words = 0, line_len = 0, processed_words = 0;
            var justified_line = new List<string>();

            foreach (var word in words){
                Console.WriteLine("main loop");
                n_words++;

                int possible_line_len = line_len + word.Length + n_words - 1;

                if(possible_line_len == line_width){
                    string j_line = JoinLine(
                        words,
                        start_index,
                        processed_words,
                        processed_words - start_index
                    );

                    justified_line.Add(j_line);

                    start_index = processed_words + 1;
                    n_words = 0; 
                    line_len = 0;
                }
                else if(possible_line_len > line_width){
                    string j_line = JoinLine(
                        words,
                        start_index,
                        processed_words - 1,
                        processed_words - line_len
                    );

                    justified_line.Add(j_line);

                    start_index = processed_words;
                    n_words = 1;
                    line_len = word.Length;
                }
                else{
                    line_len += word.Length;
                }

                processed_words++;
            }

            if(line_len > 0){
                string j_line = JoinLine(
                        words,
                        start_index,
                        len - 1,
                        line_len - 1
                    );

                justified_line.Add(j_line);
            }

            foreach(var line in justified_line){
                Console.WriteLine(line);
            }
        }
        static void N_Main(string[] args)
        {
            string text = "This is a text. I will try to justify this text using c sharp.";
            int line_width = 15;

            Justify(text, 15);
        }
    }
}
