#include "datatransfer.h"
#include "wifi.h"
/////////////////////////////////////////////////////////////////////////////////////
//Data_Receive_Prepare函数是协议预解析，根据协议的格式，将收到的数据进行一次格式性解析，格式正确的话再进行数据解析
//移植时，此函数应由用户根据自身使用的通信方式自行调用，比如串口每收到一字节数据，则调用此函数一次
//此函数解析出符合格式的数据帧后，会自行调用数据解析函数
void Receive_Prepare(u8 data)
{
	static u8 RxBuffer[50];
	static u8 _data_len = 0,_data_cnt = 0;
	static u8 state = 0;
	//帧头1
	if(state==0&&data==0xFF)
	{
		state=1;
		RxBuffer[0]=data;
	}
	//帧头2
	else if(state==1&&data==0xFF)
	{
		state=2;
		RxBuffer[1]=data;
	}
	//功能字
	else if(state==2)
	{
		state=3;
		RxBuffer[2]=data;
	}
	//长度
	else if(state==3&&data<0x25)
	{
		state = 4;
		RxBuffer[3]=data;
		_data_len = data;
		_data_cnt = 0;
	}
	//数据
	else if(state==4&&_data_len>0)
	{
		_data_len--;
		RxBuffer[4+_data_cnt++]=data;
		if(_data_len==0)
			state = 5;
	}
	//校验
	else if(state==5)
	{
		state = 0;
		RxBuffer[4+_data_cnt]=data;
		Data_Receive_Anl(RxBuffer,_data_cnt+5);
	}
	else
		state = 0;
}
/////////////////////////////////////////////////////////////////////////////////////
//Data_Receive_Anl函数是协议数据解析函数，函数参数是符合协议格式的一个数据帧，该函数会首先对协议数据进行校验
//校验通过后对数据进行解析，实现相应功能
//此函数可以不用用户自行调用，由函数Data_Receive_Prepare自动调用
u16 flash_save_en_cnt = 0;
//解析数据包，含校验位
void Data_Receive_Anl(u8 *data_buf,u8 num)
{
	float scale=1000.0f;
	u8 key_word;
	u8 connect_id;
	Simple_PID_TypeDef pid_i;       //电流环
	Simple_PID_TypeDef pid_v;      //速度环
	Simple_PID_TypeDef pid_s;       //位置环
	Simple_PID_TypeDef pid_p;       //功率环
	u8 length;
	u8 i;
	u8 sum = 0;
	for(i=0;i<(num-1);i++)
		sum += *(data_buf+i);
	if(!(sum==*(data_buf+num-1)))		return;		//判断sum
	if(!(*(data_buf)==0xFF && *(data_buf+1)==0xFF))		return;		//判断帧头
	//收到一帧有效数据
	length=*(data_buf+3);
	key_word=*(data_buf+2);
	switch(key_word){
		case 0x00:
		//WIFI组网的连接号
		connect_id=*(data_buf+4);
		handle_connect_id(connect_id);
		break;
		case 0x01:
		case 0x02:
		case 0x03:
		case 0x04:
		if(length==0x24)
		{
			pid_i.kp=((*(data_buf+4)<<24)+(*(data_buf+5)<<16)+(*(data_buf+6)<<8)+(*(data_buf+7)))/scale;
			pid_i.ki=((*(data_buf+8)<<24)+(*(data_buf+9)<<16)+(*(data_buf+10)<<8)+(*(data_buf+11)))/scale;
			pid_i.kd=((*(data_buf+12)<<24)+(*(data_buf+13)<<16)+(*(data_buf+14)<<8)+(*(data_buf+15)))/scale;
			pid_v.kp=((*(data_buf+16)<<24)+(*(data_buf+17)<<16)+(*(data_buf+18)<<8)+(*(data_buf+19)))/scale;
			pid_v.ki=((*(data_buf+20)<<24)+(*(data_buf+21)<<16)+(*(data_buf+22)<<8)+(*(data_buf+23)))/scale;
			pid_v.kd=((*(data_buf+24)<<24)+(*(data_buf+25)<<16)+(*(data_buf+26)<<8)+(*(data_buf+27)))/scale;
			pid_p.kp=((*(data_buf+28)<<24)+(*(data_buf+29)<<16)+(*(data_buf+30)<<8)+(*(data_buf+31)))/scale;
			pid_p.ki=((*(data_buf+32)<<24)+(*(data_buf+33)<<16)+(*(data_buf+34)<<8)+(*(data_buf+35)))/scale;
			pid_p.kd=((*(data_buf+36)<<24)+(*(data_buf+37)<<16)+(*(data_buf+38)<<8)+(*(data_buf+39)))/scale;
			switch(key_word){
				case 0x01:
					//底盘电机1电流环、速度环、功率环PID值
					handle_chassis_motor1_pid(&pid_i,&pid_v,&pid_p);
				break;
				case 0x02:
					//底盘电机2电流环、速度环、功率环PID值
					handle_chassis_motor2_pid(&pid_i,&pid_v,&pid_p);
				break;
				case 0x03:
					//底盘电机3电流环、速度环、功率环PID值
					handle_chassis_motor3_pid(&pid_i,&pid_v,&pid_p);
				break;
				case 0x04:
					//底盘电机4电流环、速度环、功率环PID值
					handle_chassis_motor4_pid(&pid_i,&pid_v,&pid_p);
				break;
				default:
				break;
			}
		}
		break;
		case 0x05:
		case 0x06:
		case 0x07:
		if(length==0x24)
		{
			pid_i.kp=((*(data_buf+4)<<24)+(*(data_buf+5)<<16)+(*(data_buf+6)<<8)+(*(data_buf+7)))/scale;
			pid_i.ki=((*(data_buf+8)<<24)+(*(data_buf+9)<<16)+(*(data_buf+10)<<8)+(*(data_buf+11)))/scale;
			pid_i.kd=((*(data_buf+12)<<24)+(*(data_buf+13)<<16)+(*(data_buf+14)<<8)+(*(data_buf+15)))/scale;
			pid_v.kp=((*(data_buf+16)<<24)+(*(data_buf+17)<<16)+(*(data_buf+18)<<8)+(*(data_buf+19)))/scale;
			pid_v.ki=((*(data_buf+20)<<24)+(*(data_buf+21)<<16)+(*(data_buf+22)<<8)+(*(data_buf+23)))/scale;
			pid_v.kd=((*(data_buf+24)<<24)+(*(data_buf+25)<<16)+(*(data_buf+26)<<8)+(*(data_buf+27)))/scale;
			pid_s.kp=((*(data_buf+28)<<24)+(*(data_buf+29)<<16)+(*(data_buf+30)<<8)+(*(data_buf+31)))/scale;
			pid_s.ki=((*(data_buf+32)<<24)+(*(data_buf+33)<<16)+(*(data_buf+34)<<8)+(*(data_buf+35)))/scale;
			pid_s.kd=((*(data_buf+36)<<24)+(*(data_buf+37)<<16)+(*(data_buf+38)<<8)+(*(data_buf+39)))/scale;
			switch(key_word){
				case 0x05:
					//云台电机yaw轴电流环、速度环、位置环PID值
					handle_cradle_yaw_motor_pid(&pid_i,&pid_v,&pid_s);
				break;
				case 0x06:
					//云台电机pitch轴电流环、速度环、位置环PID值
					handle_cradle_pitch_motor_pid(&pid_i,&pid_v,&pid_s);
				break;
				case 0x07:
					//拨弹电机电流环、速度环、位置环PID值
					handle_rammer_motor_pid(&pid_i,&pid_v,&pid_s);
				break;
				default:
				break;
			}
		}
		break;
		case 0x08:
		case 0x09:
		if(length==0x18)
		{
			pid_i.kp=((*(data_buf+4)<<24)+(*(data_buf+5)<<16)+(*(data_buf+6)<<8)+(*(data_buf+7)))/scale;
			pid_i.ki=((*(data_buf+8)<<24)+(*(data_buf+9)<<16)+(*(data_buf+10)<<8)+(*(data_buf+11)))/scale;
			pid_i.kd=((*(data_buf+12)<<24)+(*(data_buf+13)<<16)+(*(data_buf+14)<<8)+(*(data_buf+15)))/scale;
			pid_v.kp=((*(data_buf+16)<<24)+(*(data_buf+17)<<16)+(*(data_buf+18)<<8)+(*(data_buf+19)))/scale;
			pid_v.ki=((*(data_buf+20)<<24)+(*(data_buf+21)<<16)+(*(data_buf+22)<<8)+(*(data_buf+23)))/scale;
			pid_v.kd=((*(data_buf+24)<<24)+(*(data_buf+25)<<16)+(*(data_buf+26)<<8)+(*(data_buf+27)))/scale;
			switch(key_word){
				case 0x08:
					//摩擦轮1电机电流环、速度环PID值
					handle_shooter1_motor_pid(&pid_i,&pid_v);
				break;
				case 0x09:
					//摩擦轮2电机电流环、速度环PID值
					handle_shooter2_motor_pid(&pid_i,&pid_v);
				break;
				default:
				break;
			}
		}
		break;
	}
}
