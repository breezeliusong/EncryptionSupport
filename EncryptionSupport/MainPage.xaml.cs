using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EncryptionSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //AsymmetricKeyAlgorithmProvider objAsymmAlgProv = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.EcdsaSha256);
            //CryptographicKey keypair = objAsymmAlgProv.CreateKeyPairWithCurveName(EccCurveNames.SecP256r1);
            //BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
            //IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary("Test Message", encoding);
            //IBuffer buffSIG = CryptographicEngine.Sign(keypair, buffMsg);

            ////var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffSIG);
            ////var output = dataReader.ReadString(64);
            //Debug.WriteLine(buffSIG.Length);
            //byte[] SignByteArray = buffSIG.ToArray();
            //Debug.WriteLine(SignByteArray.ToString());
            //bool res = CryptographicEngine.VerifySignature(keypair, buffMsg, buffSIG);
        }

        private async  void ECDSA_Cryptography(object sender, RoutedEventArgs e)
        {
            //workground1
            AsymmetricKeyAlgorithmProvider _objAlgProv = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.EcdsaSha256);
            string _StrMessage = "0055673B5138CC90D3B7F32BFDAD6A38A8EDD7B355B77AB9792196F106D16CA312049500D67477BAC1B959063726F3A8A43AA7FD068CA775C502213C0732B2ECC836B3906DB0E2D3F9CA06BA54570DB41DBDD6C49E2BAF8BECFF47B176E64983A5049500D67477BAC1B959063726F3A8A43AA7FD068CA775C502213C0732B2ECC804D7985513A5B89452FBC15FE656258062403BC0CCF619A656840AD5DF5D55B4A3FB8B1BA93577BAAD063B381E56084A655D3F2AFE85BE08C6DBA94FE651BFB435";
            IBuffer _IMessage = CryptographicBuffer.DecodeFromHexString(_StrMessage);
            CryptographicKey __KeyPair = _objAlgProv.CreateKeyPairWithCurveName(EccCurveNames.SecP256r1);
            IBuffer __ISign = await CryptographicEngine.SignAsync(__KeyPair, _IMessage);
            byte[] __ByteSign = { 0 };
            //byte[] __ByteSign = __ISign.ToArray();
            //CryptographicBuffer.CopyToByteArray(__ISign,out __ByteSign);
            bool res = CryptographicEngine.VerifySignature(__KeyPair, _IMessage,__ISign);

            //workground2
            //AsymmetricKeyAlgorithmProvider objAsymmAlgProv = AsymmetricKeyAlgorithmProvider.OpenAlgorithm(AsymmetricAlgorithmNames.EcdsaSha256);
            //CryptographicKey keypair = objAsymmAlgProv.CreateKeyPairWithCurveName(EccCurveNames.SecP256r1);
            //BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
            //IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary("Test Message", encoding);
            //IBuffer buffSIG = CryptographicEngine.Sign(keypair, buffMsg);
            //buffSIG.AsStream().AsOutputStream().ToString();
            //byte[] SignByteArray = buffSIG.ToArray();
            //Debug.WriteLine(SignByteArray.ToString());
            //bool res = CryptographicEngine.VerifySignature(keypair, buffMsg, buffSIG);
        }
    }
}
