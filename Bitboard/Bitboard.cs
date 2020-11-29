using System;
using System.Linq;

namespace TestApp
{
    public class Bitboard : ITask
    {
        public string Title { get => "Шахматные биты"; }
        ulong[,] Board = new ulong[8, 8];

        int figX, figY;

        public Bitboard()
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
        }

        public string Run(string[] data)
        {
            /** Получение порядкового номера поля */
            var n = Convert.ToByte(data[0]);

            /** Вычисление координат фигуры */
            this.figY = n / 8;
            this.figX = n % 8;

            /** Получение возможных направлений движения */
            var directions = GetDirections();
            var hash = CalcHash(directions);

            return $"{directions.Length}\r\n{hash}";
        }

        /// <summary>
        /// Определние возможных направлений для хода
        /// </summary>
        /// <param name="n">Порядковый номер поля</param>
        /// <returns>Возможные направления для хода</returns>
        private byte[] GetDirections()
        {
            /** Направления, движения в которые недоступных из крайних положений на доске */
            byte[] top = { 1, 2, 8 };
            byte[] right = { 2, 3, 4 };
            byte[] bottom = { 4, 5, 6 };
            byte[] left = { 6, 7, 8 };

            byte[] directions = { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] deniedDirections = { };

            /** Нижняя граница */
            if (this.figY == 0)
            {
                deniedDirections = deniedDirections.Concat(bottom);
            }

            /** Верхняя граница */
            if (this.figY == 7)
            {
                deniedDirections = deniedDirections.Concat(top);
            }

            /** Левая граница */
            if (this.figX == 0)
            {
                deniedDirections = deniedDirections.Concat(left);
            }

            /** Правая граница */
            if (this.figX == 7)
            {
                deniedDirections = deniedDirections.Concat(right);
            }

            return directions.Except(deniedDirections).ToArray();
        }

        /// <summary>
        /// Вычисление суммы возможных для хода полей
        /// </summary>
        /// <param name="directions">Возможные направления</param>
        /// <returns></returns>
        private ulong CalcHash(byte[] directions)
        {
            ulong result = 0;
            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case 1:
                        result += Board[figX, figY + 1];
                        break;
                    case 2:
                        result += Board[figX + 1, figY + 1];
                        break;
                    case 3:
                        result += Board[figX + 1, figY];
                        break;
                    case 4:
                        result += Board[figX + 1, figY - 1];
                        break;
                    case 5:
                        result += Board[figX, figY - 1];
                        break;
                    case 6:
                        result += Board[figX - 1, figY - 1];
                        break;
                    case 7:
                        result += Board[figX - 1, figY];
                        break;
                    case 8:
                        result += Board[figX - 1, figY + 1];
                        break;
                }
            }
            return result;
        }


    }
}