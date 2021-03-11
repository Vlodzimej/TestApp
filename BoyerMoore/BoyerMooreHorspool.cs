using System.Collections.Generic;

namespace TestApp
{
    public class OffsetTableItem
    {
        public char key { get; set; }
        public int value { get; set; }
    }

    public class BoyerMooreHorspool : ITask
    {
        public string Title { get => "Boyer-Moore-Horspool"; }

        public BoyerMooreHorspool() { }

        public string Run(string[] data)
        {
            int result = 0;

            var source = data[1];
            var template = data[0];

            int sourceLenght = source.Length;
            int templateLenght = template.Length;

            if (templateLenght > sourceLenght)
            {
                result = -1;
                return result.ToString();
            }

            var offsetTable = new List<OffsetTableItem>();

            for (var i = 0; i <= 255; i++)
            {
                offsetTable.Add(new OffsetTableItem()
                {
                    key = (char)i,
                    value = templateLenght
                });
            }

            for (var i = 0; i < templateLenght - 1; i++)
            {
                var key = template.ToCharArray()[i];
                if (offsetTable.FindIndex(item => item.key == key) < 0)
                {
                    offsetTable.Add(new OffsetTableItem()
                    {
                        key = template.ToCharArray()[i],
                        value = templateLenght - i - 1
                    });
                }
            }

            var a = templateLenght - 1;
            var b = a;
            var c = a;

            while (b >= 0 && a <= sourceLenght)
            {
                b = templateLenght - 1;
                c = a;
                while (b >= 0 && source.ToCharArray()[c] == template.ToCharArray()[b])
                {
                    c--;
                    b--;
                }
                a += offsetTable.Find(item => item.key == source.ToCharArray()[a]).value;
            }
            if (c >= sourceLenght - templateLenght)
            {
                result = -1;
            }
            else
            {
                result = c + 1;
            }

            return result.ToString();

        }
    }
}