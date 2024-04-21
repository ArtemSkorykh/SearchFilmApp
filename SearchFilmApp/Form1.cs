namespace SearchFilmApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var movie = await MovieService.GetMovieAsync(textBox1.Text, int.Parse(textBox2.Text), comboBox1.Text);
                textBox3.Text = movie.Plot;
                label3.Text = movie.Title;
                pictureBox1.LoadAsync($@"{movie.PosterUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
