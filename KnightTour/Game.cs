using System;
using System.Collections.Generic;
using System.Text;

namespace KnightTour
{
    public class Game {

        private Board _board;
        private int _step;

        public void InitGame(int size) 
        {
            _board = new Board(size);
            _step = 0;
        }

        public bool Move(int step, int i, int j) 
        {
            foreach (Directions direction in Enum.GetValues(typeof(Directions))) 
            {
                var newPosition = NextMove(direction, i, j);

                int newI = newPosition.Item1;
                int newJ = newPosition.Item2;

                if (_board.IsPaneValid(newI, newJ))
                {
                    if (_board.GetPane(newI, newJ).GetPaneStatus() == PaneStatus.empty) 
                    {
                        _board.MoveKnight(step, newI, newJ);

                        _step++;

                        if (step < _board.GetSize() * _board.GetSize()) 
                        {
                            
                            if (!Move(step + 1, newI, newJ)) 
                            {
                                _board.GetPane(newI, newJ).SetStepNumber(0);
                                _board.GetPane(newI, newJ).SetPaneStatus(PaneStatus.empty);
                            }
                            else
                            {
                                step--;
                                _board.GetPane(newI, newJ).SetPaneStatus(PaneStatus.empty);
                                _board.GetPane(newI, newJ).SetStepNumber(0);
                            }
                        }
                        else 
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void Start(int i, int j)
        {
            if (_board.IsPaneValid(i, j)) 
            {
                _board.GetPane(i, j).SetPaneStatus(PaneStatus.visited);
                _board.GetPane(i, j).SetStepNumber(1);
                if (Move(2, i, j)) 
                {
                    Console.WriteLine("Succed");
                    _board.PrintBoard();    
                }
                else 
                {
                    Console.WriteLine("Not succed");
                }
                Console.WriteLine(_step);
            }
            else 
            {
                Console.WriteLine("Wrong starting position");    
            }
        }

        private Tuple<int, int> NextMove(Directions directions, int i, int j) 
        {
            switch (directions) {
                case Directions.UpRight:
                    i += 1;
                    j += 2;
                    break;
                case Directions.RightUp:
                    i += 2;
                    j += 1;
                    break;
                case Directions.RightDown:
                    i += 2;
                    j -= 1;
                    break;
                case Directions.DownRight:
                    i += 1;
                    j -= 2;
                    break;
                case Directions.DownLeft:
                    i -= 1;
                    j -= 2;
                    break;
                case Directions.LeftDown:
                    i -= 2;
                    j -= 1;
                    break;
                case Directions.LeftUp:
                    i -= 2;
                    j += 1;
                    break;
                case Directions.UpLeft:
                    i -= 1;
                    j += 2;
                    break;

            }
            return new Tuple<int, int>(i, j);
        }
    }
}
