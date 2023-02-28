using Project1.Themes;

namespace Project1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
    }
    void DarkMode(object Passer, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new DarkMode());

        }
    }

    void LightMode(object Passer, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new LightMode());

        }
    }

    void MarsMode(object Passer, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new MarsMode());

        }
    }
    void PinkMode(object Passer, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new PinkMode());

        }
    }
}