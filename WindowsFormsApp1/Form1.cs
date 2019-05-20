using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Cuda;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public VideoCapture Webcam { get; set; }
        public EigenFaceRecognizer Facerecognition { get; set; }
        public CascadeClassifier Facedetection { get; set; }
        public CascadeClassifier Eyedetection { get; set; }
        public Mat Frame { get; set; }

        public List<Image<Gray, byte>> Faces { get; set; }
        public List<int> ids { get; set; }

        public int ProcessedImageWidth { get; set; } = 128;
        public int ProcessedImageheight { get; set; } = 150;

        public int Timercounter { get; set; } = 0;
        public int Timelimit { get; set; } = 30;
        public int Scancounter { get; set; } = 0;
        public string Ymlpath { get; set; } = "trainningdata.yml";

        public Timer Timer { get; set; }

        public bool Facesquare { get; set; } = true;
        public bool EyeSquare { get; set; } = false;

        public Image<Gray, Byte>[] trainingImages; //new Image<Gray, Byte>[];
        public int[] labels; //= new int[] ;

        public EigenFaceRecognizer recognizer;

        public int altura = 0;
        public int largura = 0;

        public int alturaface = 0;
        public int larguraface = 0;

        public Rectangle[] faceRect;

        public Emgu.CV.Image<Emgu.CV.Structure.Bgr, Byte> imageFrame;

        public Form1()
        {
            InitializeComponent();

            //Emgu.CV.Image<Gray, byte> imageFrame = new Emgu.CV.Image<Gray, byte>();

            Facerecognition = new EigenFaceRecognizer(80, double.PositiveInfinity);

            Facedetection = new CascadeClassifier
                  ((Application.StartupPath + "\\haarcascade_frontalface_default.xml"));




            /*
            trainingImages[0] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_766.bmp");
            trainingImages[1] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_2925.bmp");
            trainingImages[2] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_18231.bmp");
            trainingImages[3] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_21543.bmp");
            trainingImages[4] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_36552.bmp");
            trainingImages[5] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_36552.bmp");
            trainingImages[6] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_40854.bmp");
            trainingImages[7] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_49525.bmp");
            trainingImages[8] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_53485.bmp");
            trainingImages[9] = new Image<Gray, Byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_59721.bmp");
            */
            //trainingImages[2] = new Image<Gray, byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_25222.jpg");
            //trainingImages[3] = new Image<Gray, byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_5989.jpg");
            //trainingImages[4] = new Image<Gray, byte>("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_12713.jpg");

            Frame = new Mat();

            Faces = new List<Image<Gray, Byte>>();
            faceRect = new Rectangle[1];
            ids = new List<int>();

            BeginWebCam();
        }

        private void BeginWebCam()
        {
            if (Webcam == null)
            {
                Webcam = new VideoCapture();
            }
            Webcam.ImageGrabbed += Webcam_ImageGrabbed;
            Webcam.Start();
        }

        private void Webcam_ImageGrabbed(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            imageFrame = Frame.ToImage<Bgr, Byte>();

            if (imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, Byte>();

                var faces = Facedetection.DetectMultiScale(grayFrame, 1.3, 5);

                faceRect = faces;

                if (Facesquare)
                    foreach (var face in faces)
                    {
                        //var i = 0;
                        //var imageresize = imageFrame.Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                        //var imagegray = imageresize.Convert<Gray, byte>();
                        //imageFrame.Save("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\" +
                        //      "Debug\\fotos\\foto_" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg");
                        //imageresize.Save("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\" +
                        //   "Debug\\fotos\\foto_" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg");

                        //foreach (Rectangle face1 in faces)
                        // {
                        //get the region 
                        //var faceGrayPic = imageFrame
                        //    .Copy(face)
                        //    .Convert<Gray, Byte>()
                        //    .Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear );
                        //cut the face
                        //CvInvoke.cvSaveImage("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_"+
                        //   DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() +".bmp", faceGrayPic, faceGrayPic);
                        //faceGrayPic.Save
                        //  ("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_" +
                        //  DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() +".jpg");


                        //}




                        imageFrame.Draw(face, new Bgr(Color.BurlyWood), 3);





                        //foreach (var im in trainingImages)
                        //{
                        //    trainingImages[i] = im.Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                        //    i = i + 1;
                        //}

                        // recognizer.Train(trainingImages, labels);
                        // EigenFaceRecognizer.PredictionResult result = recognizer.Predict(faceGrayPic);

                        // if (result.Label != -1)
                        // {
                        //     int lab = result.Label;
                        // }

                        //face1 = face;
                        this.webcambox.Image = imageFrame.ToBitmap();


                        //alturaface = face.Height;
                        //larguraface = face.Width;
                    }








                //Image<Gray, Byte> testImage = new Image<Gray, Byte>("C:\\Image\\Stevie.jpg" );

                //recognizer.Train(trainingImages, labels);

                //EigenFaceRecognizer.PredictionResult result = recognizer.Predict( grayFrame );
                //this.lbresposta.Text = result.Label.ToString();

            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Train_Click(object sender, EventArgs e)
        {
            Timer = new Timer();
            Timer.Interval = 500;
            Timer.Tick += Timer_tick;
            Timer.Start();
        }

        private void Timer_tick(object sender, EventArgs e)
        {
            Webcam.Retrieve(Frame);
            var imageFrame = Frame.ToImage<Gray, Byte>();

            if (Timercounter < Timelimit)
            {
                Timercounter++;

                if (imageFrame != null)
                {
                    var faces = Facedetection.DetectMultiScale(imageFrame, 1.3, 5);

                    if (faces.Count() > 0)
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize
                              (ProcessedImageWidth, ProcessedImageheight, Emgu.CV.CvEnum.Inter.Cubic);

                        Faces.Add(processedImage);


                    }

                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var i = 0;

            imageFrame._EqualizeHist();//equaliza o brilho

            int indtam = 0;

            int[] tamimagem = new int[5];
            int[] altimagem = new int[5];

            tamimagem[0] = 64;
            tamimagem[1] = 100;
            tamimagem[2] = 128;
            tamimagem[3] = 160;
            tamimagem[4] = 200;

            altimagem[0] = 64;
            altimagem[1] = 100;
            altimagem[2] = 128;
            altimagem[3] = 160;
            altimagem[4] = 200;

            int[] resposta = new int[5];
            double[] distance = new double[5];

            //int tamimagem[] = [64 , 100,128 ,240];
            lbretorno.Text = "";
            foreach (var face in this.faceRect)
            {
              //  tamimagem[0] = face.Width - 50;
              //  tamimagem[1] = face.Width;
              //  tamimagem[2] = face.Width + 50;
              //  tamimagem[3] = face.Width + 80;
              //  tamimagem[4] = face.Width + 100;

              //  altimagem[0] = face.Height - 50;
              //  altimagem[1] = face.Height ;
              //  altimagem[2] = face.Height + 50;
              //  altimagem[3] = face.Height + 80;
              //  altimagem[4] = face.Height + 100;



                for (indtam = 0; indtam < 5; indtam++)
                {
                    var imageresize = imageFrame.Resize(tamimagem[indtam], altimagem[indtam], Emgu.CV.CvEnum.Inter.Cubic);
                    var imagegray = imageresize.Convert<Gray, Byte>();
                    //imageFrame.Save("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\" +
                    //    "Debug\\fotos\\foto_" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg");
                    //imageresize.Save("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\" +
                    //   "Debug\\fotos\\foto_" + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".jpg");

                    //foreach (Rectangle face1 in faces)
                    // {
                    //get the region


                    var faceGrayPic = imageFrame
                        .Copy(face)
                        .Convert<Gray, Byte>()
                        .Resize(tamimagem[indtam], altimagem[indtam], Emgu.CV.CvEnum.Inter.Cubic);



                    string caminho =
                                    "C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_" +
                        DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_" + textBox1.Text.ToString() + ".bmp";

                    //faceGrayPic.Save(caminho);

                    //var imagepesquisa = new Image<Gray, byte>(caminho);
                    string[] arquivos = Directory.GetFiles("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\", "*.bmp", SearchOption.AllDirectories);
                    Image<Gray, Byte>[] trainingImages = new Image<Gray, Byte>[arquivos.Length];
                    int[] labels = new int[arquivos.Length];
                    int indice = 0;
                    foreach (var bmp in arquivos)
                    {
                        trainingImages[indice] = new Image<Gray, Byte>(bmp);
                        int tamanho = bmp.Length;
                        int posicao = 5;
                        string letra = "";
                        Boolean achou_ = false;
                        string indicefoto = "";
                        while (!achou_)
                        {
                            letra = bmp.Substring(tamanho - posicao, 1);
                            if (!achou_)
                            {
                                if (letra == "_")
                                {
                                    achou_ = true;
                                }
                                else
                                {
                                    indicefoto = letra + indicefoto;
                                }
                            }
                            posicao = posicao + 1;
                        }

                        labels[indice] = Convert.ToInt32(indicefoto);
                        indice = indice + 1;
                    }

                    i = 0;



                    foreach (var im in trainingImages)
                    {
                        trainingImages[i] = im.Convert<Gray, Byte>().Resize(tamimagem[indtam], altimagem[indtam], Emgu.CV.CvEnum.Inter.Cubic);
                        trainingImages[i]._EqualizeHist();
                        //trainingImages[i].ROI = new Rectangle(face.X, face.Y, face.Width ,face.Height);


                        //trainingImages[i].ROI = this.faceRect[i];
                        //trainingImages[i] = trainingImages[i].Copy();

                        // System.IO.Stream stream = new MemoryStream();
                        // stream.Write(trainingImages[i], 0,  trainingImages[i] );
                        // var faceImage = new Image<Gray, byte>(new Bitmap(stream));


                        i = i + 1;
                    }

                    EigenFaceRecognizer recognizer = new EigenFaceRecognizer();
                    //recognizer.Train<Gray, Byte>(trainingImages.ToArray(), labels.ToArray());
                    //recognizer.Write("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\train_" + tamimagem[indtam].ToString() + ".yml");
                    recognizer.Read("C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\train_" + tamimagem[indtam].ToString() + ".yml");

                    //recognizer.Train<Gray, Byte>(trainingImages.ToArray(), labels.ToArray());



                    //recognizer.Write("recognizer.txt");


                    EigenFaceRecognizer.PredictionResult result = recognizer.Predict(faceGrayPic);

                    if (result.Label != -1)
                    {
                        int lab = result.Label;
                        distance[indtam] = result.Distance;
                        int ind = -1;
                        int indencontrado = -1;
                        foreach (var val in labels)
                        {
                            ind = ind + 1;
                            if (val == lab)
                            {
                                indencontrado = ind;
                                
                                break;
                            }

                        }

                        resposta[indtam] = indencontrado;

                        lbretorno.Text = lbretorno.Text +
                             tamimagem[indtam].ToString() + "=" + resposta[indtam].ToString() + ";D=" + 
                             distance[indtam].ToString() +";" ;

                        LbIndexPesquisa.Text = result.Label.ToString();
                        if (indencontrado > -1)
                            pboxpesquisada.Image = trainingImages[ind].ToBitmap();

                        //string arquivo = arquivos[lab] ;
                    }

                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {


            imageFrame._EqualizeHist();//equaliza o brilho

            foreach (var face in this.faceRect)
            {
                var imageresize = imageFrame.Resize(100, 100, Emgu.CV.CvEnum.Inter.Linear);
                var imagegray = imageresize.Convert<Gray, Byte>();

                var faceGrayPic = imageFrame
                    .Copy(face)
                    .Convert<Gray, Byte>()
                    .Resize(64, 64, Emgu.CV.CvEnum.Inter.Cubic);

                string caminho =
                                "C:\\reconhecimentofacial\\Wfreconhecimento\\WindowsFormsApp1\\bin\\Debug\\fotos\\foto_" +
                    DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + "_" + textBox1.Text.ToString() + ".bmp";


                faceGrayPic.Save(caminho);

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}


/*


            foreach (Rectangle face1 in faces)
            {
                //get the region 
                faceGrayPic = image
                    .Copy(face1)
                    .Convert<Gray, Byte>()
                    .Resize(64, 64, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
//cut the face
CvInvoke.cvSaveImage(Application.StartupPath + "/面部库" + "/Face" + faceNum.ToString() + ".bmp", faceGrayPic, faceGrayPic);
                faceNum++;
                image.Draw(face1, new Bgr(Color.Red), 2);
            }


    float threshold = 750;              // пороговое значение, равное 50% похожести изображений (установленно экспериментально)
                    float thresholdMismatch = 10000;    // пороговое значение несовпадения изоюражений (равное 1%, установлено экспериментально)
                    if (resultRecognition.Distance < threshold)
                        similarityDegree = (100 - (resultRecognition.Distance * 50.0 / threshold)).ToString();
                    else
                        similarityDegree = (50 - (resultRecognition.Distance * 50 / thresholdMismatch)).ToString();
                }
            }

            return 0;
        }








































    */
