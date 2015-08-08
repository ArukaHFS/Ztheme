using System;
using System.Windows.Forms;
using System.IO;

namespace Ztheme
{
    public partial class Form1 : Form
    {
        string fond;
        string element1;
        string element2;
        string element3;
        string element4;
        string element5;
        string video;
        string cadreVideo;
        string theme;
        string destFile;
        string baseHtml;
        string nomRom = "nom de la rom";
        string curDir = Directory.GetCurrentDirectory(); //recupère le dossier ou se trouve l'application

        public Form1()
        {
            InitializeComponent();
            //Création du fichier index.html avec sa structure de base
            baseHtml = "<html>\n<head>\n<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\n<script src=\"fabric.js\"></script>\n</head>\n<body>\n<canvas id=\"Canvas\" width=\"960\" height=\"540\">\n</canvas>\n<script>\nvar canvas = new fabric.Canvas('Canvas');\n</script>\n</body></html>";
            System.IO.StreamWriter file = new System.IO.StreamWriter("index.html");
            file.WriteLine(baseHtml);
            file.Close();
            //Affiche index.html
            webBrowser1.Navigate(String.Format("file:///{0}/index.html", curDir));
        }

        private void Ztheme_Load(object sender, EventArgs e)
        {
            var items = checkedListBox1.Items;
            items.Add("Rebond");
            items.Add("Défilement vers la gauche");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog(); //création d'une fenetre d'exploration 
            f.Title = "Choisir le fichier à importer";
            if (radioButton1.Checked) //si "fond" est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF"; //filtre le type de fichier autorisé
                f.ShowDialog(); //affiche la boite de dialogue
                fond = f.FileName;
                destFile = @"media\Background" + Path.GetExtension(fond);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
                //Ajoute l'image background dans index.html 
                string stringBuffer ="";
                using(StreamReader reader = new StreamReader("index.html"))
                {
                    string line =  reader.ReadLine();

                    while(line != null)
                    {
                        stringBuffer += line + "\n";
                        if (line.Contains("<canvas"))
                        {
                            stringBuffer += "<img src=\"media\\Background.png\" id=\"Background\">\n";
                        }
                        if (line.Contains("var canvas = new fabric.Canvas('Canvas');"))
                        {
                            stringBuffer += "var imgElement0 = document.getElementById('Background');\nvar imgInstance0 = new fabric.Image(imgElement0, {\n    width:960,\n    height:540\n});\ncanvas.add(imgInstance0);\n";
                        }
                        line = reader.ReadLine();
                    }
                    reader.Close();
                }
                System.IO.StreamWriter file = new System.IO.StreamWriter("index.html");
                file.WriteLine(stringBuffer);
                file.Close();
                webBrowser1.Refresh(); //rafraichi la vue
            }
            else if (radioButton2.Checked) //si element 1 est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                element1 = f.FileName;
                destFile = @"media\element1" + Path.GetExtension(element1);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(element1, destFile, true);
                //Ajoute l'image element1 dans index.html 
                string stringBuffer = "";
                using (StreamReader reader = new StreamReader("index.html"))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        stringBuffer += line + "\n";
                        if (line.Contains("<canvas"))
                        {
                            stringBuffer += "<img src=\"media\\element1.png\" id=\"element1\">\n";
                        }
                        if (line.Contains("var canvas = new fabric.Canvas('Canvas');"))
                        {
                            stringBuffer += "var imgElement1 = document.getElementById('element1');\nvar imgInstance1 = new fabric.Image(imgElement1, {\n    left:100,\n    top:100,\n    angle: 30\n});\ncanvas.add(imgInstance1);\n";
                        }
                        line = reader.ReadLine();
                    }
                    reader.Close();
                }
                System.IO.StreamWriter file = new System.IO.StreamWriter("index.html");
                file.WriteLine(stringBuffer);
                file.Close();
                webBrowser1.Refresh(); //rafraichi la vue
            }
            else if (radioButton3.Checked) //si element 2 est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                element2 = f.FileName;
                destFile = @"media\element2" + Path.GetExtension(element2);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
            }
            else if (radioButton4.Checked) //si element 3 est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                element3 = f.FileName;
                destFile = @"media\element3" + Path.GetExtension(element3);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
            }
            else if (radioButton5.Checked) //si element 4 est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                element4 = f.FileName;
                destFile = @"media\element4" + Path.GetExtension(element4);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
            }
            else if (radioButton8.Checked) //si element 5 est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                element5 = f.FileName;
                destFile = @"media\element5" + Path.GetExtension(element5);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
            }
            else if (radioButton6.Checked) //si video est coché
            {
                f.Filter = "Videos(*.flv;*.mp4)|*.FLV;*.MP4";
                f.ShowDialog();
                video = f.FileName;
            }
            else if (radioButton7.Checked) //si cadre video est coché
            {
                f.Filter = "Images(*.PNG;*.GIF)|*.PNG;*.GIF";
                f.ShowDialog();
                cadreVideo = f.FileName;
                destFile = @"media\cadreVideo" + Path.GetExtension(cadreVideo);
                System.IO.Directory.CreateDirectory("media");
                System.IO.File.Copy(fond, destFile, true);
            }
            else //si rien n'est coché
            {
                MessageBox.Show("Merci de cocher un element");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog(); //création d'une fenetre d'exploration 
            f.Title = "Choisir le fichier à importer";
            if (f.ShowDialog() == DialogResult.OK) //si fond est coché
            {
                f.Filter = "Images(*.ZIP)|*.ZIP"; //filtre le type de fichier autorisé
                f.ShowDialog(); //affiche la boite de dialogue
                theme = f.FileName;
            }
            else
            {
                MessageBox.Show("Erreur");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) //si fond est coché
            {
                System.IO.File.Delete(@"media\Background.png");
            }
            else if (radioButton2.Checked) //si element 1 est coché
            {
                System.IO.File.Delete(@"media\element1.png");
            }
            else if (radioButton3.Checked) //si element 2 est coché
            {
                System.IO.File.Delete(@"media\element2.png");
            }
            else if (radioButton4.Checked) //si element 3 est coché
            {
                System.IO.File.Delete(@"media\element3.png");
            }
            else if (radioButton5.Checked) //si element 4 est coché
            {
                System.IO.File.Delete(@"media\element4.png");
            }
            else if (radioButton8.Checked) //si element 5 est coché
            {
                System.IO.File.Delete(@"media\element5.png");
            }
            else if (radioButton6.Checked) //si video est coché
            {
                MessageBox.Show("cas particulier");
            }
            else if (radioButton7.Checked) //si cadre video est coché
            {
                System.IO.File.Delete(@"media\cadreVideo.png");
            }
            else //si rien n'est coché
            {
                MessageBox.Show("Merci de cocher un element");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string startPath = @".\";
            //string zipPath = @".\"+ nomRom;
            //ZipFile.CreateFromDirectory(startPath, zipPath);    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nomRom = textBox1.Text;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
