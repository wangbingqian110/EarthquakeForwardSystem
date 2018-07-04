// Algorithm.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"

#define Dt 0.002
#define Dx 10.
#define Dz 10.

//#define Nt 400 
//#define Nx 200 
//#define Nz 200


#define PI 3.1415926
//using namespace System::Runtime::InteropServices;
using namespace msclr::interop;
namespace AlgorithmNameSpace {
	public ref class Algorithm {
	public:
		Algorithm(int nt, int nx, int nz, int sx, int sz, float** v) {
			Nt = nt;
			Nx = nx;
			Nz = nz;
			Sx = sx;
			Sz = sz;
			V = v;

		}
		Algorithm(int nt, int nx, int nz, float** v) {
			Nt = nt;
			Nx = nx;
			Nz = nz;
			V = v;

		}
	private:
		int Nt, Nx, Nz, Sx, Sz;
		float ** V;
		float **all2darry(int x, int y)
			/* allocate a float matrix with subscript range m[nrl..nrh][ncl..nch] */
		{
			int i, j;
			float **m;

			/* allocate pointers to rows */
			m = (float **)malloc(x * sizeof(float*));


			/* allocate rows and set pointers to them */
			m[0] = (float *)malloc(x*y * sizeof(float));

			for (i = 1; i < x; i++) m[i] = m[i - 1] + y;

			/* initialize */
			for (i = 0; i < x; i++)
				for (j = 0; j < y; j++)
					m[i][j] = 0.0;

			/* return pointer to array of pointers to rows */
			return m;
		}
	public:
		float **Record = all2darry(Nx, Nt);
		/*
		*差分算子（2、4、6、8、10阶）
		*/

		void DOperator(int order, float* D)
		{
			switch (order)
			{

			case 1:
				D[0] = -2.00000;
				D[1] = 1.00000;
				break;
			case 2:
				D[0] = -2.50000;
				D[1] = 1.33333;
				D[2] = -8.33333e-2;
				break;
			case 3:
				D[0] = -2.72222;
				D[1] = 1.50000;
				D[2] = -1.50000e-1;
				D[3] = 1.11111e-2;
				break;

			case 4:
				D[0] = -2.84722;
				D[1] = 1.60000;
				D[2] = -2.00000e-1;
				D[3] = 2.53968e-2;
				D[4] = -1.78571e-3;
				break;
			case 5:
				D[0] = -2.92722;
				D[1] = 1.66667;
				D[2] = -2.38095e-1;
				D[3] = 3.96825e-2;
				D[4] = -4.96032e-3;
				D[5] = 3.17460e-4;
				break;
			}
		}

		float finiteDif(float *D, float **Unow, int order, int ix, int iz, int flag)
		{
			int i(0);
			float sum(0.);
			if (flag == 1)
			{
				for (i = -order; i <= order; i++)
				{
					sum += D[abs(i)] * Unow[ix + i][iz];
				}

			}
			else
			{
				for (i = -order; i <= order; i++)
				{
					sum += D[abs(i)] * Unow[ix][iz + i];
				}

			}
			return sum;
		}

		/*
		*震源函数衰减因子
		*/

		float A(int sx, int sz, float a, int ix, int iz)
		{
			return exp((-a)*(pow((ix - sx), 2.) + pow((iz - sz), 2.)));
		}


		/*
		*震源函数
		*/

		float source(float fm, float a, int sx, int sz, int st, int ix, int iz, int it)
		{
			return (1 - 2 * pow(PI*fm*(it - st)*Dt, 2.))*exp(-pow(PI*fm*(it - st)*Dt, 2.))*A(sx, sz, a, ix, iz);
		}


		/*
		*初始模型
		*/
		/*float** initialModel()
		{
			float* vel = (float*)malloc((1 + 1) * sizeof(float));
			vel[0] = 3000.;
			vel[1] = 2000.;
			float* boundary = (float*)malloc((1 + 2) * sizeof(float));
			boundary[0] = 0;
			boundary[1] = 100.;
			boundary[1 + 1] = Nz;
			int ix(0);
			int iz(0);
			int ib(0);
			float** v = all2darry(Nx, Nz);

			for (ib = 1; ib < 3; ib++)
			{
				for (ix = 0; ix < Nx; ix++)
				{
					for (iz = 0; iz < Nz; iz++)
					{
						if (iz < boundary[ib] && iz >= boundary[ib - 1])
						{
							v[ix][iz] = vel[ib - 1];
						}
					}
				}
			}
			return v;

		}*/

	public:
		void Calculate(System::String^ f1, System::String^ f2, System::String^ f3)
		{
			FILE* fpawf;
			FILE* fpwf;
			FILE* fpre;

			float **Unow = all2darry(Nx, Nz);
			float **Ubefore = all2darry(Nx, Nz);
			float **Unext = all2darry(Nx, Nz);
			float **record = all2darry(Nx, Nt);
			//	float **V = all2darry(Nx, Nz);




			float fm(30.);
			float a(1.0);


			//生成差分算子
			int order(0);



			order = 8;

			order /= 2;

			float* D = (float*)malloc((order + 1) * sizeof(float));

			DOperator(order, D);

			int sx;
			int sz;
			int st;

			sx = Sx;
			sz = Sz;
			st = 0;

			int wavetime(0);
			wavetime = 100;
			marshal_context context1;

			marshal_context context2;

			marshal_context context3;

			fpawf = fopen(context1.marshal_as<const char*>(f1), "wb");
			fpwf = fopen(context2.marshal_as<const char*>(f2), "wb"); // 200 * 200
			fpre = fopen(context3.marshal_as<const char*>(f3), "wb"); // 200 * 400


			int it(0);
			int ix(0);
			int iz(0);

			float fdx(0.);
			float fdz(0.);

			float sumx(0.);
			float sumz(0.);

			float a0, a1, a2, a3, a4, a5, a6;

			a0 = -2.50000; a1 = 1.33333; a2 = -8.33333e-2; a3 = 0; a4 = 0; a5 = 0; a6 = 0;

			for (it = 0; it < Nt; it++)
			{

				for (ix = order; ix < (Nx - order); ix++)
				{
					for (iz = order; iz < (Nz - order); iz++)
					{

						Unext[ix][iz] = 2 * Unow[ix][iz] - Ubefore[ix][iz]

							+ 0.5*pow(V[ix][iz], 2.)*(pow(Dt, 2.) / pow(Dx, 2.)*finiteDif(D, Unow, order, ix, iz, 1)

								+ pow(Dt, 2.) / pow(Dz, 2.)*finiteDif(D, Unow, order, ix, iz, 0));

					}

				}


				Unext[sx][sz] += (1.0 - 2.0*pow(PI*fm*it*Dt, 2.0))*exp(-pow(PI*fm*it*Dt, 2.0));

				for (ix = 0; ix < Nx; ix++)
				{
					for (iz = 0; iz < Nz; iz++)
					{
						Ubefore[ix][iz] = Unow[ix][iz];
						Unow[ix][iz] = Unext[ix][iz];
					}
				}



				for (ix = 0; ix < Nx; ix++)
				{
					record[ix][it] = Unow[ix][sz];
				}


				for (ix = 0; ix < Nx; ix++)
				{
					fwrite(Unow[ix], sizeof(float), Nz, fpawf);
				}



				if (it == wavetime)
				{
					for (ix = 0; ix < Nx; ix++)
					{
						fwrite(Unow[ix], sizeof(float), Nz, fpwf);
					}
				}




				//if (it % 10 == 0) printf("it=%d\n", it);

			}

			for (ix = 0; ix < Nx; ix++)
			{
				fwrite(record[ix], sizeof(float), Nt, fpre);
			}
			Record = record;
			fclose(fpawf);
			fclose(fpwf);
			fclose(fpre);

			//FILE* pFile;   //文件指针  
			//			   //long lSize;   // 用于文件长度  
			//float buffer[Nx][Nt];// 文件缓冲区指针  

			//pFile = fopen("Record.txt", "r");
			//fread(buffer, sizeof(float), Nx*Nt, pFile); // 返回值是读取的内容数量  
			//fclose(pFile);
		}
	public:
		void Calculate()
		{
			float **Unow = all2darry(Nx, Nz);
			float **Ubefore = all2darry(Nx, Nz);
			float **Unext = all2darry(Nx, Nz);
			float **record = all2darry(Nx, Nt);
			//	float **V = all2darry(Nx, Nz);




			float fm(30.);
			float a(1.0);


			//生成差分算子
			int order(0);



			order = 8;

			order /= 2;

			float* D = (float*)malloc((order + 1) * sizeof(float));

			DOperator(order, D);

			int sz;
			int st;

			sz = 50;
			st = 0;

			int wavetime(0);
			wavetime = 100;


			int it(0);
			int ix(0);
			int iz(0);

			float fdx(0.);
			float fdz(0.);

			float sumx(0.);
			float sumz(0.);

			float a0, a1, a2, a3, a4, a5, a6;

			a0 = -2.50000; a1 = 1.33333; a2 = -8.33333e-2; a3 = 0; a4 = 0; a5 = 0; a6 = 0;
			for (int sx = 20; sx < Nx; sx++)
			{
				for (it = 0; it < Nt; it++)
				{
					for (ix = order; ix < (Nx - order); ix++)
					{
						for (iz = order; iz < (Nz - order); iz++)
						{

							Unext[ix][iz] = 2 * Unow[ix][iz] - Ubefore[ix][iz]

								+ 0.5*pow(V[ix][iz], 2.)*(pow(Dt, 2.) / pow(Dx, 2.)*finiteDif(D, Unow, order, ix, iz, 1)

									+ pow(Dt, 2.) / pow(Dz, 2.)*finiteDif(D, Unow, order, ix, iz, 0));

						}

					}


					Unext[sx][sz] += (1.0 - 2.0*pow(PI*fm*it*Dt, 2.0))*exp(-pow(PI*fm*it*Dt, 2.0));

					for (ix = 0; ix < Nx; ix++)
					{
						for (iz = 0; iz < Nz; iz++)
						{
							Ubefore[ix][iz] = Unow[ix][iz];
							Unow[ix][iz] = Unext[ix][iz];
						}
					}



					for (ix = 0; ix < Nx; ix++)
					{
						record[ix][it] = Unow[ix][sz];
					}
				}

				for (int k = sx - 20; k < sx + 20; k++)
				{
						Record[k] = record[k];
					
				}
				sx = sx + 19;
			}
		}
	};
}