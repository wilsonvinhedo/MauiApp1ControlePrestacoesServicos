using System.Globalization;

namespace MauiApp1ControlePrestacoesServicos.Converters
{
    public class SaldoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal saldo)
            {
                // Retorna verde para valores positivos, vermelho para negativos
                return saldo >= 0 ? Colors.Green : Colors.Red;
            }

            // Cor padrão se o valor não for decimal
            return Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Não necessário para conversão one-way (apresentação)
            throw new NotImplementedException();
        }
    }
}