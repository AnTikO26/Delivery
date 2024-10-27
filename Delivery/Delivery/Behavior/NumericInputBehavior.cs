using Microsoft.Xaml.Behaviors;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Delivery.Behavior;

public class NumericInputBehavior : Behavior<TextBox>
{
    private const int MaxLength = 19; // Максимальная длина символов

    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        AssociatedObject.TextChanged += OnTextChanged;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        AssociatedObject.PreviewTextInput -= OnPreviewTextInput;
        AssociatedObject.TextChanged -= OnTextChanged;
    }

    private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = !IsInputAllowed(e.Text);
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;
        if (textBox != null && textBox.Text.Length > MaxLength)
        {
            textBox.Text = textBox.Text.Substring(0, MaxLength);
            textBox.SelectionStart = textBox.Text.Length; // Устанавливаем курсор в конец
        }
    }

    private bool IsInputAllowed(string input)
    {
        return !string.IsNullOrEmpty(input) && System.Text.RegularExpressions.Regex.IsMatch(input, @"^[0-9\s\.:]*$");
    }
}
