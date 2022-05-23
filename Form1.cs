using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            Axels(nachX, nachY, nachC);

            function_graph();
        }

        int nachX = 500;
        int nachY = 500;
        int nachC = 50;
        
        bool SDVIG_vlevo = false;
        bool SDVIG_vpravo = false;

        List<float> Xxx = new List<float>();
        List<float> Yyy = new List<float>();

        
        void Axels(int x0, int y0, int c)
        {
           

            Graphics formGraphics = this.CreateGraphics();

            Pen mupen = new Pen(Color.Black);
            SolidBrush mubra = new SolidBrush(Color.Black);
            Font mufont = new Font("Arial", 6);
            Pen NetPen = new Pen(Color.LightGray);


           

            int Let_P1 = 1;
            int Let_N1 = -1;
            int Let_P2 = 1;
            int Let_N2 = -1;

            

            if(x0==500)
            {
                SDVIG_vlevo = false;
                SDVIG_vpravo = false;
            }else if (x0>500)
            {
                SDVIG_vpravo = true;
                SDVIG_vlevo = false;
            }else if (x0<500)
            {
                SDVIG_vlevo = true;
                SDVIG_vpravo = false;
            }

            int ix = 0;
            for (; ix <400;)
            {
                if (SDVIG_vlevo)
                {
                    if (x0 - ix < 300)
                    {
                        if (x0 == 300 || x0 < 300)
                        {
                            formGraphics.DrawLine(NetPen, 300 + ix, y0 + 200, 300 + ix, y0 - 200); // сетка
                            

                            formGraphics.DrawLine(mupen, 300 + ix, y0 + 7, 300 + ix, y0 - 7);      //деления по оси Ох

                        }
                        else
                        {
                            if (x0 - ix > 300)
                            {
                                break;

                            }
                            else if (x0 + ix > 700)
                            {
                                break;
                            }
                            else
                            {
                                formGraphics.DrawLine(NetPen, x0 + ix, y0 + 200, x0 + ix, y0 - 200); // сетка
                                                                                                     
                                
                                formGraphics.DrawLine(mupen, x0 + ix, y0 + 7, x0 + ix, y0 - 7);      //деления по оси Ох
                            }
                        }

                        ix += c;
                    }
                    else
                    {
                        Regular_Paint(NetPen, mupen, x0, y0, ix);


                        ix += c;

                    }


                    

                }
                else if (SDVIG_vpravo)
                {
                    if (x0 + ix > 700)
                    {
                        if (x0 == 700 || x0 > 700) // РАБОТАЕТ все ставится
                        {
                            formGraphics.DrawLine(NetPen, 700 - ix, y0 + 200, 700 - ix, y0 - 200); // сетка
                            

                            formGraphics.DrawLine(mupen, 700 - ix, y0 + 7, 700 - ix, y0 - 7);      //деления по оси Ох

                        }
                        else
                        {   

                            if (x0 - ix<300)
                            {
                                break;
                            }
                            else
                            {
                                formGraphics.DrawLine(NetPen, x0 - ix, y0 + 200, x0 - ix, y0 - 200); // сетка

                                
                                formGraphics.DrawLine(mupen, x0 - ix, y0 + 7, x0 - ix, y0 - 7);      //деления по оси Ох
                            }
                            
                        }

                        ix += c;


                    }
                    else
                    {
                        Regular_Paint(NetPen, mupen, x0, y0, ix);
                        
                        ix += c;



                    }
                }
                else      // обычная отрисовка
                {   
                    if( x0+ix>700)   
                    {
                        break;
                    }
                    else
                    {
                        Regular_Paint(NetPen, mupen, x0, y0, ix);
                       
                        ix += c;
                    }
                    
                }
            }

            
            for (int iLet = c; iLet < 10000 +c ; iLet+= c)  // цифры на делениях 
            {
                
                string P1 = Convert.ToString(Let_P1);
                string N1 = Convert.ToString(Let_N1);

                if (SDVIG_vlevo)
                {


                    if (x0 < 300 || x0 == 300)
                    {

                        if (x0 + iLet > 700)
                        {
                            break;
                        }
                        else
                        {
                            if (x0 + iLet < 300 || x0 + iLet == 300)
                            {
                                mubra.Color = (this.BackColor);

                                formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                                Let_P1++;
                                mubra.Color = (Color.Black);
                            }
                            else
                            {

                                formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                                Let_P1++;
                            }


                        }
                        
                        mubra.Color = (this.BackColor);
                        formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                        mubra.Color = (Color.Black);
                    }
                    else if (x0 - iLet < 300)
                    {
                        if (x0 + iLet > 700)
                        {
                            break;
                        }
                        else
                        {
                            formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                            formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                            Let_P1++;
                        }
                    }
                    else
                    {
                        formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                        formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                        formGraphics.DrawString(N1, mufont, mubra, x0 - iLet, y0 + 6);//-
                        Let_P1++;
                        Let_N1--;


                    }



                }
                else if (SDVIG_vpravo)
                {
                    
                    if (x0 > 700 || x0 == 700)
                    {

                        if (x0 - iLet < 300)
                        {
                            break;
                        }
                        else 
                        {

                            if (x0 - iLet > 700 || x0 - iLet == 700)
                            {
                                
                                mubra.Color = (this.BackColor);

                                formGraphics.DrawString(N1, mufont, mubra, x0 - iLet - 10, y0 + 6); //+
                                Let_N1--;
                                mubra.Color = (Color.Black);
                            }
                            else 
                            {
                                
                                mubra.Color = (Color.Black);
                                formGraphics.DrawString(N1, mufont, mubra, x0 - iLet - 10, y0 + 6); //+
                                Let_N1--;
                            }

                            

                        }

                        
                        mubra.Color = (this.BackColor);
                        formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                        mubra.Color = (Color.Black);

                    }
                    else if (x0 + iLet > 700)
                    {
                        if (x0 - iLet < 300)
                        {
                            break;
                        }
                        else
                        {
                            formGraphics.DrawString(N1, mufont, mubra, x0 - iLet - 10, y0 + 6); //-
                            formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                            Let_N1--;
                        }
                    }
                    else
                    {
                        formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                        formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                        formGraphics.DrawString(N1, mufont, mubra, x0 - iLet, y0 + 6);//-
                        Let_P1++;
                        Let_N1--;


                    }


                }
                else
                {
                    if (iLet > 200)
                    {
                        break;
                    }
                    else
                    {
                        formGraphics.DrawString("0", mufont, mubra, x0 + 1, y0 - 10);
                        formGraphics.DrawString(P1, mufont, mubra, x0 + iLet - 10, y0 + 6); //+
                        formGraphics.DrawString(N1, mufont, mubra, x0 - iLet, y0 + 6);//-
                        Let_P1++;
                        Let_N1--;
                    }
                }

                    
                
            }
            
            

            for (int iy = 0; iy < 200;)
            {

                
                formGraphics.DrawLine(NetPen, 300, y0 - iy, 700, y0 - iy); // сетка
                formGraphics.DrawLine(NetPen, 300, y0 + iy, 700, y0 + iy);


                if (x0 == 300 || x0 < 300 || x0==700 ||x0>700)
                {
                    ;
                }
                else
                {
                    formGraphics.DrawLine(mupen, x0 + 7, y0 + iy, x0 - 7, y0 + iy);          // Деления по оси Оу
                    formGraphics.DrawLine(mupen, x0 + 7, y0 - iy, x0 - 7, y0 - iy);
                }
                
                iy += c;
                
                if ( iy > 200)
                {
                    break;
                }
                else
                {
                    formGraphics.DrawLine(NetPen, 300, y0 - iy, 700, y0 - iy); // сетка
                    formGraphics.DrawLine(NetPen, 300, y0 + iy, 700, y0 + iy);
                }
            }



            for (int iLet1 = c; iLet1 < 200 ; iLet1 += c)
            {
                string P2 = Convert.ToString(Let_P2);
                string N2 = Convert.ToString(Let_N2);
                if (x0 == 300 || x0 < 300 || x0 == 700 || x0 > 700)
                {
                    ;
                    
                }
                else
                {
                    formGraphics.DrawString(P2, mufont, mubra, x0 - 15, y0 - iLet1); //+
                    formGraphics.DrawString(N2, mufont, mubra, x0 - 15, y0 + iLet1 - 8);//-
                }
                    
                Let_P2++;
                Let_N2--;
            }

            // координаты левого верхнего угла 300.300 ;  нижнего левого 700.700
            // рамка
            Pen FramePen = new Pen(Color.Red); 
            formGraphics.DrawRectangle(FramePen, 300, 300, 400, 400);

            //оси
            if (x0 == 300 || x0 < 300)
            {
                formGraphics.DrawLine(mupen, 300, y0, 700, y0); 
                
            }
            else if (x0 == 700 || x0 > 700)
            {
                formGraphics.DrawLine(mupen, 300, y0, 700, y0); 
                
            }
            else
            {
                formGraphics.DrawLine(mupen, 300, y0, 700, y0); //x
                formGraphics.DrawLine(mupen, x0, y0 + 200, x0, y0 - 200); //y
            }
            
            

            mupen.Dispose();
            mubra.Dispose();
            NetPen.Dispose();

        }

        // zoom -
        private void button2_Click(object sender, EventArgs e)
        {
            CLEAR_LIST();

            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(this.BackColor);  

            if (nachC < 15)
            {
                MessageBox.Show("Ошибка - больше уменьшить масштаб нельзя");
            }
            else
            {
                nachC = nachC - 5; ;
            }
            Axels(nachX, nachY, nachC);
            function_graph();

        }

        // zoom +
        private void button3_Click(object sender, EventArgs e)
        {
            CLEAR_LIST();

            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(this.BackColor);

            nachC = nachC + 5; ;
            
            Axels(nachX, nachY, nachC );
            function_graph();
        }

        //сдвиг влево
        private void button4_Click(object sender, EventArgs e)
        {
           

            CLEAR_LIST();
            
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(this.BackColor);
            nachX = nachX - nachC;
            
            Axels(nachX, nachY, nachC);

           
            
            function_graph();
        }

        // сдвиг вправо
        private void button5_Click(object sender, EventArgs e)
        {
           
            CLEAR_LIST();

            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(this.BackColor);

            
            nachX = nachX + nachC;

            Axels(nachX, nachY, nachC);



            function_graph();
            

        }


        

        void function_graph()
        {
            
            Graphics formGraphics = this.CreateGraphics();
            
            Pen Mpen = new Pen(Color.Red);



            string[] coef = textBox1.Text.Trim().Split(' ');


            int[] K = new int[coef.Length];

            for (int i = 0; i < coef.Length; i++)
            {
                K[i] = Convert.ToInt32(coef[i]);
                
            }

            Array.Reverse(K);


            float x = -200 / nachC;


            for (int i = 0; i < 400; i++)
            {
                float resY = 0;
                

                for (int j = 0; j < K.Length; j++)
                {

                    resY += K[j] * (float)Math.Pow(x, j);


                }

                
                float TempX = (float)Convert_to_XOY(x);
                
                float TempY = (float)Convert_to_XOY(-resY);

                if (SDVIG_vlevo)
                {
                    TempX -=  500-nachX;
                    ADD(TempX, TempY);
                    
                   
                }else if (SDVIG_vpravo)
                {
                    
                    TempX += Math.Abs(500-nachX);
                    ADD(TempX, TempY);
                    
                }
                else
                {
                    ADD(TempX, TempY);
                }


                x += (float)0.1;
            }


            
            
            for ( int u =0; u<Yyy.Count-1 ; u++)
            {
                
                if (u ==0)
                {
                   formGraphics.DrawLine(Mpen, Xxx[u ], Yyy[u ], Xxx[u], Yyy[u]);
                }
                else
                {

                    if ((float)Xxx[u] < 300 || (float)Xxx[u] > 700 || (float)Yyy[u] < 100 || (float)Yyy[u] > 1000)
                    {
                        formGraphics.DrawLine(Mpen, (float)Xxx[u], (float)Yyy[u], (float)Xxx[u], (float)Yyy[u]);
                        
                    }
                    else
                    {
                        formGraphics.DrawLine(Mpen, (float)Xxx[u - 1], (float)Yyy[u - 1], (float)Xxx[u], (float)Yyy[u]);
                    }
                }
 
            }

            SolidBrush zalivka = new SolidBrush(this.BackColor);
            
            formGraphics.FillRectangle(zalivka, 0, 0, 701, 300);
            formGraphics.FillRectangle(zalivka, 300, 701, 700, 300);
            formGraphics.FillRectangle(zalivka, 0, 0, 300, 900);
            formGraphics.FillRectangle(zalivka, 701, 0, 2000, 2000);
            
        }


        double Convert_to_XOY (float a)
        {
            float c = nachC;
            float y = nachY;
            float result = a *c + y;
            return result;
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            

            CLEAR_LIST();
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.Clear(this.BackColor);

            
        }

        
        void Regular_Paint ( Pen pen , Pen pen1, int a, int b, int i)
        {
            Graphics formGraphics = this.CreateGraphics();
            formGraphics.DrawLine(pen, a + i, b + 200, a + i, b - 200); // сетка
            formGraphics.DrawLine(pen, a - i, b + 200, a - i, b - 200);

            formGraphics.DrawLine(pen1, a + i, b + 7, a + i, b - 7);      //деления по оси Ох
            formGraphics.DrawLine(pen1, a - i, b + 7, a - i, b - 7);
        }

        void ADD (float a, float b)
        {
            Xxx.Add(a);
            Yyy.Add(b);
        }


        void CLEAR_LIST ()
        {
            Xxx.Clear();
            Yyy.Clear();
        }

        
    }
} 

