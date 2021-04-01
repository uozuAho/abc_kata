using System;
using System.Collections.Generic;

namespace abc_kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("can make word: 'A': " + CanMakeWord("A", BlocksWithLetters("ABCT"))); // expect true
            Console.WriteLine("can make word: 'C': " + CanMakeWord("C", BlocksWithLetters("ABCT"))); // expect true
            Console.WriteLine("can make word: 'CAT': " + CanMakeWord("CAT", BlocksWithLetters("ABCT"))); // expect true
            Console.WriteLine("can make word: 'GNAT': " + CanMakeWord("GNAT", BlocksWithLetters("ABCT"))); // expect false
            Console.WriteLine("can make word: 'AA': " + CanMakeWord("AA", BlocksWithLetters("ABCT"))); // expect false
        }

        private static Blocks BlocksWithLetters(string letters)
        {
            var blocks = new List<Block>();

            foreach (var letter in letters)
            {
                blocks.Add(new Block(letter));
            }

            return new Blocks(blocks.ToArray());
        }

        private static bool CanMakeWord(string word, Blocks blocks)
        {
            foreach (var letter in word)
            {
                if (blocks.HasABlockWithLetter(letter))
                {
                    blocks.RemoveBlockWithLetter(letter);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }

    internal class Blocks
    {
        private readonly Block[] _blocks;

        public Blocks(Block[] blocks)
        {
            _blocks = blocks;
        }

        public bool HasABlockWithLetter(char letter)
        {
            foreach (var block in _blocks)
            {
                if (block.Letter == letter)
                {
                    return true;
                }
            }

            return false;
        }

        public void RemoveBlockWithLetter(char letter)
        {
        }
    }

    internal class Block
    {
        public char Letter { get; set; }

        public Block(char letter)
        {
            Letter = letter;
        }
    }
}
