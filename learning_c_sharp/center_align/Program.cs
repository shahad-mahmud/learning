using System;
using System.Collections.Generic;

namespace center_align
{
    class Program
    {
        static List<string> SplitText(string text){
            List<string> words = new List<string>();

            string temp_word = "";

            foreach(char chr in text){
                if(chr != ' '){
                    temp_word += chr;
                }
                else{
                    words.Add(temp_word);
                    temp_word = "";
                }
            }

            if(temp_word != ""){
                words.Add(temp_word);
            }

            return words;
        }

        static void PrintLine(List<string> words, int start_index, int end_index, int space_needed){
            int n_words = end_index - start_index + 1;

            // if(space_needed >= n_words)
            // {

            // }
            int left_spaces = (int)Math.Ceiling((space_needed - n_words) / 2.0);

            // Console.WriteLine($"n words {n_words} space {space_needed} left {left_spaces}");
            string line = "";
            while(left_spaces > 0){
                line += " ";
                left_spaces--;
            }

            for(int i = start_index; i < end_index; i++){
                line += words[i] + " ";
            }
            line += words[end_index];

            Console.WriteLine(line);
        }
        static void AlignCenter(string text, int line_width){
            var words = SplitText(text);

            int start_index = 0;
            int n_words_in_current_line = 0;
            int current_line_length = 0;

            int possible_line_lenght = 0;
            int i = 0;

            foreach (string word in words){
                possible_line_lenght = current_line_length + word.Length + n_words_in_current_line;

                if(possible_line_lenght == line_width){
                    // the current word is in current line
                    PrintLine(words, start_index, i, i - start_index);

                    start_index = i + 1;
                    n_words_in_current_line = 0;
                    current_line_length = 0;
                }
                else if(possible_line_lenght > line_width){
                    // the curremt word is not in current line
                    PrintLine(words, start_index, i - 1, line_width - current_line_length);

                    start_index = i;
                    n_words_in_current_line = 1;
                    current_line_length = word.Length;
                }
                else{
                    // the current word is in current line
                    n_words_in_current_line++;
                    current_line_length += word.Length;
                }

                i++;
            }

            if(n_words_in_current_line > 0){
                PrintLine(words, start_index, i - 1, line_width - current_line_length);
            }
        }
        static void Main(string[] args)
        {
            string text = "This is a text. I will try to justify this text using c sharp. I think this will be fun.";
            int line_width = 15;

            AlignCenter(text, line_width);

            // Console.WriteLine("Hello World!");
        }
    }
}
