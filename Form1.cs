using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraCientifica
{
    public partial class Form1 : Form
    {
        private bool isSecondNumber = false;
        private string expression = "";
        private double lastNumber = 0;  
        private string lastOperation = ""; 
        private bool repeatLastOperation = false;
        private double baseNumber = 0;
        private double exponent = 0;
        private bool isBase = true;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
            button29.Click += operation_Click; //Suma
            button23.Click += operation_Click;  // Resta
            button16.Click += operation_Click;  // Multiplicación
            button7.Click += operation_Click;    // División
            button9.Click += operation_Click;    // Potencia
            button19.Click += operation_Click;
            button2.Click += operation_Click;  
            button1.Click += operation_Click;
            button3.Click += operation_Click;
            button30.Click += equals_Click;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular su raíz cuadrada
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Sqrt(currentNumber);

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya la raíz
                expression = "√(" + currentNumber.ToString() + ") = " + result.ToString();
                textBox2.Text = expression;

                // Reiniciar la expresión para futuras operaciones
                expression = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la raíz cuadrada: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular 10^x
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Pow(10, currentNumber); // Calcular 10^x

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya la operación
                textBox2.Text = "10^" + currentNumber.ToString() + " = " + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular 10^x: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular su cubo
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Pow(currentNumber, 3); // Calcular el cubo

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya el cubo
                expression = currentNumber.ToString() + "³ = " + result.ToString();
                textBox2.Text = expression;

                // Reiniciar la expresión para futuras operaciones
                expression = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el cubo: " + ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular su raíz cúbica
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Pow(currentNumber, 1.0 / 3.0); // Calcular la raíz cúbica

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya la raíz cúbica
                textBox2.Text = "∛" + currentNumber.ToString() + " = " + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la raíz cúbica: " + ex.Message);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular e^x
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Exp(currentNumber); // Calcular e^x

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya la exponencial
                textBox2.Text = "e^" + currentNumber.ToString() + " = " + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular e^x: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular su cuadrado
                double currentNumber = Convert.ToDouble(textBox1.Text);
                double result = Math.Pow(currentNumber, 2); // Calcular el cuadrado

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya el cuadrado
                expression = currentNumber.ToString() + "² = " + result.ToString();
                textBox2.Text = expression;

                // Reiniciar la expresión para futuras operaciones
                expression = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el cuadrado: " + ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el número actual de textBox1 y calcular su logaritmo en base 10
                double currentNumber = Convert.ToDouble(textBox1.Text);
                if (currentNumber <= 0)
                {
                    MessageBox.Show("El logaritmo solo está definido para números mayores que cero.");
                    return;
                }
                double result = Math.Log10(currentNumber); // Calcular log10

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Actualizar la expresión en textBox2 para que incluya el logaritmo
                textBox2.Text = "log10(" + currentNumber.ToString() + ") = " + result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular el logaritmo: " + ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                // Evitar agregar un operador si el último carácter ya es un operador
                if (!string.IsNullOrEmpty(expression))
                {
                    char lastChar = expression[expression.Length - 1];
                    if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '%')
                    {
                        // Reemplazar el último operador con el nuevo si ya hay uno
                        expression = expression.Substring(0, expression.Length - 1) + "%";
                    }
                    else
                    {
                        // Agregar el operador de módulo a la expresión
                        expression += "%";
                    }
                }

                // Mostrar la expresión actual en textBox2
                textBox2.Text = expression;

                // Indicar que estamos listos para el segundo número
                isSecondNumber = true;

                // Guardar el operador para la repetición
                lastOperation = "%";

                // Resetear la bandera de repetición de operación
                repeatLastOperation = false;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            // Verificar si el número actual ya tiene un punto decimal
            if (!textBox1.Text.Contains("."))
            {
                // Si no tiene punto decimal, agregarlo
                textBox1.Text += ".";
                expression += ".";

                // Mostrar la expresión actual en textBox2
                textBox2.Text = expression;

                // Resetear la bandera de repetición de operación
                repeatLastOperation = false;
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                // Si el textBox1 contiene "0" o si estamos ingresando el segundo número, reemplazar el valor
                if (textBox1.Text == "0" || isSecondNumber)
                {
                    textBox1.Text = clickedButton.Text; // Reemplazar el "0" por el número presionado
                    isSecondNumber = false; // Indicar que ya no estamos esperando el segundo número
                }
                else
                {
                    // Si ya hay un número, simplemente concatenar el nuevo número
                    textBox1.Text += clickedButton.Text;
                }
                // Añadir el número a la expresión sin espacios
                expression += clickedButton.Text;
                // Resetear la bandera de repetición de operación
                repeatLastOperation = false;
            }
        }

        private void operation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;

                // Si el botón es una función trigonométrica (sen, cos, tan)
                if (buttonText == "sen" || buttonText == "cos" || buttonText == "tan")
                {
                    // Extraer el número actual en textBox1
                    string currentNumber = textBox1.Text;

                    // Si el número no es vacío o no es 0
                    if (!string.IsNullOrEmpty(currentNumber) && currentNumber != "0")
                    {
                        // Encerrar el número en la función trigonométrica y reemplazar en la expresión
                        expression = expression.TrimEnd(currentNumber.ToCharArray()); // Elimina el número actual
                        expression += buttonText + "(" + currentNumber + ")";

                        // Mostrar la nueva expresión en textBox2
                        textBox2.Text = expression;

                        // Reiniciar textBox1 para el siguiente número
                        textBox1.Text = "0";

                        // Guardar que el segundo número está listo para ser ingresado
                        isSecondNumber = true;
                    }
                }
                else
                {
                    // Evitar agregar un operador si el último carácter ya es un operador
                    if (!string.IsNullOrEmpty(expression))
                    {
                        char lastChar = expression[expression.Length - 1];
                        if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '^' || lastChar == '√')
                        {
                            // Reemplazar el último operador con el nuevo si ya hay uno
                            expression = expression.Substring(0, expression.Length - 1) + buttonText;
                        }
                        else
                        {
                            // Agregar el operador a la expresión
                            expression += buttonText;
                        }
                    }
                    else
                    {
                        // Agregar el operador a la expresión
                        expression += buttonText;
                    }

                    // Mostrar la expresión actual en textBox2
                    textBox2.Text = expression;

                    // Indicar que estamos listos para el segundo número
                    isSecondNumber = true;

                    // Guardar el operador para la repetición
                    lastOperation = buttonText;

                    // Resetear la bandera de repetición de operación
                    repeatLastOperation = false;
                }
            }
        }

        private void equals_Click(object sender, EventArgs e)
        {
            try
            {
                // Guardar una copia de la expresión original para mostrar en textBox2
                string originalExpression = expression;

                // Resolver operaciones de raíz
                expression = ResolveRootOperations(expression);

                // Resolver funciones trigonométricas manualmente
                expression = ResolveTrigonometricFunctions(expression);

                // Resolver operaciones de potencia manualmente
                expression = ResolvePowerOperations(expression);

                // Evaluar la expresión usando DataTable para operaciones básicas
                var result = new DataTable().Compute(expression, null);

                // Mostrar el resultado en textBox1
                textBox1.Text = result.ToString();

                // Mostrar la operación completa en textBox2 (original expresión + resultado)
                textBox2.Text = originalExpression + " = " + result.ToString();

                // Reiniciar la expresión con el resultado
                expression = result.ToString();

                // Marcar que estamos repitiendo la última operación
                repeatLastOperation = true;
            }
            catch (Exception ex)
            {
                // En caso de error (por ejemplo, una expresión inválida)
                MessageBox.Show("Error en la expresión: " + ex.Message);
            }
        }

        private string ResolvePowerOperations(string expr)
        {
            // Manejar operaciones de potencia
            while (expr.Contains("^"))
            {
                int pos = expr.IndexOf("^");
                // Buscar el número antes y después del "^"
                string leftPart = expr.Substring(0, pos).Trim();
                string rightPart = expr.Substring(pos + 1).Trim();

                // Buscar el último número antes del operador "^"
                string leftNumberStr = GetLastNumber(leftPart);
                string remainingLeft = leftPart.Substring(0, leftPart.LastIndexOf(leftNumberStr)).Trim();

                // Buscar el primer número después del operador "^"
                string rightNumberStr = GetFirstNumber(rightPart);
                string remainingRight = rightPart.Substring(rightNumberStr.Length).Trim();

                if (double.TryParse(leftNumberStr, out double baseNumber) &&
                    double.TryParse(rightNumberStr, out double exponent))
                {
                    double powerResult = Math.Pow(baseNumber, exponent);
                    // Construir la nueva expresión sin el operador "^" y reemplazar con el resultado
                    expr = remainingLeft + powerResult.ToString() + remainingRight;
                }
                else
                {
                    throw new InvalidOperationException("Error en el cálculo de la potencia.");
                }
            }
            return expr;
        }

        private string GetLastNumber(string part)
        {
            // Buscar el último número en una parte de la expresión
            int i = part.Length - 1;
            while (i >= 0 && (char.IsDigit(part[i]) || part[i] == '.'))
            {
                i--;
            }
            return part.Substring(i + 1);
        }

        private string GetFirstNumber(string part)
        {
            // Buscar el primer número en una parte de la expresión
            int i = 0;
            while (i < part.Length && (char.IsDigit(part[i]) || part[i] == '.'))
            {
                i++;
            }
            return part.Substring(0, i);
        }

        private string ResolveRootOperations(string expr)
        {
            // Manejar operaciones de raíz cuadrada o raíz de cualquier grado
            while (expr.Contains("√"))
            {
                int pos = expr.IndexOf("√");
                // Buscar el número después del símbolo de raíz
                string rightPart = expr.Substring(pos + 1).Trim();

                // Buscar el primer número después del operador "√"
                string rightNumberStr = GetFirstNumber(rightPart);
                string remainingRight = rightPart.Substring(rightNumberStr.Length).Trim();

                // Verificar si se ha parseado el número correctamente
                if (double.TryParse(rightNumberStr, out double number))
                {
                    // Calcular la raíz cuadrada (o raíz cúbica si modificas la lógica)
                    double rootResult = Math.Sqrt(number); // Cambiar a Math.Pow si necesitas raíz de otros grados

                    // Reemplazar la expresión "√número" con el resultado de la raíz
                    expr = expr.Substring(0, pos);
                }
                else
                {
                    throw new InvalidOperationException("Error en el cálculo de la raíz.");
                }
            }
            return expr;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            // Si el texto en textBox1 no está vacío y no es "0"
            if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.Text != "0")
            {
                // Eliminar el último carácter del textBox1
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

                // Si el textBox1 queda vacío después de borrar, establecer "0"
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = "0";
                }

                // Actualizar la expresión en textBox2
                UpdateExpressionAfterBackspace();
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {
            // Reiniciar el texto en textBox1
            textBox1.Text = "0";

            // Verificar si hay algo en la expresión
            if (!string.IsNullOrEmpty(expression))
            {
                // Encontrar el último operador en la expresión
                char[] operators = { '+', '-', '*', '/', '^' };
                int lastOperatorIndex = -1;

                foreach (char op in operators)
                {
                    int index = expression.LastIndexOf(op);
                    if (index > lastOperatorIndex)
                    {
                        lastOperatorIndex = index;
                    }
                }

                // Si encontramos un operador, eliminamos la parte de la expresión después de este
                if (lastOperatorIndex >= 0)
                {
                    // Mantener la parte de la expresión hasta el último operador
                    expression = expression.Substring(0, lastOperatorIndex + 1).Trim();
                }
                else
                {
                    // Si no hay operadores, reiniciar expresión a "0"
                    expression = "";
                }

                // Actualizar textBox2 con la nueva expresión
                textBox2.Text = expression;
            }

            // Reiniciar lastNumber para evitar concatenaciones incorrectas
            lastNumber = 0;

            // Resetear el flag para el segundo número
            isSecondNumber = true;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox1.Text = "0";
            isSecondNumber = false;
            expression = "";
            lastNumber = 0;
            lastOperation = "";
            repeatLastOperation =  false;
            baseNumber = 0;
            exponent = 0;
            isBase = true;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            // Verificar si hay un número en textBox1
            if (!string.IsNullOrEmpty(textBox1.Text) && textBox1.Text != "0")
            {
                // Alternar el signo del número en textBox1
                string currentNumber = textBox1.Text;

                // Alternar el signo
                if (currentNumber.StartsWith("-"))
                {
                    currentNumber = currentNumber.Substring(1); // Eliminar el signo negativo
                }
                else
                {
                    currentNumber = "-" + currentNumber; // Agregar el signo negativo
                }

                // Actualizar textBox1 con el número con el signo alternado
                textBox1.Text = currentNumber;

                // Si hay una expresión existente, actualizar el número en la expresión
                if (!string.IsNullOrEmpty(expression))
                {
                    // Verificar si el número a actualizar es el último número en la expresión
                    // Encuentra la posición del último operador
                    int lastOperatorIndex = expression.LastIndexOfAny(new char[] { '+', '-', '*', '/', '^' });

                    // Si no hay operadores, es el primer número en la expresión
                    if (lastOperatorIndex == -1)
                    {
                        // Actualiza la expresión con el nuevo número
                        expression = textBox1.Text;
                    }
                    else
                    {
                        // Encontrar la parte izquierda y derecha de la expresión
                        string leftPart = expression.Substring(0, lastOperatorIndex + 1);
                        string rightPart = expression.Substring(lastOperatorIndex + 1);

                        // Actualizar la parte derecha de la expresión con el nuevo número
                        expression = leftPart + textBox1.Text;
                    }

                    // Actualizar textBox2 con la expresión modificada
                    textBox2.Text = expression;
                }
            }
        }

        private string ResolveTrigonometricFunctions(string expr)
        {
            // Procesar funciones trigonométricas manualmente
            expr = ResolveSingleFunction(expr, "sen(", Math.Sin);
            expr = ResolveSingleFunction(expr, "cos(", Math.Cos);
            expr = ResolveSingleFunction(expr, "tan(", Math.Tan);

            return expr;
        }

        private string ResolveSingleFunction(string expr, string functionName, Func<double, double> trigFunction)
        {
            while (expr.Contains(functionName))
            {
                // Encontrar el índice inicial de la función
                int startIndex = expr.IndexOf(functionName) + functionName.Length;

                // Encontrar el índice final del paréntesis
                int endIndex = expr.IndexOf(')', startIndex);

                // Extraer el número entre los paréntesis
                string numberString = expr.Substring(startIndex, endIndex - startIndex);

                // Convertir el número de grados a radianes
                double number = double.Parse(numberString) * (Math.PI / 180);

                // Calcular la función trigonométrica
                double result = trigFunction(number);

                // Reemplazar la función trigonométrica por su resultado en la expresión
                expr = expr.Replace(functionName + numberString + ")", result.ToString());
            }

            return expr;
        }


        
