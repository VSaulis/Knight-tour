using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace KnightTour
{
    public class Board 
    {
        private Pane[,] _board;
        private readonly int _size;

        public Board(int size) 
        {
            _size = size;
            InitBoard();
        }

        public void PrintBoard() 
        {
            PrintLetters();
            Console.WriteLine("       " + new String('-', 5 * _size));
            for (int i = _size - 1; i >= 0; i--) 
            {
                Console.Write("   " + (i + 1) + "  | ");
                for (int j = 0; j < _size; j++) 
                {
                    if (_board[i, j].GetStepNumber() > 9) 
                    {
                        Console.Write(_board[i, j].GetStepNumber() + " | ");
                    }
                    else
                    {
                        Console.Write("0" + _board[i, j].GetStepNumber() + " | ");
                    }
                    
                }
                Console.WriteLine();
                Console.WriteLine("       " + new String('-', 5 * _size));
            }
            
        }

        public void MoveKnight(int step, int i, int j) 
        {
            _board[i, j].SetStepNumber(step);
            _board[i, j].SetPaneStatus(PaneStatus.visited);
        }

        public Pane GetPane(int i, int j) 
        {
            return _board[i, j];
        }

        public bool IsPaneValid(int i, int j) 
        {
            if (i <= (_size - 1) && i >= 0 && j <= (_size - 1) && j >= 0) 
            {
                return true;
            }
            return false;
        }

        public int GetSize() 
        {
            return _size;
        }

        private void PrintLetters() 
        {
            Console.WriteLine();
            Console.Write("       ");
            for (int i = char.ToUpper('A'); i < char.ToUpper('A') + _size; i++) 
            {
                Console.Write("  " + (char)i + "  ");
            }
            Console.WriteLine();
        }

        private void InitBoard() 
        {
            _board = new Pane[_size, _size];
            for (int i = 0; i < _size; i++) 
            {
                for (int j = 0; j < _size; j++)
                {
                    _board[i,j] = new Pane(i, j);
                }
            }
        }

    }
}
