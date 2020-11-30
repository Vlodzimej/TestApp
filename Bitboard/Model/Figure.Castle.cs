using System.Linq;

namespace Bits
{
    /// <summary>
    /// Фигура "Ладья"
    /// </summary>
    public class Castle : Figure
    {
        public Castle(ulong[,] board, byte n) : base(board, n)
        {
            /** Определение функций для вычисления суммы полей для каждого направления */
            directionProcesses = new DirectionProcess[8]{
                () => {
                    ulong result = 0;
                    for(int y = figY + 1; y < 8; y++) {
                        result += board[figX, y];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int x = figX + 1; x < 8; x++) {
                        result += board[x, figY];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int y = figY - 1; y >= 0; y--) {
                        result += board[figX, y];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int x = figX - 1; x >= 0; x--) {
                        result += board[x, figY];
                        moveCounter++;
                    }
                    return result;
                },
                null,
            };

            directions = GetDirections();
        }

        /// <summary>
        /// Получение возможных направлений движеня для текущих координат Лошади 
        /// </summary>
        /// <returns>Массив направлений</returns>
        private byte[] GetDirections()
        {
            byte[] directs = new byte[] { 0, 2, 4, 6 };

            if (figY == 0) directs = directs.Except(new byte[] { 4 }).ToArray();
            if (figY == 7) directs = directs.Except(new byte[] { 0 }).ToArray();
            if (figX == 0) directs = directs.Except(new byte[] { 6 }).ToArray();
            if (figX == 7) directs = directs.Except(new byte[] { 2 }).ToArray();

            return directs;
        }
    }
}