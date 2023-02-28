namespace Project1;

public partial class ScientificPage : ContentPage
{
    public ScientificPage()
    {
        InitializeComponent();
        TextClear(this, null);
    }


    async Task<string> ActCalc()
    {
        var client = new HttpClient();
        string plusChanged = FirstBatch.Replace("+", "%2B");
        System.Diagnostics.Debug.WriteLine($"{plusChanged}");
        string api = $"http://api.mathjs.org/v4/?expr={plusChanged}";
        System.Diagnostics.Debug.WriteLine($"+{api}");
        var Status = await client.GetAsync(api);
        var StatusString = await Status.Content.ReadAsStringAsync();
        if (StatusString.StartsWith("Error"))
        {
            System.Diagnostics.Debug.WriteLine("error caught");
            return "Err";
        }
        else
        {
            System.Diagnostics.Debug.WriteLine(StatusString);
            this.Batch1_Process.Text = StatusString;
            return StatusString.ToString();
        }
    }




    void ReturnKey(object Passer, EventArgs e)
    {
        ActCalc().ToString();
    }
    public void Clickable(object Passer, EventArgs e)
    {
        Button button = (Button)Passer;
        string Rets = button.Text;
        if (FirstBatch.Length < 1)
        {
            if (Rets != "+" && Rets != "*" && Rets != "/")
            {
                FirstBatch = Rets;
                this.EndText.Text = Rets;
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine($"This is the Last{FirstBatch[FirstBatch.Length - 1]}");
            if (FirstBatch[FirstBatch.Length - 1] == '+' || FirstBatch[FirstBatch.Length - 1] == '-' || FirstBatch[FirstBatch.Length - 1] == '*' || FirstBatch[FirstBatch.Length - 1] == '/')
            {
                if (Rets != "+" && Rets != "-" && Rets != "*" && Rets != "/")
                {
                    FirstBatch += Rets;
                    this.EndText.Text += Rets;
                }
            }
            else
            {
                FirstBatch += Rets;
                this.EndText.Text += Rets;
            }

        }
        System.Diagnostics.Debug.WriteLine(FirstBatch);
        System.Diagnostics.Debug.WriteLine(this.EndText.Text);

    }
    string FirstBatch = "";
    void TextClear(object Passer, EventArgs e)
    {

        this.EndText.Text = "0";
        FirstBatch = string.Empty;
    }
    void Percentage(object Passer, EventArgs e)
    {
        if (FirstBatch.Length > 0)
        {
            if (FirstBatch[FirstBatch.Length - 1] != '+' || FirstBatch[FirstBatch.Length - 1] != '-' || FirstBatch[FirstBatch.Length - 1] != '*' || FirstBatch[FirstBatch.Length - 1] != '/')
            {
                FirstBatch += "*0.01";
                this.EndText.Text += "*0.01";

            }
        }
    }
    void SqrRoot(object Passer, EventArgs e)
    {
        if (FirstBatch.Length > 0)
        {
            if (FirstBatch[FirstBatch.Length - 1] != '+' || FirstBatch[FirstBatch.Length - 1] != '-' || FirstBatch[FirstBatch.Length - 1] != '*' || FirstBatch[FirstBatch.Length - 1] != '/')
            {
                var currentEntryTemp = $"{FirstBatch}";
                FirstBatch = $"sqrt({FirstBatch})";
                this.EndText.Text = $"√{currentEntryTemp}";
            }
        }
    }
    void Mod(object Passer, EventArgs e)
    {
        if (FirstBatch.Length > 0)
        {
            if (FirstBatch[FirstBatch.Length - 1] != '+' || FirstBatch[FirstBatch.Length - 1] != '-' || FirstBatch[FirstBatch.Length - 1] != '*' || FirstBatch[FirstBatch.Length - 1] != '/')
            {
                FirstBatch += "%25";
                this.EndText.Text += "%";

            }
        }
    }
}