using System.Globalization;

namespace Bugzzinga.Infraestructura.Html
{
    public class ColumnSpan
    {
        public static ColumnSpan Span(int value)
        {
            return new ColumnSpan(value);
        }

        private readonly int value;

        private ColumnSpan(int value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
