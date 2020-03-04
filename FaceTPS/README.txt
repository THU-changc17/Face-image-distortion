C#    .Net Framework 4.6.1   VS2017

程序所在路径请不要出现中文，尤其是执行自动检测操作时

双击FaceTPS.exe即可运行应用程序,或在.\FaceTPS\FaceTPS\bin\x64\Release目录中双击exe也可运行

注意：移动exe文件时，都需要将DlibDotNet.dll    DlibDotNetNative.dll  DlibDotNetNativeDnn.dll
以及shape_predictor_68_face_landmarks.dat复制到同级目录下

进入程序首先导入图片，可选择自动检测数据或者导入数据，如果更换图片请重新导入对应数据，点击生成图片
即可观察结果，图片可保存成jpg格式。

如果系数矩阵L不可逆，系统会弹出提示，此时生成图片为黑色，这种情况对于题目提供的测试数据不会出现，
但对于自动检测的数据可能出现。

face-images是原有测试图片及数据，和用于人脸自动检测测试的四张图片

outpic是输出样例图片



