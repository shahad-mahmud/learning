using System;
using System.Collections;
using System.Collections.Generic;

namespace text_justification
{
    class New_Program{
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

        static void PrintLine(List<string> words, int start_index, int end_index, 
                    int space_needed){
            int word_count = end_index - start_index + 1;
            string line = "";

            for(int i = start_index; i <= end_index; i++){
                line += words[i];
                word_count--;
                int n_space = (int) Math.Ceiling((double) space_needed / word_count);
                // Console.WriteLine($"space needed {space_needed}, words: {word_count}");
                // Console.WriteLine(n_space);

                for(int j = 0; j < n_space; j++){
                    line += " ";
                }
                space_needed -= n_space;
            }

            Console.WriteLine(line);
        }

        static void Justify(string text, int line_width){
            var words = SplitText(text);
            int len = words.Count;

            int temp_len = 0, start_index = 0, current_line_length = 0;
            int n_words_in_current_line = 0;

            for(int i = 0; i < len; i++){
                n_words_in_current_line++;
                temp_len = current_line_length + words[i].Length + n_words_in_current_line - 1;
                // Console.WriteLine($"n_words {n_words_in_current_line}, crnt line len {current_line_length} temp len {temp_len}");
            
                if (temp_len == line_width){
                    // Console.WriteLine("if 1");
                    PrintLine(words, start_index, i, i - start_index);                    
                    start_index = i + 1;
                    temp_len = 0;
                    n_words_in_current_line = 0;
                    current_line_length = 0;
                }
                else if (temp_len > line_width){
                    // Console.WriteLine("if 2");
                    PrintLine(words, start_index, i -1 , line_width - current_line_length);                    
                    start_index = i;
                    temp_len = 0;
                    n_words_in_current_line = 1;
                    current_line_length = words[i].Length;
                }
                else{
                    current_line_length += words[i].Length;
                }
            }

            if(n_words_in_current_line > 0){
                PrintLine(words, start_index, len -1 , n_words_in_current_line - 1);
            }
        }
        static void Main(string[] args)
        {
            string text = "This is a text. I will try to justify this text using c sharp. I think this will be fun.";
            int line_width = 25;

            Justify(text, line_width);
        }
    }
}
