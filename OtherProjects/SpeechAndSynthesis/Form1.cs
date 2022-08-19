using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //创建语音识别引擎
            recognitionEngine = new SpeechRecognitionEngine();
            //创建一组语音识别的语法约束选择
            Choices choices = new Choices();
            //添加语音识别关键字
            choices.Add(new string[] { "全部启动", "全部停止", "颜色变黄", "颜色变蓝" });

            //以编程的方式为语音生成约束
            GrammarBuilder gb = new GrammarBuilder(choices);
            //grammarbuilder封装对象
            Grammar grm = new Grammar(gb);
            //SpeechRecognitionEngine异步方式LoadGrammarAsync
            recognitionEngine.LoadGrammar(grm);

            //这个没有约束，所以会识别出很多种情况
            //recognitionEngine.LoadGrammar(new DictationGrammar());
            //音频输入
            recognitionEngine.SetInputToDefaultAudioDevice();
            //创建语音接收事件
            recognitionEngine.SpeechRecognized += recognitionEngine_SpeechRecognized;

            voices= voice.GetInstalledVoices().ToList();

            foreach (InstalledVoice e in voices)
            {
                comboBox1.Items.Add(e.VoiceInfo.Name);
            }

        }
        List<InstalledVoice> voices;
        //创建语音识别引擎
        SpeechRecognitionEngine recognitionEngine;
        private void recognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.AppendText(e.Result.Text);
            switch (e.Result.Text)
            {
                case "全部启动":
                    textBox1.AppendText("全部启动");
                    break;
                case "全部停止":
                    textBox1.AppendText("全部停止");
                    break;
                case "颜色变黄":
                    textBox1.BackColor = Color.Yellow;
                    break;
                case "颜色变蓝":
                    textBox1.BackColor = Color.Blue;
                    break;
              
                default:
                   
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Voice("你好，我可以说话了！");
        }
        private SpeechSynthesizer voice = new SpeechSynthesizer();
        private void Voice(string context)
        {
            voice.Rate = 0; //语速,[-10,10]
            voice.Volume = 100; //音量,[0,100]
            //voice.SelectVoice("Microsoft Lili");
            //voice.SelectVoice("Microsoft Anna");
            voice.SpeakAsync(context);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private bool isDown = false;
        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (isDown == false)
            {
                button2_MouseDown(null, null);
                isDown = true;
            }
        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
           
            button2_MouseUp(null, null);
            isDown = false;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            //开始语音识别
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            textBox1.AppendText("开始语音输入\r\n");
            button2.BackColor = Color.LightGreen;

        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            //停止语音识别
            recognitionEngine.RecognizeAsyncStop();
            textBox1.AppendText("结束语音输入\r\n");
            button2.BackColor = Button.DefaultBackColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            voice.SetOutputToWaveFile("./output.wav");
            voice.Speak("合成文字语音到wav格式文件中");
            voice.SetOutputToDefaultAudioDevice();

            Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                voice.SelectVoice(voices[comboBox1.SelectedIndex].VoiceInfo.Name);
            }
        }
    }
}
