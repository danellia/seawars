using System.Collections;

namespace seawars
{
    public partial class Form1 : Form
    {
        const int mapSize = 10;
        int cellSize = 30;
        string alphabet = "АБВГДЕЖЗИК";

        public int[,] myMap = new int[mapSize, mapSize];
        public int[,] enemyMap = new int[mapSize, mapSize];

        public Button[,] myButtons = new Button[mapSize, mapSize];
        public Button[,] enemyButtons = new Button[mapSize, mapSize];

        public bool isPlaying = false;

        List<oneShip> ships = new List<oneShip>();

        public Form1()
        {
            InitializeComponent();
        }

        public void initMaps()
        {
            this.Width = mapSize * 2 * cellSize + 50;
            this.Height = (mapSize + 3) * cellSize + 20;
            for (int i = 0; i < mapSize; ++i)
            {
                for (int j = 0; j < mapSize; ++j)
                {
                    myMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        button.Click += new EventHandler(ConfigureShips);
                    }
                    myButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            for (int i = 0; i < mapSize; ++i)
            {
                for (int j = 0; j < mapSize; ++j)
                {
                    myMap[i, j] = 0;
                    enemyMap[i, j] = 0;

                    Button button = new Button();
                    button.Location = new Point(320 + j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    if (j == 0 || i == 0)
                    {
                        button.BackColor = Color.Gray;
                        if (i == 0 && j > 0)
                            button.Text = alphabet[j - 1].ToString();
                        if (j == 0 && i > 0)
                            button.Text = i.ToString();
                    }
                    else
                    {
                        //button.Click += new EventHandler(PlayerShoot);
                    }
                    enemyButtons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            Label map1 = new Label();
            map1.Text = "Карта игрока";
            map1.Location = new Point(mapSize * cellSize / 2, mapSize * cellSize + 10);
            this.Controls.Add(map1);

            Label map2 = new Label();
            map2.Text = "Карта противника";
            map2.Location = new Point(350 + mapSize * cellSize / 2, mapSize * cellSize + 10);
            this.Controls.Add(map2);
        }

        public void ConfigureShips(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            double x = (double)pressedButton.Location.X / (double)cellSize + 0.0;
            double y = (double)pressedButton.Location.Y / (double)cellSize + 0.0;

            //if (myMap[(int)x, (int)y] == 0 && checkShips == true)
            if (checkShips() && pressedButton.BackColor == Color.White)
            {
                oneShip temp = new oneShip(new position((int)x, (int)y));
                //for (int i = 0; i < oneShips.Length; ++i)
                
                    if (temp.checkBorders(ships)) { 
                        pressedButton.BackColor = Color.Red;
                        ships.Add(temp);
                    }
                
            }
            else
            {
                pressedButton.BackColor = Color.White;
                myMap[(int)x, (int)y] = 0;
            }
        }

        private bool checkShips()
        {
            if (ships.Count == 10) return false;
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            initMaps();
        }
    }
}