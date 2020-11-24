# Степень, Числа Фибоначчи, Простые числа

Тесты проведены на процессоре Intel i3-2330M

## 1. Алгоритм возведения в степень макс (Power)

### 1a. Итеративный (n умножений)

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         2 |
| 1   |  PASS  |         0 |
| 2   | FAILED |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   | FAILED |         0 |
| 6   |  PASS  |        61 |
| 7   |  PASS  |       527 |
| 8   |  PASS  |      5093 |
| 9   |   -    |         - |

### 1b. Через степень двойки с домножением

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         2 |
| 1   |  PASS  |         0 |
| 2   | FAILED |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   | FAILED |         5 |
| 6   |  PASS  |        52 |
| 7   |  PASS  |       521 |
| 8   |  PASS  |      5111 |
| 9   |   -    |         - |

### 1c. Через двоичное разложение показателя степени

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         2 |
| 1   |  PASS  |         0 |
| 2   | FAILED |         0 |
| 3   |  PASS  |         0 |
| 4   | FAILED |         0 |
| 5   | FAILED |         0 |
| 6   | FAILED |         0 |
| 7   | FAILED |         0 |
| 8   | FAILED |         0 |
| 9   | FAILED |         0 |

## 2. Алгоритм поиска чисел Фибоначчи макс (Fibonacci)

### 2a. Через рекурсию

| №   |     Result     | Time (ms) |
| --- | :------------: | --------: |
| 0   |      PASS      |         2 |
| 1   |      PASS      |         0 |
| 2   |      PASS      |         0 |
| 3   |      PASS      |         0 |
| 4   |      PASS      |         0 |
| 5   |      PASS      |         0 |
| 6   |      PASS      |         0 |
| 7   |     FAILED     |         0 |
| 8   |     FAILED     |         0 |
| 10  | Stack Overflow |           |

### 2b. Через итерацию

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   | FAILED |         0 |
| 8   | FAILED |         0 |
| 10  | FAILED |         0 |
| 11  | FAILED |         0 |
| 12  | FAILED |         0 |
| 13  | FAILED |         0 |
| 14  | FAILED |         4 |
| 15  | FAILED |        56 |

### 2c. По формуле золотого сечения

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   | FAILED |         0 |
| 8   | FAILED |         0 |
| 10  | FAILED |         0 |
| 11  | FAILED |         0 |
| 12  | FAILED |         0 |
| 13  | FAILED |         0 |
| 14  | FAILED |         4 |
| 15  | FAILED |        56 |

### 2d. Через умножение матриц

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   | FAILED |         0 |
| 4   | FAILED |         0 |
| 5   | FAILED |         0 |
| 6   |  PASS  |         0 |
| 7   | FAILED |         0 |
| 8   | FAILED |         0 |
| 10  | FAILED |         0 |
| 11  | FAILED |         0 |
| 12  | FAILED |         0 |
| 13  | FAILED |         0 |
| 14  | FAILED |         0 |
| 15  | FAILED |         0 |

## 3. Алгоритмы поиска кол-ва простых чисел до N макс (Primes)

### 3a. Через перебор делителей

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   |  PASS  |         0 |
| 8   |  PASS  |       451 |
| 9   |  PASS  |     38240 |
| 10  |  PASS  |   3317612 |
| 11  |   -    |         - |
| 12  |   -    |         - |
| 13  |   -    |         - |
| 14  |   -    |         - |

### 3b-1. Через перебор делителей с оптимизацией

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   |  PASS  |         0 |
| 8   |  PASS  |         0 |
| 9   |  PASS  |        16 |
| 10  |  PASS  |       307 |
| 11  |  PASS  |      6331 |
| 12  |  PASS  |    158870 |
| 13  |  PASS  |   4338154 |
| 14  |   -    |         - |

### 3b-2. Через перебор делителей с использованием массива

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   |  PASS  |         0 |
| 8   |  PASS  |         4 |
| 9   |  PASS  |       370 |
| 10  |  PASS  |     22145 |
| 11  |  PASS  |   1901717 |
| 12  |   -    |         - |
| 13  |   -    |         - |
| 14  |   -    |         - |

### 3c. Решето Эратосфена

| №   | Result | Time (ms) |
| --- | :----: | --------: |
| 0   |  PASS  |         0 |
| 1   |  PASS  |         0 |
| 2   |  PASS  |         0 |
| 3   |  PASS  |         0 |
| 4   |  PASS  |         0 |
| 5   |  PASS  |         0 |
| 6   |  PASS  |         0 |
| 7   |  PASS  |         0 |
| 8   |  PASS  |         0 |
| 9   |  PASS  |         3 |
| 10  |  PASS  |        34 |
| 11  |  PASS  |       436 |
| 12  |  PASS  |      4433 |
| 13  |  PASS  |     46771 |
| 14  |  PASS  |      5247 |
