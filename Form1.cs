using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Back_Propagation
{
    public partial class Form1 : Form
    {
        //********************************************************************************************
        //*****************************************Back Propagation Function**************************
        //********************************************************************************************
       
        public float Activation_Func(char activation_function,float net)
        {

            if(activation_function=='s')
            {
                return (float) (1 / (1 + Math.Exp(-net)) );
            }
            else
            {
                return (float) ((1 - Math.Exp(-net)) / (1 + Math.Exp(-net)));
            }

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************

        public float[][] declare_neurons_array(int num_hidden,int num_neurons, bool bias,int num_inputs)
        {
            
            float [][]layer_neuron=new float[1+num_hidden+1][];

            //declare input layer
            layer_neuron[0] = new float[num_inputs];

            //declare hidden layers
            for (int layer_indx = 1; layer_indx <= num_hidden;layer_indx++ )
            {
                layer_neuron[layer_indx] = new float[num_neurons];
            }

            //declare output layer, has 3 neurons ( 3 classes )
            layer_neuron[num_hidden+1] = new float[3];

            return layer_neuron;
        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************


        public Dictionary<float,float> declare_and_initialize_weights(int num_hidden,float[][] layer_neuron)
        {
            Dictionary<float, float> weights = new Dictionary<float, float>();

            Random random = new Random();

            // <= because of output layer
            for (int layer_indx = 1; layer_indx <= num_hidden+1; layer_indx++)
            {
                for (int neuron_indx = 0; neuron_indx < layer_neuron[layer_indx].Length; neuron_indx++)
                {
                    for (int previous_layer_neuron_indx = 0; previous_layer_neuron_indx < layer_neuron[layer_indx - 1].Count(); previous_layer_neuron_indx++)
                    {

                        int weight_indx = (((((layer_indx * 10) + neuron_indx) * 10) + (layer_indx - 1)) * 10) + previous_layer_neuron_indx;
                        weights[weight_indx] = (float)Math.Round(random.NextDouble(), 2);
                    }

                }
            }
            return weights;
        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************


        public float[][] intialize_input_layer(float [][]layer_neuron,float [,] data,int sample_indx,bool bias)
        {

            if (bias) //if bias ,put "1" in first neuron
            {
                layer_neuron[0][0] = 1;

                //intialize input layer
                for (int neuron_indx = 1; neuron_indx < 5; neuron_indx++)
                {
                    layer_neuron[0][neuron_indx] = data[sample_indx,neuron_indx - 1];
                }
            }
            else
            {
                //intialize input layer
                for (int neuron_indx = 0; neuron_indx < 4; neuron_indx++)
                {
                    layer_neuron[0][neuron_indx] = data[sample_indx,neuron_indx];
                }
            }

            return layer_neuron;

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************


        public void calc_neurons_values(ref float [][] layer_neuron,int num_hidden,Dictionary<float,float> weights,char activation_function,bool bias)
        {
            //loop on layers ,"<=" cause of output
            for(int layer_indx=1;layer_indx<=num_hidden+1;layer_indx++)
            {
                //loop on neurons
                for (int neuron_indx = 0; neuron_indx < layer_neuron[layer_indx].Count(); neuron_indx++)
                {
                    //if bias so put "1" in first neuron in the layer (except output layer)
                    if (bias && neuron_indx == 0 && layer_indx != num_hidden)
                    {
                        layer_neuron[layer_indx][0] = 1;
                        continue;
                    }


                    //get net of each neuron
                    float net = 0;

                    //loop on previous layer to get weights index and calculate net 
                    for (int prev_layer_neuron_indx = 0; prev_layer_neuron_indx < layer_neuron[layer_indx - 1].Count(); prev_layer_neuron_indx++)
                    {
                        int weight_indx = (((((layer_indx * 10) + neuron_indx) * 10) + (layer_indx - 1)) * 10) + prev_layer_neuron_indx;
                        net += (weights[weight_indx] * layer_neuron[layer_indx - 1][prev_layer_neuron_indx]);
                     }


                     //put net into activation function
                     layer_neuron[layer_indx][neuron_indx] = Activation_Func(activation_function, net);

                     
                    }
                }
            int x = 0;

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************


        public void calc_output_error(ref float [][] neuron_layer_error,float desird_class,float [][] neuron_layer,char activation_function)
        {
            float desired_class1 = 0,desired_class2=0,desired_class3=0;

                if (desird_class == 1)
                    desired_class1 = 1;

                else if (desird_class == 2)
                    desired_class2 = 1;

                else
                    desired_class1 = 1;

                float actual_class1 = neuron_layer[neuron_layer.Count() - 1][0];
                float actual_class2 = neuron_layer[neuron_layer.Count() - 1][1];
                float actual_class3 = neuron_layer[neuron_layer.Count() - 1][2];

            if(activation_function=='s')
            {
                
                neuron_layer_error[neuron_layer_error.Count()-1][0]=(desired_class1-actual_class1)*(actual_class1)*(1-actual_class1);
                neuron_layer_error[neuron_layer_error.Count()-1][1]=(desired_class2-actual_class2)*(actual_class2)*(1-actual_class2);
                neuron_layer_error[neuron_layer_error.Count()-1][2]=(desired_class3-actual_class3)*(actual_class3)*(1-actual_class3);

            }
            else
            {
                neuron_layer_error[neuron_layer_error.Count() - 1][0] = (desired_class1-actual_class1)*(1-actual_class1)*(1+actual_class1);
                neuron_layer_error[neuron_layer_error.Count() - 1][1] = (desired_class2-actual_class2)*(1-actual_class2)*(1+actual_class2);
                neuron_layer_error[neuron_layer_error.Count() - 1][2] =  (desired_class3 - actual_class3) * (1 - actual_class3) * (1 + actual_class3);
            }

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************


        public void train_test(ref float[,] train,ref float[,] test,float [][]data)
        {
            int train_count=0;
            int test_count=0;

            for (int i = 0; i < 150; i++)
            {
                if(i<30)//train
                {
                    for (int j = 0; j < 5; j++)
                        train[train_count,j] = data[i][j];

                    train_count++;
                }
                else if(i<50)//test
                {
                    for (int j = 0; j < 5; j++)
                        test[test_count,j] = data[i][j];

                    test_count++;

                }
                else if(i<80)//train
                {
                    for (int j = 0; j < 5; j++)
                        train[train_count,j] = data[i][j];

                    train_count++;

                }
                else if(i<100)//test
                {
                    for (int j = 0; j < 5; j++)
                        test[test_count,j] = data[i][j];

                    test_count++;

                }
                else if(i<130)//train
                {
                    for (int j = 0; j < 5; j++)
                        train[train_count,j] = data[i][j];

                    train_count++;

                }
                else//test
                {
                    for (int j = 0; j < 5; j++)
                        test[test_count,j] = data[i][j];

                    test_count++;

                }

            }
        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************

        

        public void calc_error_hidden_layer(ref float[][]layer_error_nueron,float[][]layer_neuron,Dictionary<float,float> weights,bool bias,char activation_function)
        {
            for (int layer_error_indx = layer_error_nueron.Count() - 2;layer_error_indx>0 ; layer_error_indx--)
            {
                int neuron_indx=0;
                int next_layer_neuron_indx=0;

                if(bias)
                {
                    neuron_indx=1;
                    next_layer_neuron_indx=1;
                }

                for(;neuron_indx<layer_error_nueron[layer_error_indx].Count();neuron_indx++)
                {
                    float net = 0;

                    for(;next_layer_neuron_indx<layer_error_nueron[layer_error_indx+1].Count();next_layer_neuron_indx++)
                    {
                        //int weight_indx = (((((layer_indx * 10) + neuron_indx) * 10) + (layer_indx - 1)) * 10) + prev_layer_neuron_indx;
                        int weight_indx = ((((((layer_error_indx+1) * 10) + next_layer_neuron_indx) * 10) + (layer_error_indx)) * 10) + neuron_indx;

                        net += (weights[weight_indx] * layer_error_nueron[layer_error_indx+1][next_layer_neuron_indx]);
                    }

                    if(activation_function=='s')
                    {
                       //neuron_layer_error[neuron_layer_error.Count() - 1][2] = (desired_class3 - actual_class3) * (actual_class3) * (1 - actual_class3);
                        layer_error_nueron[layer_error_indx][neuron_indx] = net * layer_neuron[layer_error_indx][neuron_indx] * (1 - layer_neuron[layer_error_indx][neuron_indx]);
                    }
                    else
                    {
                        
                        layer_error_nueron[layer_error_indx][neuron_indx] = net * (1-layer_neuron[layer_error_indx][neuron_indx] )* (1 + layer_neuron[layer_error_indx][neuron_indx]);

                    }

                    
                }
            }

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************

    

        public void update_weights(ref Dictionary<float,float> weights,float[][] layer_neuron,float [][] layer_neuron_error,float learning_rate)
        {
            int layer_count = layer_neuron.Count();

            //without output layer
            for(int layer_indx=0;layer_indx<layer_count-1;layer_indx++)
            {
                for (int neuron_indx = 0; neuron_indx < layer_neuron[layer_indx].Count(); neuron_indx++)
                    {
                        for(int next_layer_neuron_indx=0;next_layer_neuron_indx<layer_neuron[layer_indx+1].Count();next_layer_neuron_indx++)
                        {
                            int weight_indx = ((((((layer_indx+1) * 10) + next_layer_neuron_indx) * 10) + (layer_indx)) * 10) + neuron_indx;
                            weights[weight_indx]=weights[weight_indx]+learning_rate*layer_neuron[layer_indx][neuron_indx]*layer_neuron_error[layer_indx+1][next_layer_neuron_indx];
                        }
                    }
            }

        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************

        public float calc_error(float[][] layer_neuron,float[,] train,Dictionary<float,float> weights,char activation_function,bool bias,int num_hidden)
        {
            float total_error = 0;

            for (int sample_indx = 0; sample_indx < 90; sample_indx++)
            {
                 calc_neurons_values(ref layer_neuron, num_hidden, weights, activation_function, bias);

                float desired_class1 = 0,desired_class2=0,desired_class3=0;

                if (train[sample_indx,4] == 1)
                    desired_class1 = 1;

                else if (train[sample_indx,4] == 2)
                    desired_class2 = 1;

                else
                    desired_class1 = 1;
                

                float actual_class1 = layer_neuron[layer_neuron.Count() - 1][0];
                float actual_class2 = layer_neuron[layer_neuron.Count() - 1][1];
                float actual_class3 = layer_neuron[layer_neuron.Count() - 1][2];

                total_error+=(float)(0.5*Math.Pow( (((desired_class1-actual_class1)+ (desired_class2-actual_class2)+ (desired_class3-actual_class3) )/3 ),2));

            }
            
            return total_error/90;
        }

        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************
        public int[,] test_func(Dictionary<float,float> weights,float [,] test,int num_hidden,char activation_function,bool bias,int num_neurons,int num_inputs)
        {

            int[,] convolution_matrix = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

            float [][] layer_neuron=declare_neurons_array(num_hidden, num_neurons, bias, num_inputs);

            for(int sample_indx=0;sample_indx<60;sample_indx++)
            {
                layer_neuron = intialize_input_layer(layer_neuron, test, sample_indx, bias);

                calc_neurons_values(ref layer_neuron, num_hidden, weights, activation_function, bias);

                float[][] layer_neuron_error = declare_neurons_array(num_hidden, num_neurons, bias, num_inputs);

                calc_output_error(ref layer_neuron_error, test[sample_indx, 4], layer_neuron, activation_function);


                float c1=layer_neuron_error[layer_neuron.Count()-1][0];
                float c2=layer_neuron_error[layer_neuron.Count()-1][1];
                float c3=layer_neuron_error[layer_neuron.Count()-1][2];

                float result_class=0;

                if (c1 > c2 && c1 > c3)
                    result_class = 1;

                else if (c2 > c1 && c2 > c3)
                    result_class = 2;

                else
                    result_class = 3;

                convolution_matrix[ (int)(test[sample_indx ,4])-1 , (int)result_class-1]++;
            }

            return convolution_matrix;

        }


        //*******************************************************************************************************************
        //*******************************************************************************************************************
        //*******************************************************************************************************************

        public int[,] BackPropagation(float[][] data, int num_hidden, int num_neurons, float learning_rate, int num_epochs, bool bias, char activation_function, float mse)
        {
            int num_inputs = 4;

            if (bias)
            {
                num_inputs = 5;
                num_neurons++;
            }

            float[][] layer_neuron = declare_neurons_array(num_hidden,num_neurons, bias,num_inputs);

            Dictionary<float, float> weights = declare_and_initialize_weights(num_hidden, layer_neuron);

            float [,]train=new float[90,5];
            float [,]test=new float[60,5];

            train_test(ref train,ref test,data);
            
                //********************************************************************************
                //*********************************start training*********************************
                //********************************************************************************


                for (int epoch_indx = 0; epoch_indx < num_epochs; epoch_indx++)
                {

                     layer_neuron = declare_neurons_array(num_hidden, num_neurons, bias, num_inputs);

                    for (int sample_indx = 0; sample_indx < 90; sample_indx++)
                    {
                        
                        layer_neuron = intialize_input_layer(layer_neuron, train, sample_indx, bias);

                        calc_neurons_values(ref layer_neuron,num_hidden,weights,activation_function,bias);
                        
                       float[][] layer_neuron_error=declare_neurons_array(num_hidden,num_neurons,bias,num_inputs);

                       calc_output_error(ref layer_neuron_error,train[sample_indx,4],layer_neuron,activation_function);

                       calc_error_hidden_layer(ref layer_neuron_error, layer_neuron, weights,bias,activation_function);

                       update_weights(ref weights,layer_neuron,layer_neuron_error,learning_rate);

                        
                   }

                    //************************************************
                    float error=calc_error(layer_neuron,train,weights,activation_function,bias,num_hidden);
                    
                    chart1.Series[0].Points.AddXY(epoch_indx,error);
                    chart1.Series[0].ChartType=System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
       
                    //if no mse , mse could be zero so never succed
                    if(error<=mse)
                    
                        break;
                    }

            //******************************************************
            //**************************************************test
              

                int[,] connvoltion_matrix = test_func( weights, test, num_hidden, activation_function, bias,num_neurons,num_inputs);


                return connvoltion_matrix;
 }

      
        //********************************************************************************************
        //*****************************************read data******************************************
        //********************************************************************************************
        public float[][] ReadData()
        {
            float[][] data=new float[150][];
            int i = -1;
            int counter=0;
        
            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines("C:\\Users\\hp\\Documents\\Visual Studio 2013\\Projects\\Back Propagation\\Iris Data.txt"))
            {

                if (i == -1)
                {
                    i++;
                    continue;
                }

                string[] arr = new string[] { };
                arr=line.Split(',');


                data[i] = new float[5];
                data[i][0] = float.Parse(arr[0]);
                data[i][1] = float.Parse(arr[1]);
                data[i][2] = float.Parse(arr[2]);
                data[i][3] = float.Parse(arr[3]);

                if(counter>=100)
                data[i][4] = 3;

                else if(counter>=50)
                    data[i][4] = 2;

                else
                    data[i][4] = 1;

                i++;
                counter++;
            }

            return data;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RUN_Button_Click(object sender, EventArgs e)
        {
        
            if (string.IsNullOrWhiteSpace(this.Learning_Rate_TXT_Box.Text) || string.IsNullOrWhiteSpace(this.Num_Epochs_TXT_Box.Text) || string.IsNullOrWhiteSpace(this.Num_Hidden_TXT_Box.Text) || string.IsNullOrWhiteSpace(this.Num_Neurons_TXT_Box.Text) || Activation_Function_Compo_Box.SelectedIndex <= -1)
            {
                MessageBox.Show("Data is Missing");
                return;
            }


            int num_hidden_layers =int.Parse( Num_Hidden_TXT_Box.Text);
            int num_neurons = int.Parse(Num_Neurons_TXT_Box.Text);
            float learning_rate = float.Parse(Learning_Rate_TXT_Box.Text);
            int num_epochs = int.Parse(Num_Epochs_TXT_Box.Text);

            bool bias=false;

            if (Bias_Check_Box.Checked)
                bias = true;

            char activation_function;

            if (Activation_Function_Compo_Box.Text == "Sigmoid")
                activation_function = 's';

            else
                activation_function = 'h';

            //if(Activation_Function_Compo_Box)

            bool mse = false;

            float mse_threshold=0;

            if(With_MSE_Check_Box.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.MSE_Threshold_TXT_Box.Text))
                {
                    MessageBox.Show("Enter MSE Threshold Please ");
                    return;
                }

                mse_threshold = float.Parse(MSE_Threshold_TXT_Box.Text);
                mse = true;
            }
            //****************************************************************************************
            //****************************************************************************************
            //**********************************We got Data from the form*****************************
            //****************************************************************************************
            //****************************************************************************************

            float [][] data=new float[150][];

            //data returned:each row has 4 features , and the class number , 1 for first 50, 2 for second 50, 3 for third 50
            data = ReadData();

            int[,] convolution_matrix=BackPropagation(data,num_hidden_layers,num_neurons,learning_rate,num_epochs,bias,activation_function, mse_threshold);

            float avg = 0;

            avg=convolution_matrix[0,0] + convolution_matrix[1,1] + convolution_matrix[2,2];

            avg/=60;

            MessageBox.Show((avg*100).ToString());

        }

        private void Num_Epochs_TXT_Box_TextChanged(object sender, EventArgs e)
        {

        }

        private void MSE_Threshold_TXT_Box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
