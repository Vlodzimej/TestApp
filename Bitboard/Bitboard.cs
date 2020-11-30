using System;
using System.Linq;
using TestApp;

namespace Bits
{
    public class Bitboard : ITask
    {
        public string Title { get => "Шахматные биты"; }
        ulong[,] Board = new ulong[8, 8];

        string figureName;

        public Bitboard(string figureName)
        {
            byte count = 0;
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Board[x, y] = (ulong)Math.Pow(2, count);
                    count++;
                }
            }
            this.figureName = figureName;
        }

        public string Run(string[] data)
        {
            /** Получение порядкового номера поля */
            var n = Convert.ToByte(data[0]);
            Figure figure = new Figure(Board, 0);

            switch (figureName)
            {
                case "king":
                    figure = new King(Board, n);
                    break;
                case "knight":
                    figure = new Knight(Board, n);
                    break;
                case "castle":
                    figure = new Castle(Board, n);
                    break;
                case "bishop":
                    figure = new Bishop(Board, n);
                    break;
                case "queen":
                    figure = new Queen(Board, n);
                    break;
            }

            var hash = figure.CalcHash();

            return $"{figure.MoveCounter}\r\n{hash}";
        }
    }
}