private void UpdateExpressionAfterBackspace()
{
    // Obtener el texto en textBox1 y textBox2
    string currentTextBox1 = textBox1.Text;
    string currentExpression = textBox2.Text;

    // Si el texto en textBox1 es "0" y textBox2 no está vacío
    if (currentTextBox1 == "0" && !string.IsNullOrEmpty(currentExpression))
    {
        // Extraer la expresión en textBox2 antes del último número
        string[] operators = { "+", "-", "*", "/", "^" };
        foreach (var op in operators)
        {
            int lastOperatorIndex = currentExpression.LastIndexOf(op);
            if (lastOperatorIndex != -1)
            {
                // Eliminar el último número y posible operador
                currentExpression = currentExpression.Substring(0, lastOperatorIndex + 1).Trim();
                break;
            }
        }

        // Actualizar textBox2 con la nueva expresión
        textBox2.Text = currentExpression;
    }
    else
    {
        // Si el texto en textBox1 no es "0", necesitamos ajustar el final de la expresión
        string numberToRemove = textBox1.Text;
        if (currentExpression.EndsWith(numberToRemove))
        {
            // Eliminar el último número de la expresión
            int lengthToRemove = numberToRemove.Length;

            // Ajustar la expresión eliminando el último número
            if (currentExpression.Length >= lengthToRemove)
            {
                currentExpression = currentExpression.Substring(0, currentExpression.Length - lengthToRemove).Trim();

                // Eliminar el operador que sigue si está presente
                string[] operators = { "+", "-", "*", "/", "^" };
                foreach (var op in operators)
                {
                    if (currentExpression.EndsWith(op.ToString()))
                    {
                        currentExpression = currentExpression.Substring(0, currentExpression.Length - 1).Trim();
                        break;
                    }
                }
            }

            // Actualizar textBox2 con la nueva expresión
            textBox2.Text = currentExpression;
        }
    }
}

        private void Actualizar_Click(object sender, EventArgs e)
        {
            string repoPath = @"C:\Users\mel_v\OneDrive\Documentos\Universidad\Octavo\Desarrollo Basado en Modelos\Trabajos en Visual Studio\CalculadoraCientificaActualizada";
            if (Directory.Exists(Path.Combine(repoPath, ".git")))
            {
                PullRepository(repoPath);
            }
            else
            {
                MessageBox.Show("El repositorio no está clonado correctamente o no es un repositorio Git.");
            }
        }

        private void PullRepository(string repoPath)
        {
            string gitCommand = "git pull origin main";
            ExecuteGitCommand(gitCommand, "Cambios descargados correctamente.", repoPath);
        }

        private void ExecuteGitCommand(string command, string successMessage, string repoPath = "")
        {
            try
            {
                var processInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + command)
                {
                    WorkingDirectory = repoPath,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = System.Diagnostics.Process.Start(processInfo))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        MessageBox.Show($"Error al ejecutar el comando Git:\n{error}");
                    }
                    else
                    {
                        MessageBox.Show($"{successMessage}\n{output}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ejecutando el comando Git: {ex.Message}");
            }
        }
    }
}
