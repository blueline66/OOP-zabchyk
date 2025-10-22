using System;

namespace lab4v1
{
    // Клас для видалення пробілів із рядка
    public class SpaceRemoverFilter : AbstractFilter
    {
        public override string Apply(string input)
        {
            return input.Replace(" ", "");
        }
    }
}
