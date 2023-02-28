namespace Project1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        TextClear(this, null);
    }




    async Task<string> Act_Cal()
    {
        var client = new HttpClient();
        string act_string = FirstBatch.Replace("+", "%2B");
        System.Diagnostics.Debug.WriteLine($"{act_string}");
        string api = $"http://api.mathjs.org/v4/?expr={act_string}";
        System.Diagnostics.Debug.WriteLine($"+{api}");
        var Status = await client.GetAsync(api);
        var StatusString = await Status.Content.ReadAsStringAsync();
        if (StatusString.StartsWith("Error"))
        {
            System.Diagnostics.Debug.WriteLine("error");
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
        Act_Cal().ToString();
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
            System.Diagnostics.Debug.WriteLine($"EoL{FirstBatch[FirstBatch.Length - 1]}");

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
    string FirstBatch = ""; // Replace
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

    void TextClear(object Passer, EventArgs e)
    {

        this.EndText.Text = "0";
        FirstBatch = string.Empty;
    }
}
