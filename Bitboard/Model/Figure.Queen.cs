using System.Linq;

namespace Bits
{
    /// <summary>
    /// Фигура "Ферзь"
    /// </summary>
    public class Queen : Figure
    {
        public Queen(ulong[,] board, byte n) : base(board, n)
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
                () => {
                    ulong result = 0;
                    for(int i = 1; figX + i < 8 && figY + i < 8; i++) {
                        result += board[figX+i, figY+i];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int x = figX + 1; x < 8; x++) {
                        result += board[x, figY];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int i = 1; figX + i < 8 && figY - i >= 0; i++) {
                        result += board[figX+i, figY-i];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int y = figY - 1; y > (-1); y--) {
                        result += board[figX, y];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int i = 1; figX - i >= 0 && figY - i >= 0; i++) {
                        result += board[figX-i, figY-i];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int x = figX - 1; x > (-1); x--) {
                        result += board[x, figY];
                        moveCounter++;
                    }
                    return result;
                },
                () => {
                    ulong result = 0;
                    for(int i = 1; figX - i >= 0 && figY + i < 8; i++) {
                        result += board[figX-i, figY+i];
                        moveCounter++;
                    }
                    return result;
                },
            };

            directions = GetDirections();
        }

        /// <summary>
        /// Получение возможных направлений движеня для текущих координат Ферзя 
        /// </summary>
        /// <returns>Массив направлений</returns>
        private byte[] GetDirections()
        {
            byte[] directs = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            if (figY == 0) directs = directs.Except(new byte[] { 3, 4, 5 }).ToArray();
            if (figY == 7) directs = directs.Except(new byte[] { 0, 1, 7 }).ToArray();
            if (figX == 0) directs = directs.Except(new byte[] { 5, 6, 7 }).ToArray();
            if (figX == 7) directs = directs.Except(new byte[] { 1, 2, 3 }).ToArray();

            return directs;
        }
    }
}