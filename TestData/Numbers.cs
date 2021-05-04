using System;
using System.Collections.Generic;

namespace TestData
{
    class Numbers
    {
        
        public enum NumberType { Imei, Serial, Vatno, Vatse, Vatdk }

        public Numbers(NumberType numberType)
        {
            DataType = numberType;
        }

        public NumberType DataType { get; private set; }

        


        public string GetData(NumberType type, int qty, DataProcessor.OutputType outputMethod)
        {
            var outputProcessor = new DataProcessor();
            var _outputMethod = outputMethod;
            var _type = type;
            var _qty = qty;
            var i = _qty;
            var numberList = new LinkedList<string>();
            var output = "";

            switch (_type)
            {
                case NumberType.Imei:
                    do
                    {
                        numberList.AddLast(CreateImei());
                        i--;
                    } while (i > 0);
                    output = outputProcessor.OutputData(numberList, _outputMethod);

                    break;

                case NumberType.Serial:
                    do
                    {
                        numberList.AddLast(CreateSerial());
                        i--;
                    } while (i > 0);
                    output = outputProcessor.OutputData(numberList, _outputMethod);
                    break;
                
                case NumberType.Vatno:
                    do
                    {
                        numberList.AddLast(CreateVatNo());
                        i--;
                    } while (i > 0);
                    output = outputProcessor.OutputData(numberList, _outputMethod);
                    break;

                case NumberType.Vatse:
                    do
                    {
                        numberList.AddLast(CreateVatSe());
                        i--;
                    } while (i > 0);
                    output = outputProcessor.OutputData(numberList, _outputMethod);
                    break;

                case NumberType.Vatdk:
                    do
                    {
                        numberList.AddLast(CreateVatDk());
                        i--;
                    } while (i > 0);
                    output = outputProcessor.OutputData(numberList, _outputMethod);
                    break;

            }

            return output;
        }

        private int calcLuhn(int[] inputArray, int offset)
        {
            var _inputArray = inputArray;
            var _offset = offset;
            var sum = 0;

            for (int i = 0; i < _inputArray.Length; i++ )
            {
                if (i + _offset % 2 == 0)
                    sum += ((_inputArray[i] * 2) > 9) ? (_inputArray[i] * 2) - 9 : (_inputArray[i] * 2);
                else
                    sum += _inputArray[i];
            }

            return (sum * 9) % 10;
        }

        private string CreateImei()
        {
            var random = new Random();
            var randomArray = new int[15];
            string output = "";

            output += randomArray[0] = 3;
            output += randomArray[1] = 5;
            for (int i = 2; i < randomArray.Length - 1; i++ )
            {
                output += randomArray[i] = random.Next(0, 9);
            }

            output += calcLuhn(randomArray, 1);

            return output;
        }

        private string CreateSerial()
        {
            var validCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var serialLength = 13;
            var output = "";

            for (int i = 0; i < serialLength; i++ )
            {
                output += (i == 0) ? "S" : validCharacters[random.Next(0, validCharacters.Length)];
            }

            return output;
        }

        private string CreateVatNo()
        {
            var random = new Random();
            var weightArray = new int[] { 3, 2, 7, 6, 5, 4, 3, 2 };
            var vatArray = new int[9];
            var weightSum = 0;
            var output = "";

            do
            {
                weightSum = 0;
                for (int i = 0; i < vatArray.Length -1; i++)
                {
                    vatArray[i] = (i == 0) ? random.Next(1, 9) : random.Next(0, 9);
                    weightSum += vatArray[i] * weightArray[i];
                }
            } while (weightSum % 11 == 1);


            vatArray[8] = (weightSum % 11 == 0) ? 0 : 11 - (weightSum % 11);

            for (int i = 0; i < vatArray.Length; i++)
                output += vatArray[i];

            return output;
        }

        private string CreateVatSe()
        {
            var random = new Random();
            var randomArray = new int[8];
            var output = "";

            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = (i == 0) ? random.Next(1, 9) : random.Next(0, 9);
                output += randomArray[i];
            }
            output += calcLuhn(randomArray, 0);

            return output;
        }

        private string CreateVatDk()
        {
            var random = new Random();
            var weightArray = new int[] { 2, 7, 6, 5, 4, 3, 2 };
            var vatArray = new int[8];
            var weightSum = 0;
            var output = "";

            do
            {
                weightSum = 0;
                for (int i = 0; i < vatArray.Length - 1; i++)
                {
                    vatArray[i] = (i == 0) ? random.Next(1, 9) : random.Next(0, 9);
                    weightSum += vatArray[i] * weightArray[i];
                }
            } while (weightSum % 11 == 1);


            vatArray[vatArray.Length-1] = (weightSum % 11 == 0) ? 0 : 11 - (weightSum % 11);

            for (int i = 0; i < vatArray.Length; i++)
                output += vatArray[i];

            return output;
        }
    }
}
