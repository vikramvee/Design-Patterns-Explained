// See https://aka.ms/new-console-template for more information
using System;

Application app = new Application();
app.Main();

// The product interface declares the operations that all concrete products must implement.
interface IButton
{
    void Render();
    void OnClick(Action action);
}

// Concrete products provide various implementations of the product interface.
class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a Windows button.");
    }

    public void OnClick(Action action)
    {
        Console.WriteLine("Windows button clicked.");
        action?.Invoke();
    }
}

class HTMLButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering an HTML button.");
    }

    public void OnClick(Action action)
    {
        Console.WriteLine("HTML button clicked.");
        action?.Invoke();
    }
}

// The creator class declares the factory method that must return an object of a product class.
abstract class Dialog
{
    // Factory method
    public abstract IButton CreateButton();

    public void Render()
    {
        // Call the factory method to create a product object.
        IButton okButton = CreateButton();
        // Now use the product.
        okButton.OnClick(CloseDialog);
        okButton.Render();
    }

    private void CloseDialog()
    {
        Console.WriteLine("Dialog closed.");
    }
}

// Concrete creators override the factory method to change the resulting product's type.
class WindowsDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

class WebDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new HTMLButton();
    }
}

// Application class to initialize and run the dialog.
class Application
{
    private Dialog dialog;

    private static readonly Dictionary<string, Func<Dialog>> DialogFactory = new()
{
    { "Windows", () => new WindowsDialog() },
    { "Web", () => new WebDialog() }
};

    public void Initialize()
    {
        string configOS = ReadApplicationConfigFile();

        if (!DialogFactory.TryGetValue(configOS, out var dialog))
        {
            throw new Exception("Error! Unknown operating system.");
        }
    }

    public void Main()
    {
        Initialize();
        dialog.Render();
    }

    private string ReadApplicationConfigFile()
    {
        // Mocking configuration retrieval
        return "Windows"; // Change this value to "Web" to test WebDialog
    }
}




