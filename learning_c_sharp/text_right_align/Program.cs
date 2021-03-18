using System;
using System.Collections;
using System.Collections.Generic;

namespace right_align
{
    class Program
    {
        static List<string> SplitLine(string text){
            List<string> words = new List<string>();

            string word = "";

            foreach(var chr in text){
                if(chr != ' '){
                    word += chr;
                }else{
                    words.Add(word);
                    word = "";
                }
            }

            if(word != ""){
                words.Add(word);
            }

            return words;
        }

        static void PrintAlignedLine(List<string> words, int start_index, int end_index, int space_needed){
            int n_words = end_index - start_index + 1;

            // Console.WriteLine($"Start index {start_index}, end index {end_index} space needed {space_needed}");

            string aligned_line = "";
            for(int i = end_index; i > start_index; i--){
                aligned_line = " " + words[i] + aligned_line;
                space_needed--;
            }
            aligned_line = words[start_index] + aligned_line;

            while(space_needed > 0){
                aligned_line = " " + aligned_line;
                space_needed--;
            }
            Console.WriteLine(aligned_line);
        }
        static void right_align(string text, int line_width){
            var words = SplitLine(text);

            int start_index = 0;
            int n_words_in_current_line = 0;
            int current_line_len = 0;

            int possible_line_length = 0;
            int i = 0;

            foreach (var word in words){
                possible_line_length = current_line_len + word.Length + n_words_in_current_line;

                if(possible_line_length == line_width){
                    PrintAlignedLine(words, start_index, i, i - start_index);

                    start_index = i + 1;
                    n_words_in_current_line = 0;
                    current_line_len = 0;

                }
                else if(possible_line_length > line_width){
                    // print line upto previous word
                    PrintAlignedLine(words, start_index, i - 1, line_width - current_line_len);

                    start_index = i;
                    n_words_in_current_line = 1;
                    current_line_len = word.Length;

                }
                else{
                    // add the word in current line
                    current_line_len += word.Length;
                    n_words_in_current_line++;
                }
                i++;
            }

            if(n_words_in_current_line > 0){
                PrintAlignedLine(words, start_index, i, line_width - current_line_len);
            }
        }
        static void Main(string[] args)
        {
            string text = "This is a text. I will try to right aling this text using c sharp. I think this will be fun.";
            int line_width = 20;

            right_align(text, line_width);
        }
    }
}
