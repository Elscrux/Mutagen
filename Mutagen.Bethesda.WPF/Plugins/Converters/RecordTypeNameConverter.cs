using Loqui;
using System.Globalization;
using System.Windows.Data;
using Mutagen.Bethesda.Plugins;

namespace Mutagen.Bethesda.WPF.Plugins.Converters;

public class RecordTypeNameConverter : IValueConverter
{
    static RecordTypeNameConverter()
    {
        Warmup.Init();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Type type) return Binding.DoNothing;
        if (LoquiRegistration.TryGetRegister(type, out var register))
        {
            return register.ClassType.Name;
        }
        return type.Name;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